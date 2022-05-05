using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;


public partial class PMIS_Common_FinancialEntry : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string projectno = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role"]) == null || Convert.ToString(Session["Role"]) == "")
        {
            Response.Redirect("~/PMIS/Login.aspx");
            return;
        }
        
        if (!IsPostBack)
        {
            Financialprogress();
            BindFinancial();
            
        }
    }

    protected void Financialprogress()
    {
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);

            //projectno = Convert.ToString(enc.Decrypt(Request.QueryString["ProjectNo"]));
            //ViewState["Projectno"] = projectno;
            projectno = Request.QueryString["ProjectNo"].ToString();
            string my_String = Regex.Replace(projectno, " ", "+");
            projectno = enc.Decrypt(my_String);
            ViewState["Projectno"] = projectno;
            lblProject.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + projectno + "");
            iblProjNo.Text = " / " + ViewState["Projectno"].ToString();
            if (!Regex.IsMatch(projectno, @"[/d]"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "", true);
                return;
            }
            //lblProject.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + projectno + "");
            //iblProjNo.Text = " / " + ViewState["Projectno"].ToString();
        }


        catch( Exception ex){
        
        }
    }


    void BindFinancial()
    {
        string strWhere = string.Empty;

        //if (txtfromdate.Text.Length != 0 && txttodate.Text.Length != 0)
        //{
        //    strWhere += (string.IsNullOrEmpty(strWhere) ? "" : " AND ") + "Where FinancialProgress.Entrydate >= '" + txtfromdate.Text.Trim() + "' and  FinancialProgress.Entrydate <'" + Convert.ToDateTime(txttodate.Text.Trim()).AddDays(1).ToString("dd-MMM-yyyy") + "'";
        //}

        if (Session["Role"].ToString() == "DIVADM")
        {

            strWhere += " FinancialProgress.DivisionID=@DivisionID ";
        }
        if (Session["Role"].ToString() == "DIVADM")
        {

            strWhere += " and FinancialProgress.Projectnumber=@Projectno ";
        }
        if (txtfromdate.Text.Trim() != "" || txttodate.Text.Trim() != "")
        {
            if (txtfromdate.Text.Trim() == "" || txttodate.Text.Trim() == "")
            {
                Utility.showMessage(this, "Please select Date...!");
            }
            else
            {
                strWhere += " and cast (FinancialProgress.Entrydate as date)>=@FromDate and cast (FinancialProgress.Entrydate as date)<=@ToDate";
            }
        }
        SqlParameter _DivisionID = new SqlParameter("@DivisionID", Session["DivisionID"].ToString());
        SqlParameter fdate = new SqlParameter("@FromDate", txtfromdate.Text);
        SqlParameter tdate = new SqlParameter("@ToDate", (txttodate.Text));
        SqlParameter Projectnumber = new SqlParameter("@Projectno", ViewState["Projectno"].ToString());
        try
        {
            string qry = @"SELECT FinancialProgress.slno,FYs.FY,Months.Months,FinancialProgress.Entrydate,FinancialProgress.Projectnumber,cast(FinancialProgress.Expenditureamount as float) as Expenditureamount
                           FROM FinancialProgress inner join
                      FYs ON FinancialProgress.FYID = FYs.FYID 
                      inner join Months ON FinancialProgress.MID= Months.MID WHERE " + strWhere + " ";


            DataTable dt = cls.GetDataTable(qry, new SqlParameter[] { fdate, tdate, _DivisionID, Projectnumber });
            double totall = 0;

            totall = dt.AsEnumerable().Sum(row => row.Field<double>(dt.Columns["Expenditureamount"].ToString()));
          grdfinancial.Columns[3].FooterText = "Total :";
          grdfinancial.Columns[4].FooterText = totall.ToString();
            grdfinancial.DataSource = dt;
            grdfinancial.DataBind();
        }
        catch (Exception ex)
        { }
    }

    protected void btnsearch_click(object sender, EventArgs e)
    {
        //SqlParameter Fromdate = new SqlParameter("@Fromdate", txtfromdate.Text);
        //SqlParameter Todate = new SqlParameter("@Todate", txttodate.Text);
        //DataTable dt = cls.GetDataTableSp("SP_Get_Financial", new SqlParameter[] { Fromdate, Todate });
         BindFinancial();
    }
    
    protected void btn_Project_Entry_Click(object sender, EventArgs e)
    {
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);
            string pno = enc.Encrypt(ViewState["Projectno"].ToString());
           //string pno2 = enc.Decrypt(pno);
            Response.Redirect("AddFinancialProject.aspx?Projectno=" + pno.ToString());
        }
        catch { }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "View")
            {
                Session["slno"] = e.CommandArgument.ToString();

                //Response.Redirect("ViewAddFinancial.aspx?Projectno=" + ViewState["Projectno"].ToString());
                Encryptor enc = new Encryptor(Encryptor.PrivateKey);
                string pno = enc.Encrypt(ViewState["Projectno"].ToString());
                Response.Redirect("ViewAddFinancial.aspx?Projectno=" + pno.ToString());
            }
            if (e.CommandName == "Modify")
            {
                Session["slno"] = e.CommandArgument.ToString();
                //  Session["CircleID"] = e.CommandArgument.ToString();
                Encryptor enc = new Encryptor(Encryptor.PrivateKey);
                string pno = enc.Encrypt(ViewState["Projectno"].ToString());
                Response.Redirect("UpdateAddFinancial.aspx?Projectno=" + pno.ToString());

            }
        }
        catch (Exception ex) { }
    }


    protected void btn_reset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ProjectEntryDetails.aspx");
        }
        catch (Exception ex)
        { }
    }
    
}