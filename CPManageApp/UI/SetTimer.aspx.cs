using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.UI
{
    public partial class SetTimer : System.Web.UI.Page
    {
        BLLCarparkInfo carparkInfo = new BLLCarparkInfo();
        CarparkInfo info = new CarparkInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["login"].ToString();
            //string username = "mary";
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT DISTINCT vehicleNo FROM Vehicle WHERE username = @username";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            ddlUserVehicle.DataSource = reader;
            ddlUserVehicle.DataTextField = "vehicleNo";
            ddlUserVehicle.DataBind();
            info = carparkInfo.getCarpark("313@Somerset");
            lblClosing.Text = info.EndHour; 
            lblCurrent.Text = DateTime.Now.ToString("HH:mm");

        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            double hour = double.Parse(txtHours.Text);
            double min = double.Parse(txtMinutes.Text);
            //double h = double.Parse(lblClosing.Text.Substring(0, 2));
            double m = (hour * 60) + min;
            DateTime time = DateTime.ParseExact(lblClosing.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
            //int m = int.Parse(DateTime.Now.AddMinutes(m));
//            if (DateTime.Now.AddMinutes(m) <= time)
            if (true)
            {
                Session["time"] = txtHours.Text + ":" + txtMinutes.Text + ":00";
                Session["hours"] = txtHours.Text;
                Session["minutes"] = txtMinutes.Text;
                Session["vehicleNo"] = ddlUserVehicle.SelectedItem.Text;
                Response.Redirect("TimerInformation.aspx");
                //Response.Redirect("Timercountdown.aspx");
            } else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('Time set has passed the carpark operating hours');</script>");
            }

        }


    }
}