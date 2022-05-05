using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Summary description for sqlinjec
/// </summary>
public class sqlinjec
{
	public sqlinjec()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public bool sqlinj_postmethod(int injectiontype)
    {
        bool b;
        int formlen = 0;
        int count = 0;
        String all_post_values = "";
        String all_get_values = "";
        //int i = 99;
        String[] mychar = new String[99]; { }
      
        // 23-06-2015 original  String[] mychar1 = new String[] { "!", "%", "^", "*", "(", ")", "~", "=", "?", ";", ":", ";", "<", ">", "{", "}", "[", "]", "|" };

        String[] mychar1 = new String[] { "!", "%", "^", "*", "(", ")", "~", "=", "?", ";", ";", "<", ">", "{", "}", "[", "]", "|", "'", "\"" };        // ":" ,  removed,  ,single and double quote added 23-06-2015


        String[] mycharsk22 = new String[] {"!", "%", "*", "=", "<", ">", "'", "\"" };        // added 25-06-2015 for application update


        
     //original sk 23-06-2015   String[] mysql = new String[] { "drop", "select", "insert", "exec", "sp_", "update", "delete" };  //due to select application entry is not working

     //sk 25-06-2015     String[] mysql = new String[] { "drop", "insert", "exec", "sp_", "update", "delete" };   //in application update it is not working due to Update text on update button

       String[] mysql = new String[] { "drop", "insert", "exec", "sp_", "delete" };   // added on 25-06-2015


        String[] ReportCharArray = new String[] { "@", "!", "$", "%", "^", "*", "(", ")", "~", ";", ":", ";", "<", ">", "{", "}", "[", "]", "/" };
        if (injectiontype == 1)
        {
            mychar = mychar1;
        }
        
        if (injectiontype == 2)
        {
            mychar = ReportCharArray;
        }


        if (injectiontype == 3)
        {
            mychar = mycharsk22;
        }




        all_get_values = System.Web.HttpContext.Current.Request.QueryString.ToString();


        for (int j = 0; j <= mychar.Length - 1; j++)
        {
            if (all_get_values.IndexOf(mychar[j]) > -1)
            {
                count = 1;
                break;
            }
        }
        for (int j = 0; j <= mysql.Length - 1; j++)
        {
            if (all_get_values.IndexOf(mysql[j]) > -1)
            {
                count = 1;
                break;
            }
        }

        formlen = System.Web.HttpContext.Current.Request.Form.AllKeys.Length;

        for (int i = 0; i <= formlen - 1; i++)
        {

            if (System.Web.HttpContext.Current.Request.Form.AllKeys[i].Substring(0, 1) == "_")
            {
                // break;
                //goto 10;
                // string s = "s";
            }
            else
            {

              //original sk 23-06-2015  all_post_values = System.Web.HttpContext.Current.Request.Form.Get(i);
                
                all_post_values = System.Web.HttpContext.Current.Request.Form.Get(i).ToLower();
             
                
                for (int j = 0; j <= mychar.Length - 1; j++)
                {
                    if (all_post_values.IndexOf(mychar[j]) > -1)
                    {
                        count = 1;
                        break;
                    }
                }
                for (int j = 0; j <= mysql.Length - 1; j++)
                {
                    if (all_post_values.IndexOf(mysql[j]) > -1)
                    {
                        count = 1;
                        break;
                    }
                }

            }


        }

        if (count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
