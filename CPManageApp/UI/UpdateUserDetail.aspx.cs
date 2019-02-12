using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;

namespace CPManageApp.UI
{
    public partial class UpdateUserDetail : System.Web.UI.Page
    {
        BLLAccInfo accInfo = new BLLAccInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //retrieve the form information

                //1. Retrieve Username
                lblRetrieveUsername.Text = Session["login"].ToString();

                //2. Retrieve Email
                txtEmail.Text = accInfo.getEmail(Session["login"].ToString());

                //3. Retrieve Phone Number
                txtPhoneNum.Text = accInfo.getPhoneNum(Session["login"].ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHomepage.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //store the temporary values from the form.
            string username = lblRetrieveUsername.Text.ToString();
            string email = txtEmail.Text.ToString();
            string phoneNum = txtPhoneNum.Text.ToString();
            string password = txtPassword.Text.ToString();

            //call the method in business layer
            bool result = false;

            result = accInfo.updateUserDetail(username, password, email, phoneNum);

            if(result == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User Detail has changed!');window.location ='UserHomepage.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('User Detail has NOT changed!');", true);
            }

        }
    }
}