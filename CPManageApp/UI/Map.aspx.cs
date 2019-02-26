using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPManageApp.UI
{
    public partial class UserMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //**** NEED TO PUT IN FOR FINAL PRESENTATION***

                //if the session is null
                //if (string.IsNullOrEmpty(Session["login"] as string))
                //{
                //    Response.Redirect("Login.aspx");
                //
                //}
                

            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void btnManageVehicle_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewListofVehicles.aspx");
        }

        protected void btnUserDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUserDetail.aspx");
        }

        protected void btnParkingHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewParkingHistory.aspx");
        }

        protected void btnSetTimer_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetTimer.aspx");
        }
    }
}