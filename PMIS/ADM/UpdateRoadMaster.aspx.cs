using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class RCDPMISNEW_ADM_UpdateRoadMaster1 : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        string roadid = Convert.ToString(Session["RoadID"]);
        string roles = Convert.ToString(Session["Role"]);
        // if (Session["Role"].ToString() == "DIVADM")
        if ((Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindWings();
            BindRoad();
            BindSubRoad(); ;
            BindReason();

            //  BindRoad2();
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                display(2);
            }
            else
            {
                display(1);
            }
            //pnl_fileupload.Visible = false;
        }

        if (!IsPostBack)
        {
            if ((DDLWings.SelectedItem.Text == "North Wing") || (DDLWings.SelectedItem.Text == "South Wing") || (DDLWings.SelectedItem.Text == "Simanchal Wing"))
            {
                // Panel1.Visible = true;
                //  Panel4.Visible = true;
                // Panel5.Visible = true;
                Panel3.Visible = false;
            }
            else
            {
                Panel3.Visible = true;
                // Panel1.Visible = false;
                // Panel4.Visible = false;
                // Panel5.Visible = false;
            }
        }



    }


    void BindWings()
    {
        string sql = @"SELECT  WingID, WingName, WingNameHND FROM Wing order by serial_no asc";
        DataTable dt = cls.GetDataTable(sql);
        DDLWings.DataSource = dt;
        DDLWings.DataTextField = "WingName";
        DDLWings.DataValueField = "WingID";
        DDLWings.SelectedValue = null;
        DDLWings.DataBind();
        // DDLWings.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    void BindRoad()
    {


        SqlParameter wingId = new SqlParameter("@WingId", DDLWings.SelectedValue.Trim());

        DataTable dt = cls.GetDataTableSp("SP_Get_BindRoad", new SqlParameter[] { wingId });
        // DataTable dt = cls.GetDataTable(sql);
        DDLRoadType.DataSource = dt;
        DDLRoadType.DataTextField = "RoadType";
        DDLRoadType.DataValueField = "RoadTypeId";
        DDLRoadType.DataBind();
        // DDLRoadType.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    void BindSubRoad()
    {
        try
        {
            string _roadtype = DDLRoadType.SelectedValue.ToString().Trim();


            string sql = @"SELECT RoadTypeId, SubRoadTypeId, description AS SubroadType FROM  SubRoadType where RoadTypeId=@RoadTypeId order by description";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@RoadTypeId", _roadtype) });
            DDLSubRoad.DataSource = dt;
            DDLSubRoad.DataTextField = "SubroadType";
            DDLSubRoad.DataValueField = "SubRoadTypeId";
            DDLSubRoad.DataBind();
            // DDLSubRoad.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        catch { }
    }


    private void BindReason()
    {
        try
        {
            //string sql = "";         

            //sql = @" select Id,Reason from Reason order by id asc";
            //DataTable dt = cls.GetDataTable(sql);
            DataTable dt = cls.GetDataTableSp("sp_get_reason", new SqlParameter[] { });
            ddlreason.DataSource = dt;
            ddlreason.DataTextField = "Reason";
            ddlreason.DataValueField = "Id";
            // ddlreason.Attributes.Remove("Wing");
            ddlreason.DataBind();
            ddlreason.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

        }
        catch (Exception ex)
        {
        }

    }

    private void divisionshowhide()
    {
        txtRoadName.Enabled = false;
        DDLRoadType.Enabled = false;
        DDLSubRoad.Enabled = false;
        txtLength.Enabled = false;
        radioyesno.Enabled = false;
        radioroadconversion.Enabled = false;
        file_upload.Enabled = false;
        lblviewfile.Enabled = false;
        txt_converted_road_length.Enabled = false;
        txtroadconvremarks.Enabled = false;

        txtGood.Enabled = true;
        txtBad.Enabled = true;
        txtAverage.Enabled = true;
        txtFair.Enabled = true;

        txtSingleLane.Enabled = false;
        txtcsinglelane.Enabled = false;
        txtmorethanwidthseven.Enabled = false;
        txtcmorethan7.Enabled = false;
        txttwolane.Enabled = false;
        txtc2lane.Enabled = false;
        txtIntermediate.Enabled = false;
        txtcinterlane.Enabled = false;
        btn_new_road_concersion.Enabled = false;



    }
    private void adminshowhide()
    {
        txtRoadName.Enabled = true;
        DDLRoadType.Enabled = true;
        DDLSubRoad.Enabled = true;
        txtLength.Enabled = true;
        radioyesno.Enabled = true;
        radioroadconversion.Enabled = true;
        file_upload.Enabled = true;
        lblviewfile.Enabled = true;
        txt_converted_road_length.Enabled = true;
        txtroadconvremarks.Enabled = true;

        txtGood.Enabled = true;
        txtBad.Enabled = true;
        txtAverage.Enabled = true;
        txtFair.Enabled = true;
        txtSingleLane.Enabled = true;
        txtcsinglelane.Enabled = true;
        txtmorethanwidthseven.Enabled = true;
        txtcmorethan7.Enabled = true;
        txttwolane.Enabled = true;
        txtc2lane.Enabled = true;
        txtIntermediate.Enabled = true;
        txtcinterlane.Enabled = true;
        btn_new_road_concersion.Enabled = true;

    }


    private void display(int queryType = 0)
    {

        string roadid = Convert.ToString(Session["RoadID"]);

        //for division and admin login update section disabled and enabled show data
        if (Convert.ToString(Session["Role"]) == "DIVADM")
        {
            divisionshowhide();
        }
        else
        {
            adminshowhide();
        }

        if (roadid == "")
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        else
        {

            SqlParameter _QueryType = new SqlParameter("@queryType", queryType);
            SqlParameter _Rid = new SqlParameter("@RoadId", roadid);
            // string cID = Convert.ToString(Session["CircleID"]);
            // DataTable dt = cls.GetDataTable( @"select * from RoadMaster where slno='" + roadid + "'");
            DataTable dt = cls.GetDataTableSp("Sp_Get_UpdateRoadMaster", new SqlParameter[] { _QueryType, _Rid });



            if (dt.Rows.Count > 0)
            {
                //txtwing.Text = dt.Rows[0]["Wing"].ToString();
                DDLWings.SelectedValue = dt.Rows[0]["WingID"].ToString();
                BindWings();
                txtcircle.Text = dt.Rows[0]["Circle"].ToString();
                txtDivision.Text = dt.Rows[0]["Division"].ToString();
                // txt_RoadType.Text = dt.Rows[0]["description"].ToString();
                DDLRoadType.SelectedValue = dt.Rows[0]["RoadType"].ToString();
                BindRoad();
                //txt_subroadtype.Text = dt.Rows[0]["description"].ToString();
                DDLSubRoad.SelectedValue = dt.Rows[0]["SubRoadTypeId"].ToString();
                BindSubRoad();
                txtstartpoint.Text = dt.Rows[0]["startpoint"].ToString();
                txtendpoint.Text = dt.Rows[0]["endpoint"].ToString();
                txtnhno.Text = dt.Rows[0]["nhno"].ToString();
                txtimportentplace.Text = dt.Rows[0]["importentplace"].ToString();
                txtmissinglength.Text = dt.Rows[0]["missinglength"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();


                txtSingleLane.Text = dt.Rows[0]["SingleLane"].ToString();
                if (txtSingleLane.Text == "")
                {
                    txtSingleLane.Text = "0";
                }
                Session["SingleLane"] = txtSingleLane.Text;
                txtIntermediate.Text = dt.Rows[0]["Intermediate"].ToString();
                if (txtIntermediate.Text == "")
                {
                    txtIntermediate.Text = "0";
                }
                Session["Intermediate"] = txtIntermediate.Text;
                txtmorethanwidthseven.Text = dt.Rows[0]["morethanwidthseven"].ToString();
                if (txtmorethanwidthseven.Text == "")
                {
                    txtmorethanwidthseven.Text = "0";
                }
                Session["morethanwidthseven"] = txtmorethanwidthseven.Text;
                txttwolane.Text = dt.Rows[0]["twolane"].ToString();
                if (txttwolane.Text == "")
                {
                    txttwolane.Text = "0";
                }
                Session["twolane"] = txttwolane.Text;


                txtGood.Text = dt.Rows[0]["Good"].ToString();
                Session["txtGood"] = txtGood.Text;

                txtFair.Text = dt.Rows[0]["Fair"].ToString();
                Session["Fair"] = txtFair.Text;
                txtAverage.Text = dt.Rows[0]["Average"].ToString();
                Session["Average"] = txtAverage.Text;
                if (txtAverage.Text == "NULL" || txtAverage.Text == "") { }

                txtBad.Text = dt.Rows[0]["Bad"].ToString();
                Session["Bad"] = txtBad.Text;

                txtRoadName.Text = dt.Rows[0]["Name_of_the_Road"].ToString();

                txtLength.Text = dt.Rows[0]["New_Total_Length_km"].ToString();
                ViewState["txtLength"] = dt.Rows[0]["New_Total_Length_km"].ToString();
                lbl_TotalLength.Text = dt.Rows[0]["NewTotalLengthkmUpdate"].ToString();
                Session["New_Total_Length_km"] = txtLength.Text;

                if (DDLWings.SelectedItem.Text == "NH Wing" || DDLWings.SelectedItem.Text == "BSRDC")
                {
                    Panel3.Visible = true;
                }
                else
                {
                    Panel3.Visible = false;
                }
                // string reason = dt.Rows[0]["reasonId"].ToString();

                ddlreason.SelectedIndex = Int32.Parse(dt.Rows[0]["reasonId"].ToString());
                // BindReason();
                if (ddlreason.SelectedItem.Text == "Other")
                {
                    lblotherremarks.Visible = true;
                    txtotherremarks.Visible = true;
                    txtotherremarks.Text = dt.Rows[0]["OtherRemarks"].ToString();
                }
                else if (ddlreason.SelectedItem.Text == "")
                {
                    ddlreason.SelectedItem.Text = "--Select--";
                    // ddlreason.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }


                //txtotherremarks.Text = dt.Rows[0]["OtherRemarks"].ToString();
                txtdescription.Text = dt.Rows[0]["Discriptionofissu"].ToString();
                string a = dt.Rows[0]["RoadConversion_IFAny"].ToString();

                if (a == "1")
                {
                    lbl_initial.Visible = true;
                    lbl_TotalLength.Visible = true;
                    // radioyesno.Text = dt.Rows[0]["RoadConversion_IFAny"].ToString();
                    //radioyesno.SelectedIndex = 1;
                    radioyesno.SelectedValue = "1";
                    //  txtroadconvremarks.Visible = true;
                    txtLength.Enabled = false;
                    lblconversiontype.Visible = true;
                    txtroadconvremarks.Text = dt.Rows[0]["RoadConversionRemarks"].ToString();
                    radioroadconversion.Visible = true;
                    BindGrid();
                    //btn_new_road_concersion.Visible = false;
                    ////  pnl_roadconversation.Visible = true;
                    //// pnlconverted_condition_ofroad.Visible = true;
                    //// pnl_converted_LanWidth.Visible = true;
                    radioroadconversion.SelectedValue = dt.Rows[0]["ConversionType"].ToString();

                    string ctype = dt.Rows[0]["ConversionType"].ToString();
                    ViewState["ConvertedId"] = dt.Rows[0]["ConversionType"].ToString();
                    if (ctype == "1")
                    {
                        var item = (radioroadconversion.Items.FindByValue("2"));
                        if (item != null)
                        {
                            item.Enabled = false;
                        }

                        var item1 = (radioyesno.Items.FindByValue("2"));
                        if (item1 != null)
                        {
                            item1.Enabled = false;
                        }
                        pnlbtn.Visible = true;
                        pnlconvertedroad.Visible = true;
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        //  Panel3.Visible = false;
                        Panel4.Visible = false;
                        Panel5.Visible = false;
                        pnl6.Visible = false;

                        pnl_roadconversation.Visible = false;
                        pnl_fileupload.Visible = false;
                        pnl_converted_LanWidth.Visible = false;
                        pnlconverted_condition_ofroad.Visible = false;
                        pnldocument.Visible = false;

                        if (ctype.ToString() == "1")
                        {
                            pnlconvertedroad.Visible = true;
                            pnldocument.Visible = false;
                        }
                        else if (ctype.ToString() == "2")
                        {

                            pnlconvertedroad.Visible = false;
                            pnldocument.Visible = false;
                        }
                        else
                        {

                            pnlconvertedroad.Visible = false;
                            pnldocument.Visible = false;
                        }
                    }
                    else if (ctype == "2")
                    {

                        var item = (radioroadconversion.Items.FindByValue("1"));
                        if (item != null)
                        {
                            item.Enabled = false;
                        }

                        var item1 = (radioyesno.Items.FindByValue("2"));
                        if (item1 != null)
                        {
                            item1.Enabled = false;
                        }
                        pnlbtn.Visible = false;
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        // Panel3.Visible = true;
                        Panel4.Visible = false;
                        Panel5.Visible = false;
                        pnl6.Visible = false;
                        pnl_roadconversation.Visible = false;
                        pnl_fileupload.Visible = false;
                        pnl_converted_LanWidth.Visible = false;
                        pnlconverted_condition_ofroad.Visible = false;



                        pnlconverted_condition_ofroad.Visible = false;
                        pnl_converted_LanWidth.Visible = false;

                        if (ctype.ToString() == "1")
                        {
                            pnlconvertedroad.Visible = false;
                            pnldocument.Visible = false;
                        }
                        else if (ctype.ToString() == "2")
                        {

                            pnlconvertedroad.Visible = true;
                            pnldocument.Visible = false;
                        }
                        else
                        {

                            pnlconvertedroad.Visible = false;
                            pnldocument.Visible = false;
                        }
                    }
                    else
                    {
                        pnlbtn.Visible = false;
                        Panel1.Visible = true;
                        Panel2.Visible = true;
                        // Panel3.Visible = true;
                        Panel4.Visible = true;
                        Panel5.Visible = true;
                        pnl6.Visible = true;
                        pnl_roadconversation.Visible = true;
                        pnl_fileupload.Visible = true;
                        pnl_converted_LanWidth.Visible = true;
                        pnlconverted_condition_ofroad.Visible = true;



                        pnlconverted_condition_ofroad.Visible = true;
                        pnl_converted_LanWidth.Visible = true;

                        pnlconvertedroad.Visible = false;
                        pnldocument.Visible = false;
                    }
                    txtGood.Enabled = false;
                    txtBad.Enabled = false;
                    txtFair.Enabled = false;
                    txtAverage.Enabled = false;


                    txtSingleLane.Enabled = false;
                    txttwolane.Enabled = false;
                    txtmorethanwidthseven.Enabled = false;
                    txtIntermediate.Enabled = false;


                    txt_converted_road_length.Text = dt.Rows[0]["ConvertedRoadLength"].ToString();
                    txtcgood.Text = dt.Rows[0]["ConvertedGood"].ToString();
                    string cgood = dt.Rows[0]["ConvertedGood"].ToString();
                    if (cgood == "")
                    {
                        txtcgood.Text = "0";
                    }

                    txtcbad.Text = dt.Rows[0]["ConvertedBad"].ToString();
                    txtcfair.Text = dt.Rows[0]["ConvertedFair"].ToString();
                    txtcavg.Text = dt.Rows[0]["ConvertedAverage"].ToString();
                    txtcsinglelane.Text = dt.Rows[0]["ConvertedSingle"].ToString();
                    txtcmorethan7.Text = dt.Rows[0]["ConvertedMoreThanSeven"].ToString();
                    txtcinterlane.Text = dt.Rows[0]["ConvertedIntermediate"].ToString();
                    txtc2lane.Text = dt.Rows[0]["ConvertedTwoLane"].ToString();
                    //string filedata= dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
                    //     if(filedata=="" || filedata=="NULL" || filedata== null)
                    //     {
                    //         lblfileuploadpath.Text = "Noo Any Approval Letter Uploaded!!";
                    //     }
                    //     else
                    //     {
                    //         lblfileuploadpath.Text = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
                    //     }
                    ViewState["RoadConversionApprovalLetter"] = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
                    lblviewfile.Visible = true;
                    lblfileuploadpath.Text = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
                    if (lblfileuploadpath.Text == "")
                    {
                        //    file_upload.Enabled = true;
                        lblfileuploadpath.Text = "";

                    }
                    else
                    {
                        // file_upload.Enabled = false;
                        lblfileuploadpath.Text = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
                    }

                }
                else if (a == "No")
                {
                    lbl_initial.Visible = false;
                    Panel1.Visible = true;
                    Panel4.Visible = true;
                    Panel5.Visible = true;
                    radioyesno.SelectedValue = "2";
                    pnl_roadconversation.Visible = false;
                    pnl_fileupload.Visible = false;
                    pnlconverted_condition_ofroad.Visible = false;
                    pnl_converted_LanWidth.Visible = false;
                    txtLength.Enabled = true;
                    lblconversiontype.Visible = false;
                    lblviewfile.Visible = false;
                    // txtroadconvremarks.Visible = false;
                    //btn_new_road_concersion.Visible = true;
                    lbl_TotalLength.Visible = false;

                }
                else
                {
                    radioyesno.SelectedValue = "2";
                    Panel1.Visible = true;
                    Panel4.Visible = true;
                    Panel5.Visible = true;
                    // txtroadconvremarks.Visible = false;
                }
            }

        }
    }





    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        try
        {


            if (txtroadconvremarks.Visible == true)
            {
                if (txtroadconvremarks.Text.Length == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Input Road Remarks');", true);
                    return;
                }

            }
            if (radioyesno.SelectedValue == "1")
            {
                if (radioroadconversion.SelectedValue == "")
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Select Conversion Type');", true);
                    return;
                }
            }


            //double good = 0;
            //double fair = 0;
            //double bad = 0;
            //double avrage = 0;
            double good = 0;
            double fair = 0;
            double bad = 0;
            double avrage = 0;
            if (txtGood.Text == "" || txtGood.Text == null)
            {
                txtGood.Text = "0";
            }
            if (txtFair.Text == "" || txtFair.Text == null)
            {
                txtFair.Text = "0";
            }
            if (txtBad.Text == "" || txtBad.Text == null)
            {
                txtBad.Text = "0";
            }
            if (txtAverage.Text == "" || txtAverage.Text == null)
            {
                txtAverage.Text = "0";
            }

            //good = Convert.ToDouble(txtGood.Text);
            //fair = Convert.ToDouble(txtFair.Text);
            //bad = Convert.ToDouble(txtBad.Text);           
            //avrage = Convert.ToDouble(txtAverage.Text);

            good = Convert.ToDouble(txtGood.Text);
            fair = Convert.ToDouble(txtFair.Text);
            bad = Convert.ToDouble(txtBad.Text);
            avrage = Convert.ToDouble(txtAverage.Text);
            double temp = good + fair + bad + avrage;
            //double temp = good + fair + bad + avrage;

            //if (Convert.ToDouble(txtGood.Text) + Convert.ToDouble(txtFair.Text) + Convert.ToDouble(txtAverage.Text) + Convert.ToDouble(txtBad.Text) != Convert.ToDouble(txtLength.Text))

            string t = String.Format("{0:0.000}", temp);


            if (Convert.ToDouble(t) != Convert.ToDouble(txtLength.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road condition Good,Fair,Bad,Average should be equal to Total length of Road');", true);
                return;

            }
            //if (temp != Convert.ToDouble(txtLength.Text))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road condition Good,Fair,Bad,Average should be equal to Total length of Road');", true);
            //    return;

            //}
            // roadconvertedvalidation();


            if (radioyesno.SelectedItem.Text == "Yes")
            {
                double cgood = 0;
                double cfair = 0;
                double cbad = 0;
                double cavrage = 0;
                if (txtcgood.Text == "" || txtcgood.Text == null)
                {
                    txtcgood.Text = "0";
                }
                if (txtcfair.Text == "" || txtcfair.Text == null)
                {
                    txtcfair.Text = "0";
                }
                if (txtcbad.Text == "" || txtcbad.Text == null)
                {
                    txtcbad.Text = "0";
                }
                if (txtcavg.Text == "" || txtcavg.Text == null)
                {
                    txtcavg.Text = "0";
                }

                cgood = Convert.ToDouble(txtcgood.Text);
                cfair = Convert.ToDouble(txtcfair.Text);
                cbad = Convert.ToDouble(txtcbad.Text);
                cavrage = Convert.ToDouble(txtcavg.Text);


                //if (Convert.ToDouble(txtGood.Text) + Convert.ToDouble(txtFair.Text) + Convert.ToDouble(txtAverage.Text) + Convert.ToDouble(txtBad.Text) != Convert.ToDouble(txtLength.Text))
                if (cgood + cfair + cbad + cavrage != Convert.ToDouble(txt_converted_road_length.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road Converted condition Good,Fair,Bad,Average should be equal to Converted Road Length.');", true);
                    return;

                }



            }
            else
            {



                string _fuIdproof = "";
                string roadid = Session["RoadID"].ToString();
                SqlParameter Name_of_the_Road = new SqlParameter("@Name_of_the_Road", txtRoadName.Text);
                SqlParameter New_Total_Length_km = new SqlParameter("@New_Total_Length_km", txtLength.Text);
                SqlParameter Remarks = new SqlParameter("@Remarks", txtRemarks.Text);
                SqlParameter nhno = new SqlParameter("@nhno", txtnhno.Text);
                SqlParameter startpoint = new SqlParameter("@startpoint", txtstartpoint.Text);
                SqlParameter endpoint = new SqlParameter("@endpoint", txtendpoint.Text);
                SqlParameter missinglength = new SqlParameter("@missinglength", txtmissinglength.Text);
                SqlParameter importentplace = new SqlParameter("@importentplace", txtimportentplace.Text);
                SqlParameter SingleLane = new SqlParameter("@SingleLane", txtSingleLane.Text);
                SqlParameter Intermediate = new SqlParameter("@Intermediate", txtIntermediate.Text);
                SqlParameter twolane = new SqlParameter("@twolane", txttwolane.Text);
                SqlParameter morethanwidthseven = new SqlParameter("@morethanwidthseven", txtmorethanwidthseven.Text);
                SqlParameter Good = new SqlParameter("@Good", txtGood.Text);
                SqlParameter Fair = new SqlParameter("@Fair", txtFair.Text);
                SqlParameter Average = new SqlParameter("@Average", txtAverage.Text);
                SqlParameter Bad = new SqlParameter("@Bad", txtBad.Text);
                SqlParameter RoadId = new SqlParameter("@RoadId", roadid);
                string entry = Convert.ToString(Session["UserID"]);
                if (entry == "")
                {
                    Response.Redirect("~/PMIS/Login.aspx");
                }
                SqlParameter EntryBy = new SqlParameter("@EntryBy", Convert.ToString(Session["UserID"]));

                //SqlParameter reason = new SqlParameter("@Reason", ddlreason.SelectedItem.Text.Trim());
                SqlParameter reason = new SqlParameter("@Reason", ddlreason.SelectedValue);
                SqlParameter otherremarks = new SqlParameter("@OtherRemarks", txtotherremarks.Text.Trim());
                SqlParameter discriptionofissu = new SqlParameter("@Discriptionofissu", txtdescription.Text.Trim());
                SqlParameter roadconversionyesno = new SqlParameter("@RoadConversion_IFAny", radioyesno.SelectedValue);

                SqlParameter roadconversionremarks = new SqlParameter("@RoadConversionRemarks", txtroadconvremarks.Text.Trim());
                ///////////////////////////////////////////////////////
                SqlParameter conversiontype = new SqlParameter("@ConversionType", radioroadconversion.SelectedValue);
                SqlParameter convertedroadlength = new SqlParameter("@ConvertedRoadLength", txt_converted_road_length.Text.Trim());
                SqlParameter convertedgood = new SqlParameter("@ConvertedGood", txtcgood.Text.Trim());
                SqlParameter convertedbad = new SqlParameter("@ConvertedBad", txtcbad.Text.Trim());
                SqlParameter convertedfair = new SqlParameter("@ConvertedFair", txtcfair.Text.Trim());
                SqlParameter convertedavg = new SqlParameter("@ConvertedAverage", txtcavg.Text.Trim());
                SqlParameter convertedsinglelane = new SqlParameter("@ConvertedSingle", txtcsinglelane.Text.Trim());
                SqlParameter convertedinterlane = new SqlParameter("@ConvertedIntermediate", txtcinterlane.Text.Trim());
                SqlParameter converted2lane = new SqlParameter("@ConvertedTwoLane", txtc2lane.Text.Trim());
                SqlParameter convertedmorethan7 = new SqlParameter("@ConvertedMoreThanSeven", txtcmorethan7.Text.Trim());


                if (file_upload.HasFile)
                {
                    _fuIdproof = GetUploadFile2(file_upload, "RoadConversionApprovalLetter");
                }
                else
                {
                    _fuIdproof = Convert.ToString(ViewState["RoadConversionApprovalLetter"]);
                }

                SqlParameter approvalletter = new SqlParameter("@RoadConversionApprovalLetter", _fuIdproof.Trim());





                DataTable dt = cls.GetDataTableSp("sp_RoadMasterUpdate_New", new SqlParameter[] { Name_of_the_Road, New_Total_Length_km, nhno,startpoint,endpoint,missinglength,importentplace,  Remarks,
                   SingleLane,Intermediate,twolane,morethanwidthseven,Good,Fair,Average,Bad, RoadId,EntryBy,reason,otherremarks,discriptionofissu,roadconversionyesno,roadconversionremarks,
            conversiontype,convertedroadlength,convertedgood,convertedbad,convertedfair,convertedavg,convertedsinglelane,convertedinterlane,converted2lane,convertedmorethan7,approvalletter});
                if (dt.Rows.Count > 0)
                {


                    string msg = dt.Rows[0]["msg"].ToString();
                    if (msg == "1")
                    {

                        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road Master Update Successfully.');", true);

                        Response.Redirect("RoadMasterData.aspx");
                        //if (radioyesno.SelectedValue == "2")
                        //{
                        //    Response.Redirect("RoadMasterData.aspx");
                        //}
                        //else
                        //{
                        //    hideshowdata_from_conversiontype();
                        //}
                        //hideshowdata_from_conversiontype();

                        Session.Remove("txtGood");
                        Session["txtGood"] = null;
                        Session.Remove("Fair");
                        Session["Fair"] = null;
                        Session.Remove("Bad");
                        Session["Bad"] = null;
                        Session.Remove("Average");
                        Session["Average"] = null;
                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road Master Not Update Successfully.');", true);
                        //  Response.Redirect("RoadMasterData.aspx");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road Master Not Update Successfully.');", true);
                    // Response.Redirect("RoadMasterData.aspx");
                }

            }
        }
        catch (Exception ex)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Road Master Not Update Successfully.');", true);
        }
    }

    //protected void btnReset_Click(object sender, EventArgs e)
    //{
    //    //Response.Redirect("UpdateRoadMaster.aspx");
    //}






    protected void ddlreason_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlreason.SelectedItem.Text == "Other")
        {
            lblotherremarks.Visible = true;
            txtotherremarks.Visible = true;

        }
        else
        {
            lblotherremarks.Visible = false;
            txtotherremarks.Visible = false;
        }
    }

    protected void radioyesno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radioyesno.SelectedValue == "1")
        {



            lblconversiontype.Visible = true;
            radioroadconversion.Visible = true;
            txtLength.Enabled = false;


            txtGood.Enabled = false;
            txtBad.Enabled = false;
            txtFair.Enabled = false;
            txtAverage.Enabled = false;

            txtSingleLane.Enabled = false;
            txttwolane.Enabled = false;
            txtmorethanwidthseven.Enabled = false;
            txtIntermediate.Enabled = false;
            radioroadconversion.Visible = true;
            lblconversiontype.Visible = true;

            lbl_initial.Visible = true;
            lbl_TotalLength.Visible = true;
            lbl_TotalLength.Text = txtLength.Text;


            //txt_converted_road_length.Text = txtLength.Text;
            //txtLength.Text = "0";

            if (txtcgood.Text == "")
            {
                txtcgood.Text = "0";
            }
            if (txtcbad.Text == "")
            {
                txtcbad.Text = "0";
            }
            if (txtcfair.Text == "")
            {
                txtcfair.Text = "0";
            }
            if (txtcavg.Text == "")
            {
                txtcavg.Text = "0";
            }


            if (txtcinterlane.Text == "")
            {
                txtcinterlane.Text = "0";
            }
            if (txtcmorethan7.Text == "")
            {
                txtcmorethan7.Text = "0";
            }
            if (txtc2lane.Text == "")
            {
                txtc2lane.Text = "0";
            }
            if (txtcsinglelane.Text == "")
            {
                txtcsinglelane.Text = "0";
            }



        }
        else if (radioyesno.SelectedValue == "2")
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = true;
            pnl6.Visible = true;
            pnl_roadconversation.Visible = false;
            pnl_fileupload.Visible = false;
            pnlconverted_condition_ofroad.Visible = false;
            pnl_converted_LanWidth.Visible = false;

            pnlbtn.Visible = false;
            radioroadconversion.SelectedIndex = -1;
            radioroadconversion.Visible = false;
            lblconversiontype.Visible = false;

            txtGood.Enabled = true;
            txtBad.Enabled = true;
            txtFair.Enabled = true;
            txtAverage.Enabled = true;

            txtSingleLane.Enabled = true;
            txttwolane.Enabled = true;
            txtmorethanwidthseven.Enabled = true;
            txtIntermediate.Enabled = true;

            lbl_initial.Visible = false;
            lbl_TotalLength.Visible = false;

            if (txtcgood.Text == "")
            {
                txtcgood.Text = "0";
            }
            if (txtcbad.Text == "")
            {
                txtcbad.Text = "0";
            }
            if (txtcfair.Text == "")
            {
                txtcfair.Text = "0";
            }
            if (txtcavg.Text == "")
            {
                txtcavg.Text = "0";
            }


            if (txtcinterlane.Text == "")
            {
                txtcinterlane.Text = "0";
            }
            if (txtcmorethan7.Text == "")
            {
                txtcmorethan7.Text = "0";
            }
            if (txtc2lane.Text == "")
            {
                txtc2lane.Text = "0";
            }
            if (txtcsinglelane.Text == "")
            {
                txtcsinglelane.Text = "0";
            }

        }
        else
        {

            radioroadconversion.SelectedIndex = -1;



            lblconversiontype.Visible = false;
            radioroadconversion.Visible = false;
            pnl_roadconversation.Visible = false;
            pnl_fileupload.Visible = false;
            pnlconverted_condition_ofroad.Visible = false;
            pnl_converted_LanWidth.Visible = false;
            txtroadconvremarks.Text = "";
            txtLength.Enabled = true;

            txtGood.Enabled = true;
            txtBad.Enabled = true;
            txtFair.Enabled = true;
            txtAverage.Enabled = true;

            txtSingleLane.Enabled = true;
            txttwolane.Enabled = true;
            txtmorethanwidthseven.Enabled = true;
            txtIntermediate.Enabled = true;

            if (txtcgood.Text == "")
            {
                txtcgood.Text = "0";
            }
            if (txtcbad.Text == "")
            {
                txtcbad.Text = "0";
            }
            if (txtcfair.Text == "")
            {
                txtcfair.Text = "0";
            }
            if (txtcavg.Text == "")
            {
                txtcavg.Text = "0";
            }


            if (txtcinterlane.Text == "")
            {
                txtcinterlane.Text = "0";
            }
            if (txtcmorethan7.Text == "")
            {
                txtcmorethan7.Text = "0";
            }
            if (txtc2lane.Text == "")
            {
                txtc2lane.Text = "0";
            }
            if (txtcsinglelane.Text == "")
            {
                txtcsinglelane.Text = "0";
            }



        }
    }

    protected void radioroadconversion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        hideshowdata_from_conversiontype();
    }



    protected void txt_converted_road_length_TextChanged1(object sender, EventArgs e)
    {
        //Session["New_Total_Length_km"];

        if ((txt_converted_road_length.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Length can not blank.');", true);
            txt_converted_road_length.Text = "";
            txt_converted_road_length.Focus();
            return;
        }
        else if (float.Parse(txt_converted_road_length.Text) <= float.Parse(Convert.ToString(Session["New_Total_Length_km"])))
        {
            float totlength = float.Parse(Convert.ToString(Session["New_Total_Length_km"])) - float.Parse(txt_converted_road_length.Text);
            txtLength.Text = totlength.ToString("0.00");// use this for got value . after 2 digit
            txtroadconvremarks.Focus();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Length Cant be Greater Than Total Length.');", true);
            txt_converted_road_length.Text = "";
            txt_converted_road_length.Focus();
            return;
        }


    }



    protected string GetUploadFile2(FileUpload ControlName, string FileName)
    {



        // File Upload Function.......

        string RegId = Session["RoadID"].ToString();
        //DataTable dt = cls.GetDataTable(@"select RoadId,RoadConversionApprovalLetter from RoadMaster
        //          where RoadId='" + RegId + "' ");
        //string file1 = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
        //string imageunique = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
        string imageunique = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
        // string imageunique = file1;


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

                uploadDirectory = "~/PMIS/Approval_latter/";


                if (!Directory.Exists(Server.MapPath(uploadDirectory)))
                {
                    Directory.CreateDirectory(Server.MapPath(uploadDirectory));
                }
                //fileName = FileName + imageunique.Trim() + RegId.Trim() + extension;
                fileName = ControlName.FileName;



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

                // rpath = uploadDirectory + fileName;
                rpath = fileName;
            }
        }

        return rpath;
    }



    protected void txtcavg_TextChanged(object sender, EventArgs e)
    {
        if ((txtcavg.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Average Can not be Null.');", true);
            return;
        }

        if (float.Parse(txtcavg.Text) < float.Parse(Convert.ToString(Session["Average"])))
        {

            float newAvg = float.Parse(Convert.ToString(Session["Average"])) - float.Parse(txtcavg.Text);
            txtAverage.Text = newAvg.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcavg.Text) > float.Parse(Convert.ToString(Session["Average"])))
        {
            txtAverage.Text = Convert.ToString(Session["Average"]);
            txtcavg.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Average Can not be Greater Than Average.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtcavg.Text) <= float.Parse(txtAverage.Text))
            {
                float newAvg = float.Parse(txtAverage.Text) - float.Parse(txtcavg.Text);
                txtAverage.Text = newAvg.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcavg.Text = "0";
                //  ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Converted Average Can't be Greater Than Average.');", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Average Can not be Greater Than Average.');", true);

                txtcavg.Focus();
                return;
            }
        }
        txtcbad.Focus();
    }

    protected void txtcgood_TextChanged(object sender, EventArgs e)
    {


        if ((txtcgood.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Good Can not be Null.');", true);
            return;
        }

        if (float.Parse(txtcgood.Text) < float.Parse(Convert.ToString(Session["txtGood"])))
        {

            float newGood = float.Parse(Convert.ToString(Session["txtGood"])) - float.Parse(txtcgood.Text);
            txtGood.Text = newGood.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcgood.Text) > float.Parse(Convert.ToString(Session["txtGood"])))
        {
            txtGood.Text = Convert.ToString(Session["txtGood"]);
            txtcgood.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert(' Converted Good Can not be Greater Than Good.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtcgood.Text) <= float.Parse(txtGood.Text))
            {
                float newGood = float.Parse(txtGood.Text) - float.Parse(txtcgood.Text);
                txtGood.Text = newGood.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcgood.Text = "0";
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert(' Converted Good Can not be Greater Than Good.');", true);
                // ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Converted Good Can't be Greater Than Good.');", true);
                //error.Visible = true;
                //error.Text = "Converted Good Can't be Greater Than Good.";
                txtcgood.Focus();
                return;
            }
        }
        txtcfair.Focus();

    }

    protected void txtcfair_TextChanged(object sender, EventArgs e)
    {
        if ((txtcfair.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Fair Can not be Null.');", true);
            return;
        }


        if (float.Parse(txtcfair.Text) < float.Parse(Convert.ToString(Session["Fair"])))
        {

            float newFair = float.Parse(Convert.ToString(Session["Fair"])) - float.Parse(txtcfair.Text);
            txtFair.Text = newFair.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcfair.Text) > float.Parse(Convert.ToString(Session["Fair"])))
        {
            txtFair.Text = Convert.ToString(Session["Fair"]);
            txtcfair.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Fair Can not be Greater Than Fair.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtcfair.Text) <= float.Parse(txtFair.Text))
            {
                float newFair = float.Parse(txtFair.Text) - float.Parse(txtcfair.Text);
                txtFair.Text = newFair.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcgood.Text = "0";
                // ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Converted Good Can't be Greater Than Good.');", true);    
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert(' Converted Fair Can not be Greater Than Fair.');", true);
                txtcgood.Focus();
                return;
            }
        }
        txtcavg.Focus();
    }

    protected void txtcbad_TextChanged(object sender, EventArgs e)
    {
        if ((txtcbad.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Bad Can not be Null.');", true);
            return;
        }

        if (float.Parse(txtcbad.Text) < float.Parse(Convert.ToString(Session["Bad"])))
        {

            float newBad = float.Parse(Convert.ToString(Session["Bad"])) - float.Parse(txtcbad.Text);
            txtBad.Text = newBad.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcbad.Text) > float.Parse(Convert.ToString(Session["Bad"])))
        {
            txtBad.Text = Convert.ToString(Session["Bad"]);
            txtcbad.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Bad Can not be Greater Than Bad.');", true);
            //MsgUtility.showMessage(Page, "Converted Bad Can't be Greater Than Bad.");
            return;
        }


        else
        {
            if (float.Parse(txtcbad.Text) <= float.Parse(txtBad.Text))
            {
                float newBad = float.Parse(txtBad.Text) - float.Parse(txtcbad.Text);
                txtBad.Text = newBad.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcbad.Text = "0";
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Bad Can not be Greater Than Bad.');", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Converted Bad Can't be Greater Than Bad.');", true);
                //MsgUtility.showMessage(Page,"Converted Bad Can't be Greater Than Bad.");
                txtcavg.Focus();
                return;
            }
        }
        txtcsinglelane.Focus();
    }

    protected void txtcsinglelane_TextChanged(object sender, EventArgs e)
    {

        if ((txtcsinglelane.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Single Lane  Can not be Null.');", true);
            return;
        }

        if (float.Parse(txtcsinglelane.Text) < float.Parse(Convert.ToString(Session["SingleLane"])))
        {

            float newSingle = float.Parse(Convert.ToString(Session["SingleLane"])) - float.Parse(txtcsinglelane.Text);
            txtSingleLane.Text = newSingle.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcsinglelane.Text) > float.Parse(Convert.ToString(Session["SingleLane"])))
        {
            txtSingleLane.Text = Convert.ToString(Session["SingleLane"]);
            txtcsinglelane.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Single Lane Can not be Greater Than Single Lane.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtcsinglelane.Text) <= float.Parse(txtSingleLane.Text))
            {
                float newSingle = float.Parse(txtSingleLane.Text) - float.Parse(txtcsinglelane.Text);
                txtSingleLane.Text = newSingle.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcsinglelane.Text = "0";
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Single Lane Can not be Greater Than Single Lane.');", true);
                // ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Converted Single Lane Can't be Greater Than Single Lane.');", true);
                txtcsinglelane.Focus();
                return;
            }
        }
        txtcinterlane.Focus();
    }

    protected void txtcinterlane_TextChanged(object sender, EventArgs e)
    {

        Session.Remove("SingleLane");
        Session["SingleLane"] = null;

        if ((txtcinterlane.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Intermediate Lane  Can not be Null.');", true);
            return;
        }


        if (float.Parse(txtcinterlane.Text) < float.Parse(Convert.ToString(Session["Intermediate"])))
        {

            float newinterlan = float.Parse(Convert.ToString(Session["Intermediate"])) - float.Parse(txtcinterlane.Text);
            txtIntermediate.Text = newinterlan.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcinterlane.Text) > float.Parse(Convert.ToString(Session["Intermediate"])))
        {
            txtIntermediate.Text = Convert.ToString(Session["Intermediate"]);
            txtcinterlane.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Intermediate Lane Can not be Greater Than Intermediate Lane.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtcinterlane.Text) <= float.Parse(txtIntermediate.Text))
            {
                float newinterlan = float.Parse(txtIntermediate.Text) - float.Parse(txtcinterlane.Text);
                txtIntermediate.Text = newinterlan.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcinterlane.Text = "0";
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Intermediate Can not be Greater Than Intermediate.');", true);
                // ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Converted Intermediate Can't be Greater Than Intermediate.');", true);
                txtcinterlane.Focus();
                return;
            }
        }
        txtc2lane.Focus();
    }

    protected void txtc2lane_TextChanged(object sender, EventArgs e)
    {

        Session.Remove("Intermediate");
        Session["Intermediate"] = null;
        if ((txtc2lane.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Two Lane  Can not be Null.');", true);
            return;
        }

        if (float.Parse(txtc2lane.Text) < float.Parse(Convert.ToString(Session["twolane"])))
        {

            float new2lane = float.Parse(Convert.ToString(Session["twolane"])) - float.Parse(txtc2lane.Text);
            txttwolane.Text = new2lane.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtc2lane.Text) > float.Parse(Convert.ToString(Session["twolane"])))
        {
            txttwolane.Text = Convert.ToString(Session["twolane"]);
            txtc2lane.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Two Lane Can not be Greater Than Two Lane.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtc2lane.Text) <= float.Parse(txttwolane.Text))
            {
                float new2lane = float.Parse(txttwolane.Text) - float.Parse(txtc2lane.Text);
                txttwolane.Text = new2lane.ToString();
                // error.Visible = false;
            }
            else
            {


                txtc2lane.Text = "0";
                //ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Converted Two Lane Can't be Greater Than Two Lane.');", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted Two Lane Can not be Greater Than Two Lane.');", true);

                txtc2lane.Focus();
                return;
            }
        }
        txtcmorethan7.Focus();

    }

    protected void txtcmorethan7_TextChanged(object sender, EventArgs e)
    {

        Session.Remove("twolane");
        Session["twolane"] = null;
        if ((txtcmorethan7.Text) == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted More than seven Can not be Null.');", true);
            return;
        }

        if (float.Parse(txtcmorethan7.Text) < float.Parse(Convert.ToString(Session["morethanwidthseven"])))
        {

            float newmore7 = float.Parse(Convert.ToString(Session["morethanwidthseven"])) - float.Parse(txtcmorethan7.Text);
            txtmorethanwidthseven.Text = newmore7.ToString();
            // error.Visible = false;

        }
        else if (float.Parse(txtcmorethan7.Text) > float.Parse(Convert.ToString(Session["morethanwidthseven"])))
        {
            txtmorethanwidthseven.Text = Convert.ToString(Session["morethanwidthseven"]);
            txtcmorethan7.Text = "0";
            ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted More than seven Can not be Greater Than More than seven.');", true);
            return;
        }


        else
        {
            if (float.Parse(txtcmorethan7.Text) <= float.Parse(txtmorethanwidthseven.Text))
            {
                float newmore7 = float.Parse(txtmorethanwidthseven.Text) - float.Parse(txtcmorethan7.Text);
                txtmorethanwidthseven.Text = newmore7.ToString();
                // error.Visible = false;
            }
            else
            {


                txtcmorethan7.Text = "0";
                //  ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Converted More than seven Can't be Greater Than More than seven.');", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MESSAGE", "alert('Converted More than seven Can not be Greater Than More than seven.');", true);
                txtcmorethan7.Focus();
                return;
            }
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {

        ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close();", true);
        return;
    }



    private void BindGrid()
    {
        try
        {

            string strWhere = string.Empty;

            SqlParameter Road_Id = new SqlParameter("@RoadID", Convert.ToString(Session["RoadID"]));
            DataTable dt = cls.GetDataTableSp("Sp_Get_RoadConvertedReport", new SqlParameter[] { Road_Id });
            //  DataTable dt = cls.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                grdEistingRecordConvert.DataSource = dt;
                grdEistingRecordConvert.DataBind();
                // ViewState["ConvertedId"] = dt.Rows[0]["ConvertedId"].ToString();
                lblerror.Visible = false;
                // pnl.Visible = true;

            }
            else
            {
                grdEistingRecordConvert.DataSource = null;
                //grdEistingRecord.DataBind();
                lblerror.Visible = true;
                // pnl.Visible = false;


                // ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Record Found..');", true);

            }
        }
        catch (Exception ex)
        {
        }

    }






    protected void btn_new_road_concersion_Click(object sender, EventArgs e)
    {
        hideshowdatabtnclick();
        txtroadconvremarks.Text = "";
        txt_converted_road_length.Text = "0";
        txtcgood.Text = "0";
        txtcfair.Text = "0";
        txtcbad.Text = "0";
        txtcavg.Text = "0";
        txtc2lane.Text = "0";
        txtcinterlane.Text = "0";
        txtcmorethan7.Text = "0";
        txtcsinglelane.Text = "0";
        //  lblfileuploadpath.Text = "";
    }

    private void hideshowdatabtnclick()
    {
        pnlbtn.Visible = false;
        pnlconvertedroad.Visible = false;
        Panel1.Visible = true;
        Panel2.Visible = true;
        if (DDLWings.SelectedItem.Text == "NH Wing" || DDLWings.SelectedItem.Text == "BSRDC")
        {
            Panel3.Visible = true;
        }
        else
        {
            Panel3.Visible = false;
        }

        Panel4.Visible = true;
        Panel5.Visible = true;
        pnl6.Visible = true;
        pnl_roadconversation.Visible = true;
        pnl_fileupload.Visible = true;
        pnl_converted_LanWidth.Visible = true;
        pnlconverted_condition_ofroad.Visible = true;
    }

    private void hideshowdata_from_conversiontype()
    {
        pnl_fileupload.Visible = false;
        //if (radioroadconversion.SelectedValue == "1"  || radioroadconversion.SelectedValue == "2")
        if (radioroadconversion.SelectedValue == "1")
        {

            txt_converted_road_length.Text = txtLength.Text;
            txtLength.Text = ViewState["txtLength"].ToString();
            txt_converted_road_length.Enabled = true;
            pnlbtn.Visible = true;
            // pnlconvertedroad.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = false;
            // Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            pnl6.Visible = false;
            pnl_roadconversation.Visible = false;
            pnl_fileupload.Visible = true;
            pnl_converted_LanWidth.Visible = false;
            pnlconverted_condition_ofroad.Visible = false;
            BindGrid();
            // pnl_roadconversation.Visible = true;
            // pnlconverted_condition_ofroad.Visible = true;
            // pnl_converted_LanWidth.Visible = true;

            if (radioroadconversion.SelectedValue == "1")
            {
                pnlconvertedroad.Visible = true;
                pnldocument.Visible = false;

            }
            else if (radioroadconversion.SelectedValue == "2")
            {

                pnlconvertedroad.Visible = false;
                pnldocument.Visible = false;
            }
            else
            {

                pnlconvertedroad.Visible = false;
                pnldocument.Visible = false;
            }


            if (pnlconvertedroad.Visible == true)
            {

                pnl_fileupload.Visible = false;

            }

        }

        else if (radioroadconversion.SelectedValue == "2")
        {
            if (radioroadconversion.SelectedValue == "1")
            {
                pnlconvertedroad.Visible = false;
                pnldocument.Visible = false;

            }
            else if (radioroadconversion.SelectedValue == "2")
            {

                pnlconvertedroad.Visible = false;
                pnldocument.Visible = false;
            }
            else
            {

                pnlconvertedroad.Visible = false;
                pnldocument.Visible = false;
            }

            txt_converted_road_length.Text = ViewState["txtLength"].ToString();
            txtLength.Text = "0";
            txt_converted_road_length.Enabled = false;
            pnlbtn.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = true;
            // Panel3.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = true;
            pnl6.Visible = true;
            pnl_roadconversation.Visible = true;
            // pnl_fileupload.Visible = true;
            pnl_converted_LanWidth.Visible = true;
            pnlconverted_condition_ofroad.Visible = true;


            pnl_roadconversation.Visible = true;
            pnl_fileupload.Visible = true;
            pnlconverted_condition_ofroad.Visible = true;
            pnl_converted_LanWidth.Visible = true;
            if (pnldocument.Visible == true)
            {

                pnl_fileupload.Visible = false;

            }

        }


        else
        {
            if (ViewState["ConvertedId"].ToString() == "1")
            {
                pnlconvertedroad.Visible = true;

            }
            else if (ViewState["ConvertedId"].ToString() == "2")
            {

                pnlconvertedroad.Visible = true;
            }
            else
            {

                pnlconvertedroad.Visible = false;
                pnldocument.Visible = false;
            }

            if (pnlconvertedroad.Visible == true)
            {

                pnl_fileupload.Visible = false;

            }
            pnlbtn.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = true;
            // Panel3.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = true;
            pnl6.Visible = true;
            pnl_roadconversation.Visible = true;
            // pnl_fileupload.Visible = true;
            pnl_converted_LanWidth.Visible = true;
            pnlconverted_condition_ofroad.Visible = true;


            pnl_roadconversation.Visible = true;
            //pnl_fileupload.Visible = true;
            pnlconverted_condition_ofroad.Visible = true;
            pnl_converted_LanWidth.Visible = true;


        }
    }

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


    protected void grdEistingRecordConvert_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CID")
        {

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string CID = grdEistingRecordConvert.DataKeys[row.RowIndex].Values["RoadConversionId"].ToString();
            Session["CID"] = CID.ToString();
            //Response.Redirect("UploadConvertedRoadMasterLetter.aspx");
            // GridViewRow row = grdEistingRecordConvert.SelectedRow;
            // string CID = row.Cells[0].Text;
            pnldocument.Visible = true;
            //  UploadLetter(CID);
            grdEistingRecordConvert.Focus();
        }
    }

    public void UploadLetter(string CID)
    {
        try
        {
            string _fuIdproof1 = "";
            // string cid = Session["RoadConversionId"].ToString();
            _fuIdproof1 = GetUploadFile2(FileUpload1, "RoadConversionLetter");

            SqlParameter approvalletter = new SqlParameter("@RoadConversionLetter", _fuIdproof1.Trim());
            SqlParameter _RoadConversionId = new SqlParameter("@RoadConversionId", CID);


            DataTable dt = cls.GetDataTableSp("Sp_RoadMasterFileUpload", new SqlParameter[] { _RoadConversionId, approvalletter });
            if (dt.Rows.Count > 0)
            {


                string msg = dt.Rows[0]["msg"].ToString();
                if (msg == "1")
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Update Successfully.');", true);

                    Response.Redirect("RoadMasterData.aspx");


                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Not Update Successfully.');", true);

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Not Update Successfully.');", true);

            }


        }
        catch (Exception ex)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' Not Update Successfully.');", true);
        }
    }
    protected void btnuploadletter_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Select File For Upload!!');", true);
            return;
        }
        UploadLetter(Convert.ToString(Session["CID"]));

    }

    protected void btn_cancle_Click(object sender, EventArgs e)
    {
        pnldocument.Visible = false;
    }

    protected void DDLRoadType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubRoad();
    }
}