using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.UI
{
    public partial class ResetPasswordSecurityQns : System.Web.UI.Page
    {
        BLLAccInfo bllAccInfo = new BLLAccInfo();
        AccInfo accInfo = new AccInfo();
        BLLEmailService emailService = new BLLEmailService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //check session login not null
            if (!string.IsNullOrEmpty(Session["login"] as string))
            {
                lblSession.Text = Session["login"].ToString();
            }
            else
            {
                lblSession.Text = Session["username"].ToString(); // storing the session info in label
            }


            if (!IsPostBack)
            {

                lblSecurityQns.Text = bllAccInfo.getSecurityQns(lblSession.Text);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean result = false;
            result = bllAccInfo.validateSecurityAns(lblSession.Text, tbSecurityAns.Text);
            if (result == true)
            {
                string password;
                bllAccInfo.resetPassword(lblSession.Text, out password);
                string email = bllAccInfo.getEmail(lblSession.Text);
                emailService.sendResetPasswordEmail(lblSession.Text, password, email);
                string msg = "Your password has been reset. Please check your email.";
                string redirect = "UI/Login.aspx";
                string scriptText = "alert('" + msg + "'); window.location='" + Request.ApplicationPath + redirect + "'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
            }
            else
            {
                //user typed wrong security qns
                ClientScript.RegisterStartupScript(GetType(), "",
              "<script>alert('Wrong input of the answer');</script>");
            }
        }
    }
}