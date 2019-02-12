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
    public partial class CarparkView : System.Web.UI.Page
    {
        BLLCarparkInfo BllcarparkInfo = new BLLCarparkInfo();
        CarparkInfo carparkInfo = new CarparkInfo();
        BLLCarparkRates bllCarparkRates = new BLLCarparkRates();
        List<CarparkRates> carparkRatesL = new List<CarparkRates>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblLegend.Visible = false;
                lblAccessibleLots.Visible = false;
                lblAvailableLots.Visible = false;
                lblOccupiedLots.Visible = false;
                myIframe.Visible = false;
                bindData();
            }
        }
        protected void bindData()
        {
            string carparkId = Request.QueryString["carparkName"].ToString();
            carparkInfo = BllcarparkInfo.getCarpark(carparkId);
            lblCarparkName.Text = carparkInfo.CarparkName;
            lblAddr.Text = carparkInfo.CarparkLocation;
            lblStartHr.Text = carparkInfo.StartHour.Substring(0, 5);
            lblEndHr.Text = carparkInfo.EndHour.Substring(0, 5);
            lblSlots.Text = carparkInfo.TotalSlots.ToString();
            Image1.ImageUrl = "~\\UI\\MallImages\\" + carparkInfo.Image;
            if  (carparkId == "313@Somerset")
            {
                lblLegend.Visible = true;
                lblAccessibleLots.Visible = true;
                lblAvailableLots.Visible = true;
                lblOccupiedLots.Visible = true;
                myIframe.Visible = true;
                myIframe.Attributes["src"] = "313@somerset.aspx"; //aspx locaction need to change
            }
            else if (carparkId == "Bugis Junction")
            {
                lblLegend.Visible = true;
                lblAccessibleLots.Visible = true;
                lblAvailableLots.Visible = true;
                lblOccupiedLots.Visible = true;
                myIframe.Visible = true;
                myIframe.Attributes["src"] = "bugisjunction.aspx"; //aspx location need to change
            }
            




            carparkRatesL = bllCarparkRates.getRate(carparkId);
            for(int i =0; i< carparkRatesL.Count(); i++)
            {
                lblRates.Text += carparkRatesL[i].RateName +  ": <br/>$" + carparkRatesL[i].InitialHrRate +" for 1st " + carparkRatesL[i].InitialTimePeriod + " hour(s), <br/>$"+
                  carparkRatesL[i].FirstSubsequentRate + " for subsequent " + carparkRatesL[i].FirstSubsequentTimePeriod + " hour(s) <br/><br/>";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarparkSearch.aspx");
        }
    }
}