using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;
using System.IO;

public partial class RCDPMISNEW_ADM_RoadEntry : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            
            alltextboxvalue();
            BindReason();
            BindWings();

            DDLCircle.DataBind();
            DDLCircle.Items.Insert(0, new ListItem("--Select--", "0"));

            DDLDivision.DataBind();
            DDLDivision.Items.Insert(0, new ListItem("--Select--", "0"));

            DDLRoadType.DataBind();
            DDLRoadType.Items.Insert(0, new ListItem("--Select--", "0"));

            BindRoad();

            //BindHead();

            DDLSubRoad.DataBind();
            DDLSubRoad.Items.Insert(0, new ListItem("--Select--", "0"));

            BindWings2();

            DDLCircle2.DataBind();
            DDLCircle2.Items.Insert(0, new ListItem("--Select--", "0"));

            DDLDivision2.DataBind();
            DDLDivision2.Items.Insert(0, new ListItem("--Select--", "0"));

            DDLRoadType2.DataBind();
            DDLRoadType2.Items.Insert(0, new ListItem("--Select--", "0"));

            //BindRoad2();
        }

       
    }

    private void alltextboxvalue()
    {
        //for all textbox value inisiated  to 0
        txtLength.Text = "0";
        txtGood.Text = "0";
        txtBad.Text = "0";
        txtAverage.Text = "0";
        txtFair.Text = "0";

        txttwolane.Text = "0";
        txtmorethanwidthseven.Text = "0";
        txtIntermediate.Text = "0";
        txtSingleLane.Text = "0";
        txtnhno.Text = "0";
        txtstartpoint.Text = "0";
        txtendpoint.Text = "0";
        txtimportentplace.Text = "0";
        txtmissinglength.Text = "0";

    }

    private void BindReason()
    {

        try
        {
            string sql = "";
            sql = @" select id,ReasonId,Reason from Reason order by ReasonId asc";
            DataTable dt = cls.GetDataTable(sql);
            ddlreason.DataSource = dt;

            ddlreason.DataTextField = "Reason";
            ddlreason.DataValueField = "ReasonId";
            // ddlreason.Attributes.Remove("Wing");
            ddlreason.DataBind();

            ddlreason.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));




        }
        catch (Exception ex)
        {


        }

    }




    void BindWings()
    {
        string sql = @"SELECT  WingID, WingName, WingNameHND FROM Wing order by serial_no asc";
       // string sql = @"select WingName, WingID from wing WHERE WingID = @WingID  order by serial_no asc";
    DataTable dt = cls.GetDataTable(sql);
        DDLWings.DataSource = dt;
        DDLWings.DataTextField = "WingName";
        DDLWings.DataValueField = "WingID";
        DDLWings.DataBind();
        DDLWings.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    void BindWings2()
    {
        string sql = @"SELECT  WingID, WingName, WingNameHND FROM Wing order by serial_no asc";
        DataTable dt = cls.GetDataTable(sql);
        DDLWings2.DataSource = dt;
        DDLWings2.DataTextField = "WingName";
        DDLWings2.DataValueField = "WingID";
        DDLWings2.DataBind();
        DDLWings2.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    void BindCircle()
    {
        //string sql = @"SELECT CircleID, WingID, CircleName, CircleNameHND FROM Circles where WingID='" + DDLWings.SelectedValue.ToString().Trim() + "' order by CircleName";
        //DataTable dt = cls.GetDataTable(sql);
        //DDLCircle.DataSource = dt;
        //DDLCircle.DataTextField = "CircleName";
        //DDLCircle.DataValueField = "CircleID";
        //DDLCircle.DataBind();
        //DDLCircle.Items.Insert(0, new ListItem("--Select--", "0"));
        string wID = DDLWings.SelectedValue.ToString().Trim();
        string sql = @"SELECT CircleID, WingID, CircleName, CircleNameHND FROM Circles where WingID=@WingID order by CircleName";
        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", wID) });
        DDLCircle.DataSource = dt;
        DDLCircle.DataTextField = "CircleName";
        DDLCircle.DataValueField = "CircleID";
        DDLCircle.DataBind();
        DDLCircle.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    void BindCircle2()
    {
        //string sql = @"SELECT CircleID, WingID, CircleName, CircleNameHND FROM Circles where WingID='" + DDLWings2.SelectedValue.ToString().Trim() + "' order by CircleName";
        //DataTable dt = cls.GetDataTable(sql);
        //DDLCircle2.DataSource = dt;
        //DDLCircle2.DataTextField = "CircleName";
        //DDLCircle2.DataValueField = "CircleID";
        //DDLCircle2.DataBind();
        //DDLCircle2.Items.Insert(0, new ListItem("--Select--", "0"));
        string wID = DDLWings2.SelectedValue.ToString().Trim();
        string sql = @"SELECT CircleID, WingID, CircleName, CircleNameHND FROM Circles where WingID=@WingID order by CircleName";
        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", wID) });
        DDLCircle2.DataSource = dt;
        DDLCircle2.DataTextField = "CircleName";
        DDLCircle2.DataValueField = "CircleID";
        DDLCircle2.DataBind();
        DDLCircle2.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    void BindRoad()
    {
        string sql = string.Empty;
        if (DDLWings.SelectedValue == "3")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId=3 order by description";
        else if (DDLWings.SelectedValue == "1" || DDLWings.SelectedValue == "2")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId<>3 order by description";

        else if (DDLWings.SelectedValue.Trim() == "5")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId In (3,2) order by description";
        else if (DDLWings.SelectedValue.Trim() == "7")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType  order by description";

        DataTable dt = cls.GetDataTable(sql);
        DDLRoadType.DataSource = dt;
        DDLRoadType.DataTextField = "RoadType";
        DDLRoadType.DataValueField = "RoadTypeId";
        DDLRoadType.DataBind();
        DDLRoadType.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void DDLWings2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRoad2();
        btnExpToExcel.Visible = false;
        PanelGV.Visible = false;
        if (DDLWings2.SelectedValue == "0")
        {
            DDLCircle2.Items.Clear();
            DDLCircle2.SelectedValue = "0";

            DDLCircle2.Items.Insert(0, new ListItem("--Select--", "0"));

            DDLDivision2.Items.Clear();
            DDLDivision2.SelectedValue = "0";

            DDLDivision2.Items.Insert(0, new ListItem("--Select--", "0"));

            DDLRoadType2.Items.Clear();
            DDLRoadType2.Items.Insert(0, new ListItem("--Select--", "0"));

            Utility.showMessage(this, "Please Select Wings");
            PanelGV.Visible = false;


            return;

        }

        BindCircle2();

        PanelGV.Visible = false;
    }
    void BindDivision()
    {
        //string sql = @"SELECT      DivisionID, DivisionName, WingID, CircleID
        //                FROM         Divisions where CircleID='" + DDLCircle.SelectedValue.ToString().Trim() + "' order by DivisionName";
        //DataTable dt = cls.GetDataTable(sql);
        //DDLDivision.DataSource = dt;
        //DDLDivision.DataTextField = "DivisionName";
        //DDLDivision.DataValueField = "DivisionID";
        //DDLDivision.DataBind();
        //DDLDivision.Items.Insert(0, new ListItem("--Select--", "0"));
        string cid = DDLCircle.SelectedValue.ToString().Trim();
        string sql = @"SELECT      DivisionID, DivisionName, WingID, CircleID
                        FROM         Divisions where CircleID=@CircleID order by DivisionName";
        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CircleID", cid) });
        DDLDivision.DataSource = dt;
        DDLDivision.DataTextField = "DivisionName";
        DDLDivision.DataValueField = "DivisionID";
        DDLDivision.DataBind();
        DDLDivision.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    void BindDivision2()
    {
        //string sql = @"SELECT      DivisionID, DivisionName, WingID, CircleID
        //                FROM         Divisions where CircleID='" + DDLCircle2.SelectedValue.ToString().Trim() + "' order by DivisionName";
        //DataTable dt = cls.GetDataTable(sql);
        //DDLDivision2.DataSource = dt;
        //DDLDivision2.DataTextField = "DivisionName";
        //DDLDivision2.DataValueField = "DivisionID";
        //DDLDivision2.DataBind();
        //DDLDivision2.Items.Insert(0, new ListItem("--Select--", "0"));
        string cid = DDLCircle2.SelectedValue.ToString().Trim();
        string sql = @"SELECT      DivisionID, DivisionName, WingID, CircleID
                        FROM         Divisions where CircleID=@CircleID order by DivisionName";
        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CircleID", cid)});
        DDLDivision2.DataSource = dt;
        DDLDivision2.DataTextField = "DivisionName";
        DDLDivision2.DataValueField = "DivisionID";
        DDLDivision2.DataBind();
        DDLDivision2.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    void BindRoad2()
    {


        string sql = string.Empty;
        if (DDLWings2.SelectedValue.Trim() == "5" || DDLWings2.SelectedValue.Trim() == "4")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId In (3,2) order by description";

        else if (DDLWings2.SelectedValue == "3")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId=3 order by description";
        else if (DDLWings2.SelectedValue == "1" || DDLWings2.SelectedValue == "2")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId<>3 order by description";
        //else if (DDLWings2.SelectedValue == "7" || DDLWings2.SelectedValue == "7")
        //    sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType  order by description";



        DataTable dt = cls.GetDataTable(sql);
        DDLRoadType2.DataSource = dt;
        DDLRoadType2.DataTextField = "RoadType";
        DDLRoadType2.DataValueField = "RoadTypeId";
        DDLRoadType2.DataBind();
        DDLRoadType2.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void DDLCircle2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btnExpToExcel.Visible = false;
        PanelGV.Visible = false;
        if (DDLCircle2.SelectedValue == "0")
        {
            DDLDivision2.Items.Clear();
            DDLDivision2.SelectedValue = "0";



            DDLDivision2.Items.Insert(0, new ListItem("--Select--", "0"));
            Utility.showMessage(this, "Please Select Circle");
            PanelGV.Visible = false;
            return;
        }
        else
            BindDivision2();
    }

    protected void DDLDivision2_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnExpToExcel.Visible = false;
        PanelGV.Visible = false;
        if (DDLDivision2.SelectedValue == "0")
        {
            Utility.showMessage(this, "Please Select Division");
            PanelGV.Visible = false;


        }
        // BindRoad2();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void DDLRoadType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnExpToExcel.Visible = false;

        PanelGV.Visible = false;
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        //BindRoad2();
    }
    private int Max()
    {
        string sql = @"select MAX(RoadId) as MaxRoadNo from RoadMaster";
        DataTable dt = cls.GetDataTable(sql);
        string maxno = dt.Rows[0]["MaxRoadNo"].ToString();
        int Max2RoadID = Convert.ToInt32(maxno) + 1;
        return Max2RoadID;
    }
    protected void DDLWings_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblRoadID.Text = "";
        lblRoadName.Text = "";
        if (DDLWings.SelectedValue != "0")
        {
            BindCircle();
        }
        else
        {
            DDLCircle.Items.Clear();
            DDLCircle.SelectedValue = "0";

            DDLCircle.Items.Insert(0, new ListItem("--Select--", "0"));


            DDLDivision.Items.Clear();
            DDLDivision.SelectedValue = "0";

            DDLDivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        BindRoad();
    }

    protected void DDLCircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblRoadID.Text = "";
        lblRoadName.Text = "";
        if (DDLCircle.SelectedValue != "0")
        {
            BindDivision();
        }

        else
        {
            DDLDivision.Items.Clear();
            DDLDivision.SelectedValue = "0";

            DDLDivision.Items.Insert(0, new ListItem("--Select--", "0"));


        }
    }

    //protected void DDLDivision_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //lblRoadID.Text = "";
    //   // lblRoadName.Text = "";

    //    //PanelGV.Visible = true;
    //}

    protected void DDLRoadType_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindSubRoad();
        if (DDLRoadType.SelectedValue == "3")
        {
            spanSubRoad.Visible = true;

            Panel1.Visible = false;
            Panel3.Visible = true;
        }
        else
        {
            spanSubRoad.Visible = true;
            Panel1.Visible = true;
            Panel3.Visible = false;
        }

        if ((DDLRoadType.SelectedValue == "1") || (DDLRoadType.SelectedValue == "2"))
        {
            Panel1.Visible = true;
            Panel3.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int MaxRoadID = Max();


        //if (DDLHead.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Head !"); return;
        //}
        if (DDLWings.SelectedValue == "0")
        {

            Utility.showMessage(this, "Plz. Select Wings !"); return;
        }

        if (DDLCircle.SelectedValue == "0")
        {
            Utility.showMessage(this, "Plz. Select Circle !"); return;
        }

        if (DDLDivision.SelectedValue == "0")
        {
            Utility.showMessage(this, "Plz. Select Division !"); return;
        }

        if (DDLRoadType.SelectedValue == "0")
        {
            Utility.showMessage(this, "Plz. Select Road Type !"); return;
        }
        if (txtRoadName.Text == "")
        {
            Utility.showMessage(this, "Plz. Enter Road Name !"); return;
        }

        //if(radioyesno.SelectedValue=="1")
        //{
        //    if (txtroadconvremarks.Text == "")
        //    {
        //        Utility.showMessage(this, "Plz. Input converted Remarks !"); return;
        //    }
        //}
        //else
        //{

        //}
        //for check the edit and delete status 

        SqlParameter _ActionEdit = null;
        SqlParameter _ActionDelete = null;
        string wid = DDLWings.SelectedValue;
        string cid = DDLCircle.SelectedValue;
        string did = DDLDivision.SelectedValue;
        string query = @"select ActionEdit,ActionDelete,WingID,CircleID,DivisionID from RoadMaster where WingID=@WingID and CircleID=@CircleID and DivisionID=@DivisionID ";
        DataTable dt = cls.GetDataTable(query, new SqlParameter[] { new SqlParameter("@WingID", wid), new SqlParameter("@CircleID", cid), new SqlParameter("@DivisionID", did) });
        if (dt.Rows.Count > 0)
        {
            string _edit = dt.Rows[0]["ActionEdit"].ToString();
            string _del = dt.Rows[0]["ActionDelete"].ToString();
            if (_edit == "Y" && _del == "Y")
            {

                _ActionEdit = new SqlParameter("@ActionEdit", "Y");
                _ActionDelete = new SqlParameter("@ActionDelete", "Y");
            }
            else if (_edit == "N" && _del == "N")
            {
                _ActionEdit = new SqlParameter("@ActionEdit", "N");
                _ActionDelete = new SqlParameter("@ActionDelete", "N");
            }
            else if (_edit == "N" && _del == "Y")
            {
                _ActionEdit = new SqlParameter("@ActionEdit", "N");
                _ActionDelete = new SqlParameter("@ActionDelete", "Y");
            }
            else if (_edit == "Y" && _del == "N")
            {
                _ActionEdit = new SqlParameter("@ActionEdit", "Y");
                _ActionDelete = new SqlParameter("@ActionDelete", "N");
            }
            else
            {
                _ActionEdit = new SqlParameter("@ActionEdit", "");
                _ActionDelete = new SqlParameter("@ActionDelete", "");
            }

        }
        




        string sql = @"insert into RoadMaster(Name_of_the_Road, RoadType, DivisionID, WingID, CircleID, New_Total_Length_km, Good, Fair, Average, Bad, SingleLane, Intermediate, twolane, morethanwidthseven,
                         nhno, startpoint, endpoint, importentplace, missinglength, Remarks,SubRoadTypeId,IsDelete,Reason,OtherRemarks,Discriptionofissu,EntryBy,NewTotalLengthkmUpdate,ActionEdit,ActionDelete) 

                        values(@Name_of_the_Road, @RoadType, @DivisionID, @WingID, @CircleID, @New_Total_Length_km, @Good, @Fair, @Average, @Bad, @SingleLane, @Intermediate, @twolane, @morethanwidthseven,
                        @nhno, @startpoint, @endpoint, @importentplace, @missinglength, @Remarks,@SubRoadTypeId,@IsDelete,@Reason,@OtherRemarks,@Discriptionofissu,@EntryBy,@NewTotalLengthkmUpdate,@ActionEdit,@ActionDelete)";


        SqlParameter _Name_of_the_Road = new SqlParameter("@Name_of_the_Road", string.IsNullOrEmpty(txtRoadName.Text) ? DBNull.Value : (object)txtRoadName.Text.Trim());
        SqlParameter _RoadType = new SqlParameter("@RoadType", DDLRoadType.SelectedValue.ToString().Trim());
        SqlParameter _DivisionID = new SqlParameter("@DivisionID", DDLDivision.SelectedValue.ToString().Trim());
        SqlParameter _WingID = new SqlParameter("@WingID", DDLWings.SelectedValue.ToString().Trim());
        SqlParameter _CircleID = new SqlParameter("@CircleID", DDLCircle.SelectedValue.ToString().Trim());
        SqlParameter _New_Total_Length_km = new SqlParameter("@New_Total_Length_km", string.IsNullOrEmpty(txtLength.Text) ? DBNull.Value : (object)txtLength.Text.Trim());

        //SqlParameter _Head = new SqlParameter("@Head", DDLHead.SelectedValue.ToString().Trim());

        SqlParameter _Good = new SqlParameter("@Good", string.IsNullOrEmpty(txtGood.Text) ? DBNull.Value : (object)txtGood.Text.Trim());

        SqlParameter _Fair = new SqlParameter("@Fair", string.IsNullOrEmpty(txtFair.Text) ? DBNull.Value : (object)txtFair.Text.Trim());

        SqlParameter _Average = new SqlParameter("@Average", string.IsNullOrEmpty(txtAverage.Text) ? DBNull.Value : (object)txtAverage.Text.Trim());
        SqlParameter _Bad = new SqlParameter("@Bad", string.IsNullOrEmpty(txtBad.Text) ? DBNull.Value : (object)txtBad.Text.Trim());
        SqlParameter _SingleLane = new SqlParameter("@SingleLane", string.IsNullOrEmpty(txtSingleLane.Text) ? DBNull.Value : (object)txtSingleLane.Text.Trim());

        SqlParameter _Intermediate = new SqlParameter("@Intermediate", string.IsNullOrEmpty(txtIntermediate.Text) ? DBNull.Value : (object)txtIntermediate.Text.Trim());

        SqlParameter _twolane = new SqlParameter("@twolane", string.IsNullOrEmpty(txttwolane.Text) ? DBNull.Value : (object)txttwolane.Text.Trim());

        SqlParameter _morethanwidthseven = new SqlParameter("@morethanwidthseven", string.IsNullOrEmpty(txtmorethanwidthseven.Text) ? DBNull.Value : (object)txtmorethanwidthseven.Text.Trim());

        SqlParameter _nhno = new SqlParameter("@nhno", string.IsNullOrEmpty(txtnhno.Text) ? DBNull.Value : (object)txtnhno.Text.Trim());

        SqlParameter _startpoint = new SqlParameter("@startpoint", string.IsNullOrEmpty(txtstartpoint.Text) ? DBNull.Value : (object)txtstartpoint.Text.Trim());

        SqlParameter _endpoint = new SqlParameter("@endpoint", string.IsNullOrEmpty(txtendpoint.Text) ? DBNull.Value : (object)txtendpoint.Text.Trim());

        SqlParameter _importentplace = new SqlParameter("@importentplace", string.IsNullOrEmpty(txtimportentplace.Text) ? DBNull.Value : (object)txtimportentplace.Text.Trim());

        SqlParameter _missinglength = new SqlParameter("@missinglength", string.IsNullOrEmpty(txtmissinglength.Text) ? DBNull.Value : (object)txtmissinglength.Text.Trim());

        SqlParameter _Remarks = new SqlParameter("@Remarks", string.IsNullOrEmpty(txtRemarks.Text) ? DBNull.Value : (object)txtRemarks.Text.Trim());

        SqlParameter _SubRoadTypeId = new SqlParameter("@SubRoadTypeId", DDLSubRoad.SelectedValue.ToString().Trim()); 
        SqlParameter _IsDelete = new SqlParameter("@IsDelete", 'Y');
        SqlParameter remarks = new SqlParameter("@Reason", ddlreason.SelectedValue);
        SqlParameter otherremarks = new SqlParameter("@OtherRemarks", txtotherremarks.Text.Trim());
        SqlParameter discriptionofissu = new SqlParameter("@Discriptionofissu", txtdescription.Text.Trim());

        //  SqlParameter roadconvifany = new SqlParameter("@RoadConversion_IFAny", radioyesno.SelectedItem.Text.Trim());
        // SqlParameter rcdconverremarks = new SqlParameter("@RoadConversionRemarks", txtroadconvremarks.Text.Trim());
        string entry = Convert.ToString(Session["UserID"]);
        if (entry == "")
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        SqlParameter entryby = new SqlParameter("@EntryBy", Session["UserID"].ToString());
        SqlParameter _initiallength = new SqlParameter("@NewTotalLengthkmUpdate", txtLength.Text.Trim());

        decimal number = Convert.ToDecimal(txtGood.Text) + Convert.ToDecimal(txtFair.Text) + Convert.ToDecimal(txtAverage.Text) + Convert.ToDecimal(txtBad.Text);

        if (txtLength.Text != number.ToString())
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Equal Both Condition of the Road And Total Length (in Km) ');", true);
        }

        else
        {
            if (cls.ExecuteSql(sql, new SqlParameter[] {
                _Name_of_the_Road, _RoadType, _DivisionID, _WingID, _CircleID, _New_Total_Length_km, _Good, _Fair, _Average, _Bad, _SingleLane, _Intermediate, _twolane, _morethanwidthseven,
                                                        _nhno,_startpoint,_endpoint,_importentplace,_missinglength,_Remarks,_SubRoadTypeId,_IsDelete,remarks,otherremarks,discriptionofissu,entryby,_initiallength,_ActionEdit,_ActionDelete}) > 0)
            {
                Utility.showMessage(this, "Record Saved Successfully !");

                Panel3.Visible = false;
                Panel1.Visible = false;
                PanelGV.Visible = false;
                string RoadName = txtRoadName.Text.Trim();
                string RoadID = DDLRoadType.SelectedValue.ToString().Trim();
                //Response.Redirect("RoadMasterData.aspx");
                clear();

                //BindGVRoadStatistics();
                lblRoadName.Text = "Road " + RoadName + " " + MaxRoadID;
                // lblRoadID.Text = RoadID +" Saved Successfully !";
                return;
            }
        }




       
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Panel3.Visible = false;
        //btnReset.Visible = true;
        //// DDLRoadType.Enabled = false;
        //btnUpdate.Visible = false;
        //btnSave.Visible = true;
        //DDLWings.Enabled = false;
        //DDLCircle.Enabled = false;
        //DDLDivision.Enabled = false;

        ////if (DDLHead.SelectedValue == "0")
        ////{
        ////    Utility.showMessage(this, "Plz. Select Head !"); return;
        ////}
        //if (DDLWings.SelectedValue == "0")
        //{

        //    Utility.showMessage(this, "Plz. Select Wings !"); return;
        //}

        //if (DDLCircle.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Circle !"); return;
        //}

        //if (DDLDivision.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Division !"); return;
        //}

        //if (DDLRoadType.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Road Type !"); return;
        //}

        //string sql = @"Update RoadMaster set RoadName=@RoadName, RoadTypeId=@RoadTypeId, Length=@Length, Good=@Good, Fair=@Fair, Average=@Average, Bad=@Bad, SingleLane=@SingleLane, Intermediate=@Intermediate, twolane=@twolane, 
        //                morethanwidthseven=@morethanwidthseven, nhno=@nhno, startpoint=@startpoint, endpoint=@endpoint, importentplace=@importentplace, missinglength=@missinglength, Remarks=@Remarks,SubRoadTypeId=@SubRoadTypeId 
        //                where RoadId='" + ViewState["RoadID"].ToString().Trim() + "'";


        //SqlParameter _RoadName = new SqlParameter("@RoadName", string.IsNullOrEmpty(txtRoadName.Text) ? DBNull.Value : (object)txtRoadName.Text.Trim());

        //SqlParameter _RoadTypeId = new SqlParameter("@RoadTypeId", DDLRoadType.SelectedValue.ToString().Trim());
        ////SqlParameter _DivisionID = new SqlParameter("@DivisionID", DDLDivision.SelectedValue.ToString().Trim());
        ////SqlParameter _WingID = new SqlParameter("@WingID", DDLWings.SelectedValue.ToString().Trim());
        ////SqlParameter _CircleID = new SqlParameter("@CircleID", DDLCircle.SelectedValue.ToString().Trim());


        //SqlParameter _Length = new SqlParameter("@Length", string.IsNullOrEmpty(txtLength.Text) ? DBNull.Value : (object)txtLength.Text.Trim());

        ////SqlParameter _Head = new SqlParameter("@Head", DDLHead.SelectedValue.ToString().Trim());

        //SqlParameter _Good = new SqlParameter("@Good", string.IsNullOrEmpty(txtGood.Text) ? DBNull.Value : (object)txtGood.Text.Trim());

        //SqlParameter _Fair = new SqlParameter("@Fair", string.IsNullOrEmpty(txtFair.Text) ? DBNull.Value : (object)txtFair.Text.Trim());

        //SqlParameter _Average = new SqlParameter("@Average", string.IsNullOrEmpty(txtAverage.Text) ? DBNull.Value : (object)txtAverage.Text.Trim());


        //SqlParameter _Bad = new SqlParameter("@Bad", string.IsNullOrEmpty(txtBad.Text) ? DBNull.Value : (object)txtBad.Text.Trim());

        //SqlParameter _SingleLane = new SqlParameter("@SingleLane", string.IsNullOrEmpty(txtSingleLane.Text) ? DBNull.Value : (object)txtSingleLane.Text.Trim());

        //SqlParameter _Intermediate = new SqlParameter("@Intermediate", string.IsNullOrEmpty(txtIntermediate.Text) ? DBNull.Value : (object)txtIntermediate.Text.Trim());

        //SqlParameter _twolane = new SqlParameter("@twolane", string.IsNullOrEmpty(txttwolane.Text) ? DBNull.Value : (object)txttwolane.Text.Trim());

        //SqlParameter _morethanwidthseven = new SqlParameter("@morethanwidthseven", string.IsNullOrEmpty(txtmorethanwidthseven.Text) ? DBNull.Value : (object)txtmorethanwidthseven.Text.Trim());

        //SqlParameter _nhno = new SqlParameter("@nhno", string.IsNullOrEmpty(txtnhno.Text) ? DBNull.Value : (object)txtnhno.Text.Trim());

        //SqlParameter _startpoint = new SqlParameter("@startpoint", string.IsNullOrEmpty(txtstartpoint.Text) ? DBNull.Value : (object)txtstartpoint.Text.Trim());

        //SqlParameter _endpoint = new SqlParameter("@endpoint", string.IsNullOrEmpty(txtendpoint.Text) ? DBNull.Value : (object)txtendpoint.Text.Trim());

        //SqlParameter _importentplace = new SqlParameter("@importentplace", string.IsNullOrEmpty(txtimportentplace.Text) ? DBNull.Value : (object)txtimportentplace.Text.Trim());

        //SqlParameter _missinglength = new SqlParameter("@missinglength", string.IsNullOrEmpty(txtmissinglength.Text) ? DBNull.Value : (object)txtmissinglength.Text.Trim());

        //SqlParameter _Remarks = new SqlParameter("@Remarks", string.IsNullOrEmpty(txtRemarks.Text) ? DBNull.Value : (object)txtRemarks.Text.Trim());

        //SqlParameter _SubRoadTypeId = new SqlParameter("@SubRoadTypeId", DDLSubRoad.SelectedValue.ToString().Trim());

        //if (cls.ExecuteSql(sql, new SqlParameter[] { _RoadName, _RoadTypeId, _Length, _Good, _Fair, _Average, _Bad, _SingleLane, _Intermediate, _twolane, _morethanwidthseven, _nhno, _startpoint, _endpoint, _importentplace, _missinglength, _Remarks, _SubRoadTypeId }) > 0)
        //{
        //    Utility.showMessage(this, "Record Updated Successfully !");
        //    clear();

        //    DDLWings.Enabled = true;
        //    DDLCircle.Enabled = true;
        //    DDLDivision.Enabled = true;
        //    Panel3.Visible = false;
        //    Panel1.Visible = false;
        //    PanelDDL.Visible = true;
        //    btnSearch.Visible = true;

        //    // DDLRoadType.Enabled = true;
        //    // BindGVRoadStatistics();
        //    PanelGV.Visible = false;

        //    if (DDLWings.SelectedValue == "0")
        //    {
        //        DDLCircle.SelectedValue = "0";
        //        DDLCircle.Items.Clear();
        //        DDLCircle.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }
        //    if (DDLCircle.SelectedValue == "0")
        //    {
        //        DDLDivision.SelectedValue = "0";
        //        DDLDivision.Items.Clear();

        //        DDLDivision.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }

        //    return;
        //}
    }
    void clear()
    {
        txtRoadName.Text = "";
        DDLRoadType.SelectedValue = "0";
        DDLSubRoad.SelectedValue = "0";
        DDLDivision.SelectedValue = "0";
        DDLWings.SelectedValue = "0";
        DDLCircle.SelectedValue = "0";
        txtLength.Text = "";
        //DDLHead.SelectedValue = "0";
        txtGood.Text = "";
        txtFair.Text = "";
        txtAverage.Text = "";
        txtBad.Text = "";
        txtSingleLane.Text = "";
        txtIntermediate.Text = "";
        txttwolane.Text = "";
        txtmorethanwidthseven.Text = "";

        txtnhno.Text = "";
        txtstartpoint.Text = "";
        txtendpoint.Text = "";
        txtimportentplace.Text = "";
        txtmissinglength.Text = "";
        txtRemarks.Text = "";
        txtotherremarks.Text = "";
        txtdescription.Text = "";

    }

    void BindGVRoadStatistics()
    {

        //if (DDLWings.SelectedValue == "0")
        //{

        //    Utility.showMessage(this, "Plz. Select Wings !"); return;
        //}

        //if (DDLCircle.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Circle !"); return;
        //}

        //if (DDLDivision.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Division !"); return;
        //}



        //        string sql = @"SELECT     RoadMaster.RoadId, RoadMaster.RoadName, RoadMaster.Length, RoadMaster.Good, RoadMaster.Fair, RoadMaster.Average, RoadMaster.Bad, RoadMaster.SingleLane, RoadMaster.Intermediate, 
        //                      RoadMaster.twolane, RoadMaster.morethanwidthseven, Wing.WingID, Wing.WingName, Circles.CircleID, Circles.CircleName, Divisions.DivisionID, Divisions.DivisionName, RoadType.RoadTypeId, 
        //                      RoadType.description AS RoadType, Head.headId, Head.headName, RoadMaster.nhno, RoadMaster.startpoint, RoadMaster.endpoint, RoadMaster.importentplace, RoadMaster.missinglength, 
        //                      RoadMaster.Remarks, SubRoadType.description AS SubroadType, SubRoadType.SubRoadTypeId
        //                      FROM         RoadMaster LEFT OUTER JOIN
        //                      SubRoadType ON RoadMaster.RoadTypeId = SubRoadType.RoadTypeId AND RoadMaster.SubRoadTypeId = SubRoadType.SubRoadTypeId LEFT OUTER JOIN
        //                      Wing ON Wing.WingID = RoadMaster.WingID LEFT OUTER JOIN
        //                      Circles ON Circles.CircleID = RoadMaster.CircleID LEFT OUTER JOIN
        //                      Divisions ON Divisions.DivisionID = RoadMaster.DivisionID LEFT OUTER JOIN
        //                      RoadType ON RoadType.RoadTypeId = RoadMaster.RoadTypeId LEFT OUTER JOIN
        //                      Head ON Head.headId = RoadMaster.Head where Divisions.DivisionID='" + DDLDivision2.SelectedValue.ToString().Trim() + "' and RoadType.RoadTypeId='"+DDLRoadType2.SelectedValue.ToString().Trim()+"'";

        string wid = DDLWings2.SelectedValue.ToString().Trim();
        string cid = DDLCircle2.SelectedValue.ToString().Trim();
        string did = DDLDivision2.SelectedValue.ToString().Trim();
        string roadtype = DDLRoadType2.SelectedValue.ToString().Trim();
        string sql = @"SELECT     RoadMaster.RoadId, RoadMaster.RoadName, RoadMaster.Length, RoadMaster.Good, RoadMaster.Fair, RoadMaster.Average, RoadMaster.Bad, RoadMaster.SingleLane, RoadMaster.Intermediate, 
                      RoadMaster.twolane, RoadMaster.morethanwidthseven, Wing.WingID, Wing.WingName, Circles.CircleID, Circles.CircleName, Divisions.DivisionID, Divisions.DivisionName, RoadType.RoadTypeId, 
                      RoadType.description AS RoadType, Head.headId, Head.headName, RoadMaster.nhno, RoadMaster.startpoint, RoadMaster.endpoint, RoadMaster.importentplace, RoadMaster.missinglength, 
                      RoadMaster.Remarks, SubRoadType.description AS SubroadType, SubRoadType.SubRoadTypeId
                      FROM         RoadMaster LEFT OUTER JOIN
                      SubRoadType ON RoadMaster.RoadTypeId = SubRoadType.RoadTypeId AND RoadMaster.SubRoadTypeId = SubRoadType.SubRoadTypeId LEFT OUTER JOIN
                      Wing ON Wing.WingID = RoadMaster.WingID LEFT OUTER JOIN
                      Circles ON Circles.CircleID = RoadMaster.CircleID LEFT OUTER JOIN
                      Divisions ON Divisions.DivisionID = RoadMaster.DivisionID LEFT OUTER JOIN
                      RoadType ON RoadType.RoadTypeId = RoadMaster.RoadTypeId LEFT OUTER JOIN
                      Head ON Head.headId = RoadMaster.Head where Wing.WingID=@WingID and Circles.CircleID=@CircleID and Divisions.DivisionID=@DivisionID and RoadType.RoadTypeId=@RoadTypeId ORDER BY RoadName";

        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] {  new SqlParameter("@WingID", wid), new SqlParameter("@CircleID", cid), new SqlParameter("@DivisionID", did), new SqlParameter("@RoadTypeId", roadtype) });



        PanelGV.Visible = true;
        if (dt.Rows.Count > 0)
        {
            ViewState["RoadId"] = dt.Rows[0]["RoadId"].ToString().Trim();
            btnExpToExcel.Visible = true;
        }
        else
            btnExpToExcel.Visible = false;
        //else
        //{
        //    PanelGV.Visible = false;
        //}
        GVRoadStatistics.DataSource = dt;
        GVRoadStatistics.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //lblRoadID.Text = "";
        lblRoadName.Text = "";
        Response.Redirect("~/PMIS/ADM/RoadEntry.aspx");
    }
    void BindSubRoad()
    {
        string rtype = DDLRoadType.SelectedValue.ToString();
        string sql = @"SELECT RoadTypeId, SubRoadTypeId, description AS SubroadType FROM  SubRoadType where RoadTypeId=@RoadTypeId order by description";
        DataTable dt = cls.GetDataTable(sql,new SqlParameter[] { new SqlParameter("@RoadTypeId", rtype)});
        DDLSubRoad.DataSource = dt;
        DDLSubRoad.DataTextField = "SubroadType";
        DDLSubRoad.DataValueField = "SubRoadTypeId";
        DDLSubRoad.DataBind();
        DDLSubRoad.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btnExpToExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("ddMMyyhhmmss") + "RoadDetails.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);


        for (int i = 0; i < GVRoadStatistics.HeaderRow.Cells.Count; i++)
        {
            GVRoadStatistics.HeaderRow.Cells[i].Style.Add("border-style", "Solid");
            GVRoadStatistics.HeaderRow.Cells[i].Style.Add("border-color", "Black");
            GVRoadStatistics.HeaderRow.Cells[i].Style.Add("background-color", "lightblue");
            GVRoadStatistics.HeaderRow.Cells[i].Style.Add("Font-Bold", "True");
            GVRoadStatistics.HeaderRow.Cells[i].Style.Add("Fore-Color", "black");
        }
        //for (int i = 0; i < GV.FooterRow.Cells.Count; i++)
        //{
        //    GV.FooterRow.Cells[i].Style.Add("border-style", "Solid");
        //    GV.FooterRow.Cells[i].Style.Add("border-color", "Black");
        //    GV.FooterRow.Cells[i].Style.Add("background-color", "DarkSeaGreen");
        //    GV.FooterRow.Cells[i].Style.Add("Font-Bold", "True");
        //    GV.FooterRow.Cells[i].Style.Add("Fore-Color", "Black");
        //}
        int j = 1;
        //   This loop is used to apply stlye to cells based on particular row
        foreach (GridViewRow gvrow in GVRoadStatistics.Rows)
        {
            gvrow.BackColor = System.Drawing.Color.White;
            if (j <= GVRoadStatistics.Rows.Count)
            {
                for (int k = 0; k < gvrow.Cells.Count; k++)
                {
                    gvrow.Cells[k].Style.Add("border-style", "Solid");
                    gvrow.Cells[k].Style.Add("border-color", "Black");
                }
            }
            j++;
        }
        PanelGV.RenderControl(htw);
        string dd = sw.ToString();
        dd = dd.Replace("href=", "");
        Response.Write(dd);
        Response.End();
    }

    protected void GVRoadStatistics_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnExpToExcel.Visible = false;
        btnReset.Visible = true;
        if ((DDLRoadType2.SelectedValue == "1") || (DDLRoadType2.SelectedValue == "2"))
        {
            Panel1.Visible = true;
            Panel3.Visible = false;
            Panel2.Visible = true;
            PanelDDL.Visible = true;
        }
        if (DDLRoadType2.SelectedValue == "3")
        {
            spanSubRoad.Visible = true;

            Panel1.Visible = false;
            Panel3.Visible = true;
            PanelDDL.Visible = true;
            Panel2.Visible = true;
        }
        else
        {
            spanSubRoad.Visible = true;
            Panel1.Visible = true;
            Panel3.Visible = false;
        }
        PanelDDLSearch.Visible = false;
        //Panel1.Visible = true;
        //Panel3.Visible = true;
        btnSave.Visible = false;
        btnUpdate.Visible = true;
        string RoadID = GVRoadStatistics.DataKeys[GVRoadStatistics.SelectedIndex].Values["RoadId"].ToString();
        ViewState["RoadID"] = RoadID;

        //        string sql = @"SELECT    RoadMaster.RoadId, RoadMaster.RoadName, RoadMaster.Length,  RoadMaster.Good, RoadMaster.Fair, RoadMaster.Average, 
        //                        RoadMaster.Bad, RoadMaster.SingleLane, RoadMaster.Intermediate, RoadMaster.twolane, RoadMaster.morethanwidthseven,
        //
        //                         Wing.WingID, Wing.WingName, Circles.CircleID, Circles.CircleName, Divisions.DivisionID
        //                        ,Divisions.DivisionName, RoadType.RoadTypeId, RoadType.description as RoadType, Head.headId, Head.headName
        //                        FROM         RoadMaster
        //
        //                        left outer join Wing on Wing.WingID=RoadMaster.WingID
        //
        //                        left outer join Circles on Circles.CircleID=RoadMaster.CircleID
        //
        //                        left outer join Divisions on Divisions.DivisionID=RoadMaster.DivisionID
        //
        //                        left outer join RoadType on RoadType.RoadTypeId=RoadMaster.RoadTypeId
        //
        //                        left outer join Head on Head.headId=RoadMaster.Head where RoadId='"+RoadID.ToString().Trim()+"'";



        string sql = @"SELECT     RoadMaster.RoadId, RoadMaster.RoadName, RoadMaster.Length, RoadMaster.Good, RoadMaster.Fair, RoadMaster.Average, RoadMaster.Bad, RoadMaster.SingleLane, RoadMaster.Intermediate, 
                      RoadMaster.twolane, RoadMaster.morethanwidthseven, Wing.WingID, Wing.WingName, Circles.CircleID, Circles.CircleName, Divisions.DivisionID, Divisions.DivisionName, RoadType.RoadTypeId, 
                      RoadType.description AS RoadType, Head.headId, Head.headName, RoadMaster.nhno, RoadMaster.startpoint, RoadMaster.endpoint, RoadMaster.importentplace, RoadMaster.missinglength, 
                      RoadMaster.Remarks, SubRoadType.description AS SubroadType, SubRoadType.SubRoadTypeId
