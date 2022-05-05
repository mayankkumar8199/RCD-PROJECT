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

public partial class PMIS_ADM_Allotmentt : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindwings();
            bindcircles();
            binddivisions();
            bindheads();
            bindSubHead();
        }
    }
    void bindwings()
    {
        try
        {
            string sql = @"select WingID,WingName from Wing";
            DataTable dt = cls.GetDataTable(sql);
            ddlwings.DataSource = dt;
            ddlwings.DataTextField = "WingName";
            ddlwings.DataValueField = "WingID";
            ddlwings.DataBind();
            ddlwings.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }



    }
    void bindcircles()
    {
        try
        {
            string sql = @"select CircleID,CircleName,WingID from Circles where WingID=@WingID ";
            SqlParameter WingID = new SqlParameter("@WingID", ddlwings.SelectedValue.ToString());
            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { WingID });
            ddlcircle.DataSource = dt;
            ddlcircle.DataTextField = "CircleName";
            ddlcircle.DataValueField = "CircleID";
            ddlcircle.DataBind();
            ddlcircle.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }



    }
    void binddivisions()
    {
        try
        {
            string sql = @"select DivisionID,DivisionName from Divisions";
            DataTable dt = cls.GetDataTable(sql);
            ddldivision.DataSource = dt;
            ddldivision.DataTextField = "DivisionName";
            ddldivision.DataValueField = "DivisionID";
            ddldivision.DataBind();
            ddldivision.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }





    }
    void bindheads()
    {
        try
        {
            string sql = @"select headID,headName from Head";
            DataTable dt = cls.GetDataTable(sql);
            ddlhead.DataSource = dt;
            ddlhead.DataTextField = "headName";
            ddlhead.DataValueField = "headID";
            ddlhead.DataBind();
            ddlhead.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }



    }
    void bindSubHead()
    {
        try
        {
            string sql = @"select SubHeadID,SubHeadName from SubHead";
            DataTable dt = cls.GetDataTable(sql);
            ddlsub.DataSource = dt;
            ddlsub.DataTextField = "SubHeadName";
            ddlsub.DataValueField = "SubHeadID";
            ddlsub.DataBind();
            ddlsub.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }



    }

    protected void ddlwings_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcircles();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string sql = @"insert into Allotment(WingID,CircleID,DivisionID,headId,SubHeadID,AllotmentAmount,EntryDate) values(@WingID,@CircleID,@DivisionID,@headId,@SubHeadID,@AllotmentAmount,@EntryDate)";

        SqlParameter Wings = new SqlParameter("@WingID", ddlwings.SelectedValue);
        SqlParameter Circle = new SqlParameter("@CircleID", ddlcircle.SelectedValue);
        SqlParameter Division = new SqlParameter("@DivisionID", ddldivision.SelectedValue);
        SqlParameter Head = new SqlParameter("@headId", ddlhead.SelectedValue);
        SqlParameter SubHeadID = new SqlParameter("@SubHeadID", ddlsub.SelectedValue);
        SqlParameter AllotmentAmount = new SqlParameter("@AllotmentAmount", txtalltment.Text.Trim());
        SqlParameter EntryDate = new SqlParameter("@EntryDate", txtdate.Text.Trim());

        if (cls.ExecuteSql(sql, new SqlParameter[] { Wings, Circle, Division, Head, SubHeadID, AllotmentAmount, EntryDate }) > 0)
        {
            Utility.showMessage(this, "Record Saved Successfully !");
        }
    }

}