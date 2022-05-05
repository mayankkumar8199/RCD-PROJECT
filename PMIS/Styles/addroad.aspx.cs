using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;

public partial class addroad : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            bindwings();
        }
    }

    public void bindwings()
    {
        try
        {
            DataTable dt = new DataTable();


            dt = cls.GetDataTable(@"SELECT WingID,WingName FROM Wing;");
            if (dt.Rows.Count > 0)
            {
                ddlwings.DataSource = dt;
                ddlwings.DataTextField = "WingName";
                ddlwings.DataValueField = "WingID";
                ddlwings.DataBind();

                ddlwings.Items.Insert(0, new ListItem("--Select --", "0"));
                dt.Dispose();
            }
        }
        catch (Exception ex)
        {


        }
    
    
    }
}