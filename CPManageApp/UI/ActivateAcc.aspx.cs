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
    public partial class ActivateAcc : System.Web.UI.Page
    {
        BLLAccInfo BLLAccInfo = new BLLAccInfo();
        BLLEmailService emailSvc = new BLLEmailService();
        static String activationCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email;
            if (Session["login"] != null)
            {
                email = BLLAccInfo.getEmail(Session["login"].ToString());
            }
            else
            {
                email = Request.QueryString["email"].ToString();
            }
            lblActivateMsg.Text = "Your email address is " + email + "<br/> Kindly check your email inbox for the activation code.<br/><br/>";
        }

        protected void btnActivateAcc_Click(object sender, EventArgs e)
        {
            if (txtActivationCode.Text == null || txtActivationCode.Text == "")
            {
                lblErrActivationCode.Text = "Please Enter the Activation Code.";
            }
            else
            {
                String message = String.Empty;
                string username;
                username = Request.QueryString["username"].ToString();
                //email = Request.QueryString["email"].ToString();
                activationCode = txtActivationCode.Text.Trim();
                string error = string.Empty;
                int accActivated = BLLAccInfo.activateAcc(username, activationCode, out error);

                if (accActivated == 1)
                {
                    string msg = "You have successfully activated your account.";
                    string redirect = "UI/Login.aspx";
                    string scriptText = "alert('" + msg + "'); window.location='" + Request.ApplicationPath + redirect + "'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
                }
                else
                {
                    message = String.Format("Error encountered when activating {0}'s account, please make must you enter the correct activation code. {1}", username, error); //change messsage to error
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
                }
                lblErrActivationCode.Text = message;
            }
        }
        protected void btnResendActivationCode_Click(object sender, EventArgs e)
        {
            string activationCode = "";
            string username = Session["login"].ToString();
            string email = BLLAccInfo.getEmail(username);
            BLLAccInfo.reactivateAcc(username, out activationCode);
            emailSvc.sendReactivationAccEmail(username, email, activationCode);
            ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('New Activation Code has been sent. Please check your email.');</script>");
            txtActivationCode.Text = String.Empty;
        }
    }
}