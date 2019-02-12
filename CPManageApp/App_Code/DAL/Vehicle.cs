using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.DAL
{
    public class Vehicle
    {
        string _vehicleNo = "";
        string _username = "";
        string _vehicleType = "";
        int _isArchive = 0;

        //default constructor
        public Vehicle() { }

        //implicit constructor
        public Vehicle(string vehicleNo, string username, string vehicleType, int isArchive)
        {
            _vehicleNo = vehicleNo;
            _username = username;
            _vehicleType = vehicleType;
            _isArchive = isArchive;
        }
        //Access & Mutator Methods

        public string VehicleNo { get => _vehicleNo; set => _vehicleNo = value; }
        public string Username { get => _username; set => _username = value; }
        public string VehicleType { get => _vehicleType; set => _vehicleType = value; }
        public int isArchive { get => _isArchive; set => _isArchive = value; }

        //Behaviours
        public Boolean addVehicle(string username, string vehicleNo, string vehicleType)
        {
            int getResult = 0;
            Boolean finalResult = false;
            int dbArchive = 0;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string query = "SELECT isArchive FROM Vehicle WHERE username = @username and vehicleNo = @vehicleNo";
                SqlCommand cmdCheck = new SqlCommand(query, myConnect);
                cmdCheck.Parameters.AddWithValue("@username", username);
                cmdCheck.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                myConnect.Open();
                SqlDataReader dr = cmdCheck.ExecuteReader();
                if (dr.Read())
                {
                    dbArchive = int.Parse(dr["isArchive"].ToString());
                }
                myConnect.Close();
                dr.Close();
                dr.Dispose();
                if (dbArchive == 1)
                {
                    unarchiveVehicle(username, vehicleNo);
                }
                else
                {
                    //create command
                    string strCommandText = "INSERT INTO Vehicle (vehicleNo,username, vehicleType, isArchive)";
                    strCommandText += "Values(@vehicleNo,@username, @vehicleType, @isArchive)";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                    cmd.Parameters.AddWithValue("@vehicleType", vehicleType);
                    cmd.Parameters.AddWithValue("@isArchive", 0);

                    myConnect.Open();
                    getResult += cmd.ExecuteNonQuery();
                    if (getResult >= 1)
                    {
                        finalResult = true;
                    }
                }
                myConnect.Close();
            }
            catch (Exception e)
            {

            }
            return finalResult;

        }



        // Delete Vehicle (Since we cannot physically remove the vehicle from the record, we can only set it to archive)
        public Boolean removeVehicle(string username, string vehicleNo)
        {
            int getResult = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //create command
                string strCommandText = "Update Vehicle SET isArchive = @isArchive WHERE username = @username and vehicleNo = @vehicleNo";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                cmd.Parameters.AddWithValue("@isArchive", 1);
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

        public Boolean unarchiveVehicle(string username, string vehicleNo)
        {
            int getResult = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //create command
                string strCommandText = "Update Vehicle SET isArchive = @isArchive WHERE username = @username and vehicleNo = @vehicleNo";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                cmd.Parameters.AddWithValue("@isArchive", 0);
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

        public List<Vehicle> getAllVehicles(string username)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            string vehicleNo, vehicleType;
            int isArchive;

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT * FROM Vehicle Where username = @username AND isArchive = @isArchive";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@isArchive", 0);
            myConnect.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isArchive = int.Parse(dr["isArchive"].ToString());
                vehicleNo = dr["vehicleNo"].ToString();
                vehicleType = dr["vehicleType"].ToString();
                Vehicle a = new Vehicle(vehicleNo, username, vehicleType, isArchive);

                vehicleList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return vehicleList;
        }

        public Boolean updateVehicle(string username, string vehicleNo, string vehicleType)
        {
            int getResult = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //create command
                string strCommandText = "Update Vehicle SET vehicleType = @vehicleType WHERE username = @username and vehicleNo = @vehicleNo";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                cmd.Parameters.AddWithValue("@vehicleType", vehicleType);
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
    }
}