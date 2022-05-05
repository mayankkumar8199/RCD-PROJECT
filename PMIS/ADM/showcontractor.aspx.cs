using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class showcontractor : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        showrecored();
    }
    void showrecored()
    {
        string sql = @"SELECT c.ContractorID,v.TotalWorks,c.RegYear,ContractorName,ContractorClass,RegistrationType,RegistrationNo,LetterNo,LetterDate,PAN,DebarYN,DebarDate,BlacklistedYN,BlacklistDate,Remarks,Address,MobileFROM  Contractor as c
        
  inner join View_ContractorProjectCountnew as v on v.ContractorID=c.ContractorID
  inner join   ViewRegyear as vv on vv.RegYear=c.RegYear";
             

        DataTable dtt = cls.GetDataTable(sql);
        if (dtt.Rows.Count > 0)
        {
            grdshow.DataSource = dtt;
            grdshow.DataBind();
        }
    }
}