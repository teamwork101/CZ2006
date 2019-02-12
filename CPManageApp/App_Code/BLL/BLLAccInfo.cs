using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLAccInfo
    {

        AccInfo accDataLayer = new AccInfo();


        //Method 1 : Calling the AccInfo in the Data Layer to create account
        public bool creatAcc(string username, string password, string email, string phoneNum, string securityQns, string securityAns, string activationCode, out String error)
        {
            AccInfo accInfo = new AccInfo();
            // Staff staff = new Staff();
            accInfo.Username = username;
            accInfo.Password = password;
            accInfo.Email = email;
            accInfo.PhoneNum = phoneNum;
            accInfo.SecurityQns = securityQns;
            accInfo.SecurityAns = securityAns;
            accInfo.ActivationCode = activationCode;

            bool result = accInfo.createAcc(out error);
            return result;
        }


        //Method 2: To Display Msg to ask User to check email msg
        /*public void displayCheckEmailMsg()
        {

        }
        */

        public int activateAcc(string username, string activationCode, out String error)
        {
            AccInfo accInfo = new AccInfo();
            accInfo.Username = username;
            accInfo.ActivationCode = activationCode;


            int result = accInfo.activateAcc(out error);
            return result;
        }
        public Boolean reactivateAcc(string username, out string activationCode)
        {
            return accDataLayer.reactivateAcc(username, out activationCode);
        }

        //Method 3: Validate if user account exist in the DB
        public int validateUser(string username, string password)
        {
            return accDataLayer.validateUser(username, password);
        }

        //Method 4: Retrieve the Security Qns of a specific user by username
        public string getSecurityQns(string username)
        {
            return accDataLayer.getSecurityQns(username);
        }

        //Method 5: Validate the security answer given by user
        public Boolean validateSecurityAns(string username, string input)
        {
            return accDataLayer.validateSecurityAns(username, input);
        }
        public int checkUsername(string username)
        {
            return accDataLayer.checkUsername(username);
        }
        public string resetPassword(string username, out string newPassword)
        {
            return accDataLayer.resetPassword(username, out newPassword);
        }

        public string getEmail(string username)
        {
            return accDataLayer.getEmail(username);
        }

        public string getPhoneNum(string username)
        {
            return accDataLayer.getPhoneNum(username);
        }

        public string changePassword(string username, string password, string newPassword)
        {
            return accDataLayer.changePassword(username, password, newPassword);
        }

        public Boolean updateUserDetail(string username, string password, string email, string phoneNum)
        {
            return accDataLayer.updateUserDetail(username, password, email, phoneNum);
        }
    }
}