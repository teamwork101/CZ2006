using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;

namespace CPManageApp.UI
{
    public partial class ResetPasswordUsername : System.Web.UI.Page
    {
        BLLAccInfo accInfo = new BLLAccInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            string username = tbUsername.Text;
            result = accInfo.checkUsername(username);
            if (result != 0)
            {
                Session["username"] = username;
                Response.Redirect("ResetPasswordSecurityQns.aspx");
            } else
            {
                //username not found
                ClientScript.RegisterStartupScript(GetType(), "",
              "<script>alert('Incorrect username');</script>");
            }

        }
    }
}