FROM         RoadMaster LEFT OUTER JOIN
                      SubRoadType ON RoadMaster.RoadTypeId = SubRoadType.RoadTypeId AND RoadMaster.SubRoadTypeId = SubRoadType.SubRoadTypeId LEFT OUTER JOIN
                      Wing ON Wing.WingID = RoadMaster.WingID LEFT OUTER JOIN
                      Circles ON Circles.CircleID = RoadMaster.CircleID LEFT OUTER JOIN
                      Divisions ON Divisions.DivisionID = RoadMaster.DivisionID LEFT OUTER JOIN
                      RoadType ON RoadType.RoadTypeId = RoadMaster.RoadTypeId LEFT OUTER JOIN
                      Head ON Head.headId = RoadMaster.Head where RoadId='" + RoadID.ToString().Trim() + "'";

        DataTable dt = cls.GetDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            DDLWings.SelectedValue = dt.Rows[0]["WingID"].ToString().Trim();
            DDLWings.Enabled = false;

            BindCircle();
            DDLCircle.SelectedValue = dt.Rows[0]["CircleID"].ToString().Trim();
            DDLCircle.Enabled = false;

            BindDivision();
            DDLDivision.SelectedValue = dt.Rows[0]["DivisionID"].ToString().Trim();
            DDLDivision.Enabled = false;



            txtRoadName.Text = dt.Rows[0]["RoadName"].ToString().Trim();

            txtLength.Text = dt.Rows[0]["Length"].ToString().Trim();

            //BindHead();
            //DDLHead.SelectedValue = dt.Rows[0]["headId"].ToString().Trim();

            BindRoad();
            string value = dt.Rows[0]["RoadTypeID"].ToString().Trim();
            DDLRoadType.SelectedValue = value;
            //DDLRoadType.Enabled = false;

            BindSubRoad();
            string value2 = dt.Rows[0]["SubRoadTypeId"].ToString().Trim();
            DDLSubRoad.SelectedValue = value2;


            txtGood.Text = dt.Rows[0]["Good"].ToString().Trim();
            txtFair.Text = dt.Rows[0]["Fair"].ToString().Trim();
            txtAverage.Text = dt.Rows[0]["Average"].ToString().Trim();
            txtBad.Text = dt.Rows[0]["Bad"].ToString().Trim();
            txtSingleLane.Text = dt.Rows[0]["SingleLane"].ToString().Trim();
            txtIntermediate.Text = dt.Rows[0]["Intermediate"].ToString().Trim();
            txttwolane.Text = dt.Rows[0]["twolane"].ToString().Trim();
            txtmorethanwidthseven.Text = dt.Rows[0]["morethanwidthseven"].ToString().Trim();

            txtnhno.Text = dt.Rows[0]["nhno"].ToString().Trim();
            txtstartpoint.Text = dt.Rows[0]["startpoint"].ToString().Trim();
            txtendpoint.Text = dt.Rows[0]["endpoint"].ToString().Trim();
            txtimportentplace.Text = dt.Rows[0]["importentplace"].ToString().Trim();
            txtmissinglength.Text = dt.Rows[0]["missinglength"].ToString().Trim();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString().Trim();


        }
    }

    protected void GVRoadStatistics_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVRoadStatistics.PageIndex = e.NewPageIndex;
        BindGVRoadStatistics();
    }

    protected void GVRoadStatistics_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HG = (GridView)sender;
            GridViewRow gvr = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell hc = new TableCell();
            hc.Text = "";
            hc.BorderStyle = BorderStyle.Solid;
            hc.BackColor = System.Drawing.Color.Silver;

            hc.ColumnSpan = 5;
            gvr.Cells.Add(hc);

            hc = new TableCell();
            hc.Text = "Condition of the Road (in Km)";
            hc.BorderStyle = BorderStyle.Solid;
            hc.HorizontalAlign = HorizontalAlign.Center;
            hc.VerticalAlign = VerticalAlign.Bottom;
            hc.BackColor = System.Drawing.Color.Silver;
            hc.Font.Bold = true;
            hc.ColumnSpan = 4;
            gvr.Cells.Add(hc);

            hc = new TableCell();
            hc.Text = "Lane Width (m)";

            hc.HorizontalAlign = HorizontalAlign.Center;
            hc.VerticalAlign = VerticalAlign.Bottom;
            hc.BorderStyle = BorderStyle.Solid;
            hc.BackColor = System.Drawing.Color.Silver;
            hc.Font.Bold = true;
            hc.ColumnSpan = 4;
            gvr.Cells.Add(hc);



            hc = new TableCell();
            hc.Text = "";

            hc.HorizontalAlign = HorizontalAlign.Center;
            hc.VerticalAlign = VerticalAlign.Bottom;
            hc.BorderStyle = BorderStyle.Solid;
            hc.BackColor = System.Drawing.Color.Silver;
            hc.Font.Bold = true;
            hc.ColumnSpan = 6;
            gvr.Cells.Add(hc);

            GVRoadStatistics.Controls[0].Controls.AddAt(0, gvr);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //btnExpToExcel.Visible = false;
        //// lblRoadID.Text = "";
        //lblRoadName.Text = "";
        ////BindGVRoadStatistics();
        //PanelDDL.Visible = false;
        //PanelDDLSearch.Visible = true;
        //Panel1.Visible = false;
        //Panel2.Visible = false;
        //Panel3.Visible = false;
        ////PanelGV.Visible = true;
        //btnSave.Visible = false;
        //btnReset.Visible = false;
        //btnSearch.Visible = false;
        //DDLWings2.SelectedValue = "0";

        //DDLCircle2.Items.Clear();
        //DDLCircle2.SelectedValue = "0";
        //DDLCircle2.Items.Insert(0, new ListItem("--Select--", "0"));

        //DDLDivision2.Items.Clear();
        //DDLDivision2.SelectedValue = "0";
        //DDLDivision2.Items.Insert(0, new ListItem("--Select--", "0"));
        //btnBack.Visible = true;
        //DDLRoadType2.SelectedValue = "0";
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        //if (DDLWings2.SelectedValue == "0")
        //{

        //    Utility.showMessage(this, "Plz. Select Wings !"); return;
        //}

        //if (DDLCircle2.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Circle !"); return;
        //}

        //if (DDLDivision2.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Division !"); return;
        //}
        //if (DDLRoadType2.SelectedValue == "0")
        //{
        //    Utility.showMessage(this, "Plz. Select Road Type !"); return;
        //}
        //BindGVRoadStatistics();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnExpToExcel.Visible = false;
        btnBack.Visible = false;
        PanelDDLSearch.Visible = false;
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        PanelDDL.Visible = true;
        PanelGV.Visible = false;
        btnSave.Visible = true;
        btnReset.Visible = true;
       // btnSearch.Visible = true;
    }

    protected void ddlreason_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (ddlreason.SelectedItem.Text == "Other")
            {
            //txtotherremarks.Enabled = true;
            lblotherremarks.Visible = true;
            txtotherremarks.Visible = true;
            }
            else
        {
            // txtotherremarks.Enabled = false;
            lblotherremarks.Visible = false;
            txtotherremarks.Visible = false;
        }
        
    }

    //protected void rdbtndebar_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if(radioyesno.SelectedValue=="1")
    //    {
    //        txtroadconvremarks.Visible = true;
    //        lblrcconversionremarks.Visible = true;
    //    }
    //    else
    //    {
    //        txtroadconvremarks.Visible = false;
    //        lblrcconversionremarks.Visible = false;

    //    }
    //}

    protected void txtRoadName_TextChanged(object sender, EventArgs e)
   {
       
        string _roadname = txtRoadName.Text.Trim();   
        string sql = @"select Name_of_the_Road from RoadMaster where Name_of_the_Road=@Name_of_the_Road";

        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@Name_of_the_Road", _roadname) });     
        if (dt.Rows.Count > 0)
        {                     
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road Name Already Exist...');", true);
                return;
        }
        else
        {

        }
    }


    

   
}