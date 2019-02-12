using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.DAL
{
    public class CapRate
    {
        int _capID = 0;
        int _rateID = 0;
        int _isCapped = 0;
        double _cappedRate = 0.0;
        string _cappedType = "";

        //default constructor
        public CapRate() { }

        //implicit constructor
        public CapRate(int capID, int rateID, int isCapped, double cappedRate, string cappedType)
        {
            _capID = capID;
            _rateID = rateID;
            _isCapped = isCapped;
            _cappedRate = cappedRate;
            _cappedType = cappedType;
        }
        //Accessor & Mutator Method
        public int CapID{ get => _capID; set => _capID = value; }
        public int RateID { get => _rateID; set => _rateID = value; }
        public int IsCapped { get => _isCapped; set => _isCapped = value; }
        public double CappedRate { get => _cappedRate; set => _cappedRate = value; }
        public string CappedType { get => _cappedType; set => _cappedType = value; }

        //Behaviour
        //Get individual CappedRate
        public CapRate getCapRate(int capID)
        {
            int rateID, isCapped;
            string cappedType;
            double cappedRate;

            CapRate cap = new CapRate();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM CapRate WHERE capID = @capID";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("capID", capID);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                rateID = int.Parse(dr["rateID"].ToString());
                isCapped = int.Parse(dr["isCapped"].ToString());
                cappedRate = double.Parse(dr["cappedRate"].ToString());
                cappedType = dr["cappedType"].ToString();

                cap = new CapRate(capID, rateID, isCapped, cappedRate, cappedType);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return cap;
        }
        public List<CapRate> getAllCapRate()
        {
            int capID,rateID,isCapped;
            string cappedType;
            double cappedRate;

            List<CapRate> capList = new List<CapRate>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM CapRate";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                capID = int.Parse(dr["capID"].ToString());
                rateID = int.Parse(dr["rateID"].ToString());
                isCapped = int.Parse(dr["isCapped"].ToString());
                cappedRate = double.Parse(dr["cappedRate"].ToString());
                cappedType = dr["cappedType"].ToString();

                CapRate a = new CapRate(capID, rateID, isCapped, cappedRate, cappedType);
                capList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return capList;
        }
    }
}