using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class RCDPMISNEW_Common_AddProjectEntry : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string sqlQuery = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
            
        if (!Page.IsPostBack)
        {
            BindFYear();
            ddl_wings.Text = cls.ExecuteScalar("SELECT WingName FROM Wing WHERE WingID=" + Convert.ToString(Session["WingID"]).Trim() + "");
            ddl_circle.Text = cls.ExecuteScalar("SELECT CircleName FROM Circles WHERE CircleID=" + Convert.ToString(Session["CircleID"]).Trim() + "");
            ddl_division.Text = cls.ExecuteScalar("SELECT DivisionName FROM Divisions WHERE DivisionID=" + Convert.ToString(Session["DivisionID"]).Trim() + "");
            BindWing();
            BindCircle();
            BindDivision();
            BindHead();
            BindNatureOfWord();
            BindRoadType();
            bindststus();
           // loadProject(false);
           loadContractor();
            
        }
    }

    protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_status.SelectedValue == "1")
        //{

        //    txt_completiondate.Enabled = true;
        //    file_upload.Enabled = true;

        //}
        //else
        //{

        //    txt_completiondate.Enabled = false;
        //    file_upload.Enabled = false;
        //    txt_completiondate.Text = "";
        //}
    }

    protected void ddl_tyoe_of_work_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_sub_type.Visible = true;
        ddl_sub_type.Visible = true;
        BindWorkSubtype();
    }

    protected void ddl_natureofwork_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_work_type.Visible = true;
        ddl_tyoe_of_work.Visible = true;
        BindWorktype();
    }

    protected void ddl_roadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRoadName();
    }

    protected void ddl_head_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubHead();
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
            // Update();
        }
    }
    void Insert()
    {
        string sql = "";
        try
        {
            if ((Session["WingID"] == null) || ( Convert.ToString(Session["CircleID"]) == null) || ( Convert.ToString(Session["DivisionID"]) == null))
            {
                Response.Redirect("~/PMIS/Login.aspx");
            }
            if (ddl_status.SelectedValue == "1")
            {

                if (file_upload.FileName == "")
                {
                    Utility.showMessage(this, "Select File Upload");

                    return;
                }

                if (txt_completiondate.Text == "")
                {

                    Utility.showMessage(this, "Select Completion Date");

                    return;
                }

            }
            string _fuIdproof = GetUploadFile2(file_upload, "doct");

           
            sql = @"INSERT INTO ProjectMaster( FYID,ProjectName, WingID, CircleID, DivisionID, RoadId, HeadId, SubHeadID, SanctionRoadLength, AAamount, AArefno, AADate, EntryDate,
                              EntryBy, NoWID, CMBDTypeID, WSTypeID,StartDate,EndDate ,ContractorInProject,AgreementAmount,WorkProgramSubmitted,status,Completiondate,CompletionCertificate) VALUES(@FYID, @ProjectName, @WingID, @CircleID, @DivisionID, @RoadId, @HeadId, @SubHeadID,
                            @SanctionRoadLength, @AAamount, @AArefno, @AADate,@EntryDate, @EntryBy, @NoWID, @CMBDTypeID, @WSTypeID,@StartDate,@EndDate,@ContractorInProject,@AgreementAmount,@WorkProgramSubmitted,@status,@Completiondate,@CompletionCertificate)";
            SqlParameter FYID = new SqlParameter("@FYID", ddl_fyear.SelectedValue);
            SqlParameter ProjectName = new SqlParameter("@ProjectName", txt_project.Text.Trim());
            SqlParameter WingID = new SqlParameter("@WingID", Session["WingID"].ToString().Trim());
            SqlParameter CircleID = new SqlParameter("@CircleID", Session["CircleID"].ToString().Trim());
            SqlParameter DivisionID = new SqlParameter("@DivisionID", Session["DivisionID"].ToString().Trim());
            SqlParameter RoadId = new SqlParameter("@RoadId", Convert.ToInt32(ddl_roadname.SelectedValue));
            SqlParameter HeadId = new SqlParameter("@HeadId", ddl_head.SelectedValue.Trim());
            SqlParameter SubHeadID = new SqlParameter("@SubHeadID", ddl_subhead.SelectedValue.Trim());
            SqlParameter SanctionRoadLength = new SqlParameter("@SanctionRoadLength", txt_lengthofroad.Text.Trim());
            SqlParameter AAamount = new SqlParameter("@AAamount", txt_admaprovalamount.Text.Trim());
            SqlParameter AArefno = new SqlParameter("@AArefno", txt_adaproval.Text.Trim());
            SqlParameter AADate = new SqlParameter("@AADate", txt_admin_approval_date.Text.Trim());
            SqlParameter EntryDate = new SqlParameter("@EntryDate", System.DateTime.Now);
            SqlParameter EntryBy = new SqlParameter("@EntryBy", User.Identity.Name);
            SqlParameter NoWID = new SqlParameter("@NoWID", ddl_natureofwork.SelectedValue.Trim());
            SqlParameter CMBDTypeID = new SqlParameter("@CMBDTypeID", ddl_tyoe_of_work.SelectedValue.Trim());
            SqlParameter WSTypeID = new SqlParameter("@WSTypeID", ddl_sub_type.SelectedValue.Trim());
            SqlParameter StartDate = new SqlParameter("@StartDate", string.IsNullOrEmpty(txt_strtdate.Text.Trim()) ? DBNull.Value : (object)txt_strtdate.Text.Trim());
            SqlParameter EndDate = new SqlParameter("@EndDate", string.IsNullOrEmpty(txt_enddate.Text.Trim()) ? DBNull.Value : (object)txt_enddate.Text.Trim());
            SqlParameter ContractorInProject = new SqlParameter("@ContractorInProject", string.IsNullOrEmpty(ddl_conductor.SelectedValue.Trim()) ? DBNull.Value : (object)ddl_conductor.SelectedValue.Trim());
            SqlParameter AgreementAmount = new SqlParameter("@AgreementAmount", txt_aggrment_amount.Text.Trim());
            SqlParameter WorkProgramSubmitted = new SqlParameter("@WorkProgramSubmitted", RadioButtonList1.SelectedValue.Trim());
            SqlParameter _status = new SqlParameter("@status", ddl_status.SelectedValue.Trim());
            SqlParameter _Completiondate = new SqlParameter("@Completiondate", txt_completiondate.Text.Trim());
            SqlParameter _CompletionCertificate = new SqlParameter("@CompletionCertificate", _fuIdproof.Trim());

            
            if (cls.ExecuteSql(sql, new SqlParameter[] { FYID, ProjectName, WingID, CircleID, DivisionID, RoadId, HeadId, SubHeadID, SanctionRoadLength,
                               AAamount, AArefno, AADate,EntryDate, EntryBy, NoWID, CMBDTypeID, WSTypeID,StartDate,EndDate ,ContractorInProject,AgreementAmount,WorkProgramSubmitted,_status,_Completiondate,_CompletionCertificate}) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Project Details Saved Successfully.');", true);
                clear();
                Response.Redirect("ProjectEntryDetails.aspx");
              //  loadProject(true);
            }
        }
        catch (Exception ex)
        { }
    }
    protected string GetUploadFile2(FileUpload ControlName, string FileName)
    {
        // File Upload Function.......

        string RegId = Session["DivisionID"].ToString();
        string imageunique = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
        string fileName = string.Empty;
        string filePath = string.Empty;
        string extension = string.Empty;
        string rpath = string.Empty;

        if (ControlName.HasFile)
        {
            // Get selected image extension
            extension = Path.GetExtension(ControlName.FileName).ToLower();
            //Check image is of valid type or not
            if (extension == ".pdf")
            {
                if (ControlName.PostedFile.ContentLength > (1024 * 1024))
                {
                    Utility.showMessage(this, "File size must not exceed 1 MB");
                    return "0";
                }
                string serverFileName = string.Empty;
                string uploadDirectory = string.Empty;

                uploadDirectory = "~/PMIS/Uploadscertificate/" + RegId + "/";


                if (!Directory.Exists(Server.MapPath(uploadDirectory)))
                {
                    Directory.CreateDirectory(Server.MapPath(uploadDirectory));
                }
                fileName = FileName + imageunique.Trim() + RegId.Trim() + extension;
                string fullUploadPath = Path.Combine(Server.MapPath(uploadDirectory), fileName);
                FileInfo file = new FileInfo(fullUploadPath);
                if (file.Exists)
                {
                    file.Delete();

                }
                if (File.Exists(fullUploadPath))
                {
                    ControlName.SaveAs(fullUploadPath);
                }
                else
                {
                    ControlName.SaveAs(fullUploadPath);
                }

                rpath = uploadDirectory + fileName;
            }
        }

        return rpath;
    }
    private void loadContractor()
    {
        try
        {
            string sql = "";
            sql = @"SELECT ContractorID, ContractorName +'-' +PAN as ContractorName FROM Contractor where  isActive is null  order by ContractorName";
            DataTable dt = cls.GetDataTable(sql);
            ddl_conductor.DataSource = dt;
            ddl_conductor.DataValueField = "ContractorID";
            ddl_conductor.DataTextField = "ContractorName";
            ddl_conductor.DataBind();
            ddl_conductor.Items.Insert(0, new ListItem("-Select-", "0"));
            ddl_conductor.SelectedValue = "0";
        }
        catch (Exception ex)
        { }
    }
    //void Update()
    //{
    //    try
    //    {
    //        string _fuIdproof = string.Empty;
    //        if (ddl_status.SelectedValue == "1")
    //        {

    //            if (file_upload.FileName == "")
    //            {
    //                Utility.showMessage(this, "Select File Upload");

    //                return;
    //            }

    //            if (txt_completiondate.Text == "")
    //            {

    //                Utility.showMessage(this, "Select Completion Date");

    //                return;
    //            }

    //        }
    //        if (file_upload.HasFile)
    //        {
    //            _fuIdproof = GetUploadFile2(file_upload, "doct");

    //        }
    //        else
    //        {
    //            _fuIdproof = ViewState["doctpath"].ToString();
    //        }

    //        string Projectno = gvProject.DataKeys[gvProject.SelectedIndex].Values["Projectno"].ToString();
    //        string sql = @"update ProjectMaster set ProjectName=@ProjectName, SanctionRoadLength=@SanctionRoadLength, AAamount=@AAamount, AArefno=@AArefno, AADate=@AADate, 
    //                          UpdateDate=@UpdateDate, UpdateBy=@UpdateBy , NoWID=@NoWID, CMBDTypeID=@CMBDTypeID, WSTypeID=@WSTypeID,StartDate=@StartDate ,EndDate=@EndDate ,ContractorInProject=@ContractorInProject,AgreementAmount=@AgreementAmount,WorkProgramSubmitted=@WorkProgramSubmitted,status=@status,Completiondate=@Completiondate,CompletionCertificate=@CompletionCertificate where Projectno='" + Projectno + "' ";

    //        SqlParameter ProjectName = new SqlParameter("@ProjectName", txt_project.Text.Trim());
    //        //SqlParameter WingID = new SqlParameter("@WingID", Session["WingID"].ToString().Trim());
    //        //SqlParameter CircleID = new SqlParameter("@CircleID", Session["CircleID"].ToString().Trim());
    //        //SqlParameter DivisionID = new SqlParameter("@DivisionID", Session["DivisionID"].ToString().Trim());
    //        //SqlParameter RoadId = new SqlParameter("@RoadId", ddlRoad.SelectedValue.Trim());
    //        //SqlParameter HeadId = new SqlParameter("@HeadId", ddlHead.SelectedValue.Trim());
    //        SqlParameter SanctionRoadLength = new SqlParameter("@SanctionRoadLength", txt_lengthofroad.Text.Trim());
    //        SqlParameter AAamount = new SqlParameter("@AAamount", txt_adaproval.Text.Trim());
    //        SqlParameter AArefno = new SqlParameter("@AArefno", txt_admaprovalamount.Text.Trim());
    //        SqlParameter AADate = new SqlParameter("@AADate", txt_admin_approval_date.Text.Trim());

    //        SqlParameter NoWID = new SqlParameter("@NoWID", ddl_natureofwork.SelectedValue.Trim());

    //        //SqlParameter CMBDTypeID = new SqlParameter("@CMBDTypeID", string.IsNullOrEmpty(ddlNOfWrkType.SelectedValue.Trim()) ? DBNull.Value : (object)ddlNOfWrkType.SelectedValue.Trim());
    //        SqlParameter CMBDTypeID = new SqlParameter("@CMBDTypeID", ddl_tyoe_of_work.SelectedValue.Trim());
    //        SqlParameter WSTypeID = new SqlParameter("@WSTypeID", ddl_sub_type.SelectedValue.Trim());


    //        SqlParameter UpdateDate = new SqlParameter("@UpdateDate", DateTime.Now);
    //        SqlParameter UpdateBy = new SqlParameter("@UpdateBy", User.Identity.Name);
    //        SqlParameter StartDate = new SqlParameter("@StartDate", txt_strtdate.Text.Trim());
    //        SqlParameter EndDate = new SqlParameter("@EndDate", txt_enddate.Text.Trim());
    //        SqlParameter ContractorInProject = new SqlParameter("@ContractorInProject", ddl_conductor.SelectedValue.Trim());
    //        SqlParameter AgreementAmount = new SqlParameter("@AgreementAmount", txt_aggrment_amount.Text.Trim());
    //        SqlParameter WorkProgramSubmitted = new SqlParameter("@WorkProgramSubmitted", RadioButtonList1.SelectedValue.Trim());
    //        SqlParameter _status = new SqlParameter("@status", ddl_status.SelectedValue.Trim());
    //        SqlParameter _Completiondate = new SqlParameter("@Completiondate", txt_completiondate.Text.Trim());
    //        SqlParameter _CompletionCertificate = new SqlParameter("@CompletionCertificate", _fuIdproof.Trim());
    //        if (cls.ExecuteSql(sql, new SqlParameter[] { ProjectName, SanctionRoadLength, AAamount, AArefno, AADate, NoWID, CMBDTypeID, WSTypeID,
    //                                    UpdateDate, UpdateBy,EndDate,StartDate ,ContractorInProject,AgreementAmount,WorkProgramSubmitted,_status,_Completiondate,_CompletionCertificate}) > 0)
    //        {
    //            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Project Details updated successfully.');", true);
    //            // lblMsg.Text = "Project Details updated successfully.";
    //            clear();
    //            //loadProject(false);
    //            return;
    //        }
    //    }
    //    catch (Exception ex)
    //    { }

    //}
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }
    private void clear()
    {
        ddl_fyear.ClearSelection();
        ddl_circle.ClearSelection();
        ddl_conductor.ClearSelection();
        ddl_division.ClearSelection();
        ddl_head.ClearSelection();
        ddl_natureofwork.ClearSelection();
        ddl_roadname.ClearSelection();
        ddl_roadtype.ClearSelection();
        ddl_status.ClearSelection();
        txt_adaproval.Text = "";
        txt_admaprovalamount.Text = "";
        txt_project.Text = "";
        txt_aggrment_amount.Text = "";
        txt_lengthofroad.Text = "";
        txt_strtdate.Text = "";

    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {

        Response.Redirect("ProjectEntryDetails.aspx");
    }


    private void BindFYear()
    {
        try
        {
            string sql = "";
            ////sql = @"select slno,FY,FYID from FYs where slno IN (10) order by slno asc";
            sql = @"select slno,FY,FYID from FYs   order by slno desc";

            //  sql = @"select FYID, FY from FYs where  status='Y' order by FYID asc";
            //  sql = @"select FYID, FY from FYs  order by FYID asc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_fyear.DataSource = dt;
            ddl_fyear.DataTextField = "FY";
            ddl_fyear.DataValueField = "FYID";
            ddl_fyear.DataBind();
            
           // ddl_fyear.Enabled = false;

             // ddl_fyear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Fyear--", "10"));

        }
        catch (Exception ex)
        {
        }
    }
    private void BindWing()
    {
        try
        {
            string sql = "";
            if (Convert.ToString(Convert.ToString(Session["Role"])) == "DIVADM")
            {
                //sql = @" select WingID,WingName from Wing order by serial_no asc";
                sql = @"select WingID,WingName from Wing where WingID='" + Convert.ToString(Session["WingID"]) + "' order by serial_no asc";
                DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
                ddl_wings.DataSource = dt;
                ddl_wings.DataTextField = "WingName";
                ddl_wings.DataValueField = "WingID";
                ddl_wings.DataBind();
            }
            else
            {
                sql = @" select WingID,WingName from Wing order by serial_no asc";
                DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
                ddl_wings.DataSource = dt;
                ddl_wings.DataTextField = "WingName";
                ddl_wings.DataValueField = "WingID";
                ddl_wings.DataBind();
            }


            // ddl_wings.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

        }
        catch (Exception ex)
        {


        }

    }

    private void BindCircle()
    {
        try
        {

            string sql = "";
            DataTable dt = null;
            string _circleid = Convert.ToString(Session["CircleID"]);

          
            sql = @"SELECT CircleName,CircleID,WingID FROM Circles where CircleID=@CircleID order by CircleName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CircleID", _circleid) });

            ddl_circle.DataSource = dt;
            ddl_circle.DataTextField = "CircleName";
            ddl_circle.DataValueField = "CircleID";
            ddl_circle.DataBind();

           // ddl_circle.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

        }
        catch (Exception ex)
        {


        }
    }

    private void BindDivision()
    {
        try
        {

            string sql = "";
            DataTable dt = null;
            string _divisionid = Convert.ToString(Session["DivisionID"]);

            sql = @"SELECT DivisionName,DivisionID, CircleID FROM Divisions where DivisionID=@DivisionID order by DivisionName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@DivisionID", _divisionid) });

            ddl_division.DataSource = dt;
            ddl_division.DataTextField = "DivisionName";
            ddl_division.DataValueField = "DivisionID";
            ddl_division.DataBind();

           // ddl_division.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

        }
        catch (Exception ex)
        {


        }
    }
    private void BindHead()
    {
        try
        {
            string sql = "";

            sql = @"select  headId,headName from Head order by headId asc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_head.DataSource = dt;
            ddl_head.DataTextField = "headName";
            ddl_head.DataValueField = "headId";
            ddl_head.DataBind();

            ddl_head.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));




        }
        catch (Exception ex)
        {


        }
    }
    private void BindSubHead()
    {
        try
        {

            string sql = "";
            DataTable dt = null;
            sql = @"select shid,SubHeadID,SubHeadName,headId from SubHead  where headId=@headId order by SubHeadName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@headId", ddl_head.SelectedValue) });

            ddl_subhead.DataSource = dt;
            ddl_subhead.DataTextField = "SubHeadName";
            ddl_subhead.DataValueField = "SubHeadID";
            ddl_subhead.DataBind();

            ddl_subhead.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));

        }
        catch (Exception ex)
        {


        }
    }

    private void BindNatureOfWord()
    {
        try
        {
            string sql = "";

            sql = @" select NoWID,NatOfWorkName from NatureOfWrk order by NatOfWorkName asc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_natureofwork.DataSource = dt;
            ddl_natureofwork.DataTextField = "NatOfWorkName";
            ddl_natureofwork.DataValueField = "NoWID";
            ddl_natureofwork.DataBind();

            ddl_natureofwork.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));

        }
        catch (Exception ex)
        {


        }

    }

    private void BindWorktype()
    {
        try
        {

            string sql = "";
            DataTable dt = null;
            sql = @"select NoWID,CMBDTypeName,CMBDTypeID from NatOfWrk_Type  where NoWID=@NoWID order by CMBDTypeName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@NoWID", ddl_natureofwork.SelectedValue) });

            ddl_tyoe_of_work.DataSource = dt;
            ddl_tyoe_of_work.DataTextField = "CMBDTypeName";
            ddl_tyoe_of_work.DataValueField = "CMBDTypeID";
            ddl_tyoe_of_work.DataBind();

            ddl_tyoe_of_work.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));

        }
        catch (Exception ex)
        {


        }
    }

    private void BindWorkSubtype()
    {
        try
        {

            string sql = "";
            DataTable dt = null;
            string _subtypeofwork = ddl_tyoe_of_work.SelectedValue.Trim();
            sql = @"select CMBDID,WSTypeName,WSTypeID from NatOfWrk_SubType where CMBDID=@CMBDID order by WSTypeName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CMBDID", _subtypeofwork) });

            ddl_sub_type.DataSource = dt;
            ddl_sub_type.DataTextField = "WSTypeName";
            ddl_sub_type.DataValueField = "WSTypeID";
            ddl_sub_type.DataBind();

            ddl_sub_type.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));

        }
        catch (Exception ex)
        {


        }
    }

    private void BindRoadType()
    {
        try
        {
            string sql = "";

            sql = @"select RoadTypeId,description from RoadType order by RoadTypeId asc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_roadtype.DataSource = dt;
            ddl_roadtype.DataTextField = "description";
            ddl_roadtype.DataValueField = "RoadTypeId";
            ddl_roadtype.DataBind();

            ddl_roadtype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));

        }
        catch (Exception ex)
        {

            // select rt.description from RoadType as rt inner join RoadMaster as rm on rm.RoadType=rt.description where rt.description=@rt.description
        }

    }

    private void BindRoadName()
    {
        //try
        //{

          string sql = "";
        //    DataTable dt = null;
        //    sql = @"select RoadType,Name_of_the_Road from RoadMaster where RoadType=@RoadType order by Name_of_the_Road";
        //    //// sql = @" select rt.description from RoadType as rt inner join RoadMaster as rm on rm.RoadType=rt.description where rt.description=@rt.description order by rm.Name_of_the_Road";
        //    dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@RoadType", ddl_roadtype.SelectedItem.ToString()) });

        //    ddl_roadname.DataSource = dt;
        //    ddl_roadname.DataTextField = "Name_of_the_Road";
        //    ddl_roadname.DataValueField = "RoadType";
        //    ddl_roadname.DataBind();

        //    ddl_roadname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

        //}
        //catch (Exception ex)
        //{

        //        SELECT r.description, Name_of_the_Road,RoadId FROM RoadMaster rm 
        //inner join RoadType r on r.RoadTypeId = rm.RoadType
//where DivisionID = 2

        //}
        try
        {
            //sql = @"SELECT RoadType, Name_of_the_Road,RoadId FROM RoadMaster where RoadType='" + ddl_roadtype.SelectedValue + "'  order by Name_of_the_Road";

            string _divid = Convert.ToString(Session["DivisionID"]);

            sql = @"SELECT r.description, Name_of_the_Road,RoadId FROM RoadMaster rm inner join RoadType r on r.RoadTypeId = rm.RoadType 

where RoadType='" + ddl_roadtype.SelectedValue + "' and  DivisionID ='" + _divid + "' and IsDelete='Y' order by Name_of_the_Road";


            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@RoadType", ddl_roadtype.SelectedValue) } );
            ddl_roadname.DataSource = dt;
            ddl_roadname.DataValueField = "RoadId";
            ddl_roadname.DataTextField = "Name_of_the_Road";
            ddl_roadname.DataBind();
            ddl_roadname.Items.Insert(0, new ListItem("-Select-", "0"));
            ddl_roadname.SelectedValue = "0";
        }
        catch (Exception ex)
        { }
    }

    void bindststus()
    {
        try
        {
            string sql = "";
            sql = @"SELECT id, status FROM  tbl_project_status";
            DataTable dt = cls.GetDataTable(sql);
            ddl_status.DataSource = dt;
            ddl_status.DataValueField = "id";
            ddl_status.DataTextField = "status";
            ddl_status.DataBind();
           // ddl_status.Items.Insert(0, new ListItem("-Select-", "0"));
            ddl_status.SelectedValue = "2";
        }
        catch (Exception ex)
        { }
    }
}