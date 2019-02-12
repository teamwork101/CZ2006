using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;

namespace CPManageApp.UI
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BLLAccInfo accInfo = new BLLAccInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            { 
                lblRetrieveUsername.Text = Session["login"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == null || txtOldPassword.Text == "")
            {
                lblErrOldPassword.Text = "Please Enter Your Old Password. ";
            }

            if (txtNewPassword.Text == null || txtNewPassword.Text == "")
            {
                lblErrNewPassword.Text = "Please Enter Your New Password.";
            }

            else if (txtConfirmPassword.Text == null || txtConfirmPassword.Text == "")
            {
                lblErrConfirmPassword.Text = "Please Enter Your Confirm Password.";
            }

            //store temporary values
            string username = Session["login"].ToString();
            string oldPassword = txtOldPassword.Text.ToString();
            string newPassword = txtNewPassword.Text.ToString();

            //Start to call in the BLL layer
            string resultMsg = "";
            resultMsg = accInfo.changePassword(username,oldPassword,newPassword);

            if (resultMsg == "Password changed.")
            {
               
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Password has changed !');window.location ='UserHomepage.aspx';", true);
               
            }
            else if (resultMsg == "Password not changed.")
            {
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('Password not changed.');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password not changed.');", true);
            }
            else if (resultMsg == "Wrong Password")
            {
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('Wrong Password!');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Wrong Password!');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHomepage.aspx");
        }
    }
}