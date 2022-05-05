using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class RCDPMISNEW_ADM_ViewRoadMaster : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        string roadid = Request.QueryString["roadid"].ToString();
        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            display();
            ShowInitialTotalLength();
        }
    }

    private void display()
    {
        string roadid = Request.QueryString["roadid"].ToString();
         string cID = Convert.ToString(Session["CircleID"]);
        string dID = Convert.ToString(Session["DivisionID"]);
        // DataTable dt = cls.GetDataTable( @"select * from RoadMaster where slno='" + roadid + "'");
        ////        DataTable dt = cls.GetDataTable(@"select wing.WingName as Wing, Circles.CircleName as Circle,Divisions.DivisionName as Division,rt.description,
        ////rm.Name_of_the_Road,rm.New_Total_Length_km,rm.NH_ConvertedLength_km,rm.NH_Converted_Road_Remarks,
        ////rm.Remarks,rm.RoadId,rm.Change_Remarks,rm.RoadStatus,srt.description,rm.Good,
        ////case when rm.Average='NULL' then '' else rm.Average end as Average,
        ////case when rm.Bad='NULL' then '' else rm.Bad end as Bad,
        ////rm.Fair,rm.SingleLane,rm.Intermediate,rm.morethanwidthseven,rm.twolane,rm.nhno,
        ////rm.startpoint,rm.endpoint,rm.SubRoadTypeId,rm.Reason,rm.Discriptionofissu,rm.OtherRemarks,rm.ConvertedRoadLength,rct.ConvertedName,rm.RoadConversionApprovalLetter,
        ////rm.ConvertedGood,rm.ConvertedBad,rm.ConvertedFair,rm.ConvertedAverage,
        ////rm.ConvertedIntermediate,rm.ConvertedSingle,rm.ConvertedTwoLane,rm.ConvertedMoreThanSeven,r.Reason as ReasonName
        ////from (((((((RoadMaster as rm inner join Wing on rm.WingID= Wing.WingID )
        ////inner join RoadType as rt on rt.RoadTypeId= rm.RoadType)
        ////inner join Circles on Circles.CircleID=rm.CircleID)
        ////inner join Divisions on Divisions.DivisionID=rm.DivisionID) 
        ////inner join SubRoadType as srt on srt.SubRoadTypeId=rm.SubRoadTypeId)
        ////inner join RoadConvertedType rct on rct.ConvertedId=rm.ConversionType)
        ////inner join Reason r on r.ReasonID=rm.Reason)
        ////where RoadId=@RoadId ", new SqlParameter[] { new SqlParameter ("@RoadId", roadid) });

       
        SqlParameter _Rid = new SqlParameter("@RoadId", roadid);
        DataTable dt = cls.GetDataTableSp("sp_get_RoadMasterData", new SqlParameter[] { _Rid });
        if (dt.Rows.Count > 0)
        {
            txtwing.Text = dt.Rows[0]["Wing"].ToString();
            txtcircle.Text = dt.Rows[0]["Circle"].ToString();
            txtdivision.Text = dt.Rows[0]["Division"].ToString();
            txtroadtype.Text = dt.Rows[0]["description"].ToString();
             txt_SingleLane.Text = dt.Rows[0]["SingleLane"].ToString();
            txt_Intermediate.Text = dt.Rows[0]["Intermediate"].ToString();
            txt_morethanwithseven.Text = dt.Rows[0]["morethanwidthseven"].ToString();
            txt_twolane.Text = dt.Rows[0]["twolane"].ToString();
            txt_good.Text = dt.Rows[0]["Good"].ToString();
            txt_fair.Text = dt.Rows[0]["Fair"].ToString();
            txt_average.Text = dt.Rows[0]["Average"].ToString();
            txt_bad.Text = dt.Rows[0]["Bad"].ToString();
            txt_morethanwithseven.Text = dt.Rows[0]["morethanwidthseven"].ToString();
            txt_nameoftheroad.Text = dt.Rows[0]["Name_of_the_Road"].ToString();

            txt_ntlength_km.Text = dt.Rows[0]["New_Total_Length_km"].ToString();
            txt_subroadtype.Text = dt.Rows[0]["description"].ToString();
            txtreason.Text = dt.Rows[0]["Reason"].ToString();
            radioroadconversion.Text = dt.Rows[0]["ConversionType"].ToString();
            //txtotherreason.Text = dt.Rows[0]["OtherRemarks"].ToString();
            //if (txtreason.Text == "Other")
            if (txtreason.Text == "6")
            {
                lblotherremarks.Visible = true;
                txtotherreason.Visible = true;
                txtotherreason.Text = dt.Rows[0]["OtherRemarks"].ToString();
                if(txtreason.Text=="6")
                {
                    txtreason.Text = "Other";
                }
               


            }
            else
            {
                lblotherremarks.Visible = false;
                txtotherreason.Visible = false;
                if (txtreason.Text == "5")
                {
                    txtreason.Text = "Length Not Assigned to Anybody";
                }
                else if (txtreason.Text == "4")
                {
                    txtreason.Text = "Maintenance by Ordinary Repair";
                }
                else if (txtreason.Text == "3")
                {
                    txtreason.Text = "Under Maintenance of Contractor";
                }
                else if (txtreason.Text == "2")
                {
                    txtreason.Text = "Stretch Under DLP";
                }
                else if (txtreason.Text == "1")
                {
                    txtreason.Text = "Stretch Under Construction";
                }

            }



            string radio= dt.Rows[0]["RoadConversion_IFAny"].ToString();
           // radioyesno.SelectedItem.Text = radio;
          // radioyesno.SelectedItem.Text= dt.Rows[0]["RoadConversion_IFAny"].ToString();
            if(radio=="1" )
            {
                pnlroadconversion.Visible = true;
                bindgridafterconversion();
                radioyesno.SelectedValue = "1";
                lblconversiontype.Visible = true;
                radioroadconversion.Visible = true;
                //pnlconvertedroaddetails.Visible = true;
                //pnlconvertedroadcondition.Visible = true;
                //pnlconvertedlanwidth.Visible = true;
                //lblconversiontype.Visible = true;
                //if (radioroadconversion.Text == "1")
                //{
                //    radioroadconversion.SelectedValue = "1";
                //    radioroadconversion.Visible = true;
                //}
                //else
                //{
                //    radioroadconversion.SelectedValue = "2";
                //    radioroadconversion.Visible = true;
                //}
                //radioroadconversion.Visible = true;

                //radioyesno.SelectedValue = "1";



            }
            else if(radioyesno.Text == "")
            {
                pnlroadconversion.Visible = false;
                pnlconvertedroaddetails.Visible = false;
                pnlconvertedroadcondition.Visible = false;
                pnlconvertedlanwidth.Visible = false;
                lblconversiontype.Visible = false;
                radioroadconversion.Visible = false;
                // radioyesno.SelectedIndex = -1;
                radioyesno.SelectedValue = "2";
                lblconversiontype.Visible = false;
                radioroadconversion.Visible = false;
            }
            else
            {
                pnlroadconversion.Visible = false;
              
                pnlconvertedroaddetails.Visible = false;
                pnlconvertedroadcondition.Visible = false;
                pnlconvertedlanwidth.Visible = false;
                lblconversiontype.Visible = false;
                radioroadconversion.Visible = false;
                radioyesno.SelectedValue = "2";
                lblconversiontype.Visible = false;
                radioroadconversion.Visible = false;
            }


            txtdescription.Text = dt.Rows[0]["Discriptionofissu"].ToString();
            txt_converted_total_length.Text= dt.Rows[0]["ConvertedRoadLength"].ToString();
            //txt_conversion_type.Text = dt.Rows[0]["ConversionType"].ToString();
            //// lblApprovalLetter.Text = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
            btnapprovalletter.Text= dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
            if(btnapprovalletter.Text=="")
            {
                btnapprovalletter.Text = "No Record Found..";
            }
            else
            {
                btnapprovalletter.Text = dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
            }

            txtcgood.Text = dt.Rows[0]["ConvertedGood"].ToString();
            txtcbad.Text = dt.Rows[0]["ConvertedBad"].ToString();
            txtcavg.Text = dt.Rows[0]["ConvertedAverage"].ToString();
            txtcfair.Text = dt.Rows[0]["ConvertedFair"].ToString();

            txtcsingle.Text = dt.Rows[0]["ConvertedSingle"].ToString();
            txtcinter.Text = dt.Rows[0]["ConvertedIntermediate"].ToString();
            txtc2lane.Text = dt.Rows[0]["ConvertedTwoLane"].ToString();
            txtcmorethan7.Text = dt.Rows[0]["ConvertedMoreThanSeven"].ToString();



           

            if (dt.Rows[0]["New_Total_Length_km"].ToString() == "NULL")
            {
                txt_ntlength_km.Text = "";
            }
            else
            {
                txt_ntlength_km.Text = dt.Rows[0]["New_Total_Length_km"].ToString();
            }

           


        }
       
    }

    protected void lnkback_Click(object sender, EventArgs e)
    {
        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close();", true);
        //return;
        Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
        return;
    }


    protected void lnkback_Click1(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnapprovalletter_Click(object sender, EventArgs e)
    {
        displayletter();
//        string roadid = Request.QueryString["roadid"].ToString();
//        string cID = Convert.ToString(Session["CircleID"]);
//        string dID = Convert.ToString(Session["DivisionID"]);

        //        DataTable dt = cls.GetDataTable(@"select wing.WingName as Wing, Circles.CircleName as Circle,Divisions.DivisionName as Division, rm.RoadConversionApprovalLetter
        //from RoadMaster as rm inner join Wing on rm.WingID= Wing.WingID     
        //        inner join Circles on Circles.CircleID=rm.CircleID
        //        inner join Divisions on Divisions.DivisionID=rm.DivisionID   
        //        where RoadId='" + roadid + "' ");
        //        if (dt.Rows.Count > 0)
        //        {
        //            btnapprovalletter.Text= dt.Rows[0]["RoadConversionApprovalLetter"].ToString();

        //        }
    }

    private void displayletter()
    {
        string roadid = Request.QueryString["roadid"].ToString();

        DataTable dt = cls.GetDataTable(@"select RoadId,RoadConversionApprovalLetter from RoadMaster
                        where RoadId='" + roadid + "' ");

        if (dt.Rows.Count > 0)
        {
            string file = "~/PMIS/Approval_latter/" + dt.Rows[0]["RoadConversionApprovalLetter"].ToString();
            Response.Redirect(file);

        }
        else
        {

        }
    }

    private void bindgridafterconversion()
    {
        try
        {

            string strWhere = string.Empty;
            //SqlParameter Query_Type = new SqlParameter("@QueryType", 1);
            //SqlParameter Wing_Id = new SqlParameter("@WingID", ddlwings.SelectedValue.Trim());
            //SqlParameter Circle_Id = new SqlParameter("@CircleID", ddlcircle.SelectedValue.Trim());
            //SqlParameter Division_Id = new SqlParameter("@DivisionID", ddldivision.SelectedValue.Trim());
            string roadid = Request.QueryString["roadid"].ToString();
            SqlParameter Road_Id = new SqlParameter("@RoadID", roadid);
            // SqlParameter Road_Id = new SqlParameter("@RoadID", Convert.ToString(Session["RoadID"]));
            DataTable dt = cls.GetDataTableSp("Sp_Get_RoadConvertedReport", new SqlParameter[] { Road_Id });
           // string ctype = dt.Rows[0][""].ToString();

            //  DataTable dt = cls.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                grdEistingRecordConvert.DataSource = dt;
                grdEistingRecordConvert.DataBind();
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


    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close();", true);
        return;
    }

    private void ShowInitialTotalLength()
    {
        string roadid = Request.QueryString["roadid"].ToString();

        DataTable dt = cls.GetDataTable(@"select RoadId,NewTotalLengthkmUpdate from RoadMaster
                        where RoadId='" + roadid + "' ");

        if (dt.Rows.Count > 0)
        {
           
            lbl_TotalLength.Text= dt.Rows[0]["NewTotalLengthkmUpdate"].ToString();
        }
        else
        {

        }
    }
}