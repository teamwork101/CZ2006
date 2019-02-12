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
    public partial class Login : System.Web.UI.Page
    {
        static int counter;
        BLLEmailService emailSvc = new BLLEmailService();
        BLLAccInfo BLLAccInfo = new BLLAccInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                counter = 0;
            }

        }
        //protected void deactivateAccount()
        //{
        //    string username = Session["login"].ToString();
        //    string password = "";
        //    string activationCode = "";
        //    string email = BLLAccInfo.getEmail(username);
        //    BLLAccInfo.reactivateAcc(username, out activationCode);
        //    BLLAccInfo.resetPassword(username, out password);
        //    emailSvc.sendReactivationAccEmail(username, email, activationCode, password);
        //    ClientScript.RegisterStartupScript(GetType(), "",
        //     "<script>alert('Wrong input of password for 3 times. Account has been deactivated. An email containing the activation code and your new password has been sent.');</script>");
        //}
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == null || txtUsername.Text == "")
            {
                lblErrUsername.Text = "Please Enter Username.";
            }
            else if (txtPassword == null || txtPassword.Text == "")
            {
                lblErrPassword.Text = "Please Enter Password. ";
            }
            else
            {
                string username = txtUsername.Text, password = txtPassword.Text;
                int LoginStats = BLLAccInfo.validateUser(username, password);

                if (LoginStats == 1) //Account activated
                {
                    Session["login"] = username;
                    //Response.Redirect("ListOfCarpark.aspx"); //Redirect to where
                    //Response.Redirect("ViewListofVehicles.aspx");
                    Response.Redirect("UserHomepage.aspx");
                }
                else if (LoginStats == 2) //Account not activated
                {
                    Session["login"] = username;
                    Response.Redirect("ActivateAcc.aspx?username=" + username);
                }
                else if (LoginStats == 0 || LoginStats == -1) //Account don't exist or wrong username/password
                {
                    if (LoginStats == 0)
                        counter++;
                    Session["login"] = username;
                    if (counter < 3)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('Incorrect username/password');</script>");
                        txtUsername.Focus();
                    }
                    else
                    {

                        counter = 0;
                        string msg = "Wrong input of password for 3 times. Kindly answer your security question to reset your password";
                        string redirect = "UI/ResetPasswordSecurityQns.aspx";
                        string scriptText = "alert('" + msg + "'); window.location='" + Request.ApplicationPath + redirect + "'";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
                        //deactivateAccount();

                    }
                }
              

            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPasswordUsername.aspx");
        }
    }
}