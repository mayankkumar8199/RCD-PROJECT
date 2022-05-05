using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class RCDPMISNEW_Common_UpdateProjectEntry : System.Web.UI.Page
{
    public string Project;
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Role"] == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindFYear();
            BindWing();
            BindCircle();
            BindDivision();
            BindHead();
            BindSubHead();
            BindRoadType();
            BindRoadName();
            BindNatureOfWord();
            BindWorktype();
            BindWorkSubtype();
            loadContractor();
            bindststus();
            loadData();
            //  Project = Session["ProjectNo"].ToString();
            //hl_certificate.DataBind();
            //  hl_certificate.NavigateUrl =Session["certificate"].ToString();
        }
    }

    protected void loadData()
    
    {
        string ProjectNo = Convert.ToString(Request.QueryString["ProjectNo"]);
        SqlParameter _projectid = new SqlParameter("@ProjectNo", ProjectNo);
        DataTable dt = cls.GetDataTableSp("Sp_Get_ProjectEntry", new SqlParameter[] { _projectid });
        if (dt.Rows.Count > 0)
        {

            Session["ProjectNo"] = ProjectNo;
            BindFYear();
            ddl_fyear.SelectedValue= dt.Rows[0]["FYID"].ToString();
          
            ddl_wings.SelectedItem.Text= dt.Rows[0]["WingName"].ToString();
            BindWing();
            ddl_circle.SelectedItem.Text = dt.Rows[0]["CircleName"].ToString();
            BindCircle();
            ddl_division.SelectedItem.Text = dt.Rows[0]["DivisionName"].ToString();
            BindDivision();
            ddl_head.SelectedValue = dt.Rows[0]["headId"].ToString();
            // BindHead();
            BindSubHead();
            ddl_subhead.SelectedValue= dt.Rows[0]["SubHeadID"].ToString();
          
            txt_project.Text = dt.Rows[0]["ProjectName"].ToString();
            ddl_roadtype.SelectedValue= dt.Rows[0]["RoadTypeId"].ToString();
            //BindRoadType();
            ddl_roadname.SelectedItem.Text = dt.Rows[0]["Name_of_the_Road"].ToString();
            //BindRoadName();
            txt_lengthofroad.Text= dt.Rows[0]["SanctionRoadLength"].ToString();
            ddl_natureofwork.SelectedValue= dt.Rows[0]["NoWID"].ToString();
            ddl_tyoe_of_work.SelectedItem.Text= dt.Rows[0]["CMBDTypeName"].ToString();
            ddl_sub_type.SelectedItem.Text= dt.Rows[0]["WSTypeName"].ToString();
            txt_adaproval.Text= dt.Rows[0]["AArefno"].ToString();
      
            string a= dt.Rows[0]["AAamount"].ToString();
            double aa = Convert.ToDouble(a);
            txt_admaprovalamount.Text = aa.ToString();



            string CheckTime = "";            
            string _adate= dt.Rows[0]["AADate"].ToString();
            if(_adate.ToString()!="")
            {
                DateTime timeIn = Convert.ToDateTime(dt.Rows[0]["AADate"].ToString());
                CheckTime = timeIn.ToString("yyyy-MM-dd");

            }
            else
            {
                CheckTime = "";
            }
            txt_admin_approval_date.Text = CheckTime;

         
            string checktimestdate = "";
            string _stdate = dt.Rows[0]["StartDate"].ToString();
            if (_stdate.ToString() != "")
            {
                DateTime timeIn = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
                checktimestdate = timeIn.ToString("yyyy-MM-dd");

            }
            else
            {
                checktimestdate = "";
            }
            txt_strtdate.Text = checktimestdate;



            string checkenddate = "";
            string _enddate = dt.Rows[0]["EndDate"].ToString();

            if (_enddate.ToString() != "")
            {
                DateTime timeIn = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                checkenddate = timeIn.ToString("yyyy-MM-dd");

            }
            else
            {
                checkenddate = "";
            }
            txt_enddate.Text = checkenddate;

          
            string checkcomplectiondate = "";
            string _complectiondate = dt.Rows[0]["Completiondate"].ToString();

            if (_complectiondate.ToString() == "" || _complectiondate != "01/01/1900 00:00:00")
            {
                DateTime timeIn = Convert.ToDateTime(dt.Rows[0]["Completiondate"].ToString());
                checkcomplectiondate = timeIn.ToString("yyyy-MM-dd");
                txt_completiondate.Text = checkcomplectiondate;

            }
           
            //    else if(_complectiondate == "01/01/1900 00:00:00")
            //{
            //    checkcomplectiondate = "";
            //    txt_completiondate.Text = checkcomplectiondate;
                
            //    }
            else
            {
                checkcomplectiondate = "";
                txt_completiondate.Text = checkcomplectiondate;
            }
            string extdate1 = "";
            extdate1 = dt.Rows[0]["ExtensionDate1"].ToString();
            if (extdate1.ToString() == "" || extdate1 == "01/01/1900 00:00:00")
            {
                txtExtensiondate1.Text = "";
            }
            else
            {
                DateTime ExtensionDate1 = Convert.ToDateTime(dt.Rows[0]["ExtensionDate1"].ToString());
                extdate1 = ExtensionDate1.ToString("yyyy-MM-dd");
                txtExtensiondate1.Text = extdate1;
             
            }

            string extdate2 = "";
            extdate2 = dt.Rows[0]["ExtensionDate2"].ToString();
            if (extdate2.ToString() == "" || extdate2 == "01/01/1900 00:00:00")
            {
                txtExtensiondate2.Text = "";
            }
            else
            {
                DateTime ExtensionDate2 = Convert.ToDateTime(dt.Rows[0]["ExtensionDate2"].ToString());
                extdate2 = ExtensionDate2.ToString("yyyy-MM-dd");
                txtExtensiondate2.Text = extdate2;

            }

            string extdate3 = "";
            extdate3 = dt.Rows[0]["ExtensionDate3"].ToString();
            if (extdate3.ToString() == "" || extdate3 == "01/01/1900 00:00:00")
            {
                txtExtensiondate3.Text = "";
            }
            else
            {
                DateTime ExtensionDate3 = Convert.ToDateTime(dt.Rows[0]["ExtensionDate3"].ToString());
                extdate3 = ExtensionDate3.ToString("yyyy-MM-dd");
                txtExtensiondate3.Text = extdate3;

            }
            //string extdate2 = "";
            //DateTime ExtensionDate2 = Convert.ToDateTime(dt.Rows[0]["ExtensionDate2"].ToString());
            //extdate2 = ExtensionDate2.ToString("yyyy-MM-dd");
            //txtExtensiondate2.Text = extdate2;

            //string extdate3 = "";
            //DateTime ExtensionDate3 = Convert.ToDateTime(dt.Rows[0]["ExtensionDate3"].ToString());
            //extdate3 = ExtensionDate3.ToString("yyyy-MM-dd");
            //txtExtensiondate3.Text = extdate3;
       
            string Certificate = dt.Rows[0]["CompletionCertificate"].ToString();
            Session["certificate"] = Certificate;
            txt_aggrment_amount.Text= dt.Rows[0]["AgreementAmount"].ToString();
            ddl_conductor.SelectedValue= dt.Rows[0]["ContractorID"].ToString(); 
            RadioButtonList1.SelectedValue= dt.Rows[0]["WorkProgramSubmitted"].ToString();
            ddl_status.SelectedValue = dt.Rows[0]["StatusId"].ToString();
            string _projectstatus= dt.Rows[0]["StatusId"].ToString();
            if(_projectstatus=="1")
            {
                Label15.Visible = true;
                txt_completiondate.Visible = true;
                Label16.Visible = true;
                file_upload.Visible = true;
                lblcertificate.Visible = true;
                hl_certificate.Visible = true;
            }
            else
            {
                Label15.Visible = false;
                txt_completiondate.Visible = false;
                Label16.Visible = false;
                file_upload.Visible = false;
                lblcertificate.Visible = false;
                hl_certificate.Visible = false;
            }


        }
    }


    private void BindFYear()
    {
        try
        {
            string sql = "";
        
            sql = @"select slno,FY,FYID from FYs   order by slno desc";

          
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_fyear.DataSource = dt;
            ddl_fyear.DataTextField = "FY";
            ddl_fyear.DataValueField = "FYID";
            ddl_fyear.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    private void BindWing()
    {
        if ((Session["Role"].ToString()) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        else
        {
            try
            {
                string sql = "";
                if (Convert.ToString((Session["Role"].ToString())) == "DIVADM")
                {
              
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


           
            }
            catch (Exception ex)
            {


            }
        }


    }

    private void BindCircle()
    {
        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        else
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

             

            }
            catch (Exception ex)
            {


            }
        }

    }

    private void BindDivision()
    {
        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        else
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

             

            }
            catch (Exception ex)
            {


            }
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
            string _head = ddl_head.SelectedValue.Trim();
            sql = @"select SubHeadID,SubHeadName,headId from SubHead  where headId=@headId order by SubHeadName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@headId", ddl_head.SelectedValue) });

            ddl_subhead.DataSource = dt;
            ddl_subhead.DataTextField = "SubHeadName";
            ddl_subhead.DataValueField = "SubHeadID";
            ddl_subhead.DataBind();
       


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
            string Noid = ddl_natureofwork.SelectedValue;

            sql = @"select NoWID,CMBDTypeName from NatOfWrk_Type  where NoWID=@NoWID order by CMBDTypeName";


            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@NoWID", ddl_natureofwork.SelectedValue.ToString()) });

            ddl_tyoe_of_work.DataSource = dt;
            ddl_tyoe_of_work.DataTextField = "CMBDTypeName";
            ddl_tyoe_of_work.DataValueField = "NoWID";
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
            sql = @"select CMBDID,WSTypeName,WSTypeID from NatOfWrk_SubType where CMBDID=@CMBDID order by WSTypeName";

            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CMBDID", ddl_tyoe_of_work.SelectedValue) });

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

        }

    }

    private void BindRoadName()
    {
        
        string sql = "";
       
        try
        {
           
            string _divid = Convert.ToString(Session["DivisionID"]);
            string _roadtype = ddl_roadtype.SelectedValue;

            sql = @"SELECT r.description, Name_of_the_Road,RoadId FROM RoadMaster rm inner join RoadType r on r.RoadTypeId = rm.RoadType 

where RoadType=@RoadType and  DivisionID =@DivisionID order by Name_of_the_Road";


            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@RoadType", _roadtype), new SqlParameter("@DivisionID", _divid) });
            ddl_roadname.DataSource = dt;
            ddl_roadname.DataValueField = "RoadId";
            ddl_roadname.DataTextField = "Name_of_the_Road";
            ddl_roadname.DataBind();
            ddl_roadname.Items.Insert(0, new ListItem("-Select-", "0"));
           
        }
        catch (Exception ex)
        { }
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
          
        }
        catch (Exception ex)
        { }
    }
    protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        string _projectstatus = ddl_status.SelectedValue;
        if (_projectstatus == "1")
        {
            Label15.Visible = true;
            txt_completiondate.Visible = true;
            Label16.Visible = true;
            file_upload.Visible = true;
        }
        else
        {
            Label15.Visible = false;
            txt_completiondate.Visible = false;
            Label16.Visible = false;
            file_upload.Visible = false;
            lblcertificate.Visible = false;
            hl_certificate.Visible = false;
        }
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        Update();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }



    protected void ddl_tyoe_of_work_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    }

    protected void ddl_head_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubHead();

    }

    protected void btn_Back_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }



    protected void ddl_roadname_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRoadName();
    }

    void Update()
    {
        try
        {
            string _fuIdproof = "";
             if (ddl_status.SelectedValue == "1")
            {

                //if (file_upload.FileName == "")
                //{
                //    Utility.showMessage(this, "Select File Upload");

                //    return;
                //}

                if (txt_completiondate.Text == "")
                {

                    Utility.showMessage(this, "Select Completion Date");

                    return;
                }

            }
            if (file_upload.HasFile)
            {
                _fuIdproof = GetUploadFile2(file_upload, "doct");
                Session["file"] = _fuIdproof;

            }

           

            if (ddl_conductor.SelectedValue == "0")
            {

                Utility.showMessage(this, "Select Contractor");
                return;
            }
            if (ddl_head.SelectedValue == "0")
            {

                Utility.showMessage(this, "Select Head");
                return;
            }
            if (ddl_subhead.SelectedValue == "0")
            {

                Utility.showMessage(this, "Select Subhead");
                return;
            }
           

            string ProjectNo = Convert.ToString(Request.QueryString["ProjectNo"]);
            SqlParameter _projectid = new SqlParameter("@Projectno", ProjectNo);

            SqlParameter _Fyr = new SqlParameter("@FYID", Convert.ToInt32(ddl_fyear.SelectedValue.Trim()));
            SqlParameter ProjectName = new SqlParameter("@ProjectName", txt_project.Text.Trim());
            SqlParameter HeadId = new SqlParameter("@HeadId", Convert.ToInt32(ddl_head.SelectedValue.Trim()));
            SqlParameter subhead = new SqlParameter("@SubHeadID", ddl_subhead.SelectedValue.Trim());
            SqlParameter SanctionRoadLength = new SqlParameter("@SanctionRoadLength", Convert.ToDouble(txt_lengthofroad.Text.Trim()));
            // SqlParameter AAamount = new SqlParameter("@AAamount", float.Parse(txt_admaprovalamount.Text.Trim()));
            SqlParameter AAamount = new SqlParameter("@AAamount", Convert.ToDouble(txt_admaprovalamount.Text.Trim()));
            SqlParameter AArefno = new SqlParameter("@AArefno", txt_adaproval.Text.Trim());
            SqlParameter AADate = new SqlParameter("@AADate", txt_admin_approval_date.Text.Trim());
            SqlParameter entrydate = new SqlParameter("@EntryDate", DateTime.Now);
            SqlParameter UpdateBy = new SqlParameter("@UpdateBy", User.Identity.Name);
            SqlParameter UpdateDate = new SqlParameter("@UpdateDate", DateTime.Now);
            SqlParameter NoWID = new SqlParameter("@NoWID", Convert.ToInt32(ddl_natureofwork.SelectedValue.Trim()));

           
            SqlParameter CMBDTypeID = new SqlParameter("@CMBDTypeID", Convert.ToInt32(ddl_tyoe_of_work.SelectedValue.Trim()));
            SqlParameter WSTypeID = new SqlParameter("@WSTypeID", Convert.ToInt32(ddl_sub_type.SelectedValue.Trim()));

            SqlParameter StartDate = new SqlParameter("@StartDate", txt_strtdate.Text.Trim());
            SqlParameter EndDate = new SqlParameter("@EndDate", txt_enddate.Text.Trim());
            SqlParameter ContractorInProject = new SqlParameter("@ContractorInProject", ddl_conductor.SelectedValue.Trim());
            SqlParameter AgreementAmount = new SqlParameter("@AgreementAmount", Convert.ToDouble(txt_aggrment_amount.Text.Trim()));
            SqlParameter WorkProgramSubmitted = new SqlParameter("@WorkProgramSubmitted", RadioButtonList1.SelectedValue.Trim());
            SqlParameter _status = new SqlParameter("@status", Convert.ToInt32(ddl_status.SelectedValue.Trim()));
            SqlParameter _Completiondate = new SqlParameter("@Completiondate", txt_completiondate.Text.Trim());
            SqlParameter _CompletionCertificate = new SqlParameter("@CompletionCertificate", Convert.ToString(Session["file"]));

           
            SqlParameter _ExtensionDate1 = new SqlParameter("@ExtensionDate1", txtExtensiondate1.Text.Trim());
            SqlParameter _ExtensionDate2 = new SqlParameter("@ExtensionDate2", txtExtensiondate2.Text.Trim());
            SqlParameter _ExtensionDate3 = new SqlParameter("@ExtensionDate3", txtExtensiondate3.Text.Trim());

            DataTable dt = cls.GetDataTableSp("sp_ProjectMasterUpdate", new SqlParameter[] { _projectid, _Fyr, ProjectName, HeadId, subhead , SanctionRoadLength, AAamount, AArefno, AADate,
            entrydate,UpdateBy,UpdateDate,NoWID,CMBDTypeID,WSTypeID,StartDate,EndDate,ContractorInProject,AgreementAmount,WorkProgramSubmitted,_status,_Completiondate,_CompletionCertificate,_ExtensionDate1,_ExtensionDate2,_ExtensionDate3});
            if (dt.Rows.Count > 0)
            {


                string msg = dt.Rows[0]["msg"].ToString();
                if (msg == "1")
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Project Master Update Successfully.');", true);

                    //Response.Redirect("ProjectEntryDetails.aspx");



                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Project Master Not Update Successfully.');", true);
                    //  Response.Redirect("RoadMasterData.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Project Master Not Update Successfully.');", true);
                // Response.Redirect("RoadMasterData.aspx");
            }


        }
        catch (Exception ex)
        {


        }
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

}