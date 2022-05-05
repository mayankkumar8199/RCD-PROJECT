using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RCDPMISNEW_Common_ViewProjectEntry : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            ViewState["tid"] = Convert.ToString(Request.QueryString["TargetID"]);
            bindgraph();
            if ((Session["Role"]) == null)
            {
                Response.Redirect("~/PMIS/Login.aspx");
            }
            else
            {
                loadData();
               
                loaddescriptiontype();
            }

        }
    }

    protected void loadData()
    {
        try
        {
            string ProjectNo = Convert.ToString(Request.QueryString["Projectno"]);
            SqlParameter _projectid = new SqlParameter("@ProjectNo", ProjectNo);
            DataTable dt = cls.GetDataTableSp("sp_get_ProjectEntryReport", new SqlParameter[] { _projectid });
            if (dt.Rows.Count > 0)
            {
                lbl_prno.Text = dt.Rows[0]["Projectno"].ToString();
                lbl_project_name.Text = dt.Rows[0]["ProjectName"].ToString();
                lbl_head_name.Text = dt.Rows[0]["headName"].ToString();
                lbl_sub_head.Text = dt.Rows[0]["SubHeadName"].ToString();
                lblroadtype.Text = dt.Rows[0]["description"].ToString();
                lblroadname.Text = dt.Rows[0]["Name_of_the_Road"].ToString();
                lblnatureofwork.Text = dt.Rows[0]["NatOfWorkName"].ToString();
                lblworktype.Text = dt.Rows[0]["WSTypeName"].ToString();
                lbl_length_of_section.Text = dt.Rows[0]["SanctionRoadLength"].ToString();
                lbl_admin_approvalamt.Text = dt.Rows[0]["AAamount"].ToString();
                lbl_adminaproval_refno.Text = dt.Rows[0]["AArefno"].ToString();
                lbl_adminaprovaldate.Text = dt.Rows[0]["AADate"].ToString();
                lblstartdate.Text = dt.Rows[0]["StartDate"].ToString();
                lblenddate.Text = dt.Rows[0]["EndDate"].ToString();

                lblcontractor.Text = dt.Rows[0]["ContractorInProject"].ToString();
                lblagrementamt.Text = dt.Rows[0]["AgreementAmount"].ToString();

                lblworkprogram.Text = dt.Rows[0]["WorkProgramSubmitted"].ToString();
                lblstatus.Text = dt.Rows[0]["status"].ToString();
                if (dt.Rows[0]["status"].ToString() == "Completed")
                {
                    divcompletion.Visible = true;
                    lblcomplectiondate.Text = dt.Rows[0]["Completiondate"].ToString();
                    lblcomplectioncertificate.Text = dt.Rows[0]["CompletionCertificate"].ToString();

                }
                else {
                    divcompletion.Visible = false;
                    lblcomplectiondate.Text = "";
                    lblcomplectioncertificate.Text = "";
                }
             

            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void btn_Back_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }

    protected void bindgraph()
    {

        try
        {
            if (ViewState["tid"].ToString() != "")
            {

                SqlParameter _tid = new SqlParameter("@TargetID", ViewState["tid"].ToString());
                DataTable dt = cls.GetDataTableSp("sp_get_Physicalprogress", new SqlParameter[] { _tid });
                if (dt.Rows.Count > 0)
                {

                    charttxt.Titles.Add("Physical Progress Graph");
                    Chart1.Titles.Add("Physical Progress Graph");
                    // charttxt.Series["s1"].IsValueShownAsLabel = true;
                    charttxt.Series["Achieved"].IsValueShownAsLabel = true;
                    // charttxt.Series["Target"].IsValueShownAsLabel = true;
                    charttxt.Series["Target"].LabelAngle = 5;


                    charttxt.Series["Target"].Points.AddXY("E/W", dt.Rows[0]["EW"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("E/W", dt.Rows[0]["EW_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("GSB", dt.Rows[0]["GSB"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("GSB", dt.Rows[0]["GSB_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("WBM/WMM", dt.Rows[0]["WBM"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("WBM/WMM", dt.Rows[0]["WBM_WMM_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("BUSG", dt.Rows[0]["BUSG"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("BUSG", dt.Rows[0]["BUSG_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("BM", dt.Rows[0]["BM"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("BM", dt.Rows[0]["BM_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("DBM", dt.Rows[0]["DBM"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("DBM", dt.Rows[0]["DBM_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("PRIMER", dt.Rows[0]["PrimerCoat"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("PRIMER", dt.Rows[0]["PRIMER_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("TEAK COAT", dt.Rows[0]["TeakCoat"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("TEAK COAT", dt.Rows[0]["TEAK_CUMULATIVE"].ToString());

                    charttxt.Series["Target"].Points.AddXY("SDBC/BC/PMC", dt.Rows[0]["SDBC_BC_PMC"].ToString());
                    charttxt.Series["Achieved"].Points.AddXY("SDBC/BC/PMC", dt.Rows[0]["SDBC_CUMULATIVE"].ToString());


                    // Chart1.Series["s3"].IsValueShownAsLabel = true;
                    Chart1.Series["Achieved"].IsValueShownAsLabel = true;
                    Chart1.Series["Target"].Points.AddXY("PCC", dt.Rows[0]["PCC"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("PCC", dt.Rows[0]["PCC_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("DLC", dt.Rows[0]["DLC"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("DLC", dt.Rows[0]["DLC_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("PQC", dt.Rows[0]["PQC"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("PQC", dt.Rows[0]["PQC_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("DRAIN", dt.Rows[0]["Drain"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("DRAIN", dt.Rows[0]["DRAIN_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("MASTIC ASPHALT", dt.Rows[0]["Mastic_Asphalt"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("MASTIC ASPHALT", dt.Rows[0]["MASTIC_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("SHOULDER", dt.Rows[0]["Shoulder"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("SHOULDER", dt.Rows[0]["SHOULDER_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("CD Works", dt.Rows[0]["CDWork"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("CD Works", dt.Rows[0]["CDWORK_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("Protection Work", dt.Rows[0]["Protection_Work"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("Protection Work", dt.Rows[0]["PROTECTION_CUMULATIVE"].ToString());

                    Chart1.Series["Target"].Points.AddXY("Bolder Pitch", dt.Rows[0]["Bolder_Pitch"].ToString());
                    Chart1.Series["Achieved"].Points.AddXY("Bolder Pitch", dt.Rows[0]["BOLDER_CUMULATIVE"].ToString());

                }

            }
            else 
            {
                charttxt.Titles.Add("Physical Progress Graph");
                Chart1.Titles.Add("Physical Progress Graph");
                // charttxt.Series["s1"].IsValueShownAsLabel = true;
                charttxt.Series["Achieved"].IsValueShownAsLabel = true;
                // charttxt.Series["Target"].IsValueShownAsLabel = true;
                charttxt.Series["Target"].LabelAngle = 5;


                charttxt.Series["Target"].Points.AddXY("E/W", 0);
                charttxt.Series["Achieved"].Points.AddXY("E/W", 0);

                charttxt.Series["Target"].Points.AddXY("GSB",0);
                charttxt.Series["Achieved"].Points.AddXY("GSB", 0);

                charttxt.Series["Target"].Points.AddXY("WBM/WMM", 0);
                charttxt.Series["Achieved"].Points.AddXY("WBM/WMM", 0);

                charttxt.Series["Target"].Points.AddXY("BUSG", 0);
                charttxt.Series["Achieved"].Points.AddXY("BUSG", 0);

                charttxt.Series["Target"].Points.AddXY("BM", 0);
                charttxt.Series["Achieved"].Points.AddXY("BM", 0);

                charttxt.Series["Target"].Points.AddXY("DBM", 0);
                charttxt.Series["Achieved"].Points.AddXY("DBM", 0);

                charttxt.Series["Target"].Points.AddXY("PRIMER", 0);
                charttxt.Series["Achieved"].Points.AddXY("PRIMER", 0);

                charttxt.Series["Target"].Points.AddXY("TEAK COAT", 0);
                charttxt.Series["Achieved"].Points.AddXY("TEAK COAT", 0);

                charttxt.Series["Target"].Points.AddXY("SDBC/BC/PMC", 0);
                charttxt.Series["Achieved"].Points.AddXY("SDBC/BC/PMC", 0);


                // Chart1.Series["s3"].IsValueShownAsLabel = true;
                Chart1.Series["Achieved"].IsValueShownAsLabel = true;
                Chart1.Series["Target"].Points.AddXY("PCC",0);
                Chart1.Series["Achieved"].Points.AddXY("PCC", 0);

                Chart1.Series["Target"].Points.AddXY("DLC", 0);
                Chart1.Series["Achieved"].Points.AddXY("DLC", 0);

                Chart1.Series["Target"].Points.AddXY("PQC", 0);
                Chart1.Series["Achieved"].Points.AddXY("PQC", 0);

                Chart1.Series["Target"].Points.AddXY("DRAIN", 0);
                Chart1.Series["Achieved"].Points.AddXY("DRAIN", 0);

                Chart1.Series["Target"].Points.AddXY("MASTIC ASPHALT", 0);
                Chart1.Series["Achieved"].Points.AddXY("MASTIC ASPHALT", 0);

                Chart1.Series["Target"].Points.AddXY("SHOULDER", 0);
                Chart1.Series["Achieved"].Points.AddXY("SHOULDER", 0);

                Chart1.Series["Target"].Points.AddXY("CD Works", 0);
                Chart1.Series["Achieved"].Points.AddXY("CD Works", 0);

                Chart1.Series["Target"].Points.AddXY("Protection Work", 0);
                Chart1.Series["Achieved"].Points.AddXY("Protection Work", 0);

                Chart1.Series["Target"].Points.AddXY("Bolder Pitch", 0);
                Chart1.Series["Achieved"].Points.AddXY("Bolder Pitch", 0);

            }
            
        }
        catch (Exception ex)
        {

        }


    }


    void loaddescriptiontype()
    {
     
        string ProjectNo = Convert.ToString(Request.QueryString["Projectno"]);
        SqlParameter _projectid = new SqlParameter("@ProjectNo", ProjectNo);
        string sql = @"select descriptiontype1,id FROM [dbo].[mst_SetTarget] where ProjectNo=@ProjectNo and descriptiontype1 is not null and descriptiontype1 <> '---Select Road Component---'";
        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { _projectid });
            if (dt.Rows.Count > 0)
            {
                pnlimage.Visible = true;
                ddlimageshow.DataSource = dt;
                ddlimageshow.DataTextField = "descriptiontype1";
                ddlimageshow.DataValueField = "id";
                ddlimageshow.DataBind();
                ddlimageshow.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Road Component--", "0"));
              

            
            }

    }
    protected void ddlimageshow_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string ProjectNo = Convert.ToString(Request.QueryString["Projectno"]);
            SqlParameter _projectid = new SqlParameter("@ProjectNo", ProjectNo);
            SqlParameter _ddlimageshow = new SqlParameter("@Id", ddlimageshow.SelectedValue.ToString());

            string sql = @"select descriptiontype1,id ,[Image1_Description]
      ,[Image2_Description],[IMAGE1]
      ,[IMAGE2] FROM [dbo].[mst_SetTarget] where ProjectNo=@ProjectNo and Id=@Id and descriptiontype1 is not null";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { _projectid, _ddlimageshow });
            if (dt.Rows.Count > 0)
            {
                lblDescription2.Focus();
                pnldesc.Visible = true;
                lblDescription1.Visible = true;
                lblDescription2.Visible = true;
                lblDescription1.Text = dt.Rows[0]["Image1_Description"].ToString();
                lblDescription2.Text = dt.Rows[0]["Image2_Description"].ToString();
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
            }
           
            bindgraph();
          

        }
        catch (Exception ex)
        {

        }
    }
}