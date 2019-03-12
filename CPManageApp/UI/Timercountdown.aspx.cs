using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.UI
{
    public partial class Timercountdown : System.Web.UI.Page
    {

        static int h = 0;
        static int m = 1;
        static int s = 0;

        ParkingHistory ph = new ParkingHistory();
        protected void Page_Load(object sender, EventArgs e)
        {
            h = Convert.ToInt32(Session["hours"].ToString());
            m = Convert.ToInt32(Session["minutes"].ToString());
            //            System.Diagnostics.Debug.WriteLine(Session["hours"].ToString());
            //            System.Diagnostics.Debug.WriteLine(Session["minutes"].ToString());
            if (h == -1)
            {
                lblTimer.Text = " ";
            }
            else
            {
                lblTimer.Text = h.ToString() + ":" +  m.ToString() + ":" + s.ToString();
            }
//            System.Diagnostics.Debug.WriteLine(h);
//            System.Diagnostics.Debug.WriteLine(m);
        }

        int i;
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetTimer.aspx");// this is timer reset button
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "open", "show();", true);
            //Response.Redirect("TimerInformation.aspx");// this is back button 
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (m != 0 &&s == 0)
            {
                m--;
                s = 59;
            }
            if (m == 0 && s == 0)
            {
                // Timer1.Enabled = false; //if both 0 then will be false
                Label1.Visible = true;
                ph.sendNotification1();
                //lblTimer.Text = "0 : 0 : 0";
            }
            else { s--; //straight start the seconds
            }

            //if (m <= 0 && s < 5)
            //{
            //    //for (i = 0; i < 5; i++) //
            //        s--;
            //}
            //if (m <= 1 && s <= 0)
            //{
            //    m = 0;
            //    s = 5;

            //}

//m--; //minus the minute
            
            //while (h != 0 && m != 0 && s != 0)
            //{
            //    m--;
            //    s--;

            //    if (s < 0 && m == 0)
            //    {
            //        h--;
            //        m = 5;
            //        s = 5;
            //    }
            //    else
            //    {
            //        m--;
            //        s = 5;

            //    }


            //if (m <= 0)
            //{
            //    h--;
            //    m = 5;


            //}

            lblTimer.Text= h.ToString() + " : " + m.ToString() + " : " + s.ToString();
            //lblTimer.Text = DateTime.Now.ToString("HH: MM : ss ");


        }

        protected void Timer_Ends(object sender, EventArgs e)
        {
//            Session["hours"] = "-1";
//            h = -1;
            Label1.Visible = true;
            ph.sendNotification1();
            Response.Redirect("SetTimer.aspx");
        }

    }
}