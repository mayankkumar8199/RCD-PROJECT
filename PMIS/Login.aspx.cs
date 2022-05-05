using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;
public partial class RCDPMISNEW_Login_Page : System.Web.UI.Page
{
    private Random random = new Random();
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ccJoin.UserValidated)
        {
            Session["Role"] = null;
            Session["wing"] = null;
            Session["cirid"] = null;


            lblMsg.Visible = true;
            lblMsg.Text = "Enter Text Again Shown in Code";
            txtCaptha.Focus();
            return;
        }
    }
    public void login()
    {
        if (ValidateInput.CheckSqlInjection(txtUserName.Text) == false || ValidateInput.CheckSqlInjection(txtPassword.Text) == false)
        {
            lblMsg.Text = "Invalid Character : Username and Password should not contain characters ' and ; ";
            return;
        }
        if (txtUserName.Text.Trim() == "")
        {
            lblMsg.Text = "Enter User Name!";
            txtUserName.Focus();
            return;
        }
        if (txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Enter Password!";
            txtPassword.Focus();
            return;
        }

        ccJoin.ValidateCaptcha(txtCaptha.Text.Trim());
        if (!ccJoin.UserValidated)
        {
            lblMsg.Text = "Enter Text Again Shown in Code!";
            txtCaptha.Focus();
            Response.Cookies["CaptchaImageText"].Value = Utility.GenerateRandomCode();
            return;
        }

        Encryptor enc = new Encryptor(Encryptor.PrivateKey);
        string strQuery = @"SELECT UserRole.UserRoleDesc, UserRole.UserRoleID, UserLogin.UserID, UserLogin.District_Code, UserLogin.Password,UserLogin.DeptCode, 
                                       UserLogin.Islock,  UserLogin.DivisionID, UserLogin.CircleID, UserLogin.WingID,UserLogin.UserName,divi.ActionEdit,divi.ActionDelete FROM UserLogin INNER JOIN UserRole ON UserLogin.Userrole = UserRole.UserRoleID
                                       left join Divisions as divi on divi.DivisionID=UserLogin.DivisionID
                            WHERE      (UserLogin.UserID = @USERID) AND (UserLogin.Password = @PWD) ";

        SqlParameter prmUserID = new SqlParameter("@USERID", SqlDbType.VarChar, 50);
        prmUserID.Value = txtUserName.Text.Trim();

        SqlParameter prmPWD = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
        prmPWD.Value = enc.Encrypt(txtPassword.Text.Trim());// enc.Encrypt(PWD);
        //enc.Encrypt(txtPassword.Text.Trim().ToString())

        //  SqlParameter prmDept = new SqlParameter("@DeptCode", "BCD");

        DataTable dt = cls.GetDataTable(strQuery, new SqlParameter[] { prmUserID, prmPWD });

        if (dt.Rows.Count == 0)
        {
            lblMsg.Text = "Invalid User Name/Password";
            return;
        }
        else if (dt.Rows[0]["IsLock"].ToString().Trim() == "Y")
        {
            lblMsg.Text = " Your account has been locked. Please Contact Administrator";
            return;
        }
        else
        {
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(1).ToString();

            Session["Role"] = dt.Rows[0]["UserRoleID"].ToString().Trim();
            Session["UserID"] = dt.Rows[0]["UserID"].ToString().Trim();

            Session["DivisionID"] = dt.Rows[0]["DivisionID"].ToString().Trim();
            Session["WingID"] = dt.Rows[0]["WingID"].ToString().Trim();
            Session["UserName"] = dt.Rows[0]["UserName"].ToString().Trim();
            Session["CircleID"] = dt.Rows[0]["CircleID"].ToString().Trim();


            //if (dt.Rows[0]["ActionEdit"].ToString().Trim() == "")
            //{
            //    Session["ActionEdit"] = "P";
            //}
            //else
            //{
            //    Session["ActionEdit"] = dt.Rows[0]["ActionEdit"].ToString().Trim();
            //}

            //if (dt.Rows[0]["ActionDelete"].ToString().Trim() == "")
            //{
            //    Session["ActionDelete"] = "P";
            //}
            //else
            //{
            //    Session["ActionDelete"] = dt.Rows[0]["ActionDelete"].ToString().Trim();
            //}



            FormsAuthentication.Initialize();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUserName.Text.Trim() + "(" + dt.Rows[0]["UserName"].ToString().Trim() + ")", DateTime.Now, DateTime.Now.AddMinutes(30), false, dt.Rows[0]["UserRoleID"].ToString(), FormsAuthentication.FormsCookiePath);

            // Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); // Hashed ticket

            // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            // Add the cookie to the list for outgoing response
            Response.Cookies.Add(cookie);

            string strRole = dt.Rows[0]["UserRoleID"].ToString().Trim();

            string returnUrl = Request.QueryString["ReturnUrl"];
            if (strRole == "SUPERADMIN")
            {
                //returnUrl = "ADM/Default.aspx";
                returnUrl = "ADM/Dashboard.aspx";
                Response.Redirect(returnUrl);
            }
          else  if (strRole == "ADM")
            {
                //returnUrl = "ADM/Default.aspx";
                returnUrl = "ADM/Dashboard.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "WINGADM")
            {
                returnUrl = "Common/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "CIRADM")//circle adm entry
            {
                // string cirid = txtUserName.Text;
                // Session["circleid"] = cirid;
                returnUrl = "Common/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "DIVADM")
            {
                //returnUrl = "ADM/Default.aspx";
                returnUrl = "ADM/Dashboard.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "DIR" || strRole == "MON")
            {
                returnUrl = "ADM/ConsolidatedReport.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "MINCELL")
            {
                returnUrl = "MIN/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "GRVADM")
            {
                returnUrl = "Grievance/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "INSP")//sid team login december
            {
                returnUrl = "Inspection/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "ODIVADM")
            {
                returnUrl = "ODIV/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "SIDAUG")
            {
                returnUrl = "Inspection/Defaultsid.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "FLYSQADTTRI")
            {
                returnUrl = "DIR/Default.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "BRPNNLDIV")
            {
                returnUrl = "BRPNNL/BrpnnlInsertQc.aspx";
                Response.Redirect(returnUrl);
            }
            else if (strRole == "BRPNNLMD")
            {
                returnUrl = "BRPNNL/ViewBrpnnlQCReport.aspx";
                Response.Redirect(returnUrl);
            }
            else
            {
                returnUrl = "Login.aspx";
                Response.Redirect(returnUrl);
            }
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        login();
    }

  
}