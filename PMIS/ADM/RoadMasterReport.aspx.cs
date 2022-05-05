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

public partial class RCDPMISNEW_ADM_RoadMasterReport : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string strPreviousRowID = string.Empty;
    // To keep track the Index of Group Total    
    int intSubTotalIndex = 1;
    // To temporarily store Sub Total    
    double dblSubTotalLenght = 0;
    double dblSubTotalGood = 0;
    double dblSubTotalBAD = 0;
    double dblSubTotalfair = 0;
    double dblSubTotalavg = 0;
    double dblSubTotaladdcolumn = 0;
    double dblSubTotalsingle = 0;
    double dblSubTotaldouble = 0;
    double dblSubTotalmorethan5 = 0;
    double dblSubTotalmorethan7 = 0;
    double dblSubTotalIntermediate = 0;
   // double dblSubTotalupdatelength = 0;


    // To temporarily store Grand Total    
    double dblGrandTotalLenght = 0;
    double dblGrandTotalGood = 0;
    double dblGrandTotalBAD = 0;
    double dblGrandTotalfair = 0;
    double dblGrandTotalavg = 0;
    double dblGrandTotaladdcolumn = 0;
    double dblGrandTotalsingle = 0;
    double dblGrandTotaldouble = 0;
    double dblGrandTotalmorethan5 = 0;
    double dblGrandTotalmorethan7 = 0;
    double dblGrandTotalIntermediate = 0;
   // double dblGrandTotalupdatelength = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(Session["UserID"]== null)
        //{
        //    Response.Redirect("Login.aspx");
        //}

        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }


        if (!IsPostBack)
        {
            // string script = "$(document).ready(function () { $('[id*=btn_view]').click(); });";

            // ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

           // totalcount();
            //road();
            BindWings();
            BindCircle();
            BindDivision();
            RoadType();
            //  ddlcircle.DataBind();

            //ddlcircle.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
            //  ddldivision.DataBind();

            //  ddldivision.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
          
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                ddlcircle.SelectedValue = Session["CircleID"].ToString();
                ddlcircle.Enabled = false;
                ddldivision.SelectedValue = Session["DivisionID"].ToString();
                ddldivision.Enabled = false;

                // btn_view.Visible = false;
                //// ImageButton1.Visible = false;
            }

          //  BindGrid();


        }
    }
   
    private void BindWings()
    {
        SqlParameter Query_Type = new SqlParameter("@QueryType", 1);
        SqlParameter Wing_Id = new SqlParameter("@WingID", ddlwings.SelectedValue.Trim());

        try
        {
            string sql = "";
            if (Session["Role"].ToString() == "DIVADM")
            {
               
                sql = @"select WingName,WingID from wing WHERE WingID=@WingID  order by serial_no asc";
            }
            else
            {
               
                sql = @"select WingName,WingID from wing  order by serial_no asc";

            }

            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", Session["WingID"].ToString()) });
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
            DataTable dt = null;
            if (Session["Role"].ToString() == "DIVADM")
            {
                sql = @"select CircleName,CircleID from Circles WHERE CircleID='" + Session["CircleID"].ToString() + "'  order by CircleID asc";
                //sql = @"select WingName,WingID from wing WHERE WingID=@WingID  order by WingID asc";
            }
            else
            {
                sql = @"SELECT CircleName,CircleID,WingID FROM Circles where WingID=@WingID order by CircleName";
            }
            
            dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", ddlwings.SelectedValue) });

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

    private void BindGrid()
    {
       

        try
        {

            string strWhere = string.Empty;
            SqlParameter Query_Type = new SqlParameter("@QueryType", 1);
            SqlParameter Wing_Id = new SqlParameter("@WingID", ddlwings.SelectedValue.Trim());
            SqlParameter Circle_Id = new SqlParameter("@CircleID", ddlcircle.SelectedValue.Trim());
            SqlParameter Division_Id = new SqlParameter("@DivisionID", ddldivision.SelectedValue.Trim());
            SqlParameter Road_Id = new SqlParameter("@RoadType", ddl_roadtype.SelectedValue.Trim());
            DataTable dt = cls.GetDataTableSp("Sp_Get_RoadReport", new SqlParameter[] { Query_Type, Wing_Id, Circle_Id, Division_Id, Road_Id });
          //  DataTable dt = cls.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                grdEistingRecord.DataSource = dt;
                grdEistingRecord.DataBind();
                lblerror.Visible = false;
                pnl.Visible = true;

            }
            else
            {
                grdEistingRecord.DataSource = null;
                //grdEistingRecord.DataBind();
                
                lblerror.Visible = true;
                pnl.Visible = false;
               


                // ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Record Found..');", true);

            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void ddlcircle_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        BindDivision();
        //  BindGrid();


    }

    protected void ddlwings_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCircle();
      //  BindDivision();
        BindRoadType();

        // BindGrid();


    }


    //protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    //BindGrid();
    //}
    //protected void grdEistingRecord_PageIndexChanged(object sender, GridViewPageEventArgs e)
    //{
    //    grdEistingRecord.PageIndex = e.NewPageIndex;
    //    grdEistingRecord.DataBind();
    //    BindGrid();
    //}

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        if (Convert.ToString(Session["Role"]) == "DIVADM")
        {
          //  ddlwings.SelectedValue = "0";
          //  ddlcircle.SelectedValue = "0";
           // ddldivision.SelectedValue = "0";
            ddl_roadtype.SelectedValue = "0";
            //// BindGrid();
            lblerror.Visible = false;
        }
        else
        {
            ddlwings.SelectedValue = "0";
            ddlcircle.SelectedValue = "0";
            ddldivision.SelectedValue = "0";
            ddl_roadtype.SelectedValue = "0";
            lblerror.Visible = false;
           //// BindGrid();
        }    
      
    }

    protected void btn_view_Click(object sender, EventArgs e)
    {       
        BindGrid();
    }

    private void RoadType()
    {
        try
        {
            string sql = "";
            sql = @" select RoadTypeId,description from RoadType order by RoadTypeId asc";
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
            ddl_roadtype.DataSource = dt;
            ddl_roadtype.DataTextField = "description";
            ddl_roadtype.DataValueField = "RoadTypeId";
            ddl_roadtype.DataBind();
            ddl_roadtype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

        }
        catch (Exception ex)
        {

        }


    }

    void BindRoadType()
    {
        //string sql = string.Empty;
        //if (ddlwings.SelectedValue == "3")
        //    sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId=3 order by description";
        //else if((ddlwings.SelectedValue == "7"))
        //    sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId<>3 order by description";   
        //    else if (ddlwings.SelectedValue == "1" || ddlwings.SelectedValue == "2")
        //    sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId<>3 order by description";

        //else if (ddlwings.SelectedValue.Trim() == "5")
        //    sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId In (3,2) order by description";

        //DataTable dt = cls.GetDataTable(sql);
        //ddl_roadtype.DataSource = dt;
        //ddl_roadtype.DataTextField = "RoadType";
        //ddl_roadtype.DataValueField = "RoadTypeId";
        //ddl_roadtype.DataBind();
        //ddl_roadtype.Items.Insert(0, new ListItem("--All--", "0"));
        SqlParameter wingId = new SqlParameter("@WingId", ddlwings.SelectedValue.Trim());

        DataTable dt = cls.GetDataTableSp("SP_Get_BindRoad", new SqlParameter[] { wingId });
        // DataTable dt = cls.GetDataTable(sql);
        ddl_roadtype.DataSource = dt;
        ddl_roadtype.DataTextField = "RoadType";
        ddl_roadtype.DataValueField = "RoadTypeId";
        ddl_roadtype.DataBind();
        ddl_roadtype.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void btn_export_to_excel_Click(object sender, EventArgs e)
    {
               

        try
        {
            //  this.BindGrid();
            string str = "";
            string wing = ddlwings.SelectedItem.Text.Substring(ddlwings.SelectedItem.Text.IndexOf(',')+1);
            string cir = ddlcircle.SelectedItem.Text.Substring(ddlcircle.SelectedItem.Text.IndexOf(',') + 1);
            string div = ddldivision.SelectedItem.Text.Substring(ddldivision.SelectedItem.Text.IndexOf(',') + 1);
            str = wing+"_"+ cir+"_Circle" + div+ "_Division";
            Response.ClearContent();            
            Response.AddHeader("content-disposition", "attachment;filename="+ str +"_RoadMaster.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            //  pnl.RenderControl(htm);
           
            grdEistingRecord.AllowPaging = false;
            this.BindGrid();
            ///////////////////////////////////

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




            ///////////////////////////////////////////////
            int a = grdEistingRecord.Rows.Count;
            grdEistingRecord.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch(Exception ex)
        {
        }


    }

    protected void grdEistingRecord_RowCreated1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
               


            //}


            //////////////////////////////////
            bool IsSubTotalRowNeedToAdd = false;
            bool IsGrandTotalRowNeedtoAdd = false;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Division") != null))
                if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "Division").ToString())
                    IsSubTotalRowNeedToAdd = true;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Division") == null))
            {
                IsSubTotalRowNeedToAdd = true;
                IsGrandTotalRowNeedtoAdd = true;
                intSubTotalIndex = 0;
            }
            #region Inserting first Row and populating fist Group Header details
            //if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Division") != null))
            //{
            //    GridView grdViewOrders = (GridView)sender;
            //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            //    TableCell cell = new TableCell();
            //    cell.Text = "Division Name : " + DataBinder.Eval(e.Row.DataItem, "Division").ToString();
            //    cell.ColumnSpan = 1;
            //    cell.CssClass = "GroupHeaderStyle";
            //    row.Cells.Add(cell);
            //    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
            //    intSubTotalIndex++;
            //}
            #endregion
            if (IsSubTotalRowNeedToAdd)
            {
                #region Adding Sub Total Row
                GridView grdViewOrders = (GridView)sender;
                // Creating a Row          
                GridViewRow row = new GridViewRow(-2, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                //Adding Total Cell          
                TableCell cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;



                cell.Text = "Sub Total of " + strPreviousRowID;
                cell.HorizontalAlign = HorizontalAlign.Left;
                cell.ColumnSpan = 4;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                //Total Length(km)	Good	Fair	Average	 Bad	Single Lane 	Intermediate	2 Lane 	More than width seven

                //Adding Total Length(km) Column          
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.000}", dblSubTotalLenght);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                //Adding Good Column            
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.00}", dblSubTotalGood);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                //Adding Fair Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                cell.Text = string.Format("{0:0.000}", dblSubTotalfair);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle"; row.Cells.Add(cell);


                //Adding Average Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;

                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                cell.Text = string.Format("{0:0.000}", dblSubTotalavg);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                //Adding Bad Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;

                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                cell.Text = string.Format("{0:0.000}", dblSubTotalBAD);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                // Adding addition of good,bad,avg,fair colums Column
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.000}", dblSubTotaladdcolumn);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                //Adding Single lane Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.000}", dblSubTotalsingle);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);



                //Adding Intermediate Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.000}", dblSubTotalIntermediate);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);


                //Adding 2lane Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.000}", dblSubTotaldouble);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                //Adding More than 7 Column         
                cell = new TableCell();
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.Text = string.Format("{0:0.000}", dblSubTotalmorethan7);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);


                ////Adding 2lane Column         
                //cell = new TableCell();
                //cell.Text = string.Format("{0:0.000}", dblSubTotalupdatelength);
                //cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.CssClass = "SubTotalRowStyle";
                //row.Cells.Add(cell);




                //Adding the Row at the RowIndex position in the Grid      
                grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
                #endregion

                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "Division") != null)
                {
                    row = new GridViewRow(-2, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.BackColor = System.Drawing.Color.White;
                    cell.ForeColor = System.Drawing.Color.Black;
                    cell.Text = "Division Name : " + DataBinder.Eval(e.Row.DataItem, "Division").ToString();
                    cell.ColumnSpan = 4;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                #endregion


                #region Reseting the Sub Total Variables
                dblSubTotalLenght = 0;
                dblSubTotalGood = 0;
                dblSubTotalBAD = 0;
                dblSubTotalfair = 0;
                dblSubTotalavg = 0;
                dblSubTotaladdcolumn = 0;
                dblSubTotalsingle = 0;
                dblSubTotalIntermediate = 0;
                dblSubTotaldouble = 0;
                // dblSubTotalmorethan5 = 0;

                dblSubTotalmorethan7 = 0;
              //  dblSubTotalupdatelength = 0;
                #endregion
            }
            if (IsGrandTotalRowNeedtoAdd)
            {
                #region Grand Total Row
                GridView grdViewOrders = (GridView)sender;
                // Creating a Row      
                GridViewRow row = new GridViewRow(-2, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                //Adding Total Cell           
                TableCell cell = new TableCell();

                cell.Text = "Grand Total";
                cell.HorizontalAlign = HorizontalAlign.Left;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);

                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                cell.ColumnSpan = 4;
                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Unit Price Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalLenght);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Quantity Column           
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalGood);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Amount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalfair);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Amount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalavg);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Discount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalBAD);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);


                //Adding addcolumns Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotaladdcolumn);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);







                //Adding Amount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalsingle);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Amount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalIntermediate);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Amount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotaldouble);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);
                //Adding Amount Column          
                cell = new TableCell();
                cell.Text = string.Format("{0:0.000}", dblGrandTotalmorethan7);
                cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.BackColor = System.Drawing.Color.FromArgb(29, 103, 150);
                //cell.ForeColor = System.Drawing.Color.White;
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;

                cell.CssClass = "GrandTotalRowStyle";
                row.Cells.Add(cell);

                ////Adding Amount Column          
                //cell = new TableCell();
                //cell.Text = string.Format("{0:0.000}", dblGrandTotalupdatelength);
                //cell.HorizontalAlign = HorizontalAlign.Right;
                //cell.CssClass = "GrandTotalRowStyle";
                //row.Cells.Add(cell);



                //Adding the Row at the RowIndex position in the Grid     
                grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
                #endregion
            }



            /////////////////////////////////////
        }
        catch (Exception er)
        {
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void add_RoadMaster_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("RoadEntry.aspx");
    }

    private void totalcount()
    {
        //for (int i = 0; i < grdEistingRecord.Rows.Count; i++)
        //{
        //    grdEistingRecord.Rows[i].Cells[12].Text = Convert.ToString(Convert.ToDecimal(grdEistingRecord.Rows[i].Cells[8].Text) + Convert.ToDecimal(grdEistingRecord.Rows[i].Cells[9].Text)
        //        + Convert.ToDecimal(grdEistingRecord.Rows[i].Cells[10].Text) + Convert.ToDecimal(grdEistingRecord.Rows[i].Cells[11].Text));
        //}

    }

    

    protected void grdEistingRecord_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "Division").ToString();

            double dblTotalLenght = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "New_Total_Length_km").ToString());
            double dblTotalGood = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Good").ToString());
            double dblTotalBAD = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Bad").ToString());
            double dblTotalfair = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Fair").ToString());
            double dblTotalavg = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Average").ToString());
            double dblTotaladdcolumn = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "totalgfba").ToString());
            double dblTotalsingle = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SingleLane").ToString());
            double dblTotaldouble = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "twolane").ToString());
            double dbtotalIntermediate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Intermediate").ToString());
            double dblTotalmorethan7 = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "morethanwidthseven").ToString());
           // double dblTotalKengthUpdated = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalUpdate").ToString());


            // Cumulating Sub Total            
            dblSubTotalLenght += dblTotalLenght;
            dblSubTotalGood += dblTotalGood;
            dblSubTotalBAD += dblTotalBAD;
            dblSubTotalfair += dblTotalfair;
            dblSubTotalavg += dblTotalavg;
            dblSubTotaladdcolumn += dblTotaladdcolumn;
            dblSubTotalsingle += dblTotalsingle;
            dblSubTotaldouble += dblTotaldouble;
            dblSubTotalIntermediate += dbtotalIntermediate;
            dblSubTotalmorethan7 += dblTotalmorethan7;
          //  dblSubTotalupdatelength += dblTotalKengthUpdated;


            // To temporarily store Grand Total    
            dblGrandTotalLenght += dblTotalLenght;
            dblGrandTotalGood += dblTotalGood;
            dblGrandTotalBAD += dblTotalBAD;
            dblGrandTotalfair += dblTotalfair;
            dblGrandTotalavg += dblTotalavg;
            dblGrandTotaladdcolumn += dblTotaladdcolumn;
            dblGrandTotalsingle += dblTotalsingle;
            dblGrandTotaldouble += dblTotaldouble;
            dblGrandTotalIntermediate += dbtotalIntermediate;
          //  dblGrandTotalupdatelength += dblTotalKengthUpdated;
            // Cumulating Grand Total           


            //// This is for cumulating the values  
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ddd'");
            //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
            //    e.Row.Attributes.Add("style", "cursor:pointer;");
            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(grdEistingRecord, "Select$" + e.Row.RowIndex);
            //}
        }
    }

   

    public void grdEistingDataBound(object sender, EventArgs e)
    {
        GridView HG3 = (GridView)sender;
        GridViewRow gvr3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell hc3 = new TableCell();

        hc3 = new TableCell();
        hc3.Text = "";
        hc3.BorderStyle = BorderStyle.Solid;
        hc3.BorderColor = System.Drawing.Color.Black;
        //  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc3.BackColor = System.Drawing.Color.White;
        hc3.ColumnSpan = 5;

        gvr3.Cells.Add(hc3);

        hc3 = new TableCell();
        hc3.Text = "Condition Of Road (in KM)";
        hc3.Font.Size = 12;
        hc3.HorizontalAlign = HorizontalAlign.Center;
        hc3.BorderStyle = BorderStyle.Solid;
        hc3.ForeColor = System.Drawing.Color.Black;
        hc3.BorderColor = System.Drawing.Color.Black;
        // hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);     
        hc3.BackColor = System.Drawing.Color.White;
        hc3.ColumnSpan = 4;




        gvr3.Cells.Add(hc3);
        hc3 = new TableCell();
        hc3.Text = "";
        hc3.BorderStyle = BorderStyle.Solid;
        hc3.BorderColor = System.Drawing.Color.Black;
        hc3.HorizontalAlign = HorizontalAlign.Center;
        hc3.VerticalAlign = VerticalAlign.Bottom;
        // hc3.BackColor = System.Drawing.Color.Black;
        //  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc3.BackColor = System.Drawing.Color.White;
        hc3.ForeColor = System.Drawing.Color.Black;
        hc3.Font.Bold = true;
        hc3.ColumnSpan = 1;
        ////////////////////////////////////


        gvr3.Cells.Add(hc3);

        hc3 = new TableCell();
        hc3.Text = "Lane Width (m)";
        hc3.BorderStyle = BorderStyle.Solid;
        hc3.Font.Size = 12;
        hc3.HorizontalAlign = HorizontalAlign.Center;
        hc3.BorderColor = System.Drawing.Color.Black;
        hc3.ForeColor = System.Drawing.Color.Black;
        // hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);     
        hc3.BackColor = System.Drawing.Color.White;
        hc3.ColumnSpan = 4;





        ////////////////////////////////////////////////////////////////
        ////gvr3.Cells.Add(hc3);
        ////hc3 = new TableCell();
        ////hc3.Text = "Single Lane 3.75m width";
        ////hc3.BorderStyle = BorderStyle.Solid;
        ////hc3.BorderColor = System.Drawing.Color.Black;
        ////hc3.HorizontalAlign = HorizontalAlign.Center;
        ////hc3.VerticalAlign = VerticalAlign.Bottom;
        ////// hc3.BackColor = System.Drawing.Color.Black;
        //////  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        ////hc3.BackColor = System.Drawing.Color.White;
        ////hc3.ForeColor = System.Drawing.Color.Black;
        ////hc3.Font.Bold = true;
        //hc3.ColumnSpan = 1;


        //gvr3.Cells.Add(hc3);
        //hc3 = new TableCell();
        //hc3.Text = "Intermediate Lane 5.50m width";
        //hc3.BorderStyle = BorderStyle.Solid;
        //hc3.BorderColor = System.Drawing.Color.Black;
        ////  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc3.BackColor = System.Drawing.Color.White;
        //hc3.ColumnSpan = 1;


        //gvr3.Cells.Add(hc3);
        //hc3 = new TableCell();
        //hc3.Text = "2 Lane 7.00m width";
        //hc3.BorderStyle = BorderStyle.Solid;
        //hc3.BorderColor = System.Drawing.Color.Black;
        ////  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc3.BackColor = System.Drawing.Color.White;
        //hc3.ColumnSpan = 1;


        //gvr3.Cells.Add(hc3);
        //hc3 = new TableCell();
        //hc3.Text = "More than 7.00m width";
        //hc3.BorderStyle = BorderStyle.Solid;
        //hc3.BorderColor = System.Drawing.Color.Black;
        ////  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc3.BackColor = System.Drawing.Color.White;
        //hc3.ColumnSpan = 1;


        /////////////////////////////////////////

        //gvr3.Cells.Add(hc3);
        //hc3 = new TableCell();
        //hc3.Text = "";
        //hc3.BorderStyle = BorderStyle.Solid;
        //hc3.BorderColor = System.Drawing.Color.Black;
        //// hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc3.BackColor = System.Drawing.Color.White;
        //hc3.ColumnSpan = 1;

        gvr3.Cells.Add(hc3);
        hc3 = new TableCell();
        hc3.Text = "";
        hc3.BorderStyle = BorderStyle.Solid;
        hc3.BorderColor = System.Drawing.Color.Black;
        // hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc3.BackColor = System.Drawing.Color.White;
        hc3.ColumnSpan = 1;
        gvr3.Cells.Add(hc3);
        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr3);




        GridViewRow gvr1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell hc1 = new TableCell();
        hc1 = new TableCell();
        hc1.HorizontalAlign = HorizontalAlign.Center;
        hc1.VerticalAlign = VerticalAlign.Bottom;
        hc1.BorderStyle = BorderStyle.Solid;
        hc1.BorderColor = System.Drawing.Color.Black;
        hc1.BackColor = System.Drawing.Color.White;
        hc1.ForeColor = System.Drawing.Color.Black;
        hc1.Font.Bold = true;
        hc1.ColumnSpan = 7;

        //gvr1.Cells.Add(hc1);
        //grdEistingRecord.Controls[0].Controls.AddAt(0, gvr1);

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
        hc.ColumnSpan = 12;

        gvr.Cells.Add(hc);

        //hc = new TableCell();
        //hc.Text = "Condition Of Road (in KM)";
        //hc.BorderStyle = BorderStyle.Solid;
        //hc.BorderColor = System.Drawing.Color.White;
        //hc.HorizontalAlign = HorizontalAlign.Center;
        //hc.VerticalAlign = VerticalAlign.Bottom;
        //hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc.ForeColor = System.Drawing.Color.White;
        //hc.Font.Bold = true;
        //hc.ColumnSpan = 4;

        //gvr.Cells.Add(hc);

        //hc = new TableCell();
        //hc.Text = "Lane Width (m)";
        //hc.BorderStyle = BorderStyle.Solid;
        //hc.BorderColor = System.Drawing.Color.Black;
        //hc.HorizontalAlign = HorizontalAlign.Center;
        //hc.VerticalAlign = VerticalAlign.Bottom;
        ////hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc.BackColor = System.Drawing.Color.White;
        //hc.ForeColor = System.Drawing.Color.Black;
        //hc.Font.Bold = true;
        //hc.ColumnSpan = 4;

        //gvr.Cells.Add(hc);
        //hc = new TableCell();
        //hc.Text = "";
        //hc.BorderStyle = BorderStyle.Solid;
        //hc.BorderColor = System.Drawing.Color.Black;
        ////   hc.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        //hc.BackColor = System.Drawing.Color.White;
        //hc.ColumnSpan = 4;

        //gvr.Cells.Add(hc);
        //grdEistingRecord.Controls[0].Controls.AddAt(0, gvr);








        GridView HG4 = (GridView)sender;
        GridViewRow gvr4 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell hc4 = new TableCell();

        hc4 = new TableCell();
        //  hc4.Text = "Road Construction Department , Road Statistic";
        hc4.BorderStyle = BorderStyle.Solid;
        hc4.BorderColor = System.Drawing.Color.Black;
        //  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc4.BackColor = System.Drawing.Color.White;
        hc4.ColumnSpan = 5;

        gvr4.Cells.Add(hc4);

        string str = "";
        string wing = ddlwings.SelectedItem.Text.Substring(ddlwings.SelectedItem.Text.IndexOf(',') + 1);
        string cir = ddlcircle.SelectedItem.Text.Substring(ddlcircle.SelectedItem.Text.IndexOf(',') + 1);
        string div = ddldivision.SelectedItem.Text.Substring(ddldivision.SelectedItem.Text.IndexOf(',') + 1);

        str = wing + "_" + cir + "_Circle" + div + "_Division";

        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr4);
        hc4 = new TableCell();
        hc4.Text = "Road Construction Department, Road Statistics, "+ div + "";
        hc4.BorderStyle = BorderStyle.Solid;
        hc4.Font.Size = 11;
        hc4.HorizontalAlign = HorizontalAlign.Left;
        hc4.ForeColor = System.Drawing.Color.Black;
        hc4.BorderColor = System.Drawing.Color.Black;
        //  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc4.BackColor = System.Drawing.Color.White;
        hc4.ColumnSpan = 6;

        gvr4.Cells.Add(hc4);
        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr4);
        hc4 = new TableCell();
        hc4.Text = "";
        hc4.BorderStyle = BorderStyle.Solid;
        hc4.BorderColor = System.Drawing.Color.Black;
        //  hc3.BackColor = System.Drawing.Color.FromArgb(1, 78, 156);
        hc4.BackColor = System.Drawing.Color.White;
        hc4.ColumnSpan = 4;

        gvr4.Cells.Add(hc4);

        grdEistingRecord.Controls[0].Controls.AddAt(0, gvr4);

    }

    
}