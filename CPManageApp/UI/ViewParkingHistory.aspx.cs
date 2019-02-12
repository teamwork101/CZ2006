using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;

namespace CPManageApp.UI
{
    public partial class ViewParkingHistory : System.Web.UI.Page
    {
        int carparkID;
        BLLParkingHistory parkingHistory = new BLLParkingHistory();
        BLLCarparkInfo carparkInfo = new BLLCarparkInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblSession.Text = Session["login"].ToString();
                bind();
                bindDDL();
            }
        }
        protected void bindDDL()
        {
            string username = Session["login"].ToString();
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
            ddlUserVehicle.Items.Insert(0, "All");
        }
        protected void bind()
        {
            gvParkingHistory.DataSource = parkingHistory.displayRecord(lblSession.Text);
            gvParkingHistory.DataBind();
        }
        protected void bindByVehicle()
        {
            gvParkingHistory.DataSource = parkingHistory.displayRecordByVehicle(lblSession.Text, ddlUserVehicle.SelectedItem.Text);
            gvParkingHistory.DataBind();
        }

        protected void gvParkingHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHomepage.aspx");
        }

        protected void ddlUserVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserVehicle.SelectedItem.Text == "All")
            {
                bind();
            }
            else
            {
                bindByVehicle();
            }
        }
    }
}