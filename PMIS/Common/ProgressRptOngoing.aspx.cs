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
public partial class PMIS_Common_ProgressRptOngoing : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["Role"].ToString() == "")
        {

            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindFyr();
            BindWings();
            BindCircle();
            BindDivision();
            RoadType();
            Head();
            // BindGrid();

        }
    }
    protected void rowBind()
    {

//        string sql = @"SELECT pan.[PanchayatCode],pan.[PanchayatName],pan.[PanchayatNameHnd] FROM [AanganPublic].[dbo].[Panchayat] pan
//  JOIN Projects pro on pro.BlockCode = pan.BlockCode
//  join dbo.AWC awc on awc.ProjCode = pro.ProjCode
//  where pro.ProjCode='" + ddlproject.SelectedValue + "'group by pan.[PanchayatCode],pan.[PanchayatName],pan.[PanchayatNameHnd]" +
//    "order by pan.PanchayatName asc";
//        // string _sql1 = @"select PanchayatCode,PanchayatName from Panchayat where BlockCode='" + ddlBlock.SelectedValue + "' order by PanchayatName";
//        DataTable dt = cls.GetDataTable(sql);

        foreach (GridViewRow grv in grdEistingRecord.Rows)
        {
            Label Lbl_ew = (grv.FindControl("lblew") as Label);
            Label Lbl_gsb = (grv.FindControl("lblgsb") as Label);
            Label Lbl_wbm = (grv.FindControl("lblwbm") as Label);
            Label Lbl_bm = (grv.FindControl("lblbm") as Label);
            Label Lbl_dbm = (grv.FindControl("lbldbm") as Label);
            Label Lbl_dlc = (grv.FindControl("lbldlc") as Label);
            Label Lbl_pqc = (grv.FindControl("lblpqc") as Label);
            Label Lbl_sdbc = (grv.FindControl("lblsdbc") as Label);
            Label Lbl_pcc = (grv.FindControl("lblpcc") as Label);
            Label Lbl_cd = (grv.FindControl("lblcd") as Label);
            Label Lbl_bridge = (grv.FindControl("lblbridge") as Label);
            Label Lbl_drain = (grv.FindControl("lbldrain") as Label);

            Label valueLblew = (grv.FindControl("lbl_ew") as Label);
            Label valueLblgsb = (grv.FindControl("lbl_gsb") as Label);
            Label valueLblwbm = (grv.FindControl("lbl_wbm") as Label);
            Label valueLblbm = (grv.FindControl("lbl_bm") as Label);
            Label valueLbldbm = (grv.FindControl("lbl_dbm") as Label);
            Label valueLbldlc = (grv.FindControl("lbl_dlc") as Label);
            Label valueLblpqc = (grv.FindControl("lbl_pqc") as Label);
            Label valueLblsdbc = (grv.FindControl("lbl_sdbc") as Label);
            Label valueLblpcc = (grv.FindControl("lbl_pcc") as Label);
            Label valueLblcd = (grv.FindControl("lbl_cd") as Label);
            Label valueLblbridge = (grv.FindControl("lbl_bridge") as Label);
            Label valueLbldrain = (grv.FindControl("lbl_drain") as Label);
            Label valueLblbmc = (grv.FindControl("lblbmc") as Label);
            Label valueLbldbmc = (grv.FindControl("lbldbmc") as Label);



            if (valueLblew.Text == "0" || valueLblew.Text == "")
            {
                Lbl_ew.Visible = false;
                valueLblew.Visible = false;
            }
            if (valueLblgsb.Text == "0" || valueLblgsb.Text == "")
            {
                Lbl_gsb.Visible = false;
                valueLblgsb.Visible = false;
            }
            if (valueLblwbm.Text == "0" || valueLblwbm.Text == "")
            {
                Lbl_wbm.Visible = false;
                valueLblwbm.Visible = false;
            }
            if (valueLblbm.Text == "0" || valueLblbm.Text == "")
            {
                Lbl_bm.Visible = false;
                valueLblbm.Visible = false;
            }
            if (valueLbldbm.Text == "0" || valueLbldbm.Text == "")
            {
                Lbl_dbm.Visible = false;
                valueLbldbm.Visible = false;
            }
            if (valueLbldlc.Text == "0" || valueLbldlc.Text == "")
            {
                Lbl_dlc.Visible = false;
                valueLbldlc.Visible = false;
            }
            if (valueLblpqc.Text == "0" || valueLblpqc.Text == "")
            {
                Lbl_pqc.Visible = false;
                valueLblpqc.Visible = false;
            }

            if (valueLblsdbc.Text == "0" || valueLblsdbc.Text == "")
            {
                Lbl_sdbc.Visible = false;
                valueLblsdbc.Visible = false;
            }
            if (valueLblpcc.Text == "0" || valueLblpcc.Text == "")
            {
                Lbl_pcc.Visible = false;
                valueLblpcc.Visible = false;
            }
            if (valueLblcd.Text == "0" || valueLblcd.Text == "")
            {
                Lbl_cd.Visible = false;
                valueLblcd.Visible = false;
            }
            if (valueLblbridge.Text == "0" || valueLblbridge.Text == "")
            {
                Lbl_bridge.Visible = false;
                valueLblbridge.Visible = false;
            }
            if (valueLbldrain.Text == "0" || valueLbldrain.Text == "")
            {
                Lbl_drain.Visible = false;
                valueLbldrain.Visible = false;
            }

            if (valueLblbmc.Text == "0" || valueLblbmc.Text == "")
            {
                //valueLbldbmc.Visible = true;
                valueLblbmc.Visible = false;
            }

            if (valueLbldbmc.Text == "0" || valueLbldbmc.Text == "")
            {
                valueLbldbmc.Visible = false;
                //valueLblbmc.Visible = true;
            }
           

        }

    }




    private void BindWings()
    {
        try
        {
            string sql = "";
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                sql = @"select WingName,WingID from wing WHERE WingID='" + Session["WingID"].ToString() + "'  order by WingID asc";

            } 

            else {
                sql = @"select WingName,WingID from wing  order by WingID asc";
            
            }
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddlwings.DataSource = dt;

            ddlwings.DataTextField = "WingName";
            ddlwings.DataValueField = "WingID";
            ddlwings.Attributes.Remove("Wing");
            ddlwings.DataBind();
            ddlwings.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));


            if (Session["Role"].ToString() == "DIVADM")
            {
                ddlwings.SelectedValue = Session["WingID"].ToString();
                ddlwings.Enabled = false;
            }
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

            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                sql = @"SELECT CircleName,CircleID,WingID FROM Circles where CircleID='" + Session["CircleID"].ToString() + "' order by CircleName";
            }
            else {

                sql = @"SELECT CircleName,CircleID,WingID FROM Circles where WingID=@WingID order by CircleName";
            }


            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", ddlwings.SelectedValue)});

            ddlcircle.DataSource = dt;
            ddlcircle.DataTextField = "CircleName";
            ddlcircle.DataValueField = "CircleID";
            ddlcircle.DataBind();

            ddlcircle.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
            if (Session["Role"].ToString() == "DIVADM")
            {
                ddlcircle.SelectedValue = Session["CircleID"].ToString();
                ddlcircle.Enabled = false;
            }
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
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                sql = @"select DivisionID,DivisionName from Divisions WHERE DivisionID='" + Session["DivisionID"].ToString() + "'  order by DivisionID asc";
                //sql = @"select WingName,WingID from wing WHERE WingID=@WingID  order by WingID asc";
            }
            else
            {
                sql = @"SELECT DivisionName,DivisionID, CircleID FROM Divisions where CircleID=@CircleID order by DivisionName";
            }
            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CircleID", ddlcircle.SelectedValue) });

            ddldivision.DataSource = dt;
            ddldivision.DataTextField = "DivisionName";
            ddldivision.DataValueField = "DivisionID";
            ddldivision.DataBind();
            ddldivision.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                ddldivision.SelectedValue = Session["DivisionID"].ToString();
                ddldivision.Enabled = false;
            }
        }
        catch (Exception ex)
        {


        }
    }
    private void RoadType()
    {
        try
        {
            SqlParameter wingId = new SqlParameter("@WingId", ddlwings.SelectedValue.Trim());

            DataTable dt = cls.GetDataTableSp("SP_Get_BindRoad", new SqlParameter[] { wingId });
            // DataTable dt = cls.GetDataTable(sql);
            ddl_roadtype.DataSource = dt;
            ddl_roadtype.DataTextField = "RoadType";
            ddl_roadtype.DataValueField = "RoadTypeId";
            ddl_roadtype.DataBind();
            ddl_roadtype.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch (Exception ex)
        {

        }



    }

    private void Head()
    {
        try
        {
            string sql = "";
            sql = @" select  headId,headName from Head order by headId asc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddlhead.DataSource = dt;
            ddlhead.DataTextField = "headName";
            ddlhead.DataValueField = "headId";
            ddlhead.DataBind();
            ddlhead.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

        }
        catch (Exception ex)
        {

        }


    }

    private void BindFyr()
    {
        try
        {
            string query = "";
            query = @"select FYID,FY from FYs order by FYID desc";
            DataTable dt = cls.GetDataTable(query);
            ddlFYear.DataSource = dt;
            ddlFYear.DataTextField = "FY";
            ddlFYear.DataValueField = "FYID";
            ddlFYear.DataBind();
            ddlFYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
        }
        catch (Exception ex)
        {
        }

    }



    private void BindGrid()
    {
        try
        {
            string strWhere = string.Empty;
            lblFYr.Text = ddlFYear.SelectedItem.Text.Trim();

            if (ddlFYear.SelectedValue != "0")
            {
                strWhere += " and pm.FYID=@FYID";
            }
            if (ddlwings.SelectedValue != "0")
            {
                strWhere += " and pm.WingId=@WingId";
            }
            if (ddlcircle.SelectedValue != "0")
            {
                strWhere += " and pm.CircleID=@CircleID";
            }
            if (ddldivision.SelectedValue != "0")
            {
                strWhere += " and pm.DivisionID=@DivisionID";
            }
            if (ddlhead.SelectedValue != "0")
            {
                strWhere += " and pm.HeadId=@HeadId";
            }
            if (ddl_roadtype.SelectedValue != "0")
            {
                strWhere += " and rm.RoadType=@RoadType";
            }
            if (ddlprojectstatus.SelectedValue != "0")
            {
                strWhere += " and pm.status=@status";
            }
            if (txtFromDate.Text.Trim() != "" || txtToDate.Text.Trim() != "")
            {
                if (txtFromDate.Text.Trim() == "" || txtToDate.Text.Trim() == "")
                {
                    Utility.showMessage(this, "Please select Date...!");
                }
                else
                {
                    strWhere += " and cast (st.UPDATEDDATE as date)>=@FromDate and cast (st.UPDATEDDATE as date)<=@ToDate";
                }
            }

            SqlParameter Wing_Id = new SqlParameter("@WingID", ddlwings.SelectedValue.Trim());
            SqlParameter Circle_Id = new SqlParameter("@CircleID", ddlcircle.SelectedValue.Trim());
            SqlParameter Division_Id = new SqlParameter("@DivisionID", ddldivision.SelectedValue.Trim());
            SqlParameter Road_Id = new SqlParameter("@RoadType", ddl_roadtype.SelectedValue.Trim());
            SqlParameter Head_Id = new SqlParameter("@HeadID", ddlhead.SelectedValue.Trim());
            SqlParameter _ddlFYear = new SqlParameter("@FYID", ddlFYear.SelectedValue.Trim());
            SqlParameter status = new SqlParameter("@status", ddlprojectstatus.SelectedValue.Trim());

            SqlParameter FromDate = new SqlParameter("@FromDate", txtFromDate.Text.Trim());
            SqlParameter ToDate = new SqlParameter("@ToDate", txtToDate.Text.Trim());

            string sql = @"select distinct pm.Projectno,rm.RoadId,w.WingID,w.WingName,cir.CircleID,cir.CircleName,d.DivisionID,AADate,  
d.DivisionName,Name_of_the_Road,h.headName,pm.SanctionRoadLength,pm.AAamount,pm.AArefno,pm.StartDate,pm.EndDate ,st.PCC,st.DBM,st.EW_CUMULATIVE as ewc,st.PCC_CUMULATIVE,st.CDWORK_CUMULATIVE,st.BRIDGE_CUMULATIVE,st.COMMENTS,  
c.ContractorName,pm.AgreementAmount,pm.WorkAllotedRate,pm.workorderdate,pm.ExpectedMonthofComplection,st.CDWORKS as  CDWork,st.Bridge,
st.PQC,st.SDBC_BC_PMC,st.DBM,st.EW,st.Drain,st.BM,st.DLC,st.CDWORK_UPDATE_DATE , st.BRIDGE_UPDATE_DATE,st.GSB,st.WBM_WMM as WBM,st.BUSG,pm.remarks,pm.ExpectedMonthofComplection,  
pm.periodofDLP,pm.WorkValuePerTarget,pm.ActualWorkDone,rm.RoadType,pm.HeadId,st.PQC_CUMULATIVE,st.SDBC_CUMULATIVE,st.DBM_CUMULATIVE,st.EW_CUMULATIVE,st.DRAIN_CUMULATIVE,
st.BM_CUMULATIVE,st.DLC_CUMULATIVE,st.CDWORK_CUMULATIVE,st.BRIDGE_CUMULATIVE,
st.GSB_CUMULATIVE,st.WBM_WMM_CUMULATIVE,st.BUSG_CUMULATIVE,(isnull(fp.[1920],'0')) +((isnull(fp.[2021],'0' ))) as cumfinprev, isnull(fp.[2122],'0') as '2122'
,(isnull(fp.[1920],'0')) +(isnull(fp.[2021],'0'))+isnull(fp.[2122],'0') as actalTamount,cast(fp.UpdatedDate as date) as  UpdatedDate from RoadMaster as rm  
inner join ProjectMaster as pm on pm.RoadId= rm.RoadId  
left join Head as h on h.headId= pm.HeadId  
left outer join Divisions as d on d.DivisionID=pm.DivisionId  
left outer join Contractor as c on c.ContractorID=pm.ContractorInProject  
left outer join mst_SetTarget as st on st.ProjectNo=pm.Projectno  
left outer join Expenditure as e on e.ProjectNo=pm.Projectno  
inner join Wing w on w.WingID=pm.WingID  
left outer join Circles as cir on cir.CircleID=pm.CircleID 
left outer join RoadType as rt on rt.RoadTypeId=rm.RoadType 
left join (
SELECT DivisionID,Projectnumber,sum( case when FYID ='2122' then [Expenditureamount] else 0 end ) as '2122',
sum( case when FYID ='2021' then [Expenditureamount] else 0 end ) as '2021',
sum( case when FYID ='1920' then [Expenditureamount] else 0 end ) as '1920',UpdatedDate
  FROM [RCDPMISDB].[dbo].[FinancialProgress]
  group by DivisionID,Projectnumber,UpdatedDate
)
as fp   on fp.DivisionID = d.DivisionID and pm.Projectno = fp.Projectnumber

where 1=1 and  st.IsDelete is null " + strWhere + " order by d.DivisionName";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { Wing_Id, Circle_Id, Division_Id, Road_Id, Head_Id, _ddlFYear, status, FromDate, ToDate });

            if (dt.Rows.Count > 0)
            {
                pnlmain.Visible = true;
                lblerror.Visible = false;
                grdEistingRecord.DataSource = dt;
                grdEistingRecord.DataBind();
                rowBind();
                grdEistingRecord.HeaderRow.Cells[13].Text = "Expenditure During 2021-22 upto " + DateTime.Now.ToString("dd.MM.yyyy") + "(Rs. in Lacs)";
                //grdEistingRecord.HeaderRow.Cells[2].Text = "Destination";

            }
            else
            {
                pnlmain.Visible = false;
                lblerror.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }

    }


    protected void grdEistingRecord_DataBound(object sender, EventArgs e)
    {
        GridView HG = (GridView)sender;
        GridViewRow gvr = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell hc = new TableCell();

        hc = new TableCell();
        hc.Text = "";
        //hc.Attributes.Add("text-align", "center");
        hc.BorderStyle = BorderStyle.Solid;
        hc.BorderColor = System.Drawing.Color.Black;
        // hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc.BackColor = System.Drawing.Color.White;
        hc.ColumnSpan = 5;
        gvr.Cells.Add(hc);

        hc = new TableCell();
        hc.Text = "Administrative Approval";
        hc.BorderStyle = BorderStyle.Solid;
        hc.BorderColor = System.Drawing.Color.Black;
        hc.HorizontalAlign = HorizontalAlign.Center;
        hc.VerticalAlign = VerticalAlign.Bottom;
        //hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc.BackColor = System.Drawing.Color.White;
        hc.ForeColor = System.Drawing.Color.Black;
        hc.Font.Bold = true;
        hc.ColumnSpan = 2;
        gvr.Cells.Add(hc);


        hc = new TableCell();
        hc.Text = " ";
        hc.BorderStyle = BorderStyle.Solid;
        hc.BorderColor = System.Drawing.Color.Black;
        hc.HorizontalAlign = HorizontalAlign.Center;
        hc.VerticalAlign = VerticalAlign.Bottom;
        //hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc.BackColor = System.Drawing.Color.White;
        hc.ForeColor = System.Drawing.Color.Black;
        hc.Font.Bold = true;
        hc.ColumnSpan = 4;
        gvr.Cells.Add(hc);
        //For blank text create  row start

        hc = new TableCell();
        hc.Text = "Financial Progress during 2021-22 upto"  + DateTime.Now.ToString("dd.MM.yyyy");
        hc.BorderStyle = BorderStyle.Solid;
        hc.BorderColor = System.Drawing.Color.Black;
        hc.HorizontalAlign = HorizontalAlign.Center;
        hc.VerticalAlign = VerticalAlign.Bottom;
        //hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc.BackColor = System.Drawing.Color.White;
        hc.ForeColor = System.Drawing.Color.Black;
        hc.Font.Bold = true;
        hc.ColumnSpan = 5;
        gvr.Cells.Add(hc);

        //For blank text create  row end




        //For Financial Progress upto oct-19 /sept-19 text create  row start


        //hc = new TableCell();
        //string FYR = ddlFYear.SelectedItem.Text;
        //hc.Text = "Expenditure upto " + FYR + "";
        //hc.BorderStyle = BorderStyle.Solid;
        //hc.BorderColor = System.Drawing.Color.Black;
        //hc.HorizontalAlign = HorizontalAlign.Center;
        //hc.VerticalAlign = VerticalAlign.Bottom;
        ////hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc.BackColor = System.Drawing.Color.White;
        //hc.ForeColor = System.Drawing.Color.Black;
        //hc.Font.Bold = true;
        //hc.ColumnSpan = 2;
        //gvr.Cells.Add(hc);

        //For Financial Progress upto oct-19 /sept-19 text create  row end



        hc = new TableCell();
        string FYR1 = ddlFYear.SelectedItem.Text;
        hc.Text = "Physical Progress";
        hc.BorderStyle = BorderStyle.Solid;
        hc.BorderColor = System.Drawing.Color.Black;
        hc.HorizontalAlign = HorizontalAlign.Center;
        hc.VerticalAlign = VerticalAlign.Bottom;
        //hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc.BackColor = System.Drawing.Color.White;
        hc.ForeColor = System.Drawing.Color.Black;
        hc.Font.Bold = true;
        hc.ColumnSpan = 8;
        gvr.Cells.Add(hc);

        hc = new TableCell();
        hc.Text = "";
        hc.BorderStyle = BorderStyle.Solid;
        hc.BorderColor = System.Drawing.Color.Black;
        hc.HorizontalAlign = HorizontalAlign.Center;
        hc.VerticalAlign = VerticalAlign.Bottom;
        //hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc.BackColor = System.Drawing.Color.White;
        hc.ForeColor = System.Drawing.Color.Black;
        hc.Font.Bold = true;
        hc.ColumnSpan = 3;
        gvr.Cells.Add(hc);

      

        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr);


        GridView HG4 = (GridView)sender;
        GridViewRow gvr4 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell hc4 = new TableCell();

        string FYR2 = ddlFYear.SelectedItem.Text;
        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr4);
        hc4 = new TableCell();
        hc4.Text = " Road Construction Department,Bihar <br> Progress Report Of Ongoing Road Schemes For The Year " + FYR2 + "";
        hc4.HorizontalAlign = HorizontalAlign.Center;
        hc4.BorderStyle = BorderStyle.Solid;
        hc4.BorderColor = System.Drawing.Color.Black;
        //  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc4.BackColor = System.Drawing.Color.White;
        hc4.ColumnSpan = 30;

        gvr4.Cells.Add(hc4);

        //grdEistingRecord.Controls[0].Controls.AddAt(0, gvr4);
        //hc4 = new TableCell();
        //hc4.Text = "";
        //hc4.BorderStyle = BorderStyle.Solid;
        //hc4.BorderColor = System.Drawing.Color.Black;
        ////  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc4.BackColor = System.Drawing.Color.White;
        //hc4.ColumnSpan = 15;

        //gvr4.Cells.Add(hc4);

        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr4);


    }

    protected void grdEistingRecord_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdEistingRecord_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }




    protected void ddlwings_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCircle();
        RoadType();
    }

    protected void ddlcircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDivision();
    }



    protected void btn_view_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BindWings();
        BindCircle();
        BindDivision();
        RoadType();
        Head();
        pnlmain.Visible = false;
        lblerror.Visible = false;
    }

    //protected void btn_export_to_excel_Click(object sender, ImageClickEventArgs e)
    //{

    //}
    protected void btn_export_to_excelClick(object sender, EventArgs e)
    {
        try
        {
            //  this.BindGrid();

            string FYR = ddlFYear.SelectedItem.Text;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=" + FYR + "Ongoing Projects.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            //  pnl.RenderControl(htm);

            grdEistingRecord.AllowPaging = false;
            this.BindGrid();
           
            grdEistingRecord.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in grdEistingRecord.HeaderRow.Cells)
            {
                cell.BackColor = grdEistingRecord.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in grdEistingRecord.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = grdEistingRecord.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = grdEistingRecord.RowStyle.BackColor;
                    }
                    cell.Width = 80;
                    cell.Height = 80;
                    cell.CssClass = "textmode";
                }
            }


            int a = grdEistingRecord.Rows.Count;
            grdEistingRecord.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch
        {
        }

    }
}