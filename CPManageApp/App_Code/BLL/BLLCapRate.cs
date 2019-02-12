using CPManageApp.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.BLL
{
    public class BLLCapRate
    {
        //initialise a DAL object for easier access 
        CapRate capRdata = new CapRate();

        //Method 1 : get individual cap Rate
        public CapRate getRate(int rateID)
        {
            return capRdata.getCapRate(rateID);
        }

        //Method 2 : get all the cap rates
        public List<CapRate> getAllRate()
        {
            return capRdata.getAllCapRate();
        }
    }
}