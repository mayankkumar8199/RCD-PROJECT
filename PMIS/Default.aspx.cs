using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;

public partial class RCDPMISNEW_Default : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        //Response.Cache.SetNoStore();
        //txtUserId.Attributes.Add("autocomplete", "off");
        //txtCaptcha.Attributes.Add("autocomplete", "off");
        //if (!IsPostBack)
        //{
        //}
    }

    //protected void btn_login_Click(object sender, EventArgs e)
    //{
    //    if (txtUserId.Text.Length == 0)
    //    {
    //        lblMessage.Text = "Please enter UserID";
    //        return;
    //    }
    //    if (txtPassword.Text.Trim() == "")
    //    {
    //        lblMessage.Text = "Please enter Password";
    //        return;
    //    }
    //    if (txtCaptcha.Text.Trim().Length == 0)
    //    {
    //        txtCaptcha.Text = "";
    //        lblMessage.Text = "Please enter code as shown in image";
    //        return;
    //    }
    //    cptCaptcha.ValidateCaptcha(txtCaptcha.Text.Trim());
    //    if (cptCaptcha.UserValidated)
    //    {
    //        login();
    //    }
    //    else
    //    {
    //        lblMessage.Text = "Please enter code as shown in image";
    //        return;
    //    }
    //}

    public void login()
    {
        Encryptor enc = new Encryptor(Encryptor.PrivateKey);
      //  lblMessage.Text = string.Empty;
        string DistCode = string.Empty;
        string Role = string.Empty;
        string RoleSlNO = string.Empty;
        bool authorised = false;
        try
        {
            string sql = @"SELECT     UserRole.UserRoleDesc,Userrole, UserRole.UserRoleID, UserLogin.UserID, UserLogin.District_Code, UserLogin.Password,UserLogin.DeptCode, 
                                       UserLogin.Islock,  UserLogin.DivisionID, UserLogin.CircleID, UserLogin.WingID,UserLogin.UserName
                            FROM       UserLogin INNER JOIN
                                       UserRole ON UserLogin.Userrole = UserRole.UserRoleID
                  
                            WHERE      (UserLogin.UserID = @USERID) AND (UserLogin.Password = @PWD) ";

            SqlParameter prmUserID = new SqlParameter("@USERID", SqlDbType.VarChar, 50);
          //  prmUserID.Value = txtUserId.Text.Trim();

            SqlParameter prmPWD = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
          //  prmPWD.Value = enc.Encrypt(txtPassword.Text.Trim());// enc.Encrypt(PWD);
            //enc.Encrypt(txtPassword.Text.Trim().ToString())

            //  SqlParameter prmDept = new SqlParameter("@DeptCode", "BCD");

            DataTable dt = cls.GetDataTable(sql, new SqlParameter[] { prmUserID, prmPWD });
            // dtRole = cls.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                //Session.Add("Role", Convert.ToString(dt.Rows[0]["UserRoleID"]).Trim());
                ////Session.Add("RoleDesc", Convert.ToString(dtRole.Rows[0]["RoleDesc"]).Trim());
                //Session.Add("UserID", Convert.ToString(dt.Rows[0]["UserID"]).Trim());
                //Session.Add("DivisionID", Convert.ToString(dt.Rows[0]["DivisionID"]).Trim());
                //Session.Add("WingID", Convert.ToString(dt.Rows[0]["WingID"]).Trim());
                //Session.Add("UserName", Convert.ToString(dt.Rows[0]["UserName"]).Trim());
                //Session.Add("CircleID", Convert.ToString(dt.Rows[0]["CircleID"]).Trim());
                //Role = Convert.ToString(dt.Rows[0]["Userrole"]).Trim();
                //FormsAuthentication.SetAuthCookie(txtUserId.Text.Trim(), false);
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, dt.Rows[0]["UserName"].ToString(), DateTime.Now, DateTime.Now.AddMinutes(30), false, Role, FormsAuthentication.FormsCookiePath);
                //string hash = FormsAuthentication.Encrypt(ticket);
                //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                //if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                //Response.Cookies.Add(cookie);
                //authorised = true;
            }

        }
        catch (Exception exp)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Database error !!! - Error message: " + exp.Message;
        }
        finally
        {

        }

        if (authorised)
        {


            string returnUrl = "";
            switch (Session["Role"].ToString().Trim())
            {

                case "ADM":
                    returnUrl = "ADM/Default.aspx";
                    break;


                case "DEPT":
                    returnUrl = "DEPT/Default.aspx";
                    break;

                case "UNR":
                    returnUrl = "DEPT/Default.aspx";
                    break;


            }
            if (returnUrl.Trim().Length > 0)
            {
                Response.Redirect(returnUrl);

            }


            else
            {
                //lblMessage.Text = "User Disabled!!!";
            }

        }
        else
        {

            //lblMessage.Text = "Unauthorised User!!!";
        }



    }
}