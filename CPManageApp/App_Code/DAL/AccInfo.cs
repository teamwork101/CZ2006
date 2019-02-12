using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CPManageApp.App_Code.DAL
{
    public class AccInfo
    {
        //DBConn dbConn = new DBConn(); // connect to database

        // defining attributes
        string _username = "";
        string _password = "";
        string _email = "";
        string _phoneNum = "";
        string _securityQns = "";
        string _securityAns = "";
        int _isActivate = 0;
        string _activationCode = "";

        // default constructor
        public AccInfo() { }
        //implicit constructor
        public AccInfo(string username, string password, string email, string phoneNum, string securityQns, string securityAns, int isActivate, string activationCode)
        {
            this._username = username;
            this._password = password;
            this._email = email;
            this._phoneNum = phoneNum;
            this._securityQns = securityQns;
            this._securityAns = securityAns;
            this._isActivate = isActivate;
            this._activationCode = activationCode;
        }
        // Accessor & Mutator Methods
        public string Username { get => _username; set => _username = value; } //generated from refactoring
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNum { get => _phoneNum; set => _phoneNum = value; }
        public string SecurityQns { get => _securityQns; set => _securityQns = value; }
        public string SecurityAns { get => _securityAns; set => _securityAns = value; }
        public int IsActivate { get => _isActivate; set => _isActivate = value; }
        public string ActivationCode { get => _activationCode; set => _activationCode = value; }


        //Behaviours
        //hashing password to be stored in database
        public string HashPassword(string password)
        {
            // step 1, calculate SHA256 hash from input
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = sha256.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        //activate account
        public int activateAcc(out String error)
        {
            int result = 0;
            error = String.Empty;
            String query =
               " UPDATE AccInfo SET isActivate = @isActivate WHERE username = @username and activationCode = @activationCode";

            string connectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", this.Username);
                    cmd.Parameters.AddWithValue("@isActivate", 1);
                    cmd.Parameters.AddWithValue("@activationCode", this.ActivationCode);

                    try
                    {
                        connection.Open();
                        result = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (System.Exception exception)
                    {
                        error = exception.Message;
                    }
                }
            }

            return result;
        }
        //create account 
        public bool createAcc(out String error)
        {
            int result = 0;
            bool getResult = false;
            error = String.Empty;
            String strCommandText = "INSERT AccInfo (username, password, email, phoneNum, securityQns, securityAns, isActivate, activationCode)";
            strCommandText += "Values(@username, @password, @email, @phoneNum, @securityQns, @securityAns, @isActivate, @activationCode)";

            string connectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strCommandText, connection))
                {
                    string hash = HashPassword(this.Password);
                    cmd.Parameters.AddWithValue("@username", this.Username);
                    cmd.Parameters.AddWithValue("@password", hash);
                    cmd.Parameters.AddWithValue("@email", this.Email);
                    cmd.Parameters.AddWithValue("@phoneNum", this.PhoneNum);
                    cmd.Parameters.AddWithValue("@securityQns", this.SecurityQns);
                    cmd.Parameters.AddWithValue("@securityAns", this.SecurityAns);
                    cmd.Parameters.AddWithValue("@isActivate", 0);
                    cmd.Parameters.AddWithValue("@activationCode", this.ActivationCode);

                    try
                    {
                        connection.Open();
                        result += cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            getResult = true;
                        }
                        else
                        {
                            getResult = false;
                        }

                        connection.Close();
                    }
                    catch (SqlException sqlException)
                    {
                        error = String.Format("{0} already exists.", this.Username);
                    }
                    catch (System.Exception exception)
                    {
                        error = exception.Message;
                    }
                }
            }
            return getResult;
        }
        //Login
        public int validateUser(string username, string password)
        {
            int getResult = 0;
            string dbUsername = "", dbPassword = "", hashed = "";
            int isActivate = 0;

            try
            {
                hashed = HashPassword(password);
                string queryAccount = "SELECT * from AccInfo "
                 + "WHERE username = @username";
                

                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                SqlCommand accountCmd = new SqlCommand(queryAccount, myConnect);
                accountCmd.Parameters.AddWithValue("@username", username);
                //accountCmd.Parameters.AddWithValue("@password", hashed);
                myConnect.Open();

                SqlDataReader dr = accountCmd.ExecuteReader();
                if (dr.Read())
                {
                    dbUsername = dr["username"].ToString();
                    dbPassword = dr["password"].ToString();
                    isActivate = int.Parse(dr["isActivate"].ToString());
                }
                else
                {
                    getResult = -1;//Account don't exist or wrong username
                }

                myConnect.Close();
                dr.Close();
                dr.Dispose();
                if (getResult != -1)
                {
                    if (username == dbUsername && hashed == dbPassword)
                    {
                        if (isActivate == 1)
                        {

                            getResult = 1;

                        }
                        else if (isActivate == 0)
                        {
                            getResult = 2; //it means isActivate = 0 (account not activate)
                        }
                    }
                    else
                    {
                        getResult = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Wrong username or password.";
            }
            return getResult;
        }
        //change password
        public string changePassword(string username, string password, string newPassword)
        {
            string msg = "";
            string dbhashed = "";
            string oldhashed = HashPassword(password);
            string newHashed = HashPassword(newPassword);

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "SELECT password FROM AccInfo WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dbhashed = dr["password"].ToString();
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();
            if (oldhashed == dbhashed)
            {
                string queryStr = "UPDATE AccInfo SET "
                    + "password = @password "
                    + "WHERE username = @username ";
                SqlCommand cmdNew = new SqlCommand(queryStr, myConnect);
                cmdNew.Parameters.AddWithValue("@username", username);
                cmdNew.Parameters.AddWithValue("@password", newHashed);
                myConnect.Open();
                int result = cmdNew.ExecuteNonQuery();
                if (result > 0)
                {
                    msg = "Password changed.";
                }
                else
                {
                    msg = "Password not changed.";
                }
            }
            else
            {
                msg = "Wrong Password";
            }
            return msg;
        }
        //change password
        public string resetPassword(string username, out string newPassword)
        {
            string msg = "";
            newPassword = generateRandomPassword();
            string newHashed = HashPassword(newPassword);

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string queryStr = "UPDATE AccInfo SET "
                + "password = @password "
                + "WHERE username = @username ";
            SqlCommand cmdNew = new SqlCommand(queryStr, myConnect);
            cmdNew.Parameters.AddWithValue("@username", username);
            cmdNew.Parameters.AddWithValue("@password", newHashed);
            myConnect.Open();
            int result = cmdNew.ExecuteNonQuery();
            if (result > 0)
            {
                msg = "Your password have been reset. Please check your email.";
            }
            else
            {
                msg = "Unable to reset password.";
            }
            return msg;
        }
        //updating user details other then password
        public Boolean updateUserDetail(string username, string password, string email, string phoneNum)
        {
            string msg = "";
            string dbhashed = "";
            string hashed = HashPassword(password);
            Boolean check = false;
            int getResult = 0;
            Boolean finalResult = false;

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "SELECT password FROM AccInfo WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dbhashed = dr["password"].ToString();
            }
            dr.Close();
            dr.Dispose();
            myConnect.Close();
            if (dbhashed == hashed)
            {
                check = true;
            }
            if (check == true)
            {
                if (email == "")
                {
                    string queryStr = "UPDATE AccInfo SET "
                    + "phoneNum = @phoneNum "
                    + "WHERE username = @username ";
                    SqlCommand cmdNew = new SqlCommand(queryStr, myConnect);
                    cmdNew.Parameters.AddWithValue("@username", username);
                    cmdNew.Parameters.AddWithValue("@phoneNum", phoneNum);
                    myConnect.Open();
                    getResult += cmdNew.ExecuteNonQuery();
                    if (getResult >= 1)
                    {
                        finalResult = true;
                    }

                    myConnect.Close();
                }
                else if (phoneNum == "")
                {
                    string queryStr = "UPDATE AccInfo SET "
                    + "email = @email "
                    + "WHERE username = @username ";
                    SqlCommand cmdNew = new SqlCommand(queryStr, myConnect);
                    cmdNew.Parameters.AddWithValue("@username", username);
                    cmdNew.Parameters.AddWithValue("@email", email);
                    myConnect.Open();
                    getResult += cmdNew.ExecuteNonQuery();
                    if (getResult >= 1)
                    {
                        finalResult = true;
                    }

                    myConnect.Close();

                }
                else
                {
                    string queryStr = "UPDATE AccInfo SET "
                    + "email = @email "
                    + ", phoneNum = @phoneNum "
                    + "WHERE username = @username ";
                    SqlCommand cmdNew = new SqlCommand(queryStr, myConnect);
                    cmdNew.Parameters.AddWithValue("@username", username);
                    cmdNew.Parameters.AddWithValue("@email", email);
                    cmdNew.Parameters.AddWithValue("@phoneNum", phoneNum);
                    myConnect.Open();
                    getResult += cmdNew.ExecuteNonQuery();
                    if (getResult >= 1)
                    {
                        finalResult = true;
                    }

                    myConnect.Close();
                }
            }
            return finalResult;
        }
        // validating the answer for security questions
        public Boolean validateSecurityAns(string username, string input)
        {
            string dbSecurityAns = "";
            Boolean finalResult = false;
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "SELECT securityAns FROM AccInfo WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dbSecurityAns = dr["securityAns"].ToString();
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            if (input == dbSecurityAns)
            {
                finalResult = true;
            }

            return finalResult;
        }
        // generate password due to reset
        public string generateRandomPassword()
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(8);
            for (int i = 0; i < 8; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
        //retrieve security question when user prompts for password reset
        public string getSecurityQns(string username)
        {
            string qns = "";
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "SELECT securityQns FROM AccInfo WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                qns = dr["securityQns"].ToString();
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();
            return qns;
        }

        //Deactivate account due to
        public Boolean reactivateAcc(string username, out string activationCode)
        {
            Random random = new Random();
            activationCode = random.Next(100001, 999999).ToString();
            //string hashed = HashPassword(password);
            int getResult = 0;
            Boolean finalResult = false;

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "UPDATE AccInfo SET "
                    + "isActivate = @isActivate "
                    + ", activationCode = @activationCode "
                    + "WHERE username = @username ";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@isActivate", 0);
            cmd.Parameters.AddWithValue("@activationCode", activationCode);
            myConnect.Open();
            getResult += cmd.ExecuteNonQuery();
            if (getResult >= 1)
            {
                finalResult = true;
            }

            myConnect.Close();

            return finalResult;
        }

        //check if username/account exist
        public int checkUsername(string username)
        {
            int result = 0;
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "SELECT username FROM AccInfo WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = 1;
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return result;
        }

        //get user info
        //public AccInfo getAccInfo(string username)
        //{
        //    string password, email, phoneNum, securityQns, securityAns;
        //    int isActivate;
        //    AccInfo a = new AccInfo();

        //    string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
        //    //create connection
        //    SqlConnection myConnect = new SqlConnection(strConnectionString);
        //    string strCommandText = "SELECT * FROM AccInfo Where username = @username";
        //    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        //    cmd.Parameters.AddWithValue("@username", username);
        //    myConnect.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {

        //        password = dr["password"].ToString();
        //        email = dr["email"].ToString();
        //        phoneNum = dr["phoneNum"].ToString();
        //        securityQns = dr["securityQns"].ToString();
        //        securityAns = dr["securityAns"].ToString();
        //        isActivate = int.Parse(dr["isActivate"].ToString());
        //        a = new AccInfo(username,password,email,phoneNum,securityQns,securityAns,isActivate);
        //    }
        //    myConnect.Close();
        //    dr.Close();
        //    dr.Dispose();

        //    return a;
        //}
        public string getEmail(string username)
        {
            string email = "";

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT * FROM AccInfo Where username = @username";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                email = dr["email"].ToString();

            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return email;
        }


        public string getPhoneNum(string username)
        {

            string phoneNum ="" ;
            

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT * FROM AccInfo Where username = @username";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                phoneNum = dr["phoneNum"].ToString();

            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return phoneNum;
        }

        
    }
}