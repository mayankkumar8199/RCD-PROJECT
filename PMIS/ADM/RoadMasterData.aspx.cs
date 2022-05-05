using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Configuration;

public partial class RCDPMISNEW_ADM_RoadMasterData : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role"]) == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
           
            BindWings();
            BindCircle();
            BindDivision();
            TOTALCOUNT1();
            //  RoadType();

            BindRoadType();
          //  ddlcircle.DataBind();

            //ddlcircle.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
            //  ddldivision.DataBind();

           // ddldivision.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
              BindGrid();
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                ddlcircle.SelectedValue = Convert.ToString(Session["CircleID"]);
                ddlcircle.Enabled = false;
                ddldivision.SelectedValue = Convert.ToString(Session["DivisionID"]);
                ddldivision.Enabled = false;

               // btn_view.Visible = false;
               //// ImageButton1.Visible = false;
            }

            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                //add_RoadMaster.Visible = false;
            }
            else
            {
                //add_RoadMaster.Visible = true;

            }
        }
    }

    private void BindGrid()
    {
        
       

        try
        {

            //            string strWhere = string.Empty;
            //            if (ddlwings.SelectedValue != "0")
            //                strWhere += " and WingID=" +  ddlwings.SelectedValue.Trim() + "";
            //            if (ddlcircle.SelectedValue != "0")
            //                strWhere += "and  CircleID=" + ddlcircle.SelectedValue.Trim() + "";
            //            if (ddldivision.SelectedValue != "0")
            //                strWhere += " and DivisionID=" + ddldivision.SelectedValue.Trim() + "";
            //            if (ddl_roadtype.SelectedValue != "0")
            //                strWhere += " and RoadType=" + ddl_roadtype.SelectedValue.Trim() + "";

            //            //string sql = @"SELECT [slno], [Wing], [Division], [RoadType], [SH_MDR], [Name_of_the_Road], [New_Total_Length_km], [NH_ConvertedLength_km], [NH_Converted_Road_Remarks], [Remarks], [Change_Remarks] FROM RoadMaster where Isdelete='Y'" + strWhere + "";
            //            string sql = @"select SUBSTRING(wing.WingName,0,CHARINDEX(' ',wing.WingName)) AS Wing , Circles.CircleName as Circle,Divisions.DivisionName as Division,rt.description,
            //rm.Name_of_the_Road,ISNULL(rm.New_Total_Length_km,0) as New_Total_Length_km,
            //CASE ISNULL(rm.Remarks,'') WHEN 'NULL' THEN ''ELSE    ISNULL(rm.Remarks,'') END  Remarks,
            // ISNULL(rm.Average,'0.00')   Average,
            //  ISNULL(rm.Bad,'0.00')  Bad,
            //  ISNULL(rm.Fair,'0.00') Fair, 
            //  ISNULL(rm.Good,'0.00')  Good,
            // ISNULL(Intermediate,'0.00') Intermediate,
            //ISNULL(rm.morethanwidthseven,'0.00') morethanwidthseven,
            //rm.RoadId,
            //  ISNULL(rm.SingleLane,'0.00')  SingleLane,rm.ActionEdit,rm.ActionDelete,
            //  ISNULL(rm.twolane,'0.00')  twolane,rm.WingID, rm.CircleID, rm.DivisionID, rm.RoadType into #temp
            //from ((((RoadMaster as rm inner join
            //Wing on rm.WingID= Wing.WingID )
            //inner join Circles on Circles.CircleID=rm.CircleID)
            //inner join RoadType as rt on rt.RoadTypeId= rm.RoadType)
            //inner join Divisions on Divisions.DivisionID=rm.DivisionID) where Isdelete='Y' ;
            //update #temp set bad='0.00' where bad='NULL';
            //update #temp set Average='0.00' where Average='NULL';
            //select * from #temp where 1=1  " + strWhere + "order by Name_of_the_Road asc";
            SqlParameter WingId = new SqlParameter("@WingId",ddlwings.SelectedValue.Trim());
            SqlParameter CircleID = new SqlParameter("@CircleID", ddlcircle.SelectedValue.Trim());
            SqlParameter DivisionID = new SqlParameter("@DivisionID", ddldivision.SelectedValue.Trim());
            SqlParameter RoadType = new SqlParameter("@RoadType", ddl_roadtype.SelectedValue.Trim());

            DataTable dt = cls.GetDataTableSp("SP_GetRoadMaster", new SqlParameter[] {
                WingId,CircleID,DivisionID,RoadType
            });
           // DataTable dt = cls.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {

                lbltotalcount.Text = "Total Count- " + " " + dt.Rows.Count.ToString();
                grdEistingRecord.Columns[5].FooterText = "<b style='text - align:center'>Total Length :</b>";
                grdEistingRecord.Columns[6].FooterText = dt.AsEnumerable().Select(x => x.Field<double>("New_Total_Length_km")).Sum().ToString();
                grdEistingRecord.DataSource = dt;
                grdEistingRecord.DataBind();
                lblerror.Visible = false;
                pnl.Visible = true;
                lbltotalcount.Visible = true;


            }
            else
            {
                grdEistingRecord.DataSource = null;
                //grdEistingRecord.DataBind();
                lblerror.Visible = true;
                pnl.Visible = false;
                lbltotalcount.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }

    }

    //private void BindGridForRoadSuggestion()
    //{



    //    try
    //    {

           
    //        SqlParameter RoadName = new SqlParameter("@RoadName", txtroadnamesearch.Text.Trim());

    //        DataTable dt = cls.GetDataTableSp("SP_GetRoadMasterRoadSearch", new SqlParameter[] { RoadName });



    //        if (dt.Rows.Count > 0)
    //        {

    //            lbltotalcount.Text = "Total Count- " + " " + dt.Rows.Count.ToString();
    //            grdEistingRecord.Columns[5].FooterText = "<b style='text - align:center'>Total Length :</b>";
    //            grdEistingRecord.Columns[6].FooterText = dt.AsEnumerable().Select(x => x.Field<double>("New_Total_Length_km")).Sum().ToString();
    //            grdEistingRecord.DataSource = dt;
    //            grdEistingRecord.DataBind();
    //            lblerror.Visible = false;
    //            pnl.Visible = true;
    //            lbltotalcount.Visible = true;


    //        }
    //        else
    //        {
    //            grdEistingRecord.DataSource = null;
    //            //grdEistingRecord.DataBind();
    //            lblerror.Visible = true;
    //            pnl.Visible = false;
    //            lbltotalcount.Visible = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //}

    [WebMethod]
    public static List<string> SearchRoadMaster(string prefixText)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["RCDPMISNewConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name_of_the_Road from RoadMaster where Name_of_the_Road like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Name_of_the_Road"].ToString());
                    }
                }
                conn.Close();

                return customers;
            }
        }
    }

    //private void road()
    //{

    //    try
    //    {
    //        string sql = "";
    //        if (Session["Role"].ToString() == "DIVADM")
    //        {
    //            //  sql = @"select WingName,WingID from wing WHERE WingID='"+ Session["WingID"].ToString() + "'  order by WingID asc";
    //            sql = @"select Name_of_the_Road,WingID from RoadMaster where WingID='" + Session["WingID"].ToString() + "' and CircleID='" + Session["CircleID"].ToString() + "' and DivisionID='" + Session["DivisionID"].ToString() + "' order by Name_of_the_Road asc";
    //        }
    //        else
    //        {
    //            sql = @"select Name_of_the_Road from RoadMaster  order by Name_of_the_Road asc";

    //        }

    //        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", Session["WingID"].ToString()) });
    //        ddl_search.DataSource = dt;
    //        ddl_search.DataTextField = "Name_of_the_Road";
    //        ddl_search.DataValueField = "WingID";
    //        ddl_search.DataBind();

    //        ddl_search.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

    //        if (Session["Role"].ToString() == "DIVADM")
    //        {
    //            //ddl_search.SelectedValue = Session["WingID"].ToString();
    //            //ddl_search.Enabled = false;
    //        }


    //    }
    //    catch (Exception ex)
    //    {


    //    }

    //}

    private void BindWings()
    {
        //SELECT  WingID, WingName, WingNameHND FROM Wing order by serial_no asc
        try
        {
            string sql = "";
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
               // //  sql = @"select WingName,WingID from wing WHERE WingID='"+ Session["WingID"].ToString() + "'  order by WingID asc";
                // sql = @"select WingName,WingID from wing WHERE WingID=@WingID  order by WingID asc";
                sql = @"select WingName,WingID from wing WHERE WingID=@WingID  order by serial_no asc";
            }
            else {
                //  sql = @"select WingName,WingID from wing order by WingID asc";
                sql = @"select WingName,WingID from wing  order by serial_no asc";

            }

                DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@WingID", Convert.ToString(Session["WingID"])) });
                ddlwings.DataSource = dt;
         
            ddlwings.DataTextField = "WingName";
                ddlwings.DataValueField = "WingID";
               ddlwings.Attributes.Remove("Wing");
                ddlwings.DataBind();

                ddlwings.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                ddlwings.SelectedValue = Convert.ToString(Session["WingID"]);
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
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                sql = @"select CircleName,CircleID from Circles WHERE CircleID='" + Convert.ToString(Session["CircleID"]) + "'  order by CircleID asc";
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
           
            if (Convert.ToString(Session["Role"]) == "DIVADM")
            {
                ddlcircle.SelectedValue = Convert.ToString(Session["CircleID"]);
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
                if (Session["Role"].ToString() == "DIVADM")
                {
                    sql = @"select DivisionID,DivisionName from Divisions WHERE DivisionID='" + Session["DivisionID"].ToString() + "'  order by DivisionID asc";
                    //sql = @"select WingName,WingID from wing WHERE WingID=@WingID  order by WingID asc";
                }
                else
                {
                    sql = @"SELECT DivisionName,DivisionID, CircleID FROM Divisions where CircleID=@CircleID   order by DivisionName";
                }
                dt = cls.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@CircleID", ddlcircle.SelectedValue)});

                ddldivision.DataSource = dt;
                ddldivision.DataTextField = "DivisionName";
                ddldivision.DataValueField = "DivisionID";
                ddldivision.DataBind();

                ddldivision.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
                if (Session["Role"].ToString() == "DIVADM")
                {
                    ddldivision.SelectedValue = Session["DivisionID"].ToString();
                    ddldivision.Enabled = false;
                }
            }
            catch (Exception ex)
            {


            }
        




    }

    protected void grdEistingRecord_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       

            if (e.CommandName == "Modify")
             {
          
            Session["RoadID"] = e.CommandArgument.ToString();
           //// Session["CircleID"] = e.CommandArgument.ToString();               
                Response.Redirect("UpdateRoadMaster.aspx");

           // Server.Transfer("UpdateRoadMaster.aspx");
        }
        //if (e.CommandName == "View")
        //{
        //    Session["RoadID"] = e.CommandArgument.ToString();
        //    Session["CircleID"] = e.CommandArgument.ToString();
        //    Response.Redirect("ViewRoadMaster.aspx");
        //}


        if (e.CommandName == "remove")
        {

            string RoadId = e.CommandArgument.ToString();
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;
            // TextBox txtName_of_the_Road = (TextBox)grdEistingRecord.Rows[rowIndex].FindControl("txtName_of_the_Road");

            SqlParameter slnos = new SqlParameter("@RoadId", RoadId);

            string sql = @"UPDATE  RoadMaster SET  IsDelete ='N' where RoadId=@RoadId";

            int a = cls.ExecuteSql(sql, new SqlParameter[] { slnos });
            if (a != 0)
            {
                Utility.showMessage(Page, "Record Sucessfully deleted...");
                BindGrid();

            }
            else
            {
                Utility.showMessage(Page, "Record Not Sucessfully deleted...");

            }
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
        BindRoadType();
      //  BindDivision();


        //ddldivision.SelectedValue = "0";


         //ddldivision.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));
        // BindGrid();


    }
    
    protected void grdEistingRecord_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
        grdEistingRecord.PageIndex = e.NewPageIndex;
        grdEistingRecord.DataBind();
        BindGrid();
    }
    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {

        //BindGrid();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        // BindWings();

        if ( Convert.ToString(Session["Role"]) == "DIVADM")
        {
            ddl_roadtype.SelectedValue = "0";

            BindGrid();
        }
        else
        {
            ddlwings.SelectedValue = "0";
            ddlcircle.SelectedValue = "0";
            ddldivision.SelectedValue = "0";
            ddl_roadtype.SelectedValue = "0";
            BindGrid();

        }
        
        //ddlwings.SelectedValue = "0";
        //ddlcircle.SelectedValue = "0";
        //ddldivision.SelectedValue = "0";
        //ddl_roadtype.SelectedValue = "0";
       
       // BindGrid();
    }

    protected void btn_view_Click(object sender, EventArgs e)
    {
        //if(IsPostBack)
        //{

        //}

        BindGrid();
    }

    //private void RoadType()
    //{
    //    try
    //    {
    //        string sql = "";
    //        sql = @" select RoadTypeId,description from RoadType order by RoadTypeId asc";
    //        DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { });
    //        ddl_roadtype.DataSource = dt;
    //        ddl_roadtype.DataTextField = "description";
    //        ddl_roadtype.DataValueField = "RoadTypeId";
    //        ddl_roadtype.DataBind();

    //        ddl_roadtype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---All---", "0"));

    //    }
    //    catch (Exception ex)
    //    {

    //    }


    //}

    void BindRoadType()
    {
        string sql = string.Empty;
        if (ddlwings.SelectedValue == "3")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId=3 order by description";
        else if (ddlwings.SelectedValue == "1" || ddlwings.SelectedValue == "2" || ddlwings.SelectedValue == "7")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId<>3 order by description";

        else if (ddlwings.SelectedValue.Trim() == "5")
            sql = "SELECT  RoadTypeId, description as RoadType FROM RoadType where RoadTypeId In (3,2) order by description";

        DataTable dt = cls.GetDataTable(sql);
        ddl_roadtype.DataSource = dt;
        ddl_roadtype.DataTextField = "RoadType";
        ddl_roadtype.DataValueField = "RoadTypeId";
        ddl_roadtype.DataBind();
        ddl_roadtype.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void ddl_roadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindRoadType();
    }

    //protected void btn_export_to_excel_Click(object sender, EventArgs e)
    //{
    //    this.grdEistingRecord.Columns[7].Visible = false;
    //    this.grdEistingRecord.Columns[8].Visible = true;
    //    this.grdEistingRecord.Columns[9].Visible = true;
    //    this.grdEistingRecord.Columns[10].Visible = true;
    //    this.grdEistingRecord.Columns[11].Visible = true;
    //    this.grdEistingRecord.Columns[12].Visible = true;
    //    this.grdEistingRecord.Columns[13].Visible = true;
    //    this.grdEistingRecord.Columns[14].Visible = true;
    //    this.grdEistingRecord.Columns[15].Visible = true;
    //    this.grdEistingRecord.Columns[16].Visible = true;
    //    Response.ClearContent();
    //    Response.AddHeader("content-disposition", "attachment;filename=RoadMaster.xls");
    //    Response.ContentType = "application/excel";
    //    StringWriter sw = new StringWriter(); ;
    //    HtmlTextWriter htm = new HtmlTextWriter(sw);
    //    grdEistingRecord.AllowPaging = false;
    //    this.BindGrid();
    //    grdEistingRecord.RenderControl(htm);
    //    Response.Write(sw.ToString());
    //    Response.End();
    //}

    protected void grdEistingRecord_RowCreated1(object sender, GridViewRowEventArgs e)
    {
       
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void add_RoadMaster_Click(object sender, ImageClickEventArgs e)
    {
        
        Response.Redirect("RoadEntry.aspx");
    }

  private void totalcount()
    {


        string query = @" SELECT COUNT(RoadId) as Total  FROM RoadMaster";
        DataTable dt = cls.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            lbltotalcount.Text = "Total Count- " + " " + dt.Rows[0][0].ToString();
        }

    }


    private void TOTALCOUNT1() 
    {

        if (Convert.ToString(Session["Role"]) == "DIVADM")
        {
            ddlwings.SelectedValue = Convert.ToString(Session["WingID"]);
            ddlcircle.SelectedValue = Convert.ToString(Session["CircleID"]);
            ddldivision.SelectedValue = Convert.ToString(Session["DivisionID"]);


            string query = @" SELECT COUNT(RoadId) as Total  FROM RoadMaster where WingID='" + ddlwings.SelectedValue + "' and CircleID='" + ddlcircle.SelectedValue + "' and DivisionId='" + ddldivision.SelectedValue + "'";
            DataTable dt = cls.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                lbltotalcount.Text = "Total Count- " + " " + dt.Rows[0][0].ToString();
            }
        }





        else
        {
            if ((Session["Role"].ToString()) == "")
            {
                Response.Redirect("~/PMIS/Login.aspx");
            }
            else
            {

                if (Session["Role"].ToString() == "ADM")
                {
                    string query = @" SELECT COUNT(RoadId) as Total  FROM RoadMaster";
                    DataTable dt = cls.GetDataTable(query);
                    if (dt.Rows.Count > 0)
                    {
                        lbltotalcount.Text = "Total Count- " + " " + dt.Rows[0][0].ToString();
                    }

                }
            }


        }
    }
   
    protected void grdEistingRecord_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //for action edit and delete hide and show
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Session["Role"].ToString() == "DIVADM")
            {
                string _edi = grdEistingRecord.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string _del = grdEistingRecord.DataKeys[e.Row.RowIndex].Values[1].ToString();
                if(_edi=="Y" && _del == "Y")
                {
                    LinkButton lnkBtnupdt = (LinkButton)e.Row.FindControl("lnk_update");
                    lnkBtnupdt.Visible = true;
                    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnk_delete");
                    lnkBtn.Visible = true;
                }
               else if (_edi == "Y" && _del == "N")
                {
                    LinkButton lnkBtnupdt = (LinkButton)e.Row.FindControl("lnk_update");
                    lnkBtnupdt.Visible = true;
                    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnk_delete");
                    lnkBtn.Visible = false;
                }
                else if (_edi == "N" && _del == "Y")
                {
                    LinkButton lnkBtnupdt = (LinkButton)e.Row.FindControl("lnk_update");
                    lnkBtnupdt.Visible = false;
                    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnk_delete");
                    lnkBtn.Visible = true;
                }
                else if (_edi == "N" && _del == "N")
                {
                    LinkButton lnkBtnupdt = (LinkButton)e.Row.FindControl("lnk_update");
                    lnkBtnupdt.Visible = false;
                    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnk_delete");
                    lnkBtn.Visible = false;
                }



                //else
                //{
                //    LinkButton lnkBtnupdt = (LinkButton)e.Row.FindControl("lnk_update");
                //    lnkBtnupdt.Visible = false;
                //    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnk_delete");
                //    lnkBtn.Visible = false;
                //}
                
            }

            else
            {
                LinkButton lnkBtnupdt = (LinkButton)e.Row.FindControl("lnk_update");
                lnkBtnupdt.Visible = true;
                LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnk_delete");
                lnkBtn.Visible = true;
            }
        }
    }

    //protected void btn_roadsearch_Click(object sender, EventArgs e)
    //{
    //    //BindGridForRoadSuggestion();
    //}
}