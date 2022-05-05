using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
/// <summary>
/// Summary description for SessionCls
/// </summary>
    public class SessionCls : System.Web.UI.Page
{
    // Used on ALL pages to access the user's session state
    public CPensionSession cpensionsession;
    public SessionCls()
    {
    }
    /// <summary>
    /// Automatically invoked before the page is displayed
    /// </summary>
    /// 
    protected override void OnPreInit(EventArgs e)
    {
        cpensionsession = new CPensionSession(this.Session);
        base.OnPreInit(e);
    }
    protected override void OnLoad(EventArgs e)
    {
        // Instantiate a new UserSession object
        cpensionsession = new CPensionSession(this.Session);
        base.OnLoad(e);
    }
}

    public class SessionKeyItems
    {
        public const string session_dist = "distname";
        public const string session_tres = "tresname";
        public const string session_hod = "hodname";
        public const string session_dpt = "deptname";
        public const string session_ddo = "ddoname";
        public const string Session_pwd = "none";
        public const string Session_role = "norole";
        public const string Session_ddodesig = "none";
        public const int Session_recid = 0;
        public const string session_freezeddocd = "none";
        public const string Session_divcode = "aa";
        public const string Session_Ddistcd = "distcodeforDirect";
        public const string Session_Ddptcd = "deptcodeforDirect";
        public SessionKeyItems()
        {
        }
    }

    public class CPensionSession
    {
        private HttpSessionState userSessionstate;
        
        public CPensionSession(HttpSessionState httpSessionState)
        {
            // Remember the HTTP session state for this user
            userSessionstate = httpSessionState;
        }
        public string Session_distkey
        {
            get { 
                    return (string) userSessionstate[SessionKeyItems.session_dist];
                }
            set {
                    userSessionstate[SessionKeyItems.session_dist] = value; 
                }
        }
        public string Session_treskey
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.session_tres];
            }
            set
            {
                userSessionstate[SessionKeyItems.session_tres] = value;
            }
        }
        public string Session_hodkey
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.session_hod];
            }
            set
            {
                userSessionstate[SessionKeyItems.session_hod] = value;
            }
        }
        public string Session_deptkey
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.session_dpt];
            }
            set
            {
                userSessionstate[SessionKeyItems.session_dpt] = value;
            }
        }
        public string Session_ddokey
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.session_ddo];
            }
            set
            {
                userSessionstate[SessionKeyItems.session_ddo] = value;
            }
        }
        public string Session_pwd
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.Session_pwd];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_pwd] = value;
            }
        }
        public string Session_ddodesig
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.Session_ddodesig];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_ddodesig] = value;
            }
        }
        public string Session_role
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.Session_role];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_role] = value;
            }
        }
        public int Session_recid
        {
            get
            {
                return (int)userSessionstate[SessionKeyItems.Session_recid];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_recid] = value;
            }
        }
        public string session_freezeddocd
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.session_freezeddocd];
            }
            set
            {
                userSessionstate[SessionKeyItems.session_freezeddocd] = value;
            }
        }
        public string Session_divcode
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.Session_divcode];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_divcode] = value;
            }
        }
        public string Session_Ddistcd //unused
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.Session_Ddistcd];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_Ddistcd] = value;
            }
        }
        public string Session_Ddptcd //unused
        {
            get
            {
                return (string)userSessionstate[SessionKeyItems.Session_Ddptcd];
            }
            set
            {
                userSessionstate[SessionKeyItems.Session_Ddptcd] = value;
            }
        }
    }

  
