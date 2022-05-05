using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


public partial class PMIS_Common_Default : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string sqlQuery = string.Empty;
    string projectno = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role"]) == null || Convert.ToString(Session["Role"]) == "")
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }

        if (!IsPostBack)
        {
            try
            {

                BindYear();
                BindMonths();
                Financialprogress();
                Financial();
                total();
                UpdatedDate();
            }
            catch { }
        }
    }


    protected void Financialprogress()
    {
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);

            projectno = Request.QueryString["ProjectNo"].ToString();
            string my_String = Regex.Replace(projectno, " ", "+");
            projectno = enc.Decrypt(my_String);
            ViewState["Projectno"] = projectno;
            //string projectno = (enc.Decrypt(Request.QueryString["ProjectNo"]));

            // string projectno = Convert.ToString(Request.QueryString["ProjectNo"]);
            ViewState["Projectno"] = projectno;
            lblProject.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + projectno + "");
            iblProjNo.Text = " / " + ViewState["Projectno"].ToString();
            if (!Regex.IsMatch(projectno, @"[/d]"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "", true);
                return;
            }
        }
        catch (Exception ex)
        {

        }
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
                //  lbllast.Text = dt.Rows[0]["UpdatedDate"].ToString();
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
    private void clear()
    {

        ddl_year.ClearSelection();
        ddl_month.ClearSelection();
        txt_date.Text = "";
        txt_Measuring.Text = "";
        txt_expenditure.Text = "";

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        // lblMsg.Text = "";
        if (btn_save.Text == "Save")
        {
            Insert();
            
        }
        else if (btn_save.Text == "Update")
        {


            //Update();
        }
    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);
            string pno = enc.Encrypt(ViewState["Projectno"].ToString());
            //string pno2 = enc.Decrypt(pno);
            Response.Redirect("FinancialEntry.aspx?Projectno=" + pno.ToString());
        }
        catch { }
    }




    void Insert()
    {
        string sql = "";
        try
        {
            //if ((Session["WingID"] == null) || (Convert.ToString(Session["CircleID"]) == null) || (Convert.ToString(Session["DivisionID"]) == null))
            //{
            //    Response.Redirect("~/PMIS/Login.aspx");
            //}
            if (ddl_month.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please select month.');", true);
                return;
            }
            if (ddl_year.SelectedValue == "0")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('please select Year.');", true);
                return;
            }

            if (txt_date.Text == "")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please select date.');", true);
                return;
            }

            if (txt_expenditure.Text == "")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Enter Expenditure Amount:.');", true);
                return;
            }
            //if (txt_Measuring.Text == "")
            //{

            //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Enter Measuring Book No.');", true);
            //    return;
            //}

            sql = @"Insert into FinancialProgress(FYID,MID,Entrydate,Expenditureamount,Measuringbook,Projectnumber,UpdatedDate,UserID,DivisionID,WingID,CircleID) VALUES(@FYID,@MID,@Entrydate,@Expenditureamount,@Measuringbook,@Projectnumber,getdate(),@UserID,@DivisionID,@WingID,@CircleID)";


            SqlParameter UserID = new SqlParameter("@UserID", Session["UserID"].ToString());
            SqlParameter DivisionID = new SqlParameter("@DivisionID", Session["DivisionID"].ToString());
            SqlParameter WingID = new SqlParameter("@WingID", Session["WingID"].ToString());
            SqlParameter CircleID = new SqlParameter("@CircleID", Session["CircleID"].ToString());
            SqlParameter Projectnumber = new SqlParameter("@Projectnumber", ViewState["Projectno"].ToString());
            SqlParameter FYID = new SqlParameter("@FYID", ddl_year.SelectedValue);

            SqlParameter MID = new SqlParameter("@MID", ddl_month.SelectedValue);
            SqlParameter Date = new SqlParameter("@Entrydate", txt_date.Text.Trim());
            SqlParameter Expenditureamount = new SqlParameter("@Expenditureamount", txt_expenditure.Text);
            SqlParameter Measuringbook = new SqlParameter("@Measuringbook", txt_Measuring.Text);
            if (cls.ExecuteSql(sql, new SqlParameter[] { FYID, MID, Date, Expenditureamount, Measuringbook, Projectnumber, UserID, DivisionID, WingID, CircleID }) > 0)
            {

                // ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Financial Progress Saved Successfully.');", true);
                clear();
                //Response.Redirect("FinancialEntry.aspx?ProjectNo=" + ViewState["Projectno"].ToString());
                Encryptor enc = new Encryptor(Encryptor.PrivateKey);
                string pno = enc.Encrypt(ViewState["Projectno"].ToString());
                Response.Redirect("FinancialEntry.aspx?Projectno=" + pno.ToString());
            }

            else 
            {
                 ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Financial Progress not Saved Successfully.');", true);
            
            }



        }
        catch (Exception ex)
        {

        }


    }
    //    void Update()
    //    {
    //        try
    //        {
    //            string sql = @"update FinancialProgress set FYID =@FYID, MID =@MID, Entrydate=@Entrydate, Expenditureamount =@Expenditureamount, Measuringbook =@Measuringbook
    //                      Where slno='" + Session["slno"].ToString() + "'";
    //            SqlParameter FYID = new SqlParameter("@FYID", ddl_year.SelectedValue);
    //            SqlParameter MID = new SqlParameter("@MID", ddl_month.SelectedValue);
    //            SqlParameter Date = new SqlParameter("@Entrydate", txt_date.Text.Trim());
    //            SqlParameter Expenditureamount = new SqlParameter("@Expenditureamount", txt_expenditure.Text);
    //            SqlParameter Measuringbook = new SqlParameter("@Measuringbook", txt_Measuring.Text);
    //            if (cls.ExecuteSql(sql, new SqlParameter[] { FYID, MID, Date, Expenditureamount, Measuringbook }) > 0)
    //            {

    //                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Financial Progress updated Successfully.');", true);

    //            }
    //        }
    //        catch (Exception ex)
    //        { }


    //    }


}