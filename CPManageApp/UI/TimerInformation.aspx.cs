using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPManageApp.UI
{
    public partial class TimerInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSession.Text = Session["time"].ToString();
            lblRetrieveSetTime.Text = lblSession.Text;
            lblRetrieveUsername.Text = Session["login"].ToString();
            lblRetrieveVehicleNo.Text = Session["vehicleNo"].ToString();
            lblRetrieveCurrentTime.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHomepage.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Session["statedTime"] = lblSession.Text;
            Response.Redirect("Timercountdown.aspx");
        }
    }
}