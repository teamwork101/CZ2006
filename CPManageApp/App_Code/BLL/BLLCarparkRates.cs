using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLCarparkRates
    {

        //initialise a DAL object for easier access 
        CarparkRates CarparkRdata = new CarparkRates();

        //Method 1 : get individual Rate
        public List<CarparkRates> getRate(string carparkID)
        {
            return CarparkRdata.getRate(carparkID);
        }

    }
}