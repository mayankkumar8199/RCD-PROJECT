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

public partial class RCDPMISNEW_Common_ProjectEntryDetails : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string sqlQuery = string.Empty;
    Encryptor enc = new Encryptor(Encryptor.PrivateKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["WingID"] == null) || (Session["CircleID"] == null) || (Session["DivisionID"] == null))
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("~/PMIS/Login.aspx");
            }
            else
            {
                //ViewState["Projectno"]="";
                //ViewState["LengthOfSanctionRoad"] = "";
                chechtextdataisblankornot();
                BindGrid();

            }
            
        }
        
    }


    private void BindGrid()
    {
        try
        {

            string strWhere = string.Empty;
            string divid = Convert.ToString(Session["DivisionID"]);
            SqlParameter _divid = new SqlParameter("@divid", divid);
            DataTable dt = cls.GetDataTableSp("Sp_Get_ProjectDetails", new SqlParameter[] { _divid });
            if (dt.Rows.Count > 0)
            {
                grdEistingRecord.DataSource = dt;
                grdEistingRecord.DataBind();
                //lblerror.Visible = false;
                //pnl.Visible = true;

            }
            else
            {
                grdEistingRecord.DataSource = null;
                //grdEistingRecord.DataBind();
                //lblerror.Visible = true;
                //pnl.Visible = false;


                // ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Record Found..');", true);

            }
        }
        catch (Exception ex)
        {
        }



    }


    protected void btn_Project_Entry_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProjectEntry.aspx");
    }


    protected void lnkSetTarget_Click(object sender, EventArgs e)
    {
        ////string _targetid = Request.QueryString["TargetID"];
        ////string tid = _targetid;

      


        pnl_main_search.Visible = false;
        LinkButton lnkSetTarget = (LinkButton)sender;

        GridViewRow gvr = (GridViewRow)lnkSetTarget.NamingContainer;
        string Projectno = grdEistingRecord.DataKeys[gvr.RowIndex].Values["Projectno"].ToString();
        string TargetId = grdEistingRecord.DataKeys[gvr.RowIndex].Values["TargetID"].ToString();
        ViewState["Projectno"] = Projectno;
        lnkSetTarget.Visible = false;
        pnlWTarget.Visible = true;
       //// pnlGrd.Visible = false;
        lblProject.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + ViewState["Projectno"].ToString() + "");
        iblProjNo.Text = " / " +ViewState["Projectno"].ToString();    
        if(ViewState["Projectno"].ToString()==null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }

        BindTarget();

        
//        string sql = @"SELECT  SetTarget.ProjectNo, SetTarget.TargetID, SetTarget.WingID, SetTarget.DivisionId, SetTarget.CircleID, SetTarget.EW, SetTarget.WBM, SetTarget.GSB, SetTarget.BUSG, 
//                      SetTarget.BM, SetTarget.DBM, SetTarget.SDBC_BC_PMC, SetTarget.PCC, SetTarget.CDWork,SetTarget.Bridge, SetTarget.CDTypeID, SetTarget.BMType, SetTarget.EntryBy, 
//                      SetTarget.EntryDate, SetTarget.Size, SetTarget.SpanLength, CDType.CDTypeName, SetTarget.PrimerCoat, SetTarget.TeakCoat,
//SetTarget.BridgeLength,SetTarget.DLC,SetTarget.PQC,SetTarget.DRAIN,SetTarget.Mastic_Asphalt,SetTarget.Shoulder,SetTarget.Protection_Work,SetTarget.Bolder_Pitch,pm.SanctionRoadLength
//FROM         SetTarget left outer JOIN
//                      CDType ON SetTarget.CDTypeID = CDType.CDTypeID 
//inner join ProjectMaster pm on pm.Projectno=SetTarget.ProjectNo
//where pm.ProjectNo='" + ViewState["Projectno"].ToString() + "' and pm.DivisionID=" + Session["DivisionID"].ToString() + " ";
        SqlParameter projctno = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString());
        SqlParameter DivisionID = new SqlParameter("@DivisionID", Session["DivisionID"].ToString());
        DataTable dtcheck = cls.GetDataTableSp("SP_Get_cdworksdetails", new SqlParameter[] { projctno, DivisionID });
        if (dtcheck.Rows.Count > 0)
        {
            string sanctionRoad = dtcheck.Rows[0]["SanctionRoadLength"].ToString();
            ////float sroadlength = float.Parse(sanctionRoad);
            txtEW.Text = dtcheck.Rows[0]["EW"].ToString();
            txtWBM.Text = dtcheck.Rows[0]["WBM"].ToString();
            txtGSB.Text = dtcheck.Rows[0]["GSB"].ToString();
            txtBUSG.Text = dtcheck.Rows[0]["BUSG"].ToString();
            txtBM.Text = dtcheck.Rows[0]["BM"].ToString();
            txtDBM.Text = dtcheck.Rows[0]["DBM"].ToString();
            txtSDBC.Text = dtcheck.Rows[0]["SDBC_BC_PMC"].ToString();
            txtPCC.Text = dtcheck.Rows[0]["PCC"].ToString();
            txtCDWork.Text = dtcheck.Rows[0]["CDTypeNo"].ToString();

            txtbridge.Text = dtcheck.Rows[0]["Bridgeno"].ToString();
            // ddlCD.SelectedValue = dtcheck.Rows[0]["CDTypeID"].ToString();
            txtPriCoat.Text = dtcheck.Rows[0]["PrimerCoat"].ToString();
            txtTeakCoat.Text = dtcheck.Rows[0]["TeakCoat"].ToString();
            // txtSize.Text = dtcheck.Rows[0]["Size"].ToString();
            // txtSpanLen.Text = dtcheck.Rows[0]["SpanLength"].ToString();
            //txtBridgeLen.Text = dtcheck.Rows[0]["BridgeLength"].ToString();

            txtDLC.Text = dtcheck.Rows[0]["DLC"].ToString();
            txtPQC.Text = dtcheck.Rows[0]["PQC"].ToString();
            txtDrain.Text = dtcheck.Rows[0]["DRAIN"].ToString();
            txtmasticasphalt.Text = dtcheck.Rows[0]["Mastic_Asphalt"].ToString();
            txtshoulder.Text = dtcheck.Rows[0]["Shoulder"].ToString();
            txtprotectionwok.Text = dtcheck.Rows[0]["Protection_Work"].ToString();
            txtbolderpitch.Text = dtcheck.Rows[0]["Bolder_Pitch"].ToString();
            //if (ddlCD.SelectedValue == "4")
            //{
            //    Label10.Visible = true;
            //    Label11.Visible = true;
            //    txtSize.Visible = true;
            //    txtSpanLen.Visible = true;
            //    Label12.Visible = true;
            //    Label18.Visible = true;
            //    Label17.Visible = true;
            //    txtBridgeLen.Visible = true;
            //}
            //else
            //{
            //    Label10.Visible = false;
            //    Label11.Visible = false;
            //    txtSize.Visible = false;
            //    txtSpanLen.Visible = false;
            //    Label12.Visible = false;
            //    Label18.Visible = false;
            //    txtBridgeLen.Visible = false;
            //    Label17.Visible = false;
            //}


            btnTarSave.Text = "Update";
        }
        else
        {
            btnTarSave.Text = "Save";
        }
    }
    void BindTarget()
    {
        try
        {
            SqlParameter _projectno = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString());
            SqlParameter _divid = new SqlParameter("@DivisionID", Convert.ToString(Session["DivisionID"]));
            string qry = @"SELECT     SetTarget.ProjectNo, SetTarget.TargetID, SetTarget.WingID, SetTarget.DivisionId, SetTarget.CircleID, SetTarget.EW, SetTarget.WBM, SetTarget.GSB, SetTarget.BUSG, 
                      SetTarget.BM, SetTarget.DBM, SetTarget.SDBC_BC_PMC, SetTarget.PCC, SetTarget.CDWork, SetTarget.CDTypeID, SetTarget.BMType, SetTarget.EntryBy, 
                      SetTarget.EntryDate, SetTarget.Size, SetTarget.SpanLength, CDType.CDTypeName, SetTarget.PrimerCoat, SetTarget.TeakCoat, SetTarget.BridgeLength
                        FROM  SetTarget INNER JOIN
                      CDType ON SetTarget.CDTypeID = CDType.CDTypeID where ProjectNo=@ProjectNo and DivisionID=@DivisionID  order by TargetID";
                      DataTable dt = cls.GetDataTable(qry, new SqlParameter[] {
                _projectno,_divid
        });

            //gvWrkTarget.DataSource = dt;
            //gvWrkTarget.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void lnkCdType_Click(object sender, EventArgs e)
    {
        try 
        { 
        LinkButton lnkCDType = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lnkCDType.NamingContainer;
        string Projectno = grdEistingRecord.DataKeys[gvr.RowIndex].Values["Projectno"].ToString();
        ViewState["Projectno"] = Projectno;
        lnkCDType.Visible = false;
        pnlCDType.Visible = true;
        pnl_main_search.Visible = false;
        SqlParameter _Projectno = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString());
        //lblCDTypeProjName.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + ViewState["Projectno"].ToString() + "");
        DataTable dt = cls.GetDataTable("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=@ProjectNo", new SqlParameter[] { _Projectno });
        lblCDTypeProjName.Text = dt.Rows[0][0].ToString();
        lblCDTypeProjNo.Text = ViewState["Projectno"].ToString();

        SqlParameter _Projectno1 = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString());
        //lblCDTypeProjName.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + ViewState["Projectno"].ToString() + "");
        DataTable dt1 = cls.GetDataTable("SELECT CDWork FROM SetTarget WHERE ProjectNo=@ProjectNo", new SqlParameter[] { _Projectno1 });
       // ViewState["CDWork"] = dt1.Rows[0][0].ToString();
        loadCDType1();
        BindCDType();
        }
        catch(Exception ex)
        {
        
        }
         }


    protected void lnkOthTarget_Click(object sender, EventArgs e)
    {
       
        LinkButton lnkOthTarget = (LinkButton)sender;
        pnl_main_search.Visible = false;
        GridViewRow gvr = (GridViewRow)lnkOthTarget.NamingContainer;
        string Projectno = grdEistingRecord.DataKeys[gvr.RowIndex].Values["Projectno"].ToString();
        ViewState["Projectnos"] = Projectno;
        lnkOthTarget.Visible = false;
        pnlOtherType.Visible = true;
        pnl_main_search.Visible = false;

        // Label11.Text = cls.ExecuteScalar("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=" + ViewState["Projectnos"].ToString() + "");
        SqlParameter _Projectno = new SqlParameter("@ProjectNo", ViewState["Projectnos"].ToString());
        DataTable dt = cls.GetDataTable("SELECT ProjectName FROM ProjectMaster WHERE ProjectNo=@ProjectNo", new SqlParameter[] { _Projectno });
       Label11.Text = dt.Rows[0][0].ToString();
        Label10.Text = ViewState["Projectnos"].ToString();

        BindOtherType();
    }

    protected void lnkphysicalprgs_Click(object sender, EventArgs e)
    {
        // page redirect to PhysicalProgress page
         //Response.Redirect("PhysicalProgressDetails.aspx");
       // LinkButton lnkphysicalprgs = (LinkButton)sender;
       // pnl_main_search.Visible = false;
       // GridViewRow gvr = (GridViewRow)lnkphysicalprgs.NamingContainer;       
       // string Projectno = grdEistingRecord.DataKeys[gvr.RowIndex].Values["Projectno"].ToString();
       // string targetid = grdEistingRecord.DataKeys[gvr.RowIndex].Values["TargetID"].ToString();
       //// lnkOthTarget.Visible = false;
       // pnlOtherType.Visible = false;
       // pnl_main_search.Visible = false;
       // pnlphysicalprogress.Visible = true;
       
       //// BindTargetforedit(targetid);
       // Bindtargetname();
    }

    

    void UpdateTar()
    {
        try
        {
            chechtextdataisblankornot();
            


            lblsancroad.Text = cls.ExecuteScalar("SELECT SanctionRoadLength FROM ProjectMaster WHERE ProjectNo=" + ViewState["Projectno"].ToString() + "");
          
            if (txtPQC.Text=="" )
            {
                txtPQC.Text = "0";           
                
            }
            if(txtSDBC.Text=="")
            {
                txtSDBC.Text = "0";
            }
            string sdbc = txtSDBC.Text;
            string PCCt = txtPCC.Text;


            string pqc = txtPQC.Text;

           // float Total = float.Parse(sdbc) + float.Parse(PCCt);
            decimal Total = decimal.Parse(sdbc) + decimal.Parse(pqc);
            //string sdbc = txtSDBC.Text;
            //string pqc = txtPQC.Text;

            //float Total = float.Parse(sdbc) + float.Parse(pqc);



            if (!(Total <= decimal.Parse(lblsancroad.Text)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('SDBC/BC/PMCAND PQC IS  Greater Than LENGTH OF SANCTION ROAD - " + lblsancroad.Text + " KM');", true);
                return;
            }
           
            if (float.Parse(txtEW.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('EW is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtWBM.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('WBM is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtGSB.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('GSB is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtBUSG.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('BUSG is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtBM.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('BM is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtDBM.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('DBM is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtSDBC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('SDBC is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtPCC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PCC is not greater than length of sanction road.');", true);
                return;
            }
            //if (float.Parse(txtCDWork.Text) > float.Parse(lblsancroad.Text))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CDWork is not greater than length of sanction road.');", true);
            //    return;
            //}
            if (float.Parse(txtPriCoat.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PriCoat is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtTeakCoat.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('TeakCoat is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtDLC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('DLC is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtPQC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PQC is not greater than length of sanction road.');", true);
                return;
            }
            //if (float.Parse(txtDrain.Text) > float.Parse(lblsancroad.Text))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Drain is not greater than length of sanction road.');", true);
            //    return;
            //}
            if (float.Parse(txtmasticasphalt.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('masticasphalt is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtshoulder.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('shoulder is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtprotectionwok.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('protectionwok is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtbolderpitch.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('bolderpitch is not greater than length of sanction road.');", true);
                return;
            }

            //string TargetID = gvWrkTarget.DataKeys[gvWrkTarget.SelectedIndex].Values["TargetID"].ToString();
            string sql = @"update SetTarget set  EW=@EW, WBM=@WBM, GSB=@GSB, BUSG=@BUSG, BM=@BM, DBM=@DBM, SDBC_BC_PMC=@SDBC_BC_PMC, PCC=@PCC, CDWork=@CDWork,Bridge=@Bridge, 
                                 CDTypeID=@CDTypeID, PrimerCoat=@PrimerCoat, TeakCoat=@TeakCoat, Size=@Size, SpanLength=@SpanLength, BridgeLength=@BridgeLength, UpdateDate=@UpdateDate,
                                UpdateBy=@UpdateBy,DLC=@DLC,PQC=@PQC,DRAIN=@DRAIN,Mastic_Asphalt=@Mastic_Asphalt,Shoulder=@Shoulder,Protection_Work=@Protection_Work, Bolder_Pitch=@Bolder_Pitch  where ProjectNo=@ProjectNo and DivisionID=@DivisionID";

            //SqlParameter ProjectNo = new SqlParameter("@ProjectNo", txtProject.Text.Trim());

            SqlParameter _projectno = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString());
            SqlParameter _divid = new SqlParameter("@DivisionID", Convert.ToString(Session["DivisionID"]));

            SqlParameter EW = new SqlParameter("@EW", string.IsNullOrEmpty(txtEW.Text.Trim()) ? DBNull.Value : (object)txtEW.Text.Trim());
            SqlParameter WBM = new SqlParameter("@WBM", string.IsNullOrEmpty(txtWBM.Text.Trim()) ? DBNull.Value : (object)txtWBM.Text.Trim());
            SqlParameter GSB = new SqlParameter("@GSB", string.IsNullOrEmpty(txtGSB.Text.Trim()) ? DBNull.Value : (object)txtGSB.Text.Trim());
            SqlParameter BUSG = new SqlParameter("@BUSG", string.IsNullOrEmpty(txtBUSG.Text.Trim()) ? DBNull.Value : (object)txtBUSG.Text.Trim());
            SqlParameter BM = new SqlParameter("@BM", string.IsNullOrEmpty(txtBM.Text.Trim()) ? DBNull.Value : (object)txtBM.Text.Trim());

            SqlParameter DBM = new SqlParameter("@DBM", string.IsNullOrEmpty(txtDBM.Text.Trim()) ? DBNull.Value : (object)txtDBM.Text.Trim());
            SqlParameter SDBC_BC_PMC = new SqlParameter("@SDBC_BC_PMC", string.IsNullOrEmpty(txtSDBC.Text.Trim()) ? DBNull.Value : (object)txtSDBC.Text.Trim());
            SqlParameter PCC = new SqlParameter("@PCC", string.IsNullOrEmpty(txtPCC.Text.Trim()) ? DBNull.Value : (object)txtPCC.Text.Trim());
            SqlParameter CDWork = new SqlParameter("@CDWork", string.IsNullOrEmpty(txtCDWork.Text.Trim()) ? DBNull.Value : (object)txtCDWork.Text.Trim());
            SqlParameter Bridge = new SqlParameter("@Bridge", string.IsNullOrEmpty(txtbridge.Text.Trim()) ? DBNull.Value : (object)txtbridge.Text.Trim());
            SqlParameter CDTypeID = new SqlParameter("@CDTypeID", "0");
            SqlParameter PrimerCoat = new SqlParameter("@PrimerCoat", string.IsNullOrEmpty(txtPriCoat.Text.Trim()) ? DBNull.Value : (object)txtPriCoat.Text.Trim());
            SqlParameter TeakCoat = new SqlParameter("@TeakCoat", string.IsNullOrEmpty(txtTeakCoat.Text.Trim()) ? DBNull.Value : (object)txtTeakCoat.Text.Trim());

            //    SqlParameter Size = new SqlParameter("@Size", string.IsNullOrEmpty(txtSize.Text.Trim()) ? DBNull.Value : (object)txtSize.Text.Trim());

            SqlParameter Size = null;

            Size = new SqlParameter("@Size", DBNull.Value);


            SqlParameter SpanLength = null;

            SpanLength = new SqlParameter("@SpanLength", DBNull.Value);

            SqlParameter BridgeLength = null;

            BridgeLength = new SqlParameter("@BridgeLength", DBNull.Value);


            //SqlParameter BrdgeLength = new SqlParameter("@BrdgeLength", string.IsNullOrEmpty(txtBridgeLen.Text.Trim()) ? DBNull.Value : (object)txtBridgeLen.Text.Trim());
            SqlParameter UpdateDate = new SqlParameter("@UpdateDate", DateTime.Now);
            SqlParameter UpdateBy = new SqlParameter("@UpdateBy", User.Identity.Name);

            SqlParameter DLC = new SqlParameter("@DLC", string.IsNullOrEmpty(txtDLC.Text.Trim()) ? DBNull.Value : (object)txtDLC.Text.Trim());
            SqlParameter PQC = new SqlParameter("@PQC", string.IsNullOrEmpty(txtPQC.Text.Trim()) ? DBNull.Value : (object)txtPQC.Text.Trim());
            SqlParameter DRAIN = new SqlParameter("@DRAIN", string.IsNullOrEmpty(txtDrain.Text.Trim()) ? DBNull.Value : (object)txtDrain.Text.Trim());
            SqlParameter Mastic_Asphalt = new SqlParameter("@Mastic_Asphalt", string.IsNullOrEmpty(txtmasticasphalt.Text.Trim()) ? DBNull.Value : (object)txtmasticasphalt.Text.Trim());
            SqlParameter Shoulder = new SqlParameter("@Shoulder", string.IsNullOrEmpty(txtshoulder.Text.Trim()) ? DBNull.Value : (object)txtshoulder.Text.Trim());
            SqlParameter Protection_Work = new SqlParameter("@Protection_Work", string.IsNullOrEmpty(txtprotectionwok.Text.Trim()) ? DBNull.Value : (object)txtprotectionwok.Text.Trim());
            SqlParameter Bolder_Pitch = new SqlParameter("@Bolder_Pitch", string.IsNullOrEmpty(txtbolderpitch.Text.Trim()) ? DBNull.Value : (object)txtbolderpitch.Text.Trim());


            if (cls.ExecuteSql(sql, new SqlParameter[] { _projectno, _divid, EW, WBM, GSB, BUSG, BM, DBM, SDBC_BC_PMC, PCC, CDWork,Bridge, CDTypeID, PrimerCoat, TeakCoat, Size, SpanLength, BridgeLength, UpdateDate, UpdateBy, DLC, PQC, DRAIN, Mastic_Asphalt, Shoulder, Protection_Work, Bolder_Pitch }) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Target updated successfully.');", true);

                // lblMsg.Text = "Target updated successfully.";
                // clear();
                //loadProject(false);
                return;
            }
        }
        catch (Exception ex)
        { }
    }
    void InsertTar()
    {

        try
        {
           


            lblsancroad.Text = cls.ExecuteScalar("SELECT SanctionRoadLength FROM ProjectMaster WHERE ProjectNo=" + ViewState["Projectno"].ToString() + "");

            string sdbc = txtSDBC.Text.Trim();
            string pqc = txtPQC.Text.Trim();
           // double Total = Convert.ToDouble(sdbc) + Convert.ToDouble(pqc);
            decimal Total = decimal.Parse(sdbc) + decimal.Parse(pqc);

           // float Total = float.Parse("3.1");


            if (!(Total <= decimal.Parse(lblsancroad.Text)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('SDBC/BC/PMCAND PQC IS  Greater Than LENGTH OF SANCTION ROAD - " + lblsancroad.Text + " KM');", true);                
                return;
            }
            if( float.Parse(txtEW.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('EW is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtWBM.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('WBM is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtGSB.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('GSB is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtBUSG.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('BUSG is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtBM.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('BM is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtDBM.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('DBM is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtSDBC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('SDBC is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtPCC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PCC is not greater than length of sanction road.');", true);
                return;
            }
            //if (float.Parse(txtCDWork.Text) > float.Parse(lblsancroad.Text))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CDWork is not greater than length of sanction road.');", true);
            //    return;
            //}
            if (float.Parse(txtPriCoat.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PriCoat is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtTeakCoat.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('TeakCoat is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtDLC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('DLC is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtPQC.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('PQC is not greater than length of sanction road.');", true);
                return;
            }
            //if (float.Parse(txtDrain.Text) > float.Parse(lblsancroad.Text))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Drain is not greater than length of sanction road.');", true);
            //    return;
            //}
            if (float.Parse(txtmasticasphalt.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('masticasphalt is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtshoulder.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('shoulder is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtprotectionwok.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('protectionwok is not greater than length of sanction road.');", true);
                return;
            }
            if (float.Parse(txtbolderpitch.Text) > float.Parse(lblsancroad.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('bolderpitch is not greater than length of sanction road.');", true);
                return;
            }



            sqlQuery = @"INSERT INTO SetTarget( ProjectNo, WingID, DivisionID, CircleID, EW, WBM, GSB, BUSG, BM, DBM, SDBC_BC_PMC, PCC, CDWork,Bridge, CDTypeID, PrimerCoat, TeakCoat, Size, SpanLength, BridgeLength, EntryBy,DLC,PQC,DRAIN,Mastic_Asphalt,Shoulder,Protection_Work,Bolder_Pitch)
                            VALUES(@ProjectNo, @WingID, @DivisionID, @CircleID, @EW, @WBM, @GSB, @BUSG, @BM, @DBM, @SDBC_BC_PMC, @PCC, @CDWork,@Bridge, @CDTypeID, @PrimerCoat, @TeakCoat, @Size, @SpanLength, @BridgeLength, @EntryBy,@DLC,@PQC,@DRAIN,@Mastic_Asphalt,@Shoulder,@Protection_Work,@Bolder_Pitch)";

            SqlParameter ProjectNo = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString().Trim());
            SqlParameter WingID = new SqlParameter("@WingID", Session["WingID"].ToString().Trim());
            SqlParameter CircleID = new SqlParameter("@CircleID", Session["CircleID"].ToString().Trim());
            SqlParameter DivisionID = new SqlParameter("@DivisionID", Session["DivisionID"].ToString().Trim());
            SqlParameter EW = new SqlParameter("@EW", string.IsNullOrEmpty(txtEW.Text.Trim()) ? DBNull.Value : (object)txtEW.Text.Trim());
            SqlParameter WBM = new SqlParameter("@WBM", string.IsNullOrEmpty(txtWBM.Text.Trim()) ? DBNull.Value : (object)txtWBM.Text.Trim());
            SqlParameter GSB = new SqlParameter("@GSB", string.IsNullOrEmpty(txtGSB.Text.Trim()) ? DBNull.Value : (object)txtGSB.Text.Trim());
            SqlParameter BUSG = new SqlParameter("@BUSG", string.IsNullOrEmpty(txtBUSG.Text.Trim()) ? DBNull.Value : (object)txtBUSG.Text.Trim());
            SqlParameter BM = new SqlParameter("@BM", string.IsNullOrEmpty(txtBM.Text.Trim()) ? DBNull.Value : (object)txtBM.Text.Trim());

            SqlParameter DBM = new SqlParameter("@DBM", string.IsNullOrEmpty(txtDBM.Text.Trim()) ? DBNull.Value : (object)txtDBM.Text.Trim());
            SqlParameter SDBC_BC_PMC = new SqlParameter("@SDBC_BC_PMC", string.IsNullOrEmpty(txtSDBC.Text.Trim()) ? DBNull.Value : (object)txtSDBC.Text.Trim());
            SqlParameter PCC = new SqlParameter("@PCC", string.IsNullOrEmpty(txtPCC.Text.Trim()) ? DBNull.Value : (object)txtPCC.Text.Trim());
            SqlParameter CDWork = new SqlParameter("@CDWork", string.IsNullOrEmpty(txtCDWork.Text.Trim()) ? DBNull.Value : (object)txtCDWork.Text.Trim());
            SqlParameter Bridge = new SqlParameter("@Bridge", string.IsNullOrEmpty(txtbridge.Text.Trim()) ? DBNull.Value : (object)txtbridge.Text.Trim());
            SqlParameter CDTypeID = new SqlParameter("@CDTypeID", "");

            SqlParameter PrimerCoat = new SqlParameter("@PrimerCoat", string.IsNullOrEmpty(txtPriCoat.Text.Trim()) ? DBNull.Value : (object)txtPriCoat.Text.Trim());
            SqlParameter TeakCoat = new SqlParameter("@TeakCoat", string.IsNullOrEmpty(txtTeakCoat.Text.Trim()) ? DBNull.Value : (object)txtTeakCoat.Text.Trim());

            SqlParameter Size = new SqlParameter("@Size", "0");
            SqlParameter SpanLength = new SqlParameter("@SpanLength", "0");
            SqlParameter BridgeLength = new SqlParameter("@BridgeLength", "0");
            SqlParameter EntryBy = new SqlParameter("@EntryBy", User.Identity.Name);

            SqlParameter DLC = new SqlParameter("@DLC", string.IsNullOrEmpty(txtDLC.Text.Trim()) ? DBNull.Value : (object)txtDLC.Text.Trim());
            SqlParameter PQC = new SqlParameter("@PQC", string.IsNullOrEmpty(txtPQC.Text.Trim()) ? DBNull.Value : (object)txtPQC.Text.Trim());
            SqlParameter DRAIN = new SqlParameter("@DRAIN", string.IsNullOrEmpty(txtDrain.Text.Trim()) ? DBNull.Value : (object)txtDrain.Text.Trim());
            SqlParameter Mastic_Asphalt = new SqlParameter("@Mastic_Asphalt", string.IsNullOrEmpty(txtmasticasphalt.Text.Trim()) ? DBNull.Value : (object)txtmasticasphalt.Text.Trim());
            SqlParameter Shoulder = new SqlParameter("@Shoulder", string.IsNullOrEmpty(txtshoulder.Text.Trim()) ? DBNull.Value : (object)txtshoulder.Text.Trim());
            SqlParameter Protection_Work = new SqlParameter("@Protection_Work", string.IsNullOrEmpty(txtprotectionwok.Text.Trim()) ? DBNull.Value : (object)txtprotectionwok.Text.Trim());
            SqlParameter Bolder_Pitch = new SqlParameter("@Bolder_Pitch", string.IsNullOrEmpty(txtbolderpitch.Text.Trim()) ? DBNull.Value : (object)txtbolderpitch.Text.Trim());

            //,DLC,PQC,DRAIN

            if (cls.ExecuteSql(sqlQuery, new SqlParameter[] { ProjectNo, WingID, DivisionID, CircleID, EW, WBM, GSB, BUSG, BM, DBM, SDBC_BC_PMC, PCC, CDWork,Bridge, CDTypeID, PrimerCoat, TeakCoat, Size, SpanLength, BridgeLength, EntryBy, DLC, PQC, DRAIN, Mastic_Asphalt, Shoulder, Protection_Work, Bolder_Pitch }) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Target Are Saved Successfully.');", true);
                // ClearTar();
                return;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnTarSave_Click(object sender, EventArgs e)
    {
        //string roadid = Request.QueryString["SanctionRoadLength"].ToString();
        //string sanroadlength = roadid.ToString();

        SqlParameter _projectno = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString());
        SqlParameter _divid = new SqlParameter("@DivisionID", Convert.ToString(Session["DivisionID"]));
        string sql = @"SELECT  TargetID FROM SetTarget where ProjectNo=@ProjectNo and DivisionID=@DivisionID ";        
        DataTable dtcheck = cls.GetDataTable(sql, new SqlParameter[] {
                _projectno,_divid
        });
        if (dtcheck.Rows.Count > 0)
        {
            UpdateTar();

        }
        else
        {
            InsertTar();
        }
    }


    protected void btnTarUpdate_Click(object sender, EventArgs e)
    {
       // UpdateTar();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }

    //CD Work Type code..

    protected void gvCDType_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            // Button2.Enabled = true;
            // btnCDDelete.Enabled = true;
            string slno = gvCDType.DataKeys[gvCDType.SelectedIndex].Values["slno"].ToString();
            string qry = @" SELECT  slno, ProjectNo, CDTypeID, CDTypeNo,Size,SpanLengh,lengh FROM  CDWork where slno='" + slno + "'";
            DataTable dt = cls.GetDataTable(qry);
            if (dt.Rows.Count > 0)
            {

                ddlCDType.Text = dt.Rows[0]["CDTypeID"].ToString();
                txtCdTypeNo.Text = dt.Rows[0]["CDTypeNo"].ToString();
                txtcdSize.Text = dt.Rows[0]["Size"].ToString();
                txtSpanLength.Text = dt.Rows[0]["SpanLengh"].ToString();
                txtLength.Text = dt.Rows[0]["lengh"].ToString();

                Button1.Visible = false;
                Button2.Visible = true;
                btnCDDelete.Visible = true;

            }
        }
        catch (Exception ex)
        {

        }



        if (ddlCDType.SelectedValue == "4" || ddlCDType.SelectedValue == "6")
        {
            lblCdTypeNo.Visible = true;
            txtCdTypeNo.Visible = true;
            lblcdSize.Visible = true;
            txtcdSize.Visible = true;
            lblSpanLength.Visible = true;
            txtSpanLength.Visible = true;
            lblLength.Visible = true;
            txtLength.Visible = true;
            lblInM.Visible = true;
            lblInKM.Visible = true;

        }
        else
        {
            lblCdTypeNo.Visible = true;
            txtCdTypeNo.Visible = true;
            lblcdSize.Visible = false;
            txtcdSize.Visible = false;
            lblSpanLength.Visible = false;
            txtSpanLength.Visible = false;
            lblLength.Visible = false;
            txtLength.Visible = false;
            lblInM.Visible = false;
            lblInKM.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        InsertCDTypeData();
    }
    protected void InsertCDTypeData()
    {
        try
        {
            //if (ddlCDType.SelectedValue == "4")
            //{
            //    if (txtCdTypeNo.Text == "" || txtcdSize.Text == "" || txtSpanLength.Text == "" || txtLength.Text == "")
            //    {
            //        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Enter blank field...');", true);
            //    }
            //    else
            //    {
                    sqlQuery = @"INSERT INTO CDWork(CDTypeID, CDTypeNo, Size, SpanLengh, lengh,ProjectNo) VALUES(@CDTypeID, @CDTypeNo, @Size, @SpanLengh, @lengh,@ProjectNo)";

                    SqlParameter CDTypeID = new SqlParameter("@CDTypeID", ddlCDType.SelectedValue);
                    SqlParameter CDTypeNo = new SqlParameter("@CDTypeNo", string.IsNullOrEmpty(txtCdTypeNo.Text.Trim()) ? DBNull.Value : (object)txtCdTypeNo.Text.Trim());
                    SqlParameter Size = new SqlParameter("@Size", string.IsNullOrEmpty(txtcdSize.Text.Trim()) ? DBNull.Value : (object)txtcdSize.Text.Trim());
                    //SqlParameter Size = new SqlParameter("@Size", txtcdSize.Text.Trim());
                    SqlParameter SpanLengh = new SqlParameter("@SpanLengh", txtSpanLength.Text.Trim());
                    SqlParameter lengh = new SqlParameter("@lengh", txtLength.Text.Trim());
                    SqlParameter ProjectNo = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString().Trim());

                    if (cls.ExecuteSql(sqlQuery, new SqlParameter[] { CDTypeID, CDTypeNo,Size, SpanLengh, lengh, ProjectNo }) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CD Type Work Details Saved Successfully.');", true);
                        CleareAll();
                        // loadProject(true);
                        BindGrid();
                        BindCDType();
                    }
                //}
           // }
            else
            {
                //if (txtCdTypeNo.Text == "")
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Please Enter CD Type No...');", true);
                //}
                //else
                //{

                //    if (ddlCDType.SelectedValue == "3" || ddlCDType.SelectedValue == "1" || ddlCDType.SelectedValue == "2")
                //    {
                //        //ViewState["CDWork"].ToString()

                //        if (Convert.ToInt32(txtCdTypeNo.Text) > Convert.ToInt32(ViewState["CDWork"]))
                //        {
                //            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Exceeding the CD Work Limit...');", true);
                //            return;
                //        }
                //    }
                    sqlQuery = @"INSERT INTO CDWork(CDTypeID, CDTypeNo, Size, SpanLengh, lengh,ProjectNo) VALUES(@CDTypeID, @CDTypeNo, @Size, @SpanLengh, @lengh,@ProjectNo)";

                    SqlParameter CDTypeIDD = new SqlParameter("@CDTypeID", ddlCDType.SelectedValue);
                    SqlParameter CDTypeNoa = new SqlParameter("@CDTypeNo", txtCdTypeNo.Text.Trim());
                    SqlParameter Sizee = new SqlParameter("@Size", "0");
                    //SqlParameter Size = new SqlParameter("@Size", txtcdSize.Text.Trim());
                    SqlParameter SpanLenghh = new SqlParameter("@SpanLengh", "0");
                    SqlParameter lenghh = new SqlParameter("@lengh", "0");
                    SqlParameter ProjectNoo = new SqlParameter("@ProjectNo", ViewState["Projectno"].ToString().Trim());

                    if (cls.ExecuteSql(sqlQuery, new SqlParameter[] { CDTypeIDD, CDTypeNoa, Sizee, SpanLenghh, lenghh, ProjectNoo }) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CD Type Work Details Saved Successfully.');", true);
                        CleareAll();
                        // loadProject(true);
                        BindGrid();
                        BindCDType();
                    }
                }
           // }
        }
        catch (Exception ex)
        { }
    }
    protected void CleareAll()
    {
        txtCdTypeNo.Text = "";
        txtcdSize.Text = "";
        txtSpanLength.Text = "";
        txtLength.Text = "";
    }
    string SdId;
    protected void Button2_Click(object sender, EventArgs e)
    {
        UpdateCDType();
        
    }
    void UpdateCDType()
    {
        try
        {
            string CdSrNo = gvCDType.DataKeys[gvCDType.SelectedIndex].Values["slno"].ToString();
            SqlParameter _cdsrno = new SqlParameter("@CDWorkno", CdSrNo);
        

            //int updaterecordd = cls.ExecuteSql(sql, new SqlParameter[] { _cdsrno });
            //if (updaterecordd > 0)
           
            //string qry = @" SELECT CDWork.slno,CDWork.CDTypeID, CDWork.CDTypeNo, CDWork.Size, CDWork.SpanLengh, CDWork.lengh, CDType.CDTypeName
            //                FROM   CDWork INNER JOIN
            //          CDType ON CDWork.CDTypeID = CDType.CDTypeID where CDWork.slno='" + CdSrNo + "'";

            string qry = @" SELECT CDWork.slno,CDWork.CDTypeID, CDWork.CDTypeNo, CDWork.Size, CDWork.SpanLengh, CDWork.lengh, CDType.CDTypeName
                            FROM   CDWork INNER JOIN
                      CDType ON CDWork.CDTypeID = CDType.CDTypeID where CDWork.slno=@CDWorkno";

            DataTable dt = cls.GetDataTable(qry, new SqlParameter[] { _cdsrno });

            if (dt.Rows.Count > 0)
            {
                SdId = dt.Rows[0]["CDTypeID"].ToString();

                if (SdId == "4" || SdId=="6")
                {
                    SqlParameter CDTypeNo = new SqlParameter("@CDTypeNo", txtCdTypeNo.Text.Trim());
                    SqlParameter Size = new SqlParameter("@Size", txtcdSize.Text.Trim());
                    SqlParameter SpanLengh = new SqlParameter("@SpanLengh", txtSpanLength.Text.Trim());
                    SqlParameter lengh = new SqlParameter("@lengh", txtLength.Text.Trim());
                     string sql = @"update CDWork set  CDTypeNo=@CDTypeNo, Size=@Size, SpanLengh=@SpanLengh, lengh=@lengh  where slno='" + CdSrNo + "'";
                    if (cls.ExecuteSql(sql, new SqlParameter[] { CDTypeNo, Size, SpanLengh, lengh }) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CD Type updated successfully.');", true);
                        // lblMsg.Text = "CD Type updated successfully.";
                        // clear();
                        //loadProject(false);
                        BindCDType();
                        CleareAll();
                        Button2.Visible = false;
                        btnCDDelete.Visible = false;
                        // // btnSave.Visible = true;
                        return;
                    }
                }
                else
                {
                    //if (SdId == "3" || SdId == "1" || SdId=="2")
                    //{
                      
                    //    if (Convert.ToInt32(txtCdTypeNo.Text) > Convert.ToInt32(ViewState["CDWork"]))
                    //    {
                    //        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Exceeding the CD Work Limit...');", true);
                    //        return;
                    //    }
                    //}
                    SqlParameter CDTypeNo = new SqlParameter("@CDTypeNo", txtCdTypeNo.Text.Trim());
                    SqlParameter Size = new SqlParameter("@Size", "0");
                    SqlParameter SpanLengh = new SqlParameter("@SpanLengh", "0");
                    SqlParameter lengh = new SqlParameter("@lengh", "0");
                      string sql = @"update CDWork set  CDTypeNo=@CDTypeNo, Size=@Size, SpanLengh=@SpanLengh, lengh=@lengh  where slno='" + CdSrNo + "'";
                    if (cls.ExecuteSql(sql, new SqlParameter[] { CDTypeNo, Size, SpanLengh, lengh }) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CD Type updated successfully.');", true);
                        // lblMsg.Text = "CD Type updated successfully.";
                        // clear();
                        //loadProject(false);
                        BindCDType();
                        CleareAll();
                        Button2.Enabled = false;
                        btnCDDelete.Enabled = false;
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnCDDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string CdSrNo = gvCDType.DataKeys[gvCDType.SelectedIndex].Values["slno"].ToString();

            SqlParameter cdrno = new SqlParameter("@slno", CdSrNo);

            //string sql = @"delete from CDWork  where slno='" + CdSrNo + "'";
            string sql = @"delete from CDWork  where slno=@slno";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { cdrno });
            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('CD Type Delete successfully.');", true);
            BindCDType();
            CleareAll();
            loadCDType1();
            txtcdSize.Visible = false;
            txtSpanLength.Visible = false;
            txtLength.Visible = false;
            lblCdTypeNo.Visible = false;
            txtCdTypeNo.Visible = false;

            lblcdSize.Visible = false;
            lblLength.Visible = false;
            lblSpanLength.Visible = false;
            lblInKM.Visible = false;
            lblInM.Visible = false;
            Button2.Visible = false;
            btnCDDelete.Visible = false;
        }
        catch (Exception ex)
        { }
    }
    void BindCDType()
    {
        try
        {
            string qry = @" SELECT CDWork.slno,CDWork.CDTypeID, CDWork.CDTypeNo, CDWork.Size, CDWork.SpanLengh, CDWork.lengh, CDType.CDTypeName
                            FROM   CDWork INNER JOIN
                      CDType ON CDWork.CDTypeID = CDType.CDTypeID where CDWork.ProjectNo='" + ViewState["Projectno"].ToString() + "' order by CDTypeName desc";
            DataTable dt = cls.GetDataTable(qry);
            gvCDType.DataSource = dt;
            gvCDType.DataBind();
        }
        catch (Exception ex)
        { }
    }
    private void loadCDType1()
    {
        try
        {
            sqlQuery = @"SELECT  CDTypeID, CDTypeName FROM CDType where CDTypeID not in (5) order by CDTypeName";
            DataTable dt = cls.GetDataTable(sqlQuery);
            ddlCDType.DataSource = dt;
            ddlCDType.DataValueField = "CDTypeID";
            ddlCDType.DataTextField = "CDTypeName";
            ddlCDType.DataBind();
            ddlCDType.Items.Insert(0, new ListItem("-Select-", "0"));
            ddlCDType.SelectedValue = "0";
        }
        catch (Exception ex)
        { }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }




    protected void ddlCDType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCDType.SelectedValue == "4")
        {
            lblCdTypeNo.Visible = true;
            txtCdTypeNo.Visible = true;
            lblcdSize.Visible = true;
            txtcdSize.Visible = true;
            lblSpanLength.Visible = true;
            txtSpanLength.Visible = true;
            lblLength.Visible = true;
            txtLength.Visible = true;
            lblInM.Visible = true;
            lblInKM.Visible = true;

        }
        else if (ddlCDType.SelectedValue == "6") {

            lblCdTypeNo.Visible = true;
            txtCdTypeNo.Visible = true;
            lblcdSize.Visible = true;
            txtcdSize.Visible = true;
            lblSpanLength.Visible = true;
            txtSpanLength.Visible = true;
            lblLength.Visible = true;
            txtLength.Visible = true;
            lblInM.Visible = true;
            lblInKM.Visible = true;
        
        
        }
        else
        {
            lblCdTypeNo.Visible = true;
            txtCdTypeNo.Visible = true;
            lblcdSize.Visible = false;
            txtcdSize.Visible = false;
            lblSpanLength.Visible = false;
            txtSpanLength.Visible = false;
            lblLength.Visible = false;
            txtLength.Visible = false;
            lblInM.Visible = false;
            lblInKM.Visible = false;
        }
    }
    // other target
    protected void gvOthType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // Button2.Enabled = true;
            // btnCDDelete.Enabled = true;
            string slno = gvOthType.DataKeys[gvOthType.SelectedIndex].Values["slno"].ToString();
            string qry = @" SELECT  slno, ProjectNo, OthType_Name, OthType_No FROM  OtherType_Target where slno='" + slno + "'";
            DataTable dt = cls.GetDataTable(qry);
            if (dt.Rows.Count > 0)
            {

                txtOthTypeName.Text = dt.Rows[0]["OthType_Name"].ToString();
                txtOthType_No.Text = dt.Rows[0]["OthType_No"].ToString();

                btnOth_Save.Visible = false;
                btnOth_Update.Visible = true;
                btnOth_Delete.Visible = true;

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnOth_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectEntryDetails.aspx");
    }

    protected void btnOth_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            string slno = gvOthType.DataKeys[gvOthType.SelectedIndex].Values["slno"].ToString();
            string sql = @"delete from OtherType_Target  where slno='" + slno + "'";
            DataTable dt = cls.GetDataTable(sql);
            ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Deleted successfully.');", true);
            BindOtherType();
            txtOthTypeName.Text = "";
            txtOthType_No.Text = "";
            btnOth_Save.Visible = true;
            btnOth_Update.Visible = false;
            btnOth_Delete.Visible = false;
        }
        catch (Exception ex)
        { }
    }

    void BindOtherType()
    {
        try
        {
            string qry = @"SELECT  slno, ProjectNo, OthType_Name, OthType_No FROM  OtherType_Target where ProjectNo='" + ViewState["Projectnos"].ToString() + "' order by OthType_Name";
            DataTable dt = cls.GetDataTable(qry);
            gvOthType.DataSource = dt;
            gvOthType.DataBind();
        }
        catch (Exception ex)
        { }
    }

    protected void btnOth_Update_Click(object sender, EventArgs e)
    {
        try
        {
            string slno = gvOthType.DataKeys[gvOthType.SelectedIndex].Values["slno"].ToString();
            string sql = @"update OtherType_Target set  OthType_Name=@OthType_Name, OthType_No=@OthType_No where slno=" + slno + " ";

            //SqlParameter ProjectNo = new SqlParameter("@ProjectNo", txtProject.Text.Trim());


            SqlParameter OthType_Name = new SqlParameter("@OthType_Name", string.IsNullOrEmpty(txtOthTypeName.Text.Trim()) ? DBNull.Value : (object)txtOthTypeName.Text.Trim());
            SqlParameter OthType_No = new SqlParameter("@OthType_No", string.IsNullOrEmpty(txtOthType_No.Text.Trim()) ? DBNull.Value : (object)txtOthType_No.Text.Trim());

            if (cls.ExecuteSql(sql, new SqlParameter[] { OthType_Name, OthType_No }) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Other Target Updated Successfully.');", true);
                Label25.Text = "Other Target Updated Successfully.";
                txtOthTypeName.Text = "";
                txtOthType_No.Text = "";
                BindOtherType();
                return;
            }
        }
        catch (Exception ex)
        { }
    }


    protected void btnOth_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = @"insert into OtherType_Target (ProjectNo, OthType_Name, OthType_No) VALUES(@ProjectNo, @OthType_Name, @OthType_No) ";

            SqlParameter ProjectNo = new SqlParameter("@ProjectNo", ViewState["Projectnos"].ToString().Trim());
            SqlParameter OthType_Name = new SqlParameter("@OthType_Name", string.IsNullOrEmpty(txtOthTypeName.Text.Trim()) ? DBNull.Value : (object)txtOthTypeName.Text.Trim());
            SqlParameter OthType_No = new SqlParameter("@OthType_No", string.IsNullOrEmpty(txtOthType_No.Text.Trim()) ? DBNull.Value : (object)txtOthType_No.Text.Trim());

            if (cls.ExecuteSql(sql, new SqlParameter[] { ProjectNo, OthType_Name, OthType_No }) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msgSuccAdm", "alert('Other Target Saved Successfully.');", true);
                Label25.Text = "Other Target Saved Successfully.";
                txtOthTypeName.Text = "";
                txtOthType_No.Text = "";
                BindOtherType();
                return;
            }
        }
        catch (Exception ex)
        { }
    }


    protected void grdEistingRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEistingRecord.PageIndex = e.NewPageIndex;
        grdEistingRecord.DataBind();
        BindGrid();
    }

    protected void grdtarget_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DataTable dt1 = (DataTable)ViewState["TargetDetails"];

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string TargetName = grdtarget.DataKeys[e.Row.RowIndex].Values["TargetName"].ToString();
        //    //DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlDepartment");
        //}
    }


    private void chechtextdataisblankornot()
    {
        if(txtbolderpitch.Text=="")
        {
            txtbolderpitch.Text = "0";
        }
        if (txtprotectionwok.Text == "")
        {
            txtprotectionwok.Text = "0";
        }
        if (txtCDWork.Text == "")
        {
            txtCDWork.Text = "0";
        }
        if (txtbridge.Text == "")
        {
            txtbridge.Text = "0";
        }
        if (txtshoulder.Text == "")
        {
            txtshoulder.Text = "0";
        }
        if (txtmasticasphalt.Text == "")
        {
            txtmasticasphalt.Text = "0";
        }
        if (txtDrain.Text == "")
        {
            txtDrain.Text = "0";
        }
        if (txtPQC.Text == "")
        {
            txtPQC.Text = "0";
        }

        if (txtDLC.Text == "")
        {
            txtDLC.Text = "0";
        }
        if (txtPCC.Text == "")
        {
            txtPCC.Text = "0";
        }
        if (txtSDBC.Text == "")
        {
            txtSDBC.Text = "0";
        }
        if (txtTeakCoat.Text == "")
        {
            txtTeakCoat.Text = "0";
        }
        if (txtPriCoat.Text == "")
        {
            txtPriCoat.Text = "0";
        }
        if (txtDBM.Text == "")
        {
            txtDBM.Text = "0";
        }
        if (txtBM.Text == "")
        {
            txtBM.Text = "0";
        }
        if (txtBUSG.Text == "")
        {
            txtBUSG.Text = "0";
        }
        if (txtWBM.Text == "")
        {
            txtWBM.Text = "0";
        }
        if (txtGSB.Text == "")
        {
            txtGSB.Text = "0";
        }
        if (txtEW.Text == "")
        {
            txtEW.Text = "0";
        }



    }
    protected void lnkFinancial_Click(object sender, EventArgs e)
    {
        try

        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);
            LinkButton lnkDownloadCKList = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)lnkDownloadCKList.NamingContainer;
            string ProjectnoF = enc.Encrypt(lnkDownloadCKList.CommandArgument.ToString());

            Response.Redirect("FinancialEntry.aspx?ProjectNo=" + ProjectnoF);

        
        }


        catch(Exception ex){
        
        
        }

    }
}