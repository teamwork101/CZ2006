using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLSecurityQns
    {
        SecurityQns secQns = new SecurityQns();

        //Method 1 : Retrive all the Security Question set in the Database
        public List<SecurityQns> getAllSecurityQns()
        {
            return secQns.getAllSecurityQns();
        }
    }
}