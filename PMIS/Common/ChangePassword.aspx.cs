using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;


public partial class RCDPMISNEW_Common_ChangePassword : System.Web.UI.Page
{
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");

        }
           
    }

   

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtCaptha.Text.Trim() == "")
        {
            Utility.showMessage(this, "Please Enter Text Shown In Code!");
            txtCaptha.Focus();
            return;
        }
        ccJoin.ValidateCaptcha(txtCaptha.Text.Trim());
        if (!ccJoin.UserValidated)
        {
            Utility.showMessage(this, "Please Enter Text Again Shown In Code!");
            //lblMsg.Text = "Please Enter Text Again Shown in Code!";
            txtCaptha.Focus();
            return;
        }
        try
        {
            Encryptor enc = new Encryptor(Encryptor.PrivateKey);


            string sql = @"select UserID,UserName,Password,District_Code ,Block_Code,DeptCode,Userrole,MobileNo,Islock from UserLogin where UserLogin.UserID='" + Session["UserId"].ToString() + "'";
            DataTable dt = cls.GetDataTable(sql);
            // Session["dt"] = dt;
            if (dt.Rows.Count != 0)
            {
                string PWD = dt.Rows[0]["Password"].ToString().Trim();

                if (PWD == null || PWD.ToString() != enc.Encrypt(txtOldPwd.Text))
                {
                    Utility.showMessage(this, "Incorrect old password.Please enter right password.");
                    return;
                }
                string strQuery = "UPDATE UserLogin SET Password=@Password where UserID='" + Session["UserId"].ToString() + "'";

                SqlParameter prmPWD = new SqlParameter("@Password", enc.Encrypt(txtNewPwd.Text));
                if (cls.ExecuteSql(strQuery, new SqlParameter[] { prmPWD }) > 0)
                {
                    System.Web.Security.FormsAuthentication.SignOut();
                    Session.Abandon();
                    //Utility.showMessageNavigate(this, "Password Changed Successfully. Please Re-login With Your New Password.", "Login_Page.aspx");
                    Utility.showMessageNavigate(this, "Password Changed Successfully. Please Re-login With Your New Password.", "../Login.aspx");

                }

                else
                    Utility.showMessage(this, "Could not change password, please try after some time...");
            }
        }
        catch (Exception Ex)
        { }

    }

}
