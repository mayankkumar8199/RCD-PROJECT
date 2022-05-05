using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
/// Summary description for ConnectionCls
/// </summary>
public interface ConnectionInterface
{
    SqlConnection CreateConnection();
    void CloseConnection();
    void MessageBox(Page pg, string msgstr);
    string Convertdate(string datestr);
    void ReSet_AllControls(Control parent);
    Boolean DOADiffDOB(string doastr, string dobstr);
    string getDDODesignation(string ddocode);
    string GetDistHodTresDeptStr(string ddocode, int type);
}
public class ConnectionCls:ConnectionInterface 
{
    public SqlConnection sqlcon;
    public SqlCommand sqlcmd;
    protected SqlDataReader sqldr;
    protected string constr;
    private string doa_day;
    private string doa_mnt;
    private string doa_yr;
    private string dob_day;
    private string dob_mnt;
    private string dob_yr;
    private static string ddostring,depttresStr;
	public ConnectionCls()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SqlConnection CreateConnection()
    {
        constr = System.Configuration.ConfigurationManager.ConnectionStrings["aimsConnectionString"].ToString();
        sqlcon = new SqlConnection(constr);
        sqlcon.ConnectionString = constr;
        
        sqlcon.Open();
        return sqlcon;
    }
    public void CloseConnection()
    {
        sqlcon.Close();
    }
    public void MessageBox(Page pg,string msgstr)
    {
        string type_str;
        type_str = "<script language='Javascript' type ='text/javascript'>alert('" + msgstr + "');</script>";
        pg.ClientScript.RegisterStartupScript(GetType(), "showmessage", type_str);
    }
    public string Convertdate(string datestr)
    {
        int indx1, indx2;
        string returndate;
        char[] datearray = new char[10];
        char[] dayarray = new char[2];
        char[] montharray = new char[2];
        char[] yeararray = new char[4];
        int len;
        int i, j, k;
        string monthstr = "", daystr = "";
        returndate = "";

        if ((datestr != "") && (datestr.Length >= 8) || (datestr.Length <= 10))
        {
            indx1 = datestr.IndexOf("/");
            indx2 = datestr.LastIndexOf("/");
            len = datestr.Length;
            datearray = datestr.ToCharArray();
            //case 1 when date string is of type 01/12/2009
            if ((indx1 == 2) && (indx2 == 5))
            {
                for (j = indx1 + 1; j < indx2; j++)
                {
                    montharray[j - 3] = datearray[j];
                    returndate = returndate + montharray[j - 3];
                    monthstr = returndate;
                }
                if (Convert.ToInt32(monthstr) > 12)
                {
                    returndate = "month";
                }
                else
                {
                    returndate = returndate + "/";
                    for (i = 0; i < indx1; i++)
                    {
                        dayarray[i] = datearray[i];
                        daystr = daystr + dayarray[i];
                        returndate = returndate + dayarray[i];
                    }
                    if (Convert.ToInt32(daystr) > 31)
                    {
                        returndate = "Day";
                    }
                    else
                    {
                        returndate = returndate + "/";
                        for (k = indx2 + 1; k < len; k++)
                        {
                            yeararray[k - 6] = datearray[k];
                            returndate = returndate + yeararray[k - 6];
                        }
                    }
                }
            }
            //case 2: When date string is of type 1/2/2009 
            if ((indx1 == 1) && (indx2 == 3))
            {
                for (j = indx1 + 1; j < indx2; j++)
                {
                    montharray[j - 2] = datearray[j];
                    returndate = returndate + montharray[j - 2];
                    monthstr = returndate;
                }
                if (Convert.ToInt32(monthstr) > 12)
                {
                    returndate = "month";
                }
                else
                {
                    returndate = returndate + "/";
                    for (i = 0; i < indx1; i++)
                    {
                        dayarray[i] = datearray[i];
                        daystr = daystr + dayarray[i];
                        returndate = returndate + dayarray[i];
                    }
                    if (Convert.ToInt32(daystr) > 31)
                    {
                        returndate = "Day";
                    }
                    else
                    {
                        returndate = returndate + "/";
                        for (k = indx2 + 1; k < len; k++)
                        {
                            yeararray[k - 4] = datearray[k];
                            returndate = returndate + yeararray[k - 4];
                        }
                    }
                }
            }
            //case 2: When date string is of type 12/2/2009 
            if ((indx1 == 2) && (indx2 == 4))
            {
                for (j = indx1 + 1; j < indx2; j++)
                {
                    montharray[j - 3] = datearray[j];
                    returndate = returndate + montharray[j - 3];
                    monthstr = returndate;
                }
                if (Convert.ToInt32(monthstr) > 12)
                {
                    returndate = "month";
                }
                else
                {
                    returndate = returndate + "/";
                    for (i = 0; i < indx1; i++)
                    {
                        dayarray[i] = datearray[i];
                        daystr = daystr + dayarray[i];
                        returndate = returndate + dayarray[i];
                    }
                    if (Convert.ToInt32(daystr) > 31)
                    {
                        returndate = "Day";
                    }
                    else
                    {
                        returndate = returndate + "/";
                        for (k = indx2 + 1; k < len; k++)
                        {
                            yeararray[k - 5] = datearray[k];
                            returndate = returndate + yeararray[k - 5];
                        }
                    }
                }
            }
            //case 2: When date string is of type 1/12/2009 
            if ((indx1 == 1) && (indx2 == 4))
            {
                for (j = indx1 + 1; j < indx2; j++)
                {
                    montharray[j - 2] = datearray[j];
                    returndate = returndate + montharray[j - 2];
                    monthstr = returndate;
                }
                if (Convert.ToInt32(monthstr) > 12)
                {
                    returndate = "month";
                }
                else
                {
                    returndate = returndate + "/";
                    for (i = 0; i < indx1; i++)
                    {
                        dayarray[i] = datearray[i];
                        daystr = daystr + dayarray[i];
                        returndate = returndate + dayarray[i];
                    }
                    if (Convert.ToInt32(daystr) > 31)
                    {
                        returndate = "Day";
                    }
                    else
                    {
                        returndate = returndate + "/";
                        for (k = indx2 + 1; k < len; k++)
                        {
                            yeararray[k - 5] = datearray[k];
                            returndate = returndate + yeararray[k - 5];
                        }
                    }
                }
            }
        }
        return returndate;
    }
    public void ReSet_AllControls(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ReSet_AllControls(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = "";
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)c).Checked = false;
                        break;
                    //case "System.Web.UI.WebControls.RadioButton":
                    //    ((RadioButton)c).Checked = false;
                    //    break;
                    //case "System.Web.UI.WebControls.DropDownList":
                    //    ((DropDownList)c).SelectedValue = "-1";
                    //    break;
                    case "System.Web.UI.WebControls.ListBox":
                        ((ListBox)c).SelectedValue = "-1";
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).SelectedIndex = 0;
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).SelectedIndex = 1;
                        break;
                }
            }
        }
    }
    public Boolean  DOADiffDOB(string doastr, string dobstr)
    {
        Boolean resbool = false;
        int indx1, indx2;
        int doaint,dobint;
        if ((doastr!="")&&(dobstr!=""))
        {
            indx1 = doastr.IndexOf("/");
            indx2 = doastr.LastIndexOf("/");
            doa_day = doastr.Substring(0, indx1);
            doa_mnt = doastr.Substring(indx1 + 1, 2);
            doa_yr = doastr.Substring(indx2 + 1, 4);
            doaint = Convert.ToInt32(doa_yr.Trim () + doa_mnt.Trim () + doa_day.Trim ());
            indx1 = dobstr.IndexOf("/");
            indx2 = dobstr.LastIndexOf("/");
            dob_day = dobstr.Substring(0, indx1);
            dob_mnt = dobstr.Substring(indx1 + 1, 2);
            dob_yr = dobstr.Substring(indx2 + 1, 4);
            dobint = Convert.ToInt32(dob_yr.Trim() + dob_mnt.Trim() + dob_day.Trim());
            if ((Convert.ToInt32((doaint - dobint).ToString().Substring(0, 2)) >= 18) && (Convert.ToInt32((doaint - dobint).ToString().Substring(0, 2)) <= 60) && (doaint >= 20050101))
            {
                resbool=true;
            }
            else
            {
                resbool= false;
            }
        }
        return resbool;
    }
    public string getDDODesignation(string ddocode)
    {
        string querystr;
        try
        {
            querystr = "select dbo.initCap(designation) as desig ,ddo_code  from m_ddo where ddo_code=@ddocd";
            sqlcmd = new SqlCommand(querystr, CreateConnection());
            sqlcmd.Parameters.AddWithValue("@ddocd", ddocode.Trim());
            sqldr = sqlcmd.ExecuteReader();
            if (sqldr.HasRows)
            {
                sqldr.Read();
                if (!(sqldr.IsDBNull(0)) && !(sqldr.IsDBNull(1)))
                {
                    ddostring = sqldr.GetString(0) + "(" + sqldr.GetString(1) + ")";
                }
            }
            else
            {
                ddostring = "";
            }
            sqldr.Close();
        CloseConnection();
        }
        catch (SqlException ex)
        {
            //MessageBox(Page , ex.Number + " Can not find this ddo.");
        }
        return ddostring;
    }
    public string GetDistHodTresDeptStr(string ddocode,int type)
    {
        string querystr = "", distcode = "", trescode = "", deptcode = "" ,hodcode="";
        if (ddocode != "")
        {
            distcode = ddocode.Substring(0, 2);
            trescode = ddocode.Substring(2, 1);
            deptcode = ddocode.Substring(3, 2);
            hodcode = ddocode.Substring(5, 2);
        }
        try
        {
            switch (type)
            {
                case 1: querystr = "Select dbo.initcap(Treasury_Name)Treasury_Name from M_treasury where dist_code=@distcd and Tres_code=@trescode";
                    sqlcmd = new SqlCommand(querystr, CreateConnection());
                    sqlcmd.Parameters.AddWithValue("@distcd", distcode);
                    sqlcmd.Parameters.AddWithValue("@trescode", trescode.Trim());
                    break;
                case 2: querystr = "select dbo.initcap(Dept_Name)Dept_name from m_dept where dept_code=@deptcode";
                    sqlcmd = new SqlCommand(querystr, CreateConnection());
                    sqlcmd.Parameters.AddWithValue("@deptcode", deptcode.Trim());
                    break;
                case 3: querystr = "select dbo.initcap(Dist_Name) as dist_name from M_dist where dist_code=@distcd";
                    sqlcmd = new SqlCommand(querystr, CreateConnection());
                    sqlcmd.Parameters.AddWithValue("@distcd", distcode.Trim());
                    break;
                case 4: querystr = "select dbo.initcap(Hod_Name)Hod_Name from M_hod where dept_code=@deptcd and hod_code=@hdcode";
                    sqlcmd = new SqlCommand(querystr, CreateConnection());
                    sqlcmd.Parameters.AddWithValue("@deptcd", deptcode.Trim());
                    sqlcmd.Parameters.AddWithValue("@hdcode", hodcode.Trim());
                    break;
                default:
                    break;

            }
            sqldr = sqlcmd.ExecuteReader();
            if (sqldr.HasRows)
            {
                sqldr.Read();
                if (!(sqldr.IsDBNull(0)))
                {
                    depttresStr = sqldr.GetString(0);
                }
                else
                {
                    depttresStr = "";
                }
            }
            sqldr.Close();
            CloseConnection();
        }
        catch(SqlException ex)
        {
        }
        return depttresStr;
    }
 





}
