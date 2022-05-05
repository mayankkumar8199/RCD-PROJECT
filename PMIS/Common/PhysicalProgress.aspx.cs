using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RCDPMISNEW_Common_PhysicalProgress : System.Web.UI.Page
{
    string sqlQuery = "";
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    Encryptor enc = new Encryptor(Encryptor.PrivateKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            checktext();
            loadData();
            physicalprogress();
           
        }
    }

    protected void physicalprogress()
    {

        string projectno = Convert.ToString(Request.QueryString["ProjectNo"]);
        ViewState["Projectno"] = projectno;
        lblProject.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + projectno + "");
        iblProjNo.Text = " / " + ViewState["Projectno"].ToString();
        
    }


    protected void loadData()
    {
       
        try
        {
            string tid = Convert.ToString(Request.QueryString["TargetID"]);
            SqlParameter _tid = new SqlParameter("@TargetID", tid);
            DataTable dt = cls.GetDataTableSp("sp_get_Physicalprogress", new SqlParameter[] { _tid });
            if (dt.Rows.Count > 0)
            {
                lbl_EW.Text = dt.Rows[0]["EW"].ToString();
                lbl_GSB.Text = dt.Rows[0]["GSB"].ToString();
                lbl_WBM.Text = dt.Rows[0]["WBM"].ToString();
                lbl_BUSG.Text = dt.Rows[0]["BUSG"].ToString();
                lbl_BM.Text = dt.Rows[0]["BM"].ToString();
                lbl_DBM.Text = dt.Rows[0]["DBM"].ToString();
                lbl_SDBC.Text = dt.Rows[0]["SDBC_BC_PMC"].ToString();
                lbl_PCC.Text = dt.Rows[0]["PCC"].ToString();
                lbl_DLC.Text = dt.Rows[0]["DLC"].ToString();
                lbl_PRIMER.Text = dt.Rows[0]["PrimerCoat"].ToString();
                lbl_TEAK.Text = dt.Rows[0]["TeakCoat"].ToString();
                lbl_PQC.Text = dt.Rows[0]["PQC"].ToString();
                lbl_DRAIN.Text = dt.Rows[0]["Drain"].ToString();
                lbl_MASTIC.Text = dt.Rows[0]["Mastic_Asphalt"].ToString();
                lbl_CDWork.Text = dt.Rows[0]["CDWork"].ToString();
                lbl_Bridge.Text = dt.Rows[0]["Bridge"].ToString();
                lbl_Bolder.Text = dt.Rows[0]["Bolder_Pitch"].ToString();
                lbl_Protection.Text = dt.Rows[0]["Protection_Work"].ToString();
                lbl_SHOULDER.Text = dt.Rows[0]["Shoulder"].ToString();

                txt_EW.Text = dt.Rows[0]["EW_CUMULATIVE"].ToString();
                txt_GSB.Text = dt.Rows[0]["GSB_CUMULATIVE"].ToString();
                txt_WBM.Text = dt.Rows[0]["WBM_WMM_CUMULATIVE"].ToString();
                txt_BUSG.Text = dt.Rows[0]["BUSG_CUMULATIVE"].ToString();
                txt_BM.Text = dt.Rows[0]["BM_CUMULATIVE"].ToString();
                txt_DBM.Text = dt.Rows[0]["DBM_CUMULATIVE"].ToString();
                txt_PRIMER.Text = dt.Rows[0]["PRIMER_CUMULATIVE"].ToString();
                txt_TEAK.Text = dt.Rows[0]["TEAK_CUMULATIVE"].ToString();
                txt_SDBC.Text = dt.Rows[0]["SDBC_CUMULATIVE"].ToString();
                txt_PCC.Text = dt.Rows[0]["PCC_CUMULATIVE"].ToString();
                txt_DLC.Text = dt.Rows[0]["DLC_CUMULATIVE"].ToString();
                txt_PQC.Text = dt.Rows[0]["PQC_CUMULATIVE"].ToString();
                txt_DRAIN.Text = dt.Rows[0]["DRAIN_CUMULATIVE"].ToString();
                txt_MASTIC.Text = dt.Rows[0]["MASTIC_CUMULATIVE"].ToString();
                txt_SHOULDER.Text = dt.Rows[0]["SHOULDER_CUMULATIVE"].ToString();
                txt_CDWork.Text = dt.Rows[0]["CDWORK_CUMULATIVE"].ToString();
                txt_Bridge.Text = dt.Rows[0]["BRIDGE_CUMULATIVE"].ToString();
                txt_Protection.Text = dt.Rows[0]["PROTECTION_CUMULATIVE"].ToString();
                txt_Bolder.Text = dt.Rows[0]["BOLDER_CUMULATIVE"].ToString();


                txt_c_EW.Text = dt.Rows[0]["EW_TODAY"].ToString();
                txt_c_GSB.Text = dt.Rows[0]["GSB_TODAY"].ToString();
                txt_c_WBM.Text = dt.Rows[0]["WBM_TODAY"].ToString();
                txt_c_BUSG.Text = dt.Rows[0]["BUSG_TODAY"].ToString();
                txt_C_BM.Text = dt.Rows[0]["BM_TODAY"].ToString();
                txt_c_DBM.Text = dt.Rows[0]["DBM_TODAY"].ToString();
                txt_c_PRIMER.Text = dt.Rows[0]["PRIMER_TODAY"].ToString();
                txt_c_TEAK.Text = dt.Rows[0]["TEAK_TODAY"].ToString();
                txt_c_SDBC.Text = dt.Rows[0]["SDBC_TODAY"].ToString();
                txt_c_PCC.Text = dt.Rows[0]["PCC_TODAY"].ToString();
                txt_c_DLC.Text = dt.Rows[0]["DLC_TODAY"].ToString();
                txt_c_PQC.Text = dt.Rows[0]["PQC_TODAY"].ToString();
                txt_c_DRAIN.Text = dt.Rows[0]["DRAIN_TODAY"].ToString();
                txt_c_MASTIC.Text = dt.Rows[0]["MASTIC_TODAY"].ToString();
                txt_c_SHOULDER.Text = dt.Rows[0]["SHOULDER_TODAY"].ToString();
                txt_c_CDWORK.Text = dt.Rows[0]["CDWORK_TODAY"].ToString();
                txt_c_Bridge.Text = dt.Rows[0]["BRIDGEWORK_TODAY"].ToString();
                txt_c_Protection.Text = dt.Rows[0]["PROTECTION_TODAY"].ToString();
                txt_c_Bolder.Text = dt.Rows[0]["BOLDER_TODAY"].ToString();
                txt_Comment.Text = dt.Rows[0]["COMMENTS"].ToString();
                txtbridge_Comment.Text = dt.Rows[0]["BRIDGECOMMENTS"].ToString();
                if (dt.Rows[0]["EW_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["EW_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_ew_updatedate.Text = "01/01/1900";
                    lbl_ew_updatedate.Visible = false;
                }
                else {

                    lbl_ew_updatedate.Text = dt.Rows[0]["EW_UPDATE_DATE"].ToString();
                    lbl_ew_updatedate.Visible = true;
                
                }

                if (dt.Rows[0]["GSB_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["GSB_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_gsb_updatedate.Text = "01/01/1900";
                    lbl_gsb_updatedate.Visible = false;
                }
                else
                {

                    lbl_gsb_updatedate.Text = dt.Rows[0]["GSB_UPDATE_DATE"].ToString();
                    lbl_gsb_updatedate.Visible = true;

                }

                // lbl_gsb_updatedate.Text = dt.Rows[0]["GSB_UPDATE_DATE"].ToString();

                if (dt.Rows[0]["WBM_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["WBM_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_wbm_updatedate.Text = "01/01/1900";
                    lbl_wbm_updatedate.Visible = false;
                }
                else
                {

                    lbl_wbm_updatedate.Text = dt.Rows[0]["WBM_UPDATE_DATE"].ToString();
                    lbl_wbm_updatedate.Visible = true;

                }

                // lbl_wbm_updatedate.Text = dt.Rows[0]["WBM_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["BUSG_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["BUSG_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_busg_updatedate.Text = "01/01/1900";
                    lbl_busg_updatedate.Visible = false;
                }
                else
                {

                    lbl_busg_updatedate.Text = dt.Rows[0]["BUSG_UPDATE_DATE"].ToString();
                    lbl_busg_updatedate.Visible = true;

                }
                // lbl_busg_updatedate.Text = dt.Rows[0]["BUSG_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["BM_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["BM_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_bm_updatedate.Text = "01/01/1900";
                    lbl_bm_updatedate.Visible = false;
                }
                else
                {

                    lbl_bm_updatedate.Text = dt.Rows[0]["BM_UPDATE_DATE"].ToString();
                    lbl_bm_updatedate.Visible = true;

                }
                //lbl_bm_updatedate.Text = dt.Rows[0]["BM_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["DBM_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["DBM_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_dbm_updatedate.Text = "01/01/1900";
                    lbl_dbm_updatedate.Visible = false;
                }
                else
                {

                    lbl_dbm_updatedate.Text = dt.Rows[0]["DBM_UPDATE_DATE"].ToString();
                    lbl_dbm_updatedate.Visible = true;

                }
                // lbl_dbm_updatedate.Text = dt.Rows[0]["DBM_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["PRIMER_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["PRIMER_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_primer_updatedate.Text = "01/01/1900";
                    lbl_primer_updatedate.Visible = false;
                }
                else
                {

                    lbl_primer_updatedate.Text = dt.Rows[0]["PRIMER_UPDATE_DATE"].ToString();
                    lbl_primer_updatedate.Visible = true;

                }
                // lbl_primer_updatedate.Text = dt.Rows[0]["PRIMER_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["TEAK_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["TEAK_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_take_updatedate.Text = "01/01/1900";
                    lbl_take_updatedate.Visible = false;
                }
                else
                {

                    lbl_take_updatedate.Text = dt.Rows[0]["TEAK_UPDATE_DATE"].ToString();
                    lbl_take_updatedate.Visible = true;

                }

                //  lbl_take_updatedate.Text = dt.Rows[0]["TEAK_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["SDBC_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["SDBC_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_sdbc_updatedate.Text = "01/01/1900";
                    lbl_sdbc_updatedate.Visible = false;
                }
                else
                {

                    lbl_sdbc_updatedate.Text = dt.Rows[0]["SDBC_UPDATE_DATE"].ToString();
                    lbl_sdbc_updatedate.Visible = true;

                }
                //  lbl_sdbc_updatedate.Text = dt.Rows[0]["SDBC_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["PCC_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["PCC_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_pcc_updatedate.Text = "01/01/1900";
                    lbl_pcc_updatedate.Visible = false;
                }
                else
                {

                    lbl_pcc_updatedate.Text = dt.Rows[0]["PCC_UPDATE_DATE"].ToString();
                    lbl_pcc_updatedate.Visible = true;

                }
                // lbl_pcc_updatedate.Text = dt.Rows[0]["PCC_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["DLC_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["DLC_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_dlc_updatedate.Text = "01/01/1900";
                    lbl_dlc_updatedate.Visible = false;
                }
                else
                {

                    lbl_dlc_updatedate.Text = dt.Rows[0]["DLC_UPDATE_DATE"].ToString();
                    lbl_dlc_updatedate.Visible = true;

                }
                //  lbl_dlc_updatedate.Text = dt.Rows[0]["DLC_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["PQC_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["PQC_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_pqc_updatedate.Text = "01/01/1900";
                    lbl_pqc_updatedate.Visible = false;
                }
                else
                {

                    lbl_pqc_updatedate.Text = dt.Rows[0]["PQC_UPDATE_DATE"].ToString();
                    lbl_pqc_updatedate.Visible = true;

                }
                //lbl_pqc_updatedate.Text = dt.Rows[0]["PQC_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["DRAIN_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["DRAIN_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_drain_updatedate.Text = "01/01/1900";
                    lbl_drain_updatedate.Visible = false;
                }
                else
                {

                    lbl_drain_updatedate.Text = dt.Rows[0]["DRAIN_UPDATE_DATE"].ToString();
                    lbl_drain_updatedate.Visible = true;

                }
                // lbl_drain_updatedate.Text = dt.Rows[0]["DRAIN_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["MASTIC_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["MASTIC_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_mastic_updatedate.Text = "01/01/1900";
                    lbl_mastic_updatedate.Visible = false;
                }
                else
                {

                    lbl_mastic_updatedate.Text = dt.Rows[0]["MASTIC_UPDATE_DATE"].ToString();
                    lbl_mastic_updatedate.Visible = true;

                }
                // lbl_mastic_updatedate.Text = dt.Rows[0]["MASTIC_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["SHOULDER_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["SHOULDER_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_shoulder_updatedate.Text = "01/01/1900";
                    lbl_shoulder_updatedate.Visible = false;
                }
                else
                {

                    lbl_shoulder_updatedate.Text = dt.Rows[0]["SHOULDER_UPDATE_DATE"].ToString();
                    lbl_shoulder_updatedate.Visible = true;

                }
                // lbl_shoulder_updatedate.Text = dt.Rows[0]["SHOULDER_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["CDWORK_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["CDWORK_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_cdwork_updatedate.Text = "01/01/1900";
                    lbl_cdwork_updatedate.Visible = false;
                }
                else
                {

                    lbl_cdwork_updatedate.Text = dt.Rows[0]["CDWORK_UPDATE_DATE"].ToString();
                    lbl_cdwork_updatedate.Visible = true;

                }
                if (dt.Rows[0]["BRIDGE_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["BRIDGE_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_Bridge_updatedate.Text = "01/01/1900";
                    lbl_Bridge_updatedate.Visible = false;
                }
                else
                {

                    lbl_Bridge_updatedate.Text = dt.Rows[0]["BRIDGE_UPDATE_DATE"].ToString();
                    lbl_Bridge_updatedate.Visible = true;

                }
                // lbl_cdwork_updatedate.Text = dt.Rows[0]["CDWORK_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["PROTECTION_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["PROTECTION_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_protectionupdatedate.Text = "01/01/1900";
                    lbl_protectionupdatedate.Visible = false;
                }
                else
                {

                    lbl_protectionupdatedate.Text = dt.Rows[0]["PROTECTION_UPDATE_DATE"].ToString();
                    lbl_protectionupdatedate.Visible = true;

                }
                //  lbl_protectionupdatedate.Text = dt.Rows[0]["PROTECTION_UPDATE_DATE"].ToString();
                if (dt.Rows[0]["BOLDER_UPDATE_DATE"].ToString() == "" || dt.Rows[0]["BOLDER_UPDATE_DATE"].ToString() == "01/01/1900")
                {
                    lbl_bolderupdatedate.Text = "01/01/1900";
                    lbl_bolderupdatedate.Visible = false;
                }
                else
                {

                    lbl_bolderupdatedate.Text = dt.Rows[0]["BOLDER_UPDATE_DATE"].ToString();
                    lbl_bolderupdatedate.Visible = true;

                }
                // lbl_bolderupdatedate.Text = dt.Rows[0]["BOLDER_UPDATE_DATE"].ToString();
                ViewState["IMg1"] = dt.Rows[0]["IMAGE1"].ToString();             
               
                
               

                string Image1 = "~/PMIS/PhysicalProgressImages/" + Convert.ToString(dt.Rows[0]["IMAGE1"]);
                if (Image1 != "")
                {
                    img1.ImageUrl = Image1;
                    img1.Visible = true;
                }
               
                ViewState["IMg2"] = dt.Rows[0]["IMAGE2"].ToString();
                string Image2 = "~/PMIS/PhysicalProgressImages/" + Convert.ToString(dt.Rows[0]["IMAGE2"]);
                if (Image2 != "")
                {
                    img2.ImageUrl = Image2;
                    img2.Visible = true;
                }
               
                lblimg1description.Text = dt.Rows[0]["Image1_Description"].ToString();
                lblimg2description.Text = dt.Rows[0]["Image2_Description"].ToString();
                if (lbl_Bridge.Text == "0" || lbl_Bridge.Text == "")
                {

                    txtbridge_Comment.Enabled = false;

                }

            }
        }
        catch(Exception ex)
        {

        }

       
    }
    

    protected void btn_save_Click(object sender, EventArgs e)
    {
        Insert();

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }
    void Insert()
    {
        string tid = Convert.ToString(Request.QueryString["TargetID"]);
        string sql = "";
        try
        {
            if ((Session["WingID"] == null) || (Convert.ToString(Session["CircleID"]) == null) || (Convert.ToString(Session["DivisionID"]) == null))
            {
                Response.Redirect("~/PMIS/Login.aspx");
            }

            string _fuIdproof = "";
            string _fuIdproof1 = "";
            string _fuIdproof2 = "";
            string _fuIdproof3 = "";
            string _fuIdproof4 = "";
            string ProjectNo = Convert.ToString(Request.QueryString["ProjectNo"]);

           



            SqlParameter _projectid = new SqlParameter("@ProjectNo", ProjectNo);
            SqlParameter _TargetId = new SqlParameter("@TargetId", tid);
            SqlParameter _EWTARGET = new SqlParameter("@EW", lbl_EW.Text.Trim());
            SqlParameter _GSB = new SqlParameter("@GSB", lbl_GSB.Text.Trim());
            SqlParameter _wbm = new SqlParameter("@WBM_WMM", lbl_WBM.Text.Trim());
            SqlParameter _busg = new SqlParameter("@BUSG", lbl_BUSG.Text.Trim());
            SqlParameter _bm = new SqlParameter("@BM", lbl_BM.Text.Trim());
            SqlParameter _dbm = new SqlParameter("@DBM", lbl_DBM.Text.Trim());
            SqlParameter _primerTARGET = new SqlParameter("@PRIMER_COAT", lbl_PRIMER.Text.Trim());
            SqlParameter _teakTARGET = new SqlParameter("@TEAK_COAT", lbl_TEAK.Text.Trim());
            SqlParameter _sdbcTARGET = new SqlParameter("@SDBC_BC_PMC", lbl_SDBC.Text.Trim());
            SqlParameter _pccTARGET = new SqlParameter("@PCC", lbl_PCC.Text.Trim());
            SqlParameter _dlcTARGET = new SqlParameter("@DLC", lbl_DLC.Text.Trim());
            SqlParameter _pqcTARGET = new SqlParameter("@PQC", lbl_PQC.Text.Trim());
            SqlParameter _drainTARGET = new SqlParameter("@DRAIN", lbl_DRAIN.Text.Trim());
            SqlParameter _masticTARGET = new SqlParameter("@MASTIC_ASPHALT", lbl_MASTIC.Text.Trim());
            SqlParameter _shoulderTARGET = new SqlParameter("@SHOULDER", lbl_SHOULDER.Text.Trim());
            SqlParameter _cdworkTARGET = new SqlParameter("@CDWORKS", lbl_CDWork.Text.Trim());
            SqlParameter _BridgeTARGET = new SqlParameter("@Bridge", lbl_Bridge.Text.Trim());
            SqlParameter _protectionTARGET = new SqlParameter("@PROTECTION_WORK", lbl_Protection.Text.Trim());
            SqlParameter _bolderpitchTARGET = new SqlParameter("@BOLDER_PITCH", lbl_Bolder.Text.Trim());


            SqlParameter _EWCUMULATIVE = new SqlParameter("@EW_CUMULATIVE", txt_EW.Text.Trim());
            SqlParameter _GSBCUMULATIVE = new SqlParameter("@GSB_CUMULATIVE", txt_GSB.Text.Trim());
            SqlParameter _wbmCUMULATIVE = new SqlParameter("@WBM_WMM_CUMULATIVE", txt_WBM.Text.Trim());
            SqlParameter _busgCUMULATIVE = new SqlParameter("@BUSG_CUMULATIVE", txt_BUSG.Text.Trim());
            SqlParameter _bmCUMULATIVE = new SqlParameter("@BM_CUMULATIVE", txt_BM.Text.Trim());
            SqlParameter _dbmCUMULATIVE = new SqlParameter("@DBM_CUMULATIVE", txt_DBM.Text.Trim());
            SqlParameter _primerTARGETCUMULATIVE = new SqlParameter("@PRIMER_CUMULATIVE", txt_PRIMER.Text.Trim());
            SqlParameter _teakTARGETCUMULATIVE = new SqlParameter("@TEAK_CUMULATIVE", txt_TEAK.Text.Trim());
            SqlParameter _sdbcTARGETCUMULATIVE = new SqlParameter("@SDBC_CUMULATIVE", txt_SDBC.Text.Trim());
            SqlParameter _pccTARGETPCUMULATIVE = new SqlParameter("@PCC_CUMULATIVE", txt_PCC.Text.Trim());
            SqlParameter _dlcTARGETCUMULATIVE = new SqlParameter("@DLC_CUMULATIVE", txt_DLC.Text.Trim());
            SqlParameter _pqcTARGETCUMULATIVE = new SqlParameter("@PQC_CUMULATIVE", txt_PQC.Text.Trim());
            SqlParameter _drainTARGETCUMULATIVE = new SqlParameter("@DRAIN_CUMULATIVE", txt_DRAIN.Text.Trim());
            SqlParameter _masticTARGETCUMULATIVE = new SqlParameter("@MASTIC_CUMULATIVE", txt_MASTIC.Text.Trim());
            SqlParameter _shoulderTARGETCUMULATIVE = new SqlParameter("@SHOULDER_CUMULATIVE", txt_SHOULDER.Text.Trim());
            SqlParameter _cdworkTARGETCUMULATIVE = new SqlParameter("@CDWORK_CUMULATIVE", txt_CDWork.Text.Trim());
            SqlParameter _BridgeTARGETCUMULATIVE = new SqlParameter("@BRIDGE_CUMULATIVE", txt_Bridge.Text.Trim());
            SqlParameter _protectionTARGETCUMULATIVE = new SqlParameter("@PROTECTION_CUMULATIVE", txt_Protection.Text.Trim());
            SqlParameter _bolderpitchTARGETCUMULATIVE = new SqlParameter("@BOLDER_CUMULATIVE", txt_Bolder.Text.Trim());  
             
            SqlParameter _EWPREVIOUS = new SqlParameter("@EW_PERVIOUS", txt_c_EW.Text.Trim());           
            SqlParameter _GSBPREVIOUS = new SqlParameter("@GSB_PERVIOUS", txt_c_GSB.Text.Trim());
            SqlParameter _wbmPREVIOUS = new SqlParameter("@WBM_PERVIOUS", txt_c_WBM.Text.Trim());
            SqlParameter _busgPREVIOUS = new SqlParameter("@BUSG_PERVIOUS", txt_c_BUSG.Text.Trim());
            SqlParameter _bmPREVIOUS = new SqlParameter("@BM_PERVIOUS", txt_C_BM.Text.Trim());
            SqlParameter _dbmPREVIOUS = new SqlParameter("@DBM_PERVIOUS", txt_c_DBM.Text.Trim());
            SqlParameter _primerTARGETPREVIOUS = new SqlParameter("@PRIMER_PERVIOUS", txt_c_PRIMER.Text.Trim());
            SqlParameter _teakTARGETPREVIOUS = new SqlParameter("@TEAK_PERVIOUS", txt_c_TEAK.Text.Trim());
            SqlParameter _sdbcTARGETPREVIOUS = new SqlParameter("@SDBC_PERVIOUS", txt_c_SDBC.Text.Trim());
            SqlParameter _pccTARGETPREVIOUS = new SqlParameter("@PCC_PERVIOUS", txt_c_PCC.Text.Trim());
            SqlParameter _dlcTARGETPREVIOUS = new SqlParameter("@DLC_PERVIOUS", txt_c_DLC.Text.Trim());
            SqlParameter _pqcTARGETPREVIOUS = new SqlParameter("@PQC_PERVIOUS", txt_c_PQC.Text.Trim());
            SqlParameter _drainTARGETPREVIOUS = new SqlParameter("@DRAIN_PERVIOUS", txt_c_DRAIN.Text.Trim());
            SqlParameter _masticTARGETPREVIOUS = new SqlParameter("@MASTIC_PERVIOUS", txt_c_MASTIC.Text.Trim());
            SqlParameter _shoulderTARGETPREVIOUS = new SqlParameter("@SHOULDER_PERVIOUS", txt_c_SHOULDER.Text.Trim());
            SqlParameter _cdworkTARGETPREVIOUS = new SqlParameter("@CDWORK_PERVIOUS", txt_c_CDWORK.Text.Trim());
            SqlParameter _BridgeTARGETPREVIOUS = new SqlParameter("@BRIDGE_PERVIOUS", txt_c_Bridge.Text.Trim());
            SqlParameter _protectionTARGETPREVIOUS = new SqlParameter("@PROTECTION_PERVIOUS", txt_c_Protection.Text.Trim());
            SqlParameter _bolderpitchTARGETPREVIOUS = new SqlParameter("@BOLDER_PERVIOUS", txt_c_Bolder.Text.Trim());


            SqlParameter _EWTODAY = null;
            SqlParameter _EWpdate = null;
               
            if (Convert.ToDouble(txt_EW_Date.Text) > 0)
            {
                _EWTODAY = new SqlParameter("@EW_TODAY", txt_EW_Date.Text.Trim());
                _EWpdate = new SqlParameter("@EW_UPDATE_DATE", System.DateTime.Now);
            }
            else {
                _EWTODAY = new SqlParameter("@EW_TODAY", txt_c_EW.Text.Trim());

                _EWpdate = new SqlParameter("@EW_UPDATE_DATE", Convert.ToDateTime(lbl_ew_updatedate.Text.Trim()));
            }

        
            SqlParameter _GSBTODAY = null;
            SqlParameter _GSBpdate = null;
            if (Convert.ToDouble(txt_GSB_Date.Text) > 0)
            {
                _GSBTODAY = new SqlParameter("@GSB_TODAY", txt_GSB_Date.Text.Trim());
                _GSBpdate = new SqlParameter("@GSB_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _GSBTODAY = new SqlParameter("@GSB_TODAY", txt_c_GSB.Text.Trim());
                 _GSBpdate = new SqlParameter("@GSB_UPDATE_DATE", Convert.ToDateTime(lbl_gsb_updatedate.Text.Trim()));
            }

            SqlParameter _wbmTODAY = null;
            SqlParameter _wbmpdate = null;
            if (Convert.ToDouble(txt_WBM_Date.Text) > 0)
            {
                _wbmTODAY = new SqlParameter("@WBM_TODAY", txt_WBM_Date.Text.Trim());
                _wbmpdate = new SqlParameter("@WBM_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _wbmTODAY = new SqlParameter("@WBM_TODAY", txt_c_WBM.Text.Trim());
                _wbmpdate = new SqlParameter("@WBM_UPDATE_DATE", Convert.ToDateTime(lbl_wbm_updatedate.Text.Trim()));
            }


            SqlParameter _busgTODAY = null;
            SqlParameter _busgpdate = null;
            if (Convert.ToDouble(txt_BUSG_Date.Text) > 0)
            {
                _busgTODAY = new SqlParameter("@BUSG_TODAY", txt_BUSG_Date.Text.Trim());
                _busgpdate = new SqlParameter("@BUSG_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _busgTODAY = new SqlParameter("@BUSG_TODAY", txt_c_BUSG.Text.Trim());
                _busgpdate = new SqlParameter("@BUSG_UPDATE_DATE", Convert.ToDateTime(lbl_busg_updatedate.Text.Trim()));
            }

            SqlParameter _bmTODAY = null;
            SqlParameter _bmpdate = null;
            if (Convert.ToDouble(txt_BM_Date.Text) > 0)
            {
                _bmTODAY = new SqlParameter("@BM_TODAY", txt_BM_Date.Text.Trim());
               _bmpdate = new SqlParameter("@BM_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _bmTODAY = new SqlParameter("@BM_TODAY", txt_C_BM.Text.Trim());
               _bmpdate = new SqlParameter("@BM_UPDATE_DATE", Convert.ToDateTime(lbl_bm_updatedate.Text.Trim()));
            }


            SqlParameter _dbmTODAY = null;
            SqlParameter _dbmpdate = null;
            if (Convert.ToDouble(txt_DBM_Date.Text) > 0)
            {
                _dbmTODAY = new SqlParameter("@DBM_TODAY", txt_DBM_Date.Text.Trim());
                _dbmpdate = new SqlParameter("@DBM_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _dbmTODAY = new SqlParameter("@DBM_TODAY", txt_c_DBM.Text.Trim());
               _dbmpdate = new SqlParameter("@DBM_UPDATE_DATE", Convert.ToDateTime(lbl_dbm_updatedate.Text.Trim()));
            }

            SqlParameter _primerTARGETTODAY = null;
            SqlParameter _primerpdate = null;
            if (Convert.ToDouble(txt_PRIMER_Date.Text) > 0)
            {
                _primerTARGETTODAY = new SqlParameter("@PRIMER_TODAY", txt_PRIMER_Date.Text.Trim());
                _primerpdate = new SqlParameter("@PRIMER_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _primerTARGETTODAY = new SqlParameter("@PRIMER_TODAY", txt_c_PRIMER.Text.Trim());
               _primerpdate = new SqlParameter("@PRIMER_UPDATE_DATE", Convert.ToDateTime(lbl_primer_updatedate.Text.Trim()));
            }

            SqlParameter _teakTARGETTODAY = null;
            SqlParameter _teakpdate = null;
            if (Convert.ToDouble(txt_TEAK_Date.Text) > 0)
            {
                _teakTARGETTODAY = new SqlParameter("@TEAK_TODAY", txt_TEAK_Date.Text.Trim());
                _teakpdate = new SqlParameter("@TEAK_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _teakTARGETTODAY = new SqlParameter("@TEAK_TODAY", txt_c_TEAK.Text.Trim());
               _teakpdate = new SqlParameter("@TEAK_UPDATE_DATE", Convert.ToDateTime(lbl_take_updatedate.Text.Trim()));
            }

            SqlParameter _sdbcTARGETTODAY = null;
            SqlParameter _sdbcpdate = null;
            if (Convert.ToDouble(txt_SDBC_Date.Text) > 0)
            {
                _sdbcTARGETTODAY = new SqlParameter("@SDBC_TODAY", txt_SDBC_Date.Text.Trim());
                _sdbcpdate = new SqlParameter("@SDBC_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _sdbcTARGETTODAY = new SqlParameter("@SDBC_TODAY", txt_c_SDBC.Text.Trim());
               _sdbcpdate = new SqlParameter("@SDBC_UPDATE_DATE", Convert.ToDateTime(lbl_sdbc_updatedate.Text.Trim()));
            }

            SqlParameter _pccTARGETTODAY = null;
            SqlParameter _pccpdate = null;
            if (Convert.ToDouble(txt_PCC_Date.Text) > 0)
            {
                _pccTARGETTODAY = new SqlParameter("@PCC_TODAY", txt_PCC_Date.Text.Trim());
               _pccpdate = new SqlParameter("@PCC_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _pccTARGETTODAY = new SqlParameter("@PCC_TODAY", txt_c_PCC.Text.Trim());
                _pccpdate = new SqlParameter("@PCC_UPDATE_DATE", Convert.ToDateTime(lbl_pcc_updatedate.Text.Trim()));
            }

            SqlParameter _dlcTARGETTODAY = null;
            SqlParameter _dlcpdate = null;
            if (Convert.ToDouble(txt_DLC_Date.Text) > 0)
            {
                _dlcTARGETTODAY = new SqlParameter("@DLC_TODAY", txt_DLC_Date.Text.Trim());
               _dlcpdate = new SqlParameter("@DLC_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _dlcTARGETTODAY = new SqlParameter("@DLC_TODAY", txt_c_DLC.Text.Trim());
                _dlcpdate = new SqlParameter("@DLC_UPDATE_DATE", Convert.ToDateTime(lbl_dlc_updatedate.Text.Trim()));
            }

            SqlParameter _pqcTARGETTODAY = null;
            SqlParameter _pqcpdate = null;
            if (Convert.ToDouble(txt_PQC_Date.Text) > 0)
            {
                _pqcTARGETTODAY = new SqlParameter("@PQC_TODAY", txt_PQC_Date.Text.Trim());
                _pqcpdate = new SqlParameter("@PQC_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _pqcTARGETTODAY = new SqlParameter("@PQC_TODAY", txt_c_PQC.Text.Trim());
               _pqcpdate = new SqlParameter("@PQC_UPDATE_DATE", Convert.ToDateTime(lbl_pqc_updatedate.Text.Trim()));
            }

            SqlParameter _drainTARGETTODAY = null;
            SqlParameter _drainpdate = null;
            if (Convert.ToDouble(txt_DRAIN_Date.Text) > 0)
            {
                _drainTARGETTODAY = new SqlParameter("@DRAIN_TODAY", txt_DRAIN_Date.Text.Trim());
                _drainpdate = new SqlParameter("@DRAIN_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _drainTARGETTODAY = new SqlParameter("@DRAIN_TODAY", txt_c_DRAIN.Text.Trim());
               _drainpdate = new SqlParameter("@DRAIN_UPDATE_DATE", Convert.ToDateTime(lbl_drain_updatedate.Text.Trim()));
            }

            SqlParameter _masticTARGETTODAY = null;
            SqlParameter _masticpdate = null;
            if (Convert.ToDouble(txt_MASTIC_Date.Text) > 0)
            {
                _masticTARGETTODAY = new SqlParameter("@MASTIC_TODAY", txt_MASTIC_Date.Text.Trim());
                _masticpdate = new SqlParameter("@MASTIC_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _masticTARGETTODAY = new SqlParameter("@MASTIC_TODAY", txt_c_MASTIC.Text.Trim());
                _masticpdate = new SqlParameter("@MASTIC_UPDATE_DATE", Convert.ToDateTime(lbl_mastic_updatedate.Text.Trim()));
            }


            SqlParameter _shoulderTARGETTODAY = null;
            SqlParameter _shoulderpdate = null;
            if (Convert.ToDouble(txt_SHOULDER_Date.Text) > 0)
            {
                _shoulderTARGETTODAY = new SqlParameter("@SHOULDER_TODAY", txt_SHOULDER_Date.Text.Trim());
                _shoulderpdate = new SqlParameter("@SHOULDER_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _shoulderTARGETTODAY = new SqlParameter("@SHOULDER_TODAY", txt_c_SHOULDER.Text.Trim());
               _shoulderpdate = new SqlParameter("@SHOULDER_UPDATE_DATE", Convert.ToDateTime(lbl_shoulder_updatedate.Text.Trim()));
            }


            SqlParameter _cdworkTARGETTODAY = null;
            SqlParameter _cdworkpdate = null;
            if (Convert.ToDouble(txt_CDWork_Date.Text) > 0)
            {
                _cdworkTARGETTODAY = new SqlParameter("@CDWORK_TODAY", txt_CDWork_Date.Text.Trim());
                _cdworkpdate = new SqlParameter("@CDWORK_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _cdworkTARGETTODAY = new SqlParameter("@CDWORK_TODAY", txt_c_CDWORK.Text.Trim());
              _cdworkpdate = new SqlParameter("@CDWORK_UPDATE_DATE", Convert.ToDateTime(lbl_cdwork_updatedate.Text.Trim()));
            }

            SqlParameter _BridgeTARGETTODAY = null;
            SqlParameter _Bridgepdate = null;
            if (Convert.ToDouble(txt_Bridge_Date.Text) > 0)
            {
                _BridgeTARGETTODAY = new SqlParameter("@BRIDGEWORK_TODAY", txt_Bridge_Date.Text.Trim());
                _Bridgepdate = new SqlParameter("@BRIDGE_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _BridgeTARGETTODAY = new SqlParameter("@BRIDGEWORK_TODAY", txt_c_Bridge.Text.Trim());
                _Bridgepdate = new SqlParameter("@BRIDGE_UPDATE_DATE", Convert.ToDateTime(lbl_Bridge_updatedate.Text.Trim()));
            }


            SqlParameter _protectionTARGETTODAY = null;
            SqlParameter _protectionpdate = null;
            if (Convert.ToDouble(txt_Protection_Date.Text) > 0)
            {
                _protectionTARGETTODAY = new SqlParameter("@PROTECTION_TODAY", txt_Protection_Date.Text.Trim());
                _protectionpdate = new SqlParameter("@PROTECTION_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _protectionTARGETTODAY = new SqlParameter("@PROTECTION_TODAY", txt_c_Protection.Text.Trim());
              _protectionpdate = new SqlParameter("@PROTECTION_UPDATE_DATE", Convert.ToDateTime(lbl_protectionupdatedate.Text.Trim()));
            }

            SqlParameter _bolderpitchTARGETTODAY = null;
            SqlParameter _bolderpitchpdate = null;
            if (Convert.ToDouble(txt_Bolder_Date.Text) > 0)
            {
                _bolderpitchTARGETTODAY = new SqlParameter("@BOLDER_TODAY", txt_Bolder_Date.Text.Trim());
                
                _bolderpitchpdate = new SqlParameter("@BOLDER_UPDATE_DATE", System.DateTime.Now);
            }
            else
            {
                _bolderpitchTARGETTODAY = new SqlParameter("@BOLDER_TODAY", txt_c_Bolder.Text.Trim());
               
              _bolderpitchpdate = new SqlParameter("@BOLDER_UPDATE_DATE", Convert.ToDateTime(lbl_bolderupdatedate.Text.Trim()));
            }
            

            SqlParameter _comment = new SqlParameter("@COMMENTS", txt_Comment.Text.Trim());
            SqlParameter _bridgecomment = new SqlParameter("@BRIDGECOMMENTS", txtbridge_Comment.Text.Trim());
            SqlParameter _EntryBy = new SqlParameter("@ENTRYBY", User.Identity.Name);
            SqlParameter _updatedBy = new SqlParameter("@UPDATEDBY", User.Identity.Name);
            SqlParameter _Date = new SqlParameter("@UPDATEDDATE", System.DateTime.Now);

            



            if (flu1.HasFile)
            {
                _fuIdproof = GetUploadFile2(flu1, "IMAGE1");
            }
            else
            {
                _fuIdproof = Convert.ToString(ViewState["IMg1"]);
            }

          //  _fuIdproof = GetUploadFile2(flu1, "IMAGE1");
            SqlParameter _image1 = new SqlParameter("@IMAGE1", _fuIdproof.Trim());

            if (flu2.HasFile)
            {
                _fuIdproof1 = GetUploadFile2(flu2, "IMAGE2");
               
            }
            else
            {
                _fuIdproof1 = Convert.ToString(ViewState["IMg2"]);
            }

           // _fuIdproof1 = GetUploadFile2(flu2, "IMAGE2");
            SqlParameter _image2 = new SqlParameter("@IMAGE2", _fuIdproof1.Trim());

           
          
           

            SqlParameter _imgdesc1 = new SqlParameter("@Image1_Description", txtimg1desc.Text.Trim());
            SqlParameter _imgdesc2 = new SqlParameter("@Image2_Description", txtimg2desc.Text.Trim());
            SqlParameter descriptiontype1 = new SqlParameter("@descriptiontype1", ddldescriptiontype1.SelectedItem.Text.Trim());
            SqlParameter descriptiontype2 = new SqlParameter("@descriptiontype2", ddldescriptiontype2.SelectedItem.Text.Trim());


            DataTable dt =      cls.GetDataTableSp("SP_Insert_TargetUpdatedData", new SqlParameter[] { _projectid,_TargetId,_EWTARGET, _GSB, _wbm, _busg, _bm, _dbm, _primerTARGET, _teakTARGET, _sdbcTARGET,
                               _pccTARGET, _dlcTARGET, _pqcTARGET,_drainTARGET, _masticTARGET, _shoulderTARGET, _cdworkTARGET,_BridgeTARGET, _protectionTARGET,_bolderpitchTARGET,

                               _EWCUMULATIVE,_GSBCUMULATIVE, _wbmCUMULATIVE, _busgCUMULATIVE, _bmCUMULATIVE, _dbmCUMULATIVE, _primerTARGETCUMULATIVE, _teakTARGETCUMULATIVE, _sdbcTARGETCUMULATIVE, _pccTARGETPCUMULATIVE,
                               _dlcTARGETCUMULATIVE, _pqcTARGETCUMULATIVE, _drainTARGETCUMULATIVE,_masticTARGETCUMULATIVE, _shoulderTARGETCUMULATIVE, _cdworkTARGETCUMULATIVE,_BridgeTARGETCUMULATIVE, _protectionTARGETCUMULATIVE, _bolderpitchTARGETCUMULATIVE,
                               _EWPREVIOUS,_GSBPREVIOUS,_wbmPREVIOUS,_busgPREVIOUS,_bmPREVIOUS,_dbmPREVIOUS,_primerTARGETPREVIOUS,_teakTARGETPREVIOUS,_sdbcTARGETPREVIOUS,_pccTARGETPREVIOUS,_dlcTARGETPREVIOUS,
                               _pqcTARGETPREVIOUS,_drainTARGETPREVIOUS,_masticTARGETPREVIOUS,_shoulderTARGETPREVIOUS,_cdworkTARGETPREVIOUS,_BridgeTARGETPREVIOUS,_protectionTARGETPREVIOUS,_bolderpitchTARGETPREVIOUS,
                               _EWTODAY,_GSBTODAY,_wbmTODAY,_busgTODAY,_bmTODAY,_dbmTODAY,_primerTARGETTODAY,_teakTARGETTODAY,_sdbcTARGETTODAY,_pccTARGETTODAY,_dlcTARGETTODAY,_pqcTARGETTODAY,
                               _drainTARGETTODAY,_masticTARGETTODAY,_shoulderTARGETTODAY,_cdworkTARGETTODAY,_BridgeTARGETTODAY,_protectionTARGETTODAY,_bolderpitchTARGETTODAY,_comment,_bridgecomment ,_EntryBy,_updatedBy,_Date,
            _EWpdate,_GSBpdate,_wbmpdate,_busgpdate,_bmpdate,_dbmpdate,_primerpdate,_teakpdate,_sdbcpdate,_pccpdate,_dlcpdate,_pqcpdate,_drainpdate,_masticpdate,_shoulderpdate,_cdworkpdate,_Bridgepdate,
            _protectionpdate,_bolderpitchpdate,_image1,_image2,_imgdesc1,_imgdesc2,descriptiontype1,descriptiontype2});
            if(dt.Rows.Count>0)        

            {
                checktext();
                Response.Redirect("ProjectEntryDetails.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Physical Progress Saved Successfully.');", true);

                return;


            }
        }
        catch (Exception ex)
        {

        }
    }
   
    protected string GetUploadFile2(FileUpload ControlName, string FileName)
    {
        // File Upload Function.......
        string tid = Convert.ToString(Request.QueryString["TargetID"]);
       
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
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                if (ControlName.PostedFile.ContentLength > (1024 * 1024))
                {
                    Utility.showMessage(this, "File size must not exceed 1 MB");
                    return "0";
                }
                string serverFileName = string.Empty;
                string uploadDirectory = string.Empty;

                uploadDirectory = "~/PMIS/PhysicalProgressImages/";


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

    private void cleardata()
    {
        txt_EW.Text = "";
        txt_GSB.Text = "";
        txt_WBM.Text = "";
        txt_BUSG.Text = "";
        txt_BM.Text = "";
        txt_DBM.Text = "";
        txt_PRIMER.Text = "";
        txt_TEAK.Text = "";
        txt_SDBC.Text = "";
        txt_PCC.Text = "";
        txt_DLC.Text = "";
        txt_PQC.Text = "";
        txt_DRAIN.Text = "";
        txt_MASTIC.Text = "";
        txt_SHOULDER.Text = "";
        txt_CDWork.Text = "";
        txt_Bridge.Text = "";
        txt_Protection.Text = "";
        txt_Bolder.Text = "";
        txt_c_EW.Text = "";
        txt_c_GSB.Text = "";
        txt_c_WBM.Text = "";
        txt_c_BUSG.Text = "";
        txt_C_BM.Text = "";
        txt_c_DBM.Text = "";
        txt_c_PRIMER.Text = "";
        txt_c_TEAK.Text = "";
        txt_c_SDBC.Text = "";
        txt_c_PCC.Text = "";
        txt_c_DLC.Text = "";
        txt_c_PQC.Text = "";
        txt_c_DRAIN.Text = "";
        txt_c_MASTIC.Text = "";
        txt_c_SHOULDER.Text = "";
        txt_c_CDWORK.Text = "";
        txt_c_Bridge.Text = "";
        txt_c_Protection.Text = "";
        txt_c_Bolder.Text = "";
        txt_EW_Date.Text = "";
        txt_GSB_Date.Text = "";
        txt_WBM_Date.Text = "";
        txt_BUSG_Date.Text = "";
        txt_BM_Date.Text = "";
        txt_DBM_Date.Text = "";
        txt_PRIMER_Date.Text = "";
        txt_TEAK_Date.Text = "";
        txt_SDBC_Date.Text = "";
        txt_PCC_Date.Text = "";
        txt_DLC_Date.Text = "";
        txt_PQC_Date.Text = "";
        txt_DRAIN_Date.Text = "";
        txt_MASTIC_Date.Text = "";
        txt_SHOULDER_Date.Text = "";
        txt_CDWork_Date.Text = "";
        txt_Bridge_Date.Text = "";
        txt_Protection_Date.Text = "";
        txt_Bolder_Date.Text = "";
        txt_Comment.Text = "";
        txtbridge_Comment.Text = "";
        txt_EW.Focus();

    }

    public void checkvalidationoftextbox()
    {
        try
        {
            if (float.Parse(txt_EW_Date.Text) > float.Parse(lbl_EW.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today EW Value Is Not Greater than EW Target.');", true);
                txt_EW_Date.Focus();
                txt_EW_Date.Text = "0";
                txt_EW_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_GSB_Date.Text) > float.Parse(lbl_GSB.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today GSB Value Is Not Greater than GSB Target.');", true);
                txt_GSB_Date.Focus();
                txt_GSB_Date.Text = "0";
                txt_GSB_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_WBM_Date.Text) > float.Parse(lbl_WBM.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today WBM/WMM Value Is Not Greater than WBM/WMM Target.');", true);
                txt_WBM_Date.Focus();
                txt_WBM_Date.Text = "0";
                txt_WBM_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_BUSG_Date.Text) > float.Parse(lbl_BUSG.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today BUSG Value Is Not Greater than BUSG Target.');", true);
                txt_BUSG_Date.Focus();
                txt_BUSG_Date.Text = "0";
                txt_BUSG_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_BM_Date.Text) > float.Parse(lbl_BM.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today BM Value Is Not Greater than BM Target.');", true);
                txt_BM_Date.Focus();
                txt_BM_Date.Text = "0";
                txt_BM_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_DBM_Date.Text) > float.Parse(lbl_DBM.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today DBM Value Is Not Greater than DBM Target.');", true);
                txt_DBM_Date.Focus();
                txt_DBM_Date.Text = "0";
                txt_DBM_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_PRIMER_Date.Text) > float.Parse(lbl_PRIMER.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today PRIMER Value Is Not Greater than PRIMER Target.');", true);
                txt_PRIMER_Date.Focus();
                txt_PRIMER_Date.Text = "0";
                txt_PRIMER_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_TEAK_Date.Text) > float.Parse(lbl_TEAK.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today TEAK Value Is Not Greater than TEAK Target.');", true);
                txt_TEAK_Date.Focus();
                txt_TEAK_Date.Text = "0";
                txt_TEAK_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_SDBC_Date.Text) > float.Parse(lbl_SDBC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today SDBC Value Is Not Greater than SDBC Target.');", true);
                txt_SDBC_Date.Focus();
                txt_SDBC_Date.Text = "0";
                txt_SDBC_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_PCC_Date.Text) > float.Parse(lbl_PCC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today PCC Value Is Not Greater than PCC Target.');", true);
                txt_PCC_Date.Focus();
                txt_PCC_Date.Text = "0";
                txt_PCC_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_DLC_Date.Text) > float.Parse(lbl_DLC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today DLC Value Is Not Greater than DLC Target.');", true);
                txt_DLC_Date.Focus();
                txt_DLC_Date.Text = "0";
                txt_DLC_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_PQC_Date.Text) > float.Parse(lbl_PQC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today PQC Value Is Not Greater than PQC Target.');", true);
                txt_PQC_Date.Focus();
                txt_PQC_Date.Text = "0";
                txt_PQC_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }
            else if (float.Parse(txt_DRAIN_Date.Text) > float.Parse(lbl_DRAIN.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today DRAIN Value Is Not Greater than DRAIN Target.');", true);
                txt_DRAIN_Date.Focus();
                txt_DRAIN_Date.Text = "0";
                txt_DRAIN_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_MASTIC_Date.Text) > float.Parse(lbl_MASTIC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today MASTIC Value Is Not Greater than MASTIC Target.');", true);
                txt_MASTIC_Date.Focus();
                txt_MASTIC_Date.Text = "0";
                txt_MASTIC_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_CDWork_Date.Text) > float.Parse(lbl_CDWork.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today CDWORK Value Is Not Greater than CDWORK Target.');", true);
                txt_CDWork_Date.Focus();
                txt_CDWork_Date.Text = "0";
                txt_CDWork_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }
            else if (float.Parse(txt_Bridge_Date.Text) > float.Parse(lbl_Bridge.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today Bridge Value Is Not Greater than Bridge Target.');", true);
                txt_Bridge_Date.Focus();
                txt_Bridge_Date.Text = "0";
                txt_Bridge_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_Protection_Date.Text) > float.Parse(lbl_Protection.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today PROTECTION Value Is Not Greater than PROTECTION Target.');", true);
                txt_Protection_Date.Focus();
                txt_Protection_Date.Text = "0";
                txt_Protection_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }

            else if (float.Parse(txt_Bolder_Date.Text) > float.Parse(lbl_Bolder.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Today BOLDER Value Is Not Greater than BOLDER Target.');", true);
                txt_Bolder_Date.Focus();
                txt_Bolder_Date.Text = "0";
                txt_Bolder_Date.BackColor = System.Drawing.Color.LightYellow;
                return;
            }



            else
            {
                txt_EW_Date.BackColor = System.Drawing.Color.White;
                txt_GSB_Date.BackColor = System.Drawing.Color.White;
                txt_WBM_Date.BackColor = System.Drawing.Color.White;
                txt_BUSG_Date.BackColor = System.Drawing.Color.White;
                txt_BM_Date.BackColor = System.Drawing.Color.White;
                txt_DBM_Date.BackColor = System.Drawing.Color.White;
                txt_PRIMER_Date.BackColor = System.Drawing.Color.White;
                txt_TEAK_Date.BackColor = System.Drawing.Color.White;
                txt_SDBC_Date.BackColor = System.Drawing.Color.White;
                txt_PCC_Date.BackColor = System.Drawing.Color.White;
                txt_DLC_Date.BackColor = System.Drawing.Color.White;
                txt_PQC_Date.BackColor = System.Drawing.Color.White;
                txt_DRAIN_Date.BackColor = System.Drawing.Color.White;
                txt_MASTIC_Date.BackColor = System.Drawing.Color.White;
                txt_CDWork_Date.BackColor = System.Drawing.Color.White;
                txt_Bridge_Date.BackColor = System.Drawing.Color.White;
                txt_Protection_Date.BackColor = System.Drawing.Color.White;
                txt_Bolder_Date.BackColor = System.Drawing.Color.White;
            }
        }
        catch(Exception ex)
        {

        }


           
      

            
       
       
    }

    private void checktext()
    {
        txt_EW_Date.Text = "0";
        txt_GSB_Date.Text = "0";
        txt_WBM_Date.Text = "0";
        txt_BUSG_Date.Text = "0";
        txt_BM_Date.Text = "0";
        txt_DBM_Date.Text = "0";
        txt_PRIMER_Date.Text = "0";
        txt_TEAK_Date.Text = "0";
        txt_SDBC_Date.Text = "0";
        txt_PCC_Date.Text = "0";
        txt_DLC_Date.Text = "0";
        txt_PQC_Date.Text = "0";
        txt_DRAIN_Date.Text = "0";
        txt_MASTIC_Date.Text = "0";
        txt_SHOULDER_Date.Text = "0";
        txt_CDWork_Date.Text = "0";
        txt_Bridge_Date.Text = "0";
        txt_Protection_Date.Text = "0";
        txt_Bolder_Date.Text = "0";
       

    }

    protected void txt_EW_Date_TextChanged(object sender, EventArgs e)
    {
        
        checkvalidationoftextbox();
        try
        {
            if (txt_EW.Text == "")
            {

                txt_EW.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_EW.Text.Trim());
            double num2 = Convert.ToDouble(txt_EW_Date.Text.Trim());
            double total = num1 + num2;
           // double FinalTotal = Convert.ToDouble(txt_EW.Text) + total;
            txt_EW.Text = total.ToString();

          

            if (Convert.ToDouble(txt_EW.Text) > Convert.ToDouble(lbl_EW.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('EW Cumulative Value Is Equal To Target EW Value.So You Dont Add Today Target..');", true);
                txt_EW_Date.Text = "0";
              //  txt_EW_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

    }

    protected void txt_GSB_Date_TextChanged(object sender, EventArgs e)
    {
        checkvalidationoftextbox();
        try
        {
            if (txt_GSB.Text == "")
            {

                txt_GSB.Text = "0";
            }

           

            double num1 = Convert.ToDouble(txt_GSB.Text.Trim());
            double num2 = Convert.ToDouble(txt_GSB_Date.Text.Trim());
            double total = num1 + num2;
            txt_GSB.Text = total.ToString();
            if (Convert.ToDouble(txt_GSB.Text) > Convert.ToDouble(lbl_GSB.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('GSB Cumulative Value Is Equal To Target GSB Value.So You Dont Add Today Target..');", true);
                txt_GSB_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

       
    }

    protected void txt_WBM_Date_TextChanged(object sender, EventArgs e)
    {
        

        try
        {
            checkvalidationoftextbox();
            if (txt_WBM.Text == "")
            {

                txt_WBM.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_WBM.Text.Trim());
            double num2 = Convert.ToDouble(txt_WBM_Date.Text.Trim());
            double total = num1 + num2;
            txt_WBM.Text = total.ToString();

            if (Convert.ToDouble(txt_WBM.Text) > Convert.ToDouble(lbl_WBM.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('WBM/WMM Cumulative Value Is Equal To Target WBM/WMM Value.So You Dont Add Today Target..');", true);
                txt_WBM_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

       
    }

    protected void txt_BUSG_Date_TextChanged(object sender, EventArgs e)
    {
        

        try
        {
            checkvalidationoftextbox();
            if (txt_BUSG.Text == "")
            {

                txt_BUSG.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_BUSG.Text.Trim());
            double num2 = Convert.ToDouble(txt_BUSG_Date.Text.Trim());
            double total = num1 + num2;
            txt_BUSG.Text = total.ToString();
            if (Convert.ToDouble(txt_BUSG.Text) > Convert.ToDouble(lbl_BUSG.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' BUSG Cumulative Value Is Equal To Target BUSG Value.So You Dont Add Today Target..');", true);
                txt_BUSG_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
      

       
    }

    protected void txt_BM_Date_TextChanged(object sender, EventArgs e)
    {
        

        try
        {
            checkvalidationoftextbox();
            if (txt_BM.Text == "")
            {

                txt_BM.Text = "0";
            }

            double num1 = Convert.ToDouble(txt_BM.Text.Trim());
            double num2 = Convert.ToDouble(txt_BM_Date.Text.Trim());
            double total = num1 + num2;
            txt_BM.Text = total.ToString();

            if (Convert.ToDouble(txt_BM.Text) > Convert.ToDouble(lbl_BM.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' BM Cumulative Value Is Equal To Target BM Value.So You Dont Add Today Target..');", true);
                txt_BM_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
    }

    protected void txt_DBM_Date_TextChanged(object sender, EventArgs e)
    {
      

        try
        {
            checkvalidationoftextbox();
            if (txt_DBM.Text == "")
            {

                txt_DBM.Text = "0";
            }

            double num1 = Convert.ToDouble(txt_DBM.Text.Trim());
            double num2 = Convert.ToDouble(txt_DBM_Date.Text.Trim());
            double total = num1 + num2;
            txt_DBM.Text = total.ToString();

            if (Convert.ToDouble(txt_DBM.Text) > Convert.ToDouble(lbl_DBM.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' DBM Cumulative Value Is Equal To Target DBM Value.So You Dont Add Today Target..');", true);
                txt_DBM_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       


       
    }

    protected void txt_PRIMER_Date_TextChanged(object sender, EventArgs e)
    {
       

        try
        {
            checkvalidationoftextbox();
            if (txt_PRIMER.Text == "")
            {

                txt_PRIMER.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_PRIMER.Text.Trim());
            double num2 = Convert.ToDouble(txt_PRIMER_Date.Text.Trim());
            double total = num1 + num2;
            txt_PRIMER.Text = total.ToString();

            if (Convert.ToDouble(txt_PRIMER.Text) > Convert.ToDouble(lbl_PRIMER.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' PRIMER COAT Cumulative Value Is Equal To Target PRIMER COAT Value.So You Dont Add Today Target..');", true);
                txt_PRIMER_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

      
    }

    protected void txt_TEAK_Date_TextChanged(object sender, EventArgs e)
    {
       

        try
        {
            checkvalidationoftextbox();
            if (txt_TEAK.Text == "")
            {

                txt_TEAK.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_TEAK.Text.Trim());
            double num2 = Convert.ToDouble(txt_TEAK_Date.Text.Trim());
            double total = num1 + num2;
            txt_TEAK.Text = total.ToString();

            if (Convert.ToDouble(txt_TEAK.Text) > Convert.ToDouble(lbl_TEAK.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' TEAK COAT Cumulative Value Is Equal To Target TEAK COAT Value.So You Dont Add Today Target..');", true);
                txt_TEAK_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       
       
    }

    protected void txt_SDBC_Date_TextChanged(object sender, EventArgs e)
    {
        

        try
        {
            checkvalidationoftextbox();
            if (txt_SDBC.Text == "")
            {

                txt_SDBC.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_SDBC.Text.Trim());
            double num2 = Convert.ToDouble(txt_SDBC_Date.Text.Trim());
            double total = num1 + num2;
            txt_SDBC.Text = total.ToString();

            if (Convert.ToDouble(txt_SDBC.Text) > Convert.ToDouble(lbl_SDBC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' SDBC Cumulative Value Is Equal To Target SDBC Value.So You Dont Add Today Target..');", true);
                txt_SDBC_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
         catch(Exception ex)
        {

        }
    }

    protected void txt_PCC_Date_TextChanged(object sender, EventArgs e)
    {
       

        try
        {
            checkvalidationoftextbox();
            if (txt_PCC.Text == "")
            {

                txt_PCC.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_PCC.Text.Trim());
            double num2 = Convert.ToDouble(txt_PCC_Date.Text.Trim());
            double total = num1 + num2;
            txt_PCC.Text = total.ToString();

            if (Convert.ToDouble(txt_PCC.Text) > Convert.ToDouble(lbl_PCC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' PCC Cumulative Value Is Equal To Target PCC Value.So You Dont Add Today Target..');", true);
                txt_PCC_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {
           
        }
       
       
    }

    protected void txt_DLC_Date_TextChanged(object sender, EventArgs e)
    {
       
        try
        {
            checkvalidationoftextbox();
            if (txt_DLC.Text == "")
            {

                txt_DLC.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_DLC.Text.Trim());
            double num2 = Convert.ToDouble(txt_DLC_Date.Text.Trim());
            double total = num1 + num2;
            txt_DLC.Text = total.ToString();

            if (Convert.ToDouble(txt_DLC.Text) > Convert.ToDouble(lbl_DLC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert(' DLC Cumulative Value Is Equal To Target DLC Value.So You Dont Add Today Target..');", true);
                txt_DLC_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       
       
    }

    protected void txt_PQC_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_PQC.Text == "")
            {

                txt_PQC.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_PQC.Text.Trim());
            double num2 = Convert.ToDouble(txt_PQC_Date.Text.Trim());
            double total = num1 + num2;
            txt_PQC.Text = total.ToString();

            if (Convert.ToDouble(txt_PQC.Text) > Convert.ToDouble(lbl_PQC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PQC Cumulative Value Is Equal To Target PQC Value.So You Dont Add Today Target..');", true);
                txt_PQC_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }

        

    }

    protected void txt_DRAIN_Date_TextChanged(object sender, EventArgs e)
    {

        try
        {
            checkvalidationoftextbox();
            if (txt_DRAIN.Text == "")
            {

                txt_DRAIN.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_DRAIN.Text.Trim());
            double num2 = Convert.ToDouble(txt_DRAIN_Date.Text.Trim());
            double total = num1 + num2;
            txt_DRAIN.Text = total.ToString();

            if (Convert.ToDouble(txt_DRAIN.Text) > Convert.ToDouble(lbl_DRAIN.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('DRAIN Cumulative Value Is Equal To Target DRAIN Value.So You Dont Add Today Target..');", true);
                txt_DRAIN_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

    }

    protected void txt_MASTIC_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_MASTIC.Text == "")
            {

                txt_MASTIC.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_MASTIC.Text.Trim());
            double num2 = Convert.ToDouble(txt_MASTIC_Date.Text.Trim());
            double total = num1 + num2;
            txt_MASTIC.Text = total.ToString();

            if (Convert.ToDouble(txt_MASTIC.Text) > Convert.ToDouble(lbl_MASTIC.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('MASTIC ASPHALT Cumulative Value Is Equal To Target MASTIC ASPHALT Value.So You Dont Add Today Target..');", true);
                txt_MASTIC_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

    }

    protected void txt_SHOULDER_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_SHOULDER.Text == "")
            {

                txt_SHOULDER.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_SHOULDER.Text.Trim());
            double num2 = Convert.ToDouble(txt_SHOULDER_Date.Text.Trim());
            double total = num1 + num2;
            txt_SHOULDER.Text = total.ToString();

            if (Convert.ToDouble(txt_SHOULDER.Text) > Convert.ToDouble(lbl_SHOULDER.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('SHOULDER Cumulative Value Is Equal To SHOULDER Value.So You Dont Add Today Target..');", true);
                txt_SHOULDER_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
      

    }

    protected void txt_CDWork_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_CDWork.Text == "")
            {

                txt_CDWork.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_CDWork.Text.Trim());
            double num2 = Convert.ToDouble(txt_CDWork_Date.Text.Trim());
            double total = num1 + num2;
            txt_CDWork.Text = total.ToString();

            if (Convert.ToDouble(txt_CDWork.Text) > Convert.ToDouble(lbl_CDWork.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CD WORK Cumulative Value Is Equal To CD WORK Value.So You Dont Add Today Target..');", true);
                txt_CDWork_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

    }
    protected void txt_Bridge_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_Bridge.Text == "")
            {

                txt_Bridge.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_Bridge.Text.Trim());
            double num2 = Convert.ToDouble(txt_Bridge_Date.Text.Trim());
            double total = num1 + num2;
            txt_Bridge.Text = total.ToString();

            if (Convert.ToDouble(txt_Bridge.Text) > Convert.ToDouble(lbl_Bridge.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Bridge Cumulative Value Is Equal To Bridge Value.So You Dont Add Today Target..');", true);
                txt_Bridge_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch (Exception ex)
        {

        }


    }

    protected void txt_Protection_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_Protection.Text == "")
            {

                txt_Protection.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_Protection.Text.Trim());
            double num2 = Convert.ToDouble(txt_Protection_Date.Text.Trim());
            double total = num1 + num2;
            txt_Protection.Text = total.ToString();
            if (Convert.ToDouble(txt_Protection.Text) > Convert.ToDouble(lbl_Protection.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PROTECTION WORK Cumulative Value Is Equal To PROTECTION WORK Value.So You Dont Add Today Target..');", true);
                txt_Protection_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
      

    }

    protected void txt_Bolder_Date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            checkvalidationoftextbox();
            if (txt_Bolder.Text == "")
            {

                txt_Bolder.Text = "0";
            }
            double num1 = Convert.ToDouble(txt_Bolder.Text.Trim());
            double num2 = Convert.ToDouble(txt_Bolder_Date.Text.Trim());
            double total = num1 + num2;
            txt_Bolder.Text = total.ToString();

            if (Convert.ToDouble(txt_Bolder.Text) > Convert.ToDouble(lbl_Bolder.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('BOLDER PITCH WORK Cumulative Value Is Equal To BOLDER PITCH Value.So You Dont Add Today Target..');", true);
                txt_Bolder_Date.Text = "0";
                //txt_GSB_Date.Enabled = false;
                return;
            }
        }
        catch(Exception ex)
        {

        }
       

    }

    //protected void btn_update_Click(object sender, EventArgs e)
    //{

    //}
    //private void BindGrid()
    //{
    //    try
    //    {
    //        string tid = Convert.ToString(Request.QueryString["TargetID"]);
    //        SqlParameter _Tragetid = new SqlParameter("@TargetId", tid);
            

    //        DataTable dt = cls.GetDataTableSp("Sp_Get_PhysicalprogressPreviousupdatertp", new SqlParameter[] {
    //            _Tragetid
    //        });
    //        // DataTable dt = cls.GetDataTable(sql);
    //        if (dt.Rows.Count > 0)
    //        {

                
    //            grdEistingRecord.DataSource = dt;
    //            grdEistingRecord.DataBind();
    //            lblerror.Visible = false;
               


    //        }
    //        else
    //        {
    //            grdEistingRecord.DataSource = null;                
    //            lblerror.Visible = true;
                              
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //}
    //protected void btn_rtp_Click(object sender, EventArgs e)
    //{
       
    //    pnlrtp.Visible = true;
    //    pnlmain.Visible = false;
    //    BindGrid();
    //}


    
}