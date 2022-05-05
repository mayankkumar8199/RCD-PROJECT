using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class showallotment : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        showrecored();
    }
    void showrecored()
    {
        string sql = @"SELECT p.WingID,w.WingName,p.CircleID,c.CircleName,p.DivisionId,d.DivisionName,
             p.HeadId,h.headName,p.SubHeadID,s.SubHeadName,AllotmentAmount,AllotmentDate
FROM  Allotment as p
 inner join Wing as w on w.WingID=p.WingID
             inner join Circles as c on c.CircleID=p.CircleID
              inner join Divisions as d on d.DivisionId=p.DivisionId
			    inner join Head as h on h.HeadId=p.HeadId
				  inner join SubHead as s on s.SubHeadID=p.SubHeadID";

        DataTable dtt = cls.GetDataTable(sql);
        if (dtt.Rows.Count > 0)
        {
            grdshow.DataSource = dtt;
            grdshow.DataBind();
        }
    }
}