using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace CPManageApp.App_Code.DAL
{
    public class ParkingHistory
    {
        int _recordID = 0;
        string _username = "";
        string _vehicleNo = "";
        string _carparkID = "";
        int _rateID = 0;
        string _entryTime = "";
        string _exitTime = "";
        string _entryDate = "";
        string _exitDate = "";
        double _totalCost = 0.0;
        //default constructor
        public ParkingHistory() { }

        //implicit constructor
        public ParkingHistory(int recordID, string username, string vehicleNo, string carparkID, int rateID, string entryTime, string exitTime, string entryDate, string exitDate, double totalCost)
        {
            _recordID = recordID;
            _username = username;
            _vehicleNo = vehicleNo;
            _carparkID = carparkID;
            _rateID = rateID;
            _entryTime = entryTime;
            _exitTime = exitTime;
            _entryDate = entryDate;
            _exitDate = exitDate;
            _totalCost = totalCost;
        }

        //Access & Mutator Methods
        public int RecordID { get => _recordID; set => _recordID = value; }
        public string Username { get => _username; set => _username = value; }
        public string VehicleNo { get => _vehicleNo; set => _vehicleNo = value; }
        public string CarparkID { get => _carparkID; set => _carparkID = value; }
        public int RateID { get => _rateID; set => _rateID = value; }
        public string EntryTime { get => _entryTime; set => _entryTime = value; }
        public string ExitTime { get => _exitTime; set => _exitTime = value; }
        public string EntryDate { get => _entryDate; set => _entryDate = value; }
        public string ExitDate { get => _exitDate; set => _exitDate = value; }
        public double TotalCost { get => _totalCost; set => _totalCost = value; }


        //Method 1 : Create A Parking Record
        public Boolean createRecord(string username, string vehicleNo, string carparkID, int rateID, string entryTime, string exitTime, string entryDate, string exitDate, string totalCost)
        {
            int getResult = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //create command
                string strCommandText = "INSERT ParkingHistory (username, vehicleNo, carparkID, rateID, entryTime, exitTime, entryDate, exitDate, totalCost)";
                strCommandText += "Values(@username, @vehicleNo, @carparkID, @rateID, @entryTime, @exitTime, @entryDate, @exitDate, @totalCost)";

                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                cmd.Parameters.AddWithValue("@carparkID", carparkID);
                cmd.Parameters.AddWithValue("@rateID", rateID);
                cmd.Parameters.AddWithValue("@entryTime", entryTime);
                cmd.Parameters.AddWithValue("@exitTime", exitTime);
                cmd.Parameters.AddWithValue("@entryDate", entryDate);
                cmd.Parameters.AddWithValue("@exitDate", exitDate);
                cmd.Parameters.AddWithValue("@totalCost", totalCost);

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
        //** End of Method 1

        //Method 2 : Display Parking History record
        public List<ParkingHistory> displayRecord(string username)
        {
            int rateID, recordID;
            string entryTime, exitTime, vehicleNo, entryDate, exitDate, carparkID;
            double totalCost;
            List<int> archive = new List<int>();
            List<ParkingHistory> parkingHistList = new List<ParkingHistory>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);


                //create command
                string strCommandText = "SELECT * FROM ParkingHistory WHERE username = @username";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@username", username);
                myConnect.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    recordID = int.Parse(dr["recordID"].ToString());
                    //username = dr["username"].ToString();
                    vehicleNo = dr["vehicleNo"].ToString();
                    carparkID = dr["carparkID"].ToString();
                    rateID = int.Parse(dr["rateID"].ToString());
                    entryTime = dr["entryTime"].ToString();
                    exitTime = dr["exitTime"].ToString();
                    entryDate = dr["entryDate"].ToString();
                    exitDate = dr["exitDate"].ToString();
                    totalCost = double.Parse(dr["totalCost"].ToString());

                    ParkingHistory a = new ParkingHistory(recordID, username, vehicleNo, carparkID, rateID, entryTime, exitTime, entryDate, exitDate, totalCost);
                    parkingHistList.Add(a);
                }
                myConnect.Close();
                dr.Close();
                dr.Dispose();
            

            return parkingHistList;
        }
        //End of Method 2 

        //Method 2 : Display Parking History record
        public List<ParkingHistory> displayRecordByVehicle(string username, string vehicleNo)
        {
            int recordID, rateID;
            string entryTime, exitTime, location, entryDate, exitDate, carparkID;
            double totalCost;

            List<ParkingHistory> parkingHistList = new List<ParkingHistory>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //create command
            string strCommandText = "SELECT * FROM ParkingHistory WHERE username = @username AND vehicleNo = @vehicleNo";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@vehicleNo", vehicleNo);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                recordID = int.Parse(dr["recordID"].ToString());
                //username = dr["username"].ToString();
                //vehicleNo = dr["vehicleNo"].ToString();
                carparkID = dr["carparkID"].ToString();
                rateID = int.Parse(dr["rateID"].ToString());
                entryTime = dr["entryTime"].ToString();
                exitTime = dr["exitTime"].ToString();
                entryDate = dr["entryDate"].ToString();
                exitDate = dr["exitDate"].ToString();
                totalCost = double.Parse(dr["totalCost"].ToString());
                ParkingHistory a = new ParkingHistory(recordID, username, vehicleNo, carparkID, rateID, entryTime, exitTime, entryDate, exitDate, totalCost);
                parkingHistList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return parkingHistList;
        }
        //End of Method 2 


        //Method 3 : Get the entry time of a specific record
        public string getEntryTime(int recordID)
        {
            string entryTime = "";
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT entryTime FROM ParkingHistory WHERE recordID = @recordID";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("recordID", recordID);
            myConnect.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                entryTime = dr["entryTime"].ToString();
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return entryTime;
        }

        //Notify user through sms

        public void sendNotification(string username, string phoneNum, string vehicleNo, string exitTime)
        {
            DateTime currentTime = System.DateTime.Now;
            DateTime statedTime = DateTime.Parse(exitTime);
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "ACb807f8bf6a1bf14813c8b1a5edfa3cd1";
            const string authToken = "fd618a5c7ea160cec18fa90f961222bc";

            TwilioClient.Init(accountSid, authToken);
            //var twilio = new TwilioRestClient(accountSid, authToken);
            var twilio = new TwilioRestClient(Environment.GetEnvironmentVariable(accountSid), Environment.GetEnvironmentVariable(authToken));
            string from = "+15164943041";
            string to = phoneNum; //"+6591723761";

            string msg = "";
            if (currentTime.AddMinutes(15) == statedTime)
            {
                msg = "15 more minutes to your stated exit time.";
            }
            if (currentTime.AddMinutes(10) == statedTime)
            {
                msg = "10 more minutes to your stated exit time.";
            }
            if (currentTime.AddMinutes(5) == statedTime)
            {
                msg = "5 more minutes to your stated exit time.";
            }

            msg += " This is auto generated. Please do not reply.";
            var message = MessageResource.Create(
           to: new PhoneNumber(to),
           from: new PhoneNumber(from),
           body: msg);

        }


        public double calculateTotalCost(String username, string entryTime, string exitTime, int rateID)
        {
            return 0.0;
        }
        //DUMMY Method to test if sms works
        public void sendNotification1()
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "ACb807f8bf6a1bf14813c8b1a5edfa3cd1";
            const string authToken = "fd618a5c7ea160cec18fa90f961222bc";

            TwilioClient.Init(accountSid, authToken);
            //var twilio = new TwilioRestClient(accountSid, authToken);
            var twilio = new TwilioRestClient(Environment.GetEnvironmentVariable(accountSid), Environment.GetEnvironmentVariable(authToken));
            string from = "+15164943041";
             string to = "+6591598596";
            string msg = "Parking session time up!";
            msg += " This is auto generated. Please do not reply.";

            var message = MessageResource.Create(
           to: new PhoneNumber(to),
           from: new PhoneNumber(from),
           body: msg);
        }

    }
}