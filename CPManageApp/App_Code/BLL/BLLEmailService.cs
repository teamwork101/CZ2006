using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLEmailService
    {
        //initialise a DAL object for easier access 
        EmailService emailServiceData = new EmailService();

        //Method 1 : Send Activate Email to User
        public void sendActivationAccEmail(string username, string email, string activationCode)
        {
            emailServiceData.sendActivationAccEmail(username, email, activationCode);
        }


        //Method 2 : Send Reset Password to User via Email
        public void sendResetPasswordEmail(string username, string resetPassword, string email)
        {
            emailServiceData.sendResetPasswordEmail(username, resetPassword, email);
        }

        public void sendReactivationAccEmail(string username, string email, string activationCode)
        {
            emailServiceData.sendReactivationAccEmail(username, email, activationCode);
        }
    }
}