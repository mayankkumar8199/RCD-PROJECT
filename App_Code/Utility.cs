using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
//using DataAccessLayer;
/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    String SQL = null;
   // DataLayer oDL = new DataLayer();
  //  DataLayer daLayer = new DataLayer();
    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
        string SQL = string.Empty;
    }

    public static string OpenNewWindow(string URL, string width)
    {
        string str = "window.open('" + URL + "','name','type=letf=210,top=80,width=" + width + ",resizable=no,toolbar=0,addressbar =0,  top=no,  scrollbars=yes')";
        return str;
    }

    public static string OpenNewWindow(string URL, string width, string height)
    {
        string str = "window.open('" + URL + "','name','type=letf=210,top=80,width=" + width + ",height=" + height + ",resizable=no,toolbar=0,addressbar =0, top=no,  scrollbars=yes')";
        return str;
    }



    public DataTable FetchDataForDailyReport(GridView gv, Byte uid)
    {
        DataTable dt = new DataTable();
        SQL = "SELECT (convert (varchar,Rep_Date,106)) As Rep_Date, Stat_email, Stat_website, Stat_vsupload, Stat_adhikar, Stat_vpn, Othr_issue FROM Report_Data WHERE Logid ='" + uid + "' ORDER BY Rep_Date DESC";
       // dt =daLayer.FetchaData(SQL);
        return dt;
    }
    public DataTable FetchDataForDailyAdminReport(GridView gv, DateTime d)
    {
        DataTable dt = new DataTable();
        SQL = "SELECT Log_Users.District, Report_Data.Stat_email, Report_Data.Stat_website, Report_Data.Stat_vsupload, Report_Data.Stat_adhikar, Report_Data.Stat_vpn, Report_Data.Othr_issue FROM Log_Users INNER JOIN Report_Data ON Log_Users.Logid = Report_Data.Logid WHERE Report_Data.Rep_Date='" + d.ToString("dd-MMM-yyyy") + "' ORDER BY Log_Users.District";
    //    dt = daLayer.FetchaData(SQL);
        return dt;
    }
    public DataTable FetchDataForLastReportedOn(GridView gv)
    {
        DataTable dt = new DataTable();
        SQL = "SELECT Log_Users.District, Log_Users.First_Name, Log_Users.Last_Name, (convert (varchar,Report_Status.Last_Rep_Date,106)) As Last_Rep_Date FROM Log_Users INNER JOIN Report_Status ON Log_Users.Logid = Report_Status.Logid ORDER BY Log_Users.District";
      //  dt = daLayer.FetchaData(SQL);
        return dt;
    }



    /// <returns>Hexadecimal of input</returns>
    public static string UnicodeHexadecimal(string input)
    {
        string result = string.Empty;
        foreach (char c in input)
        {
            int tmp = c;
            result += String.Format("{0:x4}", (uint)System.Convert.ToUInt32(tmp.ToString()));
        }
        result = result.ToUpper();
        return result;
    }


    public static string StringToHex(string text)
    {
        string hex = "";
        foreach (char c in text)
        {
            int tmp = c;
            hex += (uint)System.Convert.ToUInt32(tmp.ToString()) + "x";
        }
        return hex;
    }


    public static string HexToString(string HexStr)
    {
        string text = "";
        string[] hex = HexStr.Split('x');


        foreach (string str in hex)
        {

            if (str.Trim() == "") continue;
            text += (char)int.Parse(str);
        }
        return text;
    }


    public static string ReplaceInvComma(string Name)
    {
        string retName;
        retName = Name.Replace("'", "''");
        return retName;
    }

    //public static int GenSLNo(string TabName, string ColName)
    //{

    //    int SlNo;
    //    clsDataAccess cls = new clsDataAccess();
    //    string sql = "select max(" + ColName + ") as SlNo from " + TabName + "";
    //    object MaxSl = cls.ExecuteScalar(sql, null);
    //    if (MaxSl != null && MaxSl != DBNull.Value)
    //    {
    //        SlNo = int.Parse(MaxSl.ToString()) + 1;
    //        return SlNo;
    //    }
    //    else
    //    {
    //        SlNo = 1;
    //        return SlNo;
    //    }
    //}

    public static void showMessage(Page page, string Message)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "Msg", "alert('" + Message + "');", true);
    }
    public static void showMessageNavigate(Page page, string Message, string navigateUrl)
    {
        string s = "alert('" + Message + "');var vers = navigator.appVersion;if(vers.indexOf('MSIE 7.0') != -1) { window.location.href='" + navigateUrl + "';} else{ window.location.href='" + navigateUrl + "';}";
        page.ClientScript.RegisterStartupScript(page.GetType(), "Information", s, true);

    }


    public static string Base64Encode(string str)
    {
        byte[] encbuff = Encoding.UTF8.GetBytes(str);
        return HttpServerUtility.UrlTokenEncode(encbuff);
    }
    ///<summary> 
    /// Decode Base64 encoded string with URL and Filename Safe Alphabet using UTF-8. 
    ///</summary> 
    ///<param name="str">Base64 code</param> 
    ///<returns>The decoded string.</returns> 
    public static string Base64Decode(string str)
    {
        byte[] decbuff = HttpServerUtility.UrlTokenDecode(str);
        return Encoding.UTF8.GetString(decbuff);
    }

    public static string GenerateRandomCode()
    {
        Random random = new Random();
        string s = "";
        for (int i = 0; i < 4; i++)
            s = String.Concat(s, random.Next(10).ToString());
        return s;
    }

}
