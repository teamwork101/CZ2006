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
    public partial class SignUp : System.Web.UI.Page
    {
        BLLAccInfo BLLAccInfo = new BLLAccInfo();
        BLLEmailService emailService = new BLLEmailService();
        static String activationCode;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == null || txtUsername.Text == "")
            {
                lblErrUsername.Text = "Please Enter Username.";
            }
            else if (txtPassword.Text == null || txtPassword.Text == "")
            {
                lblErrPassword.Text = "Please Enter Password. ";
            }
            else if (txtConfirmPassword.Text == null || txtConfirmPassword.Text == "")
            {
                lblErrConfirmPassword.Text = "Please Enter Confirmed Password. ";
            }
            else if (txtEmail.Text == null || txtEmail.Text == "")
            {
                lblErrEmail.Text = "Please Enter Email Address. ";
            }
            else if (txtContactNumber.Text == null || txtContactNumber.Text == "")
            {
                lblErrPassword.Text = "Please Enter Contact Number. ";
            }
            else if (ddlSecurityQns.Value == null || ddlSecurityQns.Value == "")
            {
                lblErrSecurityQns.Text = "Please Select a Security Question. ";
            }
            else if (txtSecurityAns.Text == null || txtSecurityAns.Text == "")
            {
                lblErrSecurityAns.Text = "Please Enter Security Answer. ";
            }
            else
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    string username, password, email, contactNum, securityQns, securityAns;
                    string message = string.Empty;
                    username = txtUsername.Text;
                    password = txtPassword.Text;
                    email = txtEmail.Text;
                    contactNum = txtContactNumber.Text;
                    securityQns = ddlSecurityQns.Value;
                    securityAns = txtSecurityAns.Text;

                    Random random = new Random();
                    activationCode = random.Next(100001, 999999).ToString();

                    bool SignUpStats = BLLAccInfo.creatAcc(username, password, email, contactNum, securityQns, securityAns, activationCode, out message);

                    if (SignUpStats == true) //Successfully created account
                    {
                        emailService.sendActivationAccEmail(username, email, activationCode);
                        Response.Redirect("ActivateAcc.aspx?email=" + email + "&username=" + username);
                    }
                    else if (SignUpStats == false) //Fail to create account
                    {
                        message = String.Format("Error encountered when saving {0}. Details: {1}", this.txtUsername.Text, message);
                        ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
                        txtUsername.Focus();
                    }
                }
            }
        }
    }
}