using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPManageApp.UI
{
    public partial class Layout2 : System.Web.UI.Page
    {
        int totalLots = 42;
        protected void Page_Load(object sender, EventArgs e)
        {
            //call method
            availableLots();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //for every time interval
            //set lots back to default color 
            
            for (int i = 1; i <= totalLots; i++)
            {
                Label labelvalue = (Label)FindControl("Label" + i.ToString());
                if (labelvalue.ID == "Label13" || labelvalue.ID == "Label14") //wheelchair lots color different
                {
                    labelvalue.BackColor = Color.Blue;
                }
                else //normal lots
                {
                    labelvalue.BackColor = Color.Green;
                }
            }
            //then call method again
            availableLots();
        }
        private void availableLots()
        {
            int lotsNum; //lotsNum is the number of lots in the capark
            //Get a random number of available lots
            Random rndAvailLots = new Random();
            int availableLots = rndAvailLots.Next(1, 43); //from 1 to 42 only
            int occupiedLots = totalLots - availableLots;
            //Store into an array of inavailableLots size
            int[] array = new int[occupiedLots];
            for (int i = 0; i < array.Length; i++)
            {
                //Random function - get random lot numbers 
                Random rndLotsNum = new Random();
                lotsNum = rndLotsNum.Next(1, 43); //from 1 to 42 only
                if (!array.Contains(lotsNum)) //if lot number DO NOT EXIST in array
                {
                    array[i] = lotsNum;
                    Label labelvalue = (Label)FindControl("Label" + lotsNum.ToString()); //get label ID
                    labelvalue.BackColor = Color.Red; //set lots to red
                }
                else // if EXIST 
                {
                    i--;
                }
            }
        }
    }
}