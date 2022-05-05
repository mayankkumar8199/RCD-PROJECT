using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class PMIS_Common_ViewAddFinancial : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role"]) == null || Convert.ToString(Session["Role"]) == "")
        {
            Response.Redirect("~/PMIS/Login.aspx");
            return;
        }
        

        if (!IsPostBack)
        {
            BindYear();
            BindMonths();
            display();
            Financialprogress();
            Financial();
            total();
            UpdatedDate();
 
        }

    }
    private void display()
    {

        try
        {
            //DataTable dt = cls.GetDataTable(@"SELECT slno,FYID,MID,CONVERT(varchar,Entrydate,105) as Entrydate  ,Expenditureamount,Measuringbook FROM FinancialProgress where slno='" + Session["slno"].ToString() + "'");
            string sql = @"SELECT slno,FYID,MID,CONVERT(varchar,Entrydate,105) as Entrydate,Expenditureamount,Measuringbook FROM FinancialProgress where slno = @slno";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@slno", Session["slno"].ToString()) });
            if (dt.Rows.Count > 0)
            {


                ddl_year.SelectedValue = dt.Rows[0]["FYID"].ToString();
                ddl_month.SelectedValue = dt.Rows[0]["MID"].ToString();
                //  string datetimeshow = (dt.Rows[0]["Entrydate"].ToString());
                txt_date.Text = dt.Rows[0]["Entrydate"].ToString();
                txt_expenditure.Text = dt.Rows[0]["Expenditureamount"].ToString();
                txt_Measuring.Text = dt.Rows[0]["Measuringbook"].ToString();
                //btn_save.Text = "Update";
            }
        }
        catch(Exception ex)
        {}
    }
    private void BindYear()
    {
        try
        {
            string sql = "";
            sql = @"select slno,FY,FYID from FYs  order by slno desc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_year.DataSource = dt;
            ddl_year.DataTextField = "FY";
            ddl_year.DataValueField = "FYID";
            ddl_year.DataBind();
            ddl_year.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            dt.Dispose();





        }

        catch (Exception ex)
        {

        }

    }
    private void BindMonths()
    {
        try
        {
            string sql = "";
            sql = @"select slno,MID,Months from Months order by slno ";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_month.DataSource = dt;
            ddl_month.DataTextField = "Months";
            ddl_month.DataValueField = "MID";
            ddl_month.DataBind();
            ddl_month.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            dt.Dispose();




        }

        catch (Exception ex)
        {

        }

    }
    protected void Financialprogress()
    {
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);
            string projectno = (enc.Decrypt(Request.QueryString["ProjectNo"]));

            // string projectno = Convert.ToString(Request.QueryString["ProjectNo"]);
            ViewState["Projectno"] = projectno;
            lblProject.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + projectno + "");
            iblProjNo.Text = " / " + ViewState["Projectno"].ToString();
        }
        catch (Exception ex)
        {

        }
    }
    private void Financial()
    {

        try
        {
            //DataTable dt = cls.GetDataTable(@"SELECT slno,FYID,MID,CONVERT(varchar,Entrydate,105) as Entrydate  ,Expenditureamount,Measuringbook FROM FinancialProgress where slno='" + Session["slno"].ToString() + "'");
            string sql = @"SELECT AAamount,AgreementAmount FROM ProjectMaster where Projectno = @Projectno";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@Projectno", ViewState["Projectno"].ToString()) });
            if (dt.Rows.Count > 0)
            {


                //  string datetimeshow = (dt.Rows[0]["Entrydate"].ToString());
                lblamount.Text = dt.Rows[0]["AAamount"].ToString();
                lblagreement.Text = dt.Rows[0]["AgreementAmount"].ToString();
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void UpdatedDate()
    {

        try
        {
            string sql = @"SELECT top 1 UpdatedDate FROM FinancialProgress where Projectnumber = @Projectno ORDER BY UpdatedDate desc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@Projectno", ViewState["Projectno"].ToString()) });
            if (dt.Rows.Count > 0)
            {

                lbllast.Text = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString()).ToString("dd-MMM-yyyy");
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void total()
    {
        try
        {
            string Projectnumber = string.Empty;
            string sql = @"select SUM(Expenditureamount) as total from FinancialProgress WHERE Projectnumber='" + ViewState["Projectno"].ToString() + "'";
            string total = cls.ExecuteScalar(sql);

            lblexpenditure.Text = total;

        }
        catch (Exception ex)
        { }

    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("FinancialEntry.aspx");
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);
            string pno = enc.Encrypt(ViewState["Projectno"].ToString());
            //string pno2 = enc.Decrypt(pno);
            Response.Redirect("FinancialEntry.aspx?Projectno=" + pno.ToString());
        }
        catch { }

    }
}