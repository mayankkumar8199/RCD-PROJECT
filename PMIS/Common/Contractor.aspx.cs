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

public partial class RCDPMISNEW_Common_Contractro : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string sqlQuery = string.Empty;
    string ContractID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["Role"]) == null)
            {
                Response.Redirect("~/PMIS/Login.aspx");
            }
            LoadYear();
            ViewState["ContractorID"] = string.Empty;
            //btnupdate.Enabled = false;
            loadContractors();
        }
        
    }
    
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadContractors();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           // lblmsg.Visible = true;
            ViewState["ContractorID"] = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string Contractor_Name = GridView1.DataKeys[e.RowIndex].Values["ContractorName"].ToString();
            TextBox txtContractorName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtContractorName");
            TextBox txtLetterNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLetterno");
            TextBox txtLetterDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLetterDate");
            TextBox txtAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAddress");

            //Pass The Parameter

            SqlParameter ContractorName = new SqlParameter("@ContractorName", string.IsNullOrEmpty(txtContractorName.Text.Trim()) ? DBNull.Value : (object)txtContractorName.Text.Trim());
            SqlParameter LetterNo = new SqlParameter("@LetterNo", string.IsNullOrEmpty(txtLetterNo.Text.Trim()) ? DBNull.Value : (object)txtLetterNo.Text.Trim());
            SqlParameter LetterDate = new SqlParameter("@LetterDate", string.IsNullOrEmpty(txtLetterDate.Text.Trim()) ? DBNull.Value : (object)txtLetterDate.Text.Trim());
            SqlParameter Address = new SqlParameter("@Address", string.IsNullOrEmpty(txtAddress.Text.Trim()) ? DBNull.Value : (object)txtAddress.Text.Trim());

            //Write the query
            sqlQuery = @"Update Contractor set ContractorName=@ContractorName,LetterNo=@LetterNo,LetterDate=@LetterDate,Address=@Address
                     Where ContractorID='" + ViewState["ContractorID"] + "'";
            int result = cls.ExecuteSql(sqlQuery, new SqlParameter[] { ContractorName, LetterNo, LetterDate, Address });
            if (result > 0)
            {
               // lblmsg.ForeColor = Color.Green;
               // lblmsg.Text = Contractor_Name + " Details Updated successfully";
            }

            loadContractors();
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadContractors();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadContractors();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
           // lblmsg.Visible = true;
            ViewState["ContractorID"] = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string Contractor_Name = GridView1.DataKeys[e.RowIndex].Values["ContractorName"].ToString();
            sqlQuery = @"Delete From Contractor Where ContractorID='" + ViewState["ContractorID"] + "'";
            int result = cls.ExecuteSql(sqlQuery);
            if (result > 0)
            {
               // lblmsg.ForeColor = Color.Green;
               // lblmsg.Text = Contractor_Name + " Details Deleted successfully";
            }

            loadContractors();
        }
        catch (Exception ex) { }
    }
    private void loadContractors()
    {
        try
        {
            sqlQuery = @"SELECT     SrNo, ContractorID, ContractorName, case when ContractorClass='01' then 'Class I' when ContractorClass='02' then 'Class II' when ContractorClass='03' then 'Class III' when ContractorClass='04' then 'Class IV' end as ContractorClass, case when RegistrationType ='01' then 'Individual' when RegistrationType ='02' then 'Partnership Firm' when RegistrationType ='03' then 'Company' when RegistrationType ='04' then 'Solo Propritership' when RegistrationType ='05' then 'UE' end as RegistrationType, RegistrationNo, RegYear, LetterNo, LetterDate, Address, Mobile, DebarYN, DebarDate, BlacklistedYN,    BlacklistDate, PAN, Remarks, isActive, Type     FROM         Contractor order by SrNo Desc";
            DataView dv = cls.GetDataTable(sqlQuery).DefaultView;
            // dv.Sort = "ContractorName";
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Session["srno"] = e.CommandArgument.ToString();

            Response.Redirect("ViewContractorDetails.aspx");
        }
        if (e.CommandName == "Modify")
        {
            Session["srno"] = e.CommandArgument.ToString();
          //  Session["CircleID"] = e.CommandArgument.ToString();
             Response.Redirect("UpdateContractor.aspx");
           
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_add_contractor_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AddNewContractor.aspx");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();

    }
    private void loadSearchContractors()
    {
        try
        {
            if (ddlsearchYear.SelectedValue.Equals("0"))
                sqlQuery = @"SELECT  SrNo, ContractorID, ContractorName,  case when ContractorClass='01' then 'Class I' when ContractorClass='02' then 'Class II' when ContractorClass='03' then 'Class III' when ContractorClass='04' then 'Class IV' end as ContractorClass, case when RegistrationType ='01' then 'Individual' when RegistrationType ='02' then 'Partnership Firm' when RegistrationType ='03' then 'Company' when RegistrationType ='04' then 'Solo Propritership' when RegistrationType ='05' then 'UE' end as RegistrationType, RegistrationNo, RegYear, LetterNo, LetterDate, Address,Mobile, DebarYN, DebarDate, 
                      BlacklistedYN, BlacklistDate, PAN, Remarks FROM Contractor";
            else
                sqlQuery = @"SELECT  SrNo, ContractorID, ContractorName,  case when ContractorClass='01' then 'Class I' when ContractorClass='02' then 'Class II' when ContractorClass='03' then 'Class III' when ContractorClass='04' then 'Class IV' end as ContractorClass, case when RegistrationType ='01' then 'Individual' when RegistrationType ='02' then 'Partnership Firm' when RegistrationType ='03' then 'Company' when RegistrationType ='04' then 'Solo Propritership' when RegistrationType ='05' then 'UE' end as RegistrationType, RegistrationNo, RegYear, LetterNo, LetterDate, Address,Mobile, DebarYN, DebarDate, 
                      BlacklistedYN, BlacklistDate, PAN, Remarks FROM Contractor where RegYear='" + ddlsearchYear.SelectedValue.ToString().Trim() + "' ";

            if (ddlsearchClass.SelectedValue.ToString() != "0")
                sqlQuery += (sqlQuery.Contains("where") ? " AND " : " where ") + "  ContractorClass=" + ddlsearchClass.SelectedValue.ToString().Trim();
            if (ddlsearchType.SelectedValue.ToString() != "0")
                sqlQuery += (sqlQuery.Contains("where") ? " AND " : " where ") + "  RegistrationType=" + ddlsearchType.SelectedValue.ToString().Trim();

            sqlQuery += " order by ContractorName";
            DataTable dv = cls.GetDataTable(sqlQuery);
            lblcontractor.Text = "Total Number of Contractor Details:-" + dv.Rows.Count.ToString();
            if (dv.Rows.Count > 0)
            {
                // dv.Sort = "ContractorName";

                GridView1.DataSource = dv;
                GridView1.DataBind();

            }

        }
        catch (Exception ex) { }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        loadSearchContractors();
    }
    private void LoadYear()
    {
        try
        {
            sqlQuery = @"SELECT  id, Year AS RegYr FROM  Year order by RegYr desc ";
            DataTable dt = cls.GetDataTable(sqlQuery);
            //DataView dv =  dt;
            //dv.Sort = "Year desc";

            ddlYear.DataSource = dt;
            ddlYear.DataTextField = "RegYr";
            ddlYear.DataValueField = "RegYr";

            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("-Select-", "0"));
            ddlYear.SelectedValue = "0";

            ddlsearchYear.DataSource = dt;
            ddlsearchYear.DataTextField = "RegYr";
            ddlsearchYear.DataValueField = "RegYr";

            ddlsearchYear.DataBind();
            ddlsearchYear.Items.Insert(0, new ListItem("-ALL-", "0"));
            ddlsearchYear.SelectedValue = "0";
        }
        catch (Exception ex) { }
    }
    string GetContractID()
    {
        try
        {

            // if (rdlist.SelectedValue == "0")

            ContractID = ddlcontractclass.SelectedValue.Trim() + "-" + ddlregtype.SelectedValue.Trim() + "-" + txtRegistration.Text.Trim() + "/" + ddlYear.SelectedItem.Text.Trim();
            // else
            //     ContractID = ddlcontractclass.SelectedValue.Trim() + "-" + ddlregtype.SelectedValue.Trim() + "-" + txtRegistration.Text.Trim() + "/" + ddlYear.SelectedItem.Text.Trim() + "/" + rdlist.SelectedValue.Trim();

        }
        catch (Exception ex) { }
        return ContractID;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
           // lblmsg.Visible = true;
            string ContractID = GetContractID();
            SqlParameter DebarYN, BlackListedYN;
            SqlParameter ContractorName = new SqlParameter("@ContractorName", string.IsNullOrEmpty(txtContractorName.Text.Trim()) ? DBNull.Value : (object)txtContractorName.Text.Trim());
            SqlParameter ContractorClass = new SqlParameter("@ContractorClass", ddlcontractclass.SelectedValue.Equals("0") ? DBNull.Value : (object)ddlcontractclass.SelectedValue);
            SqlParameter RegistrationType = new SqlParameter("@RegistrationType", ddlregtype.SelectedValue.Equals("0") ? DBNull.Value : (object)ddlregtype.SelectedValue);
            SqlParameter RegistrationNo = new SqlParameter("@RegistrationNo", string.IsNullOrEmpty(txtRegistration.Text.Trim()) ? DBNull.Value : (object)txtRegistration.Text.Trim());
            SqlParameter RegistrationYear = new SqlParameter("@RegistrationYear", ddlYear.SelectedValue.Equals("0") ? DBNull.Value : (object)ddlYear.SelectedValue);
            SqlParameter LetterNo = new SqlParameter("@LetterNo", string.IsNullOrEmpty(txtletterno.Text.Trim()) ? DBNull.Value : (object)txtletterno.Text.Trim());
            SqlParameter LetterDate = new SqlParameter("@LetterDate", string.IsNullOrEmpty(txtletterdate.Text.Trim()) ? DBNull.Value : (object)txtletterdate.Text.Trim());
            SqlParameter Address = new SqlParameter("@Address", string.IsNullOrEmpty(txtAddress.Text.Trim()) ? DBNull.Value : (object)txtAddress.Text.Trim());
            SqlParameter Mobile = new SqlParameter("@Mobile", string.IsNullOrEmpty(txtmobileno.Text.Trim()) ? DBNull.Value : (object)txtmobileno.Text.Trim());
            if (rdbtndebar.SelectedValue == "1")
            {
                DebarYN = new SqlParameter("@DebarYN", "Y");
            }
            else
            {
                DebarYN = new SqlParameter("@DebarYN", "N");
            }
            SqlParameter DebarDate = new SqlParameter("@DebarDate", string.IsNullOrEmpty(txtdebardate.Text.Trim()) ? DBNull.Value : (object)txtdebardate.Text.Trim());

            if (rdbtnblack.SelectedValue == "1")
            {
                BlackListedYN = new SqlParameter("@BlackListedYN", "Y");
            }
            else
            {
                BlackListedYN = new SqlParameter("@BlackListedYN", "N");
            }
            SqlParameter BlackListDate = new SqlParameter("@BlackListedDate", string.IsNullOrEmpty(txtBlackListeddate.Text.Trim()) ? DBNull.Value : (object)txtBlackListeddate.Text.Trim());
            SqlParameter PAN = new SqlParameter("@PAN", string.IsNullOrEmpty(txtpan.Text.Trim()) ? DBNull.Value : (object)txtpan.Text.Trim());
            SqlParameter Remarks = new SqlParameter("@Remarks", string.IsNullOrEmpty(txtremarks.Text.Trim()) ? DBNull.Value : (object)txtremarks.Text.Trim());


            if (string.IsNullOrEmpty(ContractID))
            {
               // lblmsg.Text = "<font color='Red'>Server Error Occured</font>";
                return;
            }
            SqlParameter ContractorId = new SqlParameter("@ContractorId", ContractID);

            sqlQuery = @"INSERT INTO Contractor
                   (ContractorId, ContractorName,ContractorClass,RegistrationType,RegistrationNo,RegYear,LetterNo,LetterDate,Address,Mobile,DebarYN,DebarDate,BlacklistedYN,BlacklistDate ,PAN,Remarks)
            VALUES   (@ContractorId, @ContractorName,@ContractorClass,@RegistrationType,@RegistrationNo,@RegistrationYear,@LetterNo,@LetterDate,@Address,@Mobile,@DebarYN,@DebarDate,@BlackListedYN,@BlackListedDate,@PAN,@Remarks)";


            if (cls.ExecuteSql(sqlQuery, new SqlParameter[] { ContractorId, ContractorName, ContractorClass, RegistrationType, RegistrationNo, RegistrationYear,
                                                            LetterNo,LetterDate,Address,Mobile,DebarYN,DebarDate,BlackListedYN,BlackListDate,PAN,Remarks}) > 0)
            {
                //btnsave.Enabled = false;
                btnsave.Visible = true;
               // lblmsg.ForeColor = Color.Maroon;
                //lblmsg.Text = "Saved Successfully.";
                Utility.showMessage(this, "Saved Successfully.");
                Response.Redirect("Contractor.aspx");
                //  loadContractors();
                Clear();
            }
        }
        catch (Exception ex) { }
    }
    void Clear()
    {
        txtContractorName.Text = "";
        txtRegistration.Text = "";
        txtletterno.Text = "";
        txtletterdate.Text = "";
        txtAddress.Text = "";
        ddlcontractclass.ClearSelection();
        ddlYear.ClearSelection();
        ddlregtype.ClearSelection();
        ddlcontractclass.ClearSelection();
        rdbtndebar.ClearSelection();
        rdbtnblack.ClearSelection();
        txtdebardate.Text = "";
        txtBlackListeddate.Text = "";
        txtpan.Text = "";
        txtremarks.Text = "";
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }
    void ClearControl()
    {
        Response.Redirect("Contractor.aspx");
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contractor.aspx");
    }
}