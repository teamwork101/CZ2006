using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.DAL
{
    public class SurchargeRate
    {
        int _surchargeID;
        int _rateID;
        int _isSurcharged;
        double _surchargedRate;
        string _surchargeType;
        string _surchargeStartTime;
        string _surchargeEndTime;

        //default constructor
        public SurchargeRate() { }
        //implicit constructor
        public SurchargeRate(int surchargeID, int rateID, int isSurcharged, double surchargedRate, string surchargeType, string surchargeStartTime, string surchargeEndTime)
        {
            _surchargeID = surchargeID;
            _rateID = rateID;
            _isSurcharged = isSurcharged;
            _surchargedRate = surchargedRate;
            _surchargeType = surchargeType;
            _surchargeStartTime = surchargeStartTime;
            _surchargeEndTime = surchargeEndTime;
        }

        //Accessor & Mutator Method
        public int SurchargeID { get => _surchargeID; set => _surchargeID = value; }
        public int RateID { get => _rateID; set => _rateID = value; }
        public int IsSurcharged { get => _isSurcharged; set => _isSurcharged = value; }
        public double SurchargedRate { get => _surchargedRate; set => _surchargedRate = value; }
        public string SurchargeType { get => _surchargeType; set => _surchargeType = value; }
        public string SurchargeStartTime { get => _surchargeStartTime; set => _surchargeStartTime = value; }
        public string SurchargeEndTime { get => _surchargeEndTime; set => _surchargeEndTime = value; }
        

        //Behaviour
        //Get individual SurchargeRate
        public SurchargeRate getSurchargeRate(int surchargeID)
        {
            int rateID, isSurcharge;
            string surchargeType, surchargeStartTime, surchargeEndTime;
            double surchargeRate;

            SurchargeRate surcharge = new SurchargeRate();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM CapRate WHERE surchargeID = @surchargeID";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("surchargeID", surchargeID);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                rateID = int.Parse(dr["rateID"].ToString());
                isSurcharge = int.Parse(dr["isSurcharge"].ToString());
                surchargeRate = double.Parse(dr["surchargeRate"].ToString());
                surchargeType = dr["surchargeType"].ToString();
                surchargeStartTime = dr["surchargeStartTime"].ToString();
                surchargeEndTime = dr["surchargeEndTime"].ToString();

                surcharge = new SurchargeRate(surchargeID, rateID, isSurcharge, surchargeRate, surchargeType, surchargeStartTime, surchargeEndTime);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return surcharge;
        }
        public List<SurchargeRate> getAllSurchargeRate()
        {
            int surchargeID, rateID, isSurcharge;
            string surchargeType, surchargeStartTime, surchargeEndTime;
            double surchargeRate;

            List<SurchargeRate> surchargeList = new List<SurchargeRate>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM SurchargeRate";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                surchargeID = int.Parse(dr["surchargeID"].ToString());
                rateID = int.Parse(dr["rateID"].ToString());
                isSurcharge = int.Parse(dr["isSurcharge"].ToString());
                surchargeRate = double.Parse(dr["surchargeRate"].ToString());
                surchargeType = dr["surchargeType"].ToString();
                surchargeStartTime = dr["surchargeStartTime"].ToString();
                surchargeEndTime = dr["surchargeEndTime"].ToString();

                SurchargeRate a = new SurchargeRate(surchargeID, rateID, isSurcharge, surchargeRate, surchargeType, surchargeStartTime, surchargeEndTime);
                surchargeList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return surchargeList;
        }
    }
}