using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPManageApp.UI
{
    public partial class CPMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //if the session is not null
                if (!string.IsNullOrEmpty(Session["login"] as string))
                {
                    //Change the text value
                    btnLogin.Text = "Log Out";

                    //hide the Sign up button
                    btnSignUp.Visible = false;

                    //show the user homepage
                    lblUserHomepage.Visible = true;

                }

                if (string.IsNullOrEmpty(Session["login"] as string))
                {
                    btnLogin.Text = "Login";
                    btnSignUp.Visible = true;

                    //hide the user homepage
                    lblUserHomepage.Visible = false;
                }


            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Log Out")
            {
                Session.Remove("login");
                btnLogin.Text = "Login";
                btnSignUp.Visible = true;
                //Redirect back to the Hompage
                Response.Redirect("Homepage.aspx");
            }

            if (!string.IsNullOrEmpty(Session["login"] as string))
            {
                //Change the text value
                btnLogin.Text = "Log Out";

                //hide the Sign up button
                btnSignUp.Visible = false;

                //Redirect back to the Hompage
                Response.Redirect("Homepage.aspx");
            }


            Response.Redirect("Login.aspx");


        }

        protected void lblUserHomepage_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHomepage.aspx");
        }


    }
}