using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.DAL
{
    public class SecurityQns
    {
        int _qnsID = 0;
        string _qns = "";

        //default constructor
        public SecurityQns() { }
        //implicit constructor
        public SecurityQns(int qnsID, string qns)
        {
            this._qnsID = qnsID;
            this._qns = qns;
        }

        //Accessor & Mutator Method
        public int QnsID { get => _qnsID; set => _qnsID = value; }
        public string Qns { get => _qns; set => _qns = value; }

        //Behaviours
        //Create security question
        public Boolean createQns(string question)
        {
            int getResult = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //create command
                string strCommandText = "INSERT SecurityQns (qns)";
                strCommandText += "Values(@qns)";

                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@qns", question);


                myConnect.Open();

                getResult += cmd.ExecuteNonQuery();
                if (getResult >= 1)
                {
                    finalResult = true;
                }
                myConnect.Close();
            }
            catch (Exception e)
            {

            }

            return finalResult;
        }
        //Return a list of question
        public List<SecurityQns> getAllSecurityQns()
        {
            List<SecurityQns> qnsList = new List<SecurityQns>();
            string qns;
            int qnsId;

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT * FROM SecurityQns Order By qns";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                qnsId = int.Parse(dr["qnsID"].ToString());
                qns = dr["qns"].ToString();
                SecurityQns a = new SecurityQns(qnsId, qns);
                qnsList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return qnsList;
        }
    }
}