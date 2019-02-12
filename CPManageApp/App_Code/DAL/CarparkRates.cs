using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPManageApp.App_Code.DAL
{
    public class CarparkRates
    {
        int _rateID = 0;
        string _rateName = "";
        string _rateStartTime = "";
        string _rateEndTime = "";
        double _initialHrRate = 0.0;
        double _initialTimePeriod = 0.0;
        double _firstSubsequentRate = 0.0;
        double _firstSubsequentTimePeriod = 0.0;
        string _carparkID = "";

        //default constructors
        public CarparkRates() { }
        //implicit constructors
        public CarparkRates(int rateID, string rateName, string rateStartTime, string rateEndTime, double initialHrRate, double initialTimePeriod, double firstSubsequentRate, double firstSubsequentTimePeriod, string carparkID)
        {
            _rateID = rateID;
            _rateName = rateName;
            _rateStartTime = rateStartTime;
            _rateEndTime = rateEndTime;
            _initialHrRate = initialHrRate;
            _initialTimePeriod = initialTimePeriod;
            _firstSubsequentRate = firstSubsequentRate;
            _firstSubsequentTimePeriod = firstSubsequentTimePeriod;
            _carparkID = carparkID;
        }
        //Accessor & Mutator Method
        public int RateID { get => _rateID; set => _rateID = value; }
        public string RateName { get => _rateName; set => _rateName = value; }
        public string RateStartTime { get => _rateStartTime; set => _rateStartTime = value; }
        public string RateEndTime { get => _rateEndTime; set => _rateEndTime = value; }
        public double InitialHrRate { get => _initialHrRate; set => _initialHrRate = value; }
        public double InitialTimePeriod { get => _initialTimePeriod; set => _initialTimePeriod = value; }
        public string CarparkID { get => _carparkID; set => _carparkID = value; }
        public double FirstSubsequentRate { get => _firstSubsequentRate; set => _firstSubsequentRate = value; }
        public double FirstSubsequentTimePeriod { get => _firstSubsequentTimePeriod; set => _firstSubsequentTimePeriod = value; }


        //Behaviours
        public List<CarparkRates> getRate(string carparkID)
        {
            int rateID;
            string rateName, rateStartTime, rateEndTime;
            double initialHrRate, initialTimePeriod, firstSubsequentRate, firstSubsequentTimePeriod;
            //int carparkID;
            List<CarparkRates> ratesList = new List<CarparkRates>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM CarparkRates where carparkID = @carparkID";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@carparkID", carparkID);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                rateID = int.Parse(dr["rateID"].ToString());
                rateName = dr["rateName"].ToString();
                rateStartTime = dr["rateStartTime"].ToString();
                rateEndTime = dr["rateEndTime"].ToString();
                initialHrRate = double.Parse(dr["initialHrRate"].ToString());
                initialTimePeriod = double.Parse(dr["initialTimePeriod"].ToString());

                firstSubsequentRate = double.Parse(dr["firstSubsequentRate"].ToString());
                firstSubsequentTimePeriod = double.Parse(dr["firstSubsequentTimePeriod"].ToString());

                carparkID = dr["carparkID"].ToString();

                CarparkRates a = new CarparkRates(rateID, rateName, rateStartTime, rateEndTime, initialHrRate, initialTimePeriod, firstSubsequentRate, firstSubsequentTimePeriod, carparkID);
                ratesList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return ratesList;
        }
        public Boolean CreateNewCarparkRate(string rateName, string rateStartTime, string rateEndTime, double initialHrRate, double initialTimePeriod, double firstSubsequentRate, double firstSubsequentTimePeriod, string carparkID)
        {
            CarparkInfo info = new CarparkInfo();
            //string carparkID = info.getCarparkID(carparkName);
            int getResult = 0;
            Boolean finalResult = false;
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            try
            {


                //create command
                string strCommandText = "INSERT CarparkRates (rateName, rateStartTime, rateEndTime, initialHrRate, initialTimePeriod, firstSubsequentRate, firstSubsequentTimePeriod, carparkID)";
                strCommandText += "Values(@rateName, @rateStartTime, @rateEndTime, @initialHrRate, @initialTimePeriod, @firstSubsequentRate, @firstSubsequentTimePeriod, @carparkID)";

                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@rateName", rateName);
                cmd.Parameters.AddWithValue("@rateStartTime", rateStartTime);
                cmd.Parameters.AddWithValue("@rateEndTime", rateEndTime);
                cmd.Parameters.AddWithValue("@initialHrRate", initialHrRate);
                cmd.Parameters.AddWithValue("@initialTimePeriod", initialTimePeriod);
                cmd.Parameters.AddWithValue("@firstSubsequentRate", firstSubsequentRate);
                cmd.Parameters.AddWithValue("@firstSubsequentTimePeriod", firstSubsequentTimePeriod);
                cmd.Parameters.AddWithValue("@carparkID", carparkID);

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
            finally
            {
                myConnect.Close();
            }
            return finalResult;
        }
    }



}