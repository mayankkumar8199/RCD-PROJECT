using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

/// <summary>
/// Summary description for sqlinj
/// </summary>
public class sqlinj
{
    public sqlinj()
    { }
		//
		// TODO: Add constructor logic here
		//
   
public static void sqlinj_postmethod()
	{
        string strURL1 = "";
        string strurl = "";

        strurl = "http://localhost";
	   //strurl = "http://demo.mp.nic.in";
      //  strURL1 = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
        strURL1 = "http://"+ System.Web.HttpContext.Current.Request.Url.Host.ToString();
    
//        if (strURL1 != strurl.ToString())
//      {
//          System.Web.HttpContext.Current.Response.Write("</head><body>");
//			System.Web.HttpContext.Current.Response.Write("<script>alert('web page inaccessible');</script>");
//          System.Web.HttpContext.Current.Response.Write("Page is not accessible");
//          System.Web.HttpContext.Current.Session.Abandon();
//          System.Web.HttpContext.Current.Response.End();
//          // System.Web.HttpContext.Current.Response.Write("<script>window.close();</script>");
//      }
        string all_post_values = "";
        string all_get_values = "";
        string[] mychar = new string[] {  "!", "$", "%", "^", "*", "(", ")", "=", "~", ";",  ";", "<", ">", "{", "}", "[", "]", "\\" };
        string[] mysql = new string[] { "drop", "insert", "exec", "sp_","update","delete"};
        int formlen = 0;
        int count = 0;
       
    //get values
    all_get_values = System.Web.HttpContext.Current.Request.QueryString.ToString();
    for (int j = 0; j < mychar.Length; j++)
        {
            if (all_get_values.IndexOf(mychar[j]) > -1)
            {
                count = 1;
                 break;
            }
        }
        for (int j = 0; j < mysql.Length; j++)
        {
            if (all_get_values.IndexOf(mysql[j]) > -1)
            {
                count = 1;
                break;
            }
        }
        //Post values
        formlen = System.Web.HttpContext.Current.Request.Form.AllKeys.Length;
        for (int i = 0; i < formlen; i++)
        {
            if (System.Web.HttpContext.Current.Request.Form.AllKeys[i].Substring(0,1) == "_")
            {
                continue;
            }
        all_post_values = System.Web.HttpContext.Current.Request.Form.Get(i);
            for (int j = 0; j < mychar.Length; j++)
            {
                if (all_post_values.IndexOf(mychar[j]) > -1)
                {
                    count = 1;
                   break;
                }
            }
            
            for (int j = 0; j < mysql.Length; j++)
            {
                if (all_post_values.IndexOf(mysql[j]) > -1)
                {
                    count = 1;
                   break;
                }
            }
        }
            if (count != 0)
            {
                 // System.Web.HttpContext.Current.Response.End();
              //  System.Web.HttpContext.Current.Response.Redirect("default.aspx");
              //Response.Write("<script>window.open('PageName.aspx','FrameName');</script>") 
              System.Web.HttpContext.Current.Response.Write("<script>window.open('error.aspx','_top');</script>");
    
           }
            else
            {
               return ;
            }
       
    }
public static void sqlinj_emailmethod()
    {

        string strURL1 = "";
        string strurl = "";

        strurl = "http://localhost";
	    //strurl = "http://demo.mp.nic.in";
        //  strURL1 = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
        strURL1 = "http://" + System.Web.HttpContext.Current.Request.Url.Host.ToString();

        if (strURL1 != strurl.ToString())
        {
            System.Web.HttpContext.Current.Response.Write("</head><body>");
            System.Web.HttpContext.Current.Response.Write("<script>alert('web page inaccessible');</script>");
            System.Web.HttpContext.Current.Response.Write("Page is not accessible");
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Response.End();
            // System.Web.HttpContext.Current.Response.Write("<script>window.close();</script>");
        }

        string all_post_values = "";
        string all_get_values = "";
        string[] mychar = new string[] { "!", "$", "%", "^", "*", "(", ")", "=", "~", ";", ":", ";", "<", ">", "{", "}", "[", "]", "\\", "&" };
        string[] mysql = new string[] { "drop", "insert", "exec", "sp_", "update","delete"};
        int formlen = 0;
        int count = 0;

        //get values
        all_get_values = System.Web.HttpContext.Current.Request.QueryString.ToString();
        for (int j = 0; j < mychar.Length; j++)
        {
            if (all_get_values.IndexOf(mychar[j]) > -1)
            {
                count = 1;
                break;
            }
        }


        for (int j = 0; j < mysql.Length; j++)
        {
            if (all_get_values.IndexOf(mysql[j]) > -1)
            {
                count = 1;
                break;
            }
        }


        //Post values

        formlen = System.Web.HttpContext.Current.Request.Form.AllKeys.Length;
        for (int i = 0; i < formlen; i++)
        {
            if (System.Web.HttpContext.Current.Request.Form.AllKeys[i].Substring(0, 1) == "_")
            {
                continue;
            }
            all_post_values = System.Web.HttpContext.Current.Request.Form.Get(i);
            for (int j = 0; j < mychar.Length; j++)
            {
                if (all_post_values.IndexOf(mychar[j]) > -1)
                {
                    count = 1;
                    break;
                }
            }

            for (int j = 0; j < mysql.Length; j++)
            {
                if (all_post_values.IndexOf(mysql[j]) > -1)
                {
                    count = 1;
                    break;
                }
            }
        }
        if (count != 0)
        {
            // System.Web.HttpContext.Current.Response.End();
            //  System.Web.HttpContext.Current.Response.Redirect("default.aspx");
            //Response.Write("<script>window.open('PageName.aspx','FrameName');</script>") 
            System.Web.HttpContext.Current.Response.Write("<script>window.open('error.aspx','_top');</script>");

        }
        else
        {
            return;
        }

    }
public static void sqlinj_checkuser()
    {
        try
        {
            System.Web.HttpContext.Current.Response.CacheControl = "no-cache";
            System.Web.HttpContext.Current.Response.AddHeader("pargma", "no-cache");
            System.Web.HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
            System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //if (System.Web.HttpContext.Current.Session["stnm"].ToString() == "" || System.Web.HttpContext.Current.Session["dtnm"].ToString() == "" || System.Web.HttpContext.Current.Session["stcd"].ToString() == "" || System.Web.HttpContext.Current.Session["dtcd"].ToString() == "")
            if(System.Web.HttpContext.Current.Session.Count==0)
            {
                System.Web.HttpContext.Current.Response.Redirect("default.aspx");
            }

            if (System.Web.HttpContext.Current.Request.Cookies["userid"] != null)
            {
                //Label1.Text = Server.HtmlEncode(Request.Cookies["userName"].Value);
                string label1 = string.Empty;
                string label2 = string.Empty;
                if (System.Web.HttpContext.Current.Session["saltcook"].ToString() != "")
                {
                    label1 = System.Web.HttpContext.Current.Session["saltcook"].ToString();
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script>window.open('default.aspx','_top');</script>");
                }
                label2 = System.Web.HttpContext.Current.Server.HtmlEncode(System.Web.HttpContext.Current.Request.Cookies["userid"].Value.ToString());

                if (label1.ToString() != label2.ToString())
                {
                    System.Web.HttpContext.Current.Response.Write("<script>window.open('default.aspx','_top');</script>");
                }
                else
                {

                }
                //if (Request.Cookies["userid"] != null)
                //{
                //    HttpCookie aCookie = Request.Cookies["userName"];
                //    Label1.Text = Server.HtmlEncode(aCookie.Value);
                //}

            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>window.open('default.aspx','_top');</script>");

            }


        }
        catch (NullReferenceException nulref)
        {
            System.Web.HttpContext.Current.Response.Write("<script>window.open('default.aspx','_top');</script>");
        
        }
    }

   
}
