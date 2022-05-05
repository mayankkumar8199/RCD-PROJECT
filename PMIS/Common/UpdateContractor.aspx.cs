using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class RCDPMISNEW_Common_UpdateContractor : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            display();
        }
       
        
    }

    protected void lnkback_Click(object sender, EventArgs e)
    {
        if(Page.IsPostBack)
        {
            Response.Redirect("Contractor.aspx");
        }
     
    }
    private void display()
    {
        // string roadid = Session["RoadID"].ToString();
        // string srno = Session["CircleID"].ToString();
        // DataTable dt1 = cls.GetDataTable(@"select SRNo from Contractor where SrNo=''");
        //string srno = dt1.Rows[0]["SrNo"].ToString();
        DataTable dt = cls.GetDataTable(@"SELECT  SrNo, ContractorID, ContractorName, case when ContractorClass='01' then 'Class I' when ContractorClass='02' then 'Class II' when ContractorClass='03' then 'Class III' when ContractorClass='04' then 'Class IV' end as ContractorClass, case when RegistrationType ='01' then 'Individual' when RegistrationType ='02' then 'Partnership Firm' when RegistrationType ='03' then 'Company' when RegistrationType ='04' then 'Solo Propritership' when RegistrationType ='05' then 'UE' end as RegistrationType, RegistrationNo, RegYear, LetterNo, LetterDate, Address, Mobile, DebarYN, DebarDate, BlacklistedYN,    BlacklistDate, PAN, Remarks, isActive, Type     FROM Contractor where SrNo='" + Session["srno"].ToString() + "'");
        if (dt.Rows.Count > 0)
        {
            txtcontId.Text = dt.Rows[0]["ContractorID"].ToString();
            txt_firmName.Text = dt.Rows[0]["ContractorName"].ToString();
            txt_contr_class.Text = dt.Rows[0]["ContractorClass"].ToString();
            txt_typeofcontr.Text = dt.Rows[0]["RegistrationType"].ToString();
            txt_regNo.Text = dt.Rows[0]["RegistrationNo"].ToString();
            txt_yrofreg.Text = dt.Rows[0]["RegYear"].ToString();

            txt_letterno.Text = dt.Rows[0]["LetterNo"].ToString();
            txt_letterdate.Text = dt.Rows[0]["LetterDate"].ToString();
            txt_address.Text = dt.Rows[0]["Address"].ToString();
            txt_mobile.Text = dt.Rows[0]["Mobile"].ToString();
            txt_pan.Text = dt.Rows[0]["PAN"].ToString();

        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        // string roadid = Session["RoadID"].ToString();
       // string SrNo = Session["srno"].ToString();

       // SqlParameter ContractorID = new SqlParameter("@ContractorID", txtcontId.Text);
        SqlParameter ContractorName = new SqlParameter("@ContractorName", txt_firmName.Text);
       // SqlParameter ContractorClass = new SqlParameter("@ContractorClass", txt_contr_class.Text);
       // SqlParameter RegistrationType = new SqlParameter("@RegistrationType", txt_typeofcontr.Text);
      //  SqlParameter RegistrationNo = new SqlParameter("@RegistrationNo", txt_regNo.Text);
        //SqlParameter RegYear = new SqlParameter("@RegYear", txt_yrofreg.Text);
        SqlParameter LetterNo = new SqlParameter("@LetterNo", txt_letterno.Text);
        SqlParameter LetterDate = new SqlParameter("@LetterDate", txt_letterdate.Text);
        SqlParameter Address = new SqlParameter("@Address", txt_address.Text);
        SqlParameter Mobile = new SqlParameter("@Mobile", txt_mobile.Text);
        //SqlParameter DebarYN = new SqlParameter("@DebarYN", txt_mobile.Text);

        SqlParameter PAN = new SqlParameter("@PAN", txt_pan.Text);
        SqlParameter SrNo = new SqlParameter("@SrNo", Session["srno"].ToString());

        string sql = @"Update Contractor set ContractorName=@ContractorName,LetterNo=@LetterNo,LetterDate=@LetterDate,Address=@Address,Mobile=@Mobile,PAN=@PAN 
                                           Where SrNo='" + Session["srno"].ToString() + "'";


        int a = cls.ExecuteSql(sql, new SqlParameter[] { ContractorName, LetterNo, LetterDate, Address, Mobile, PAN, SrNo });
        if (a > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Contractor Update Successfully.');", true);
            Response.Redirect("Contractor.aspx");


        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Contractor Not Update Successfully.');", true);
            Response.Redirect("Contractor.aspx");
        }

    }
}