using CPManageApp.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.BLL
{
    public class BLLSurchargeRate
    {
        //initialise a DAL object for easier access 
        SurchargeRate surchargeRdata = new SurchargeRate();

        //Method 1 : get individual cap Rate
        public SurchargeRate getRate(int rateID)
        {
            return surchargeRdata.getSurchargeRate(rateID);
        }

        //Method 2 : get all the cap rates
        public List<SurchargeRate> getAllRate()
        {
            return surchargeRdata.getAllSurchargeRate();
        }
    }
}