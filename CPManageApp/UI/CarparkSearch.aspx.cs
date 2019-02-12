using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;

namespace CPManageApp.UI
{
    public partial class CarparkSearch : System.Web.UI.Page
    {
        BLLCarparkInfo carparkInfo = new BLLCarparkInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindAll();

            }
        }
        protected void bindAll()
        {
            string region = ddlRegion.SelectedItem.Text;
            if (region == "All")
            {
                //ListView1.DataSource = retrieveByCategory.getProductByStatus("Available", "Rent");
                LVShoppingMall.DataSource = carparkInfo.getAllCarpark(); 
            }
            else
            {
                LVShoppingMall.DataSource = carparkInfo.searchCarpark(txtMallName.Text, region);
            }
            LVShoppingMall.DataBind();
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAll();
        }
        protected void btn_SearchMall_Click(object sender, EventArgs e)
        {
            string region = ddlRegion.SelectedItem.Text;
            LVShoppingMall.DataSource = carparkInfo.searchCarpark(txtMallName.Text, region);
            LVShoppingMall.DataBind();
        }
        protected void LVShoppingMall_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    Label status = (Label)e.Item.FindControl("lblStatus");
            //    if (status.Text == "Not Available")
            //    {
            //        status.ForeColor = Color.Crimson;

            //        // You also have access to the list view's SubItems collection
            //        // theItem.SubItems[0].ForeColor = Color.Blue;
            //    }
            //    else if (status.Text == "Available")
            //    {
            //        status.ForeColor = Color.MediumSeaGreen;
            //    }
            //}
        }

        protected void LVShoppingMall_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (LVShoppingMall.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            bindAll();
        }
    }
}