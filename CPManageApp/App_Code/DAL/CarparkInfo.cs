using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPManageApp.App_Code.DAL
{
    public class CarparkInfo
    {
        string _carparkID ="";
        string _carparkName = "";
        int _totalSlots = 0;
        string _carparkLocation = "";
        string _startHour = "";
        string _endHour = "";
        string _region = "";
        string _carparkStatus = "";
        int _slotTaken = 0;
        string _image = "";
        double _latitude = 0.0;
        double _longtitude = 0.0;
        //default constructor
        public CarparkInfo() { }

        //implicit constructor
        public CarparkInfo(string carparkID, string carparkName, int totalSlots, string carparkLocation, string startHour, string endHour, string region, string carparkStatus, int slotTaken, string image, double latitude, double longtitude)
        {
            _carparkID = carparkID;
            _carparkName = carparkName;
            _totalSlots = totalSlots;
            _carparkLocation = carparkLocation;
            _startHour = startHour;
            _endHour = endHour;
            _region = region;
            _carparkStatus = carparkStatus;
            _slotTaken = slotTaken;
            _image = image;
            _latitude = latitude;
            _longtitude = longtitude;
        }
        public CarparkInfo(string carparkID, string carparkName, int totalSlots, string carparkLocation, string startHour, string endHour, string region, string carparkStatus, int slotTaken, string image)
        {
            _carparkID = carparkID;
            _carparkName = carparkName;
            _totalSlots = totalSlots;
            _carparkLocation = carparkLocation;
            _startHour = startHour;
            _endHour = endHour;
            _region = region;
            _carparkStatus = carparkStatus;
            _slotTaken = slotTaken;
            _image = image;
        }

        //Accessor & Mutator Method
        public string CarparkID { get => _carparkID; set => _carparkID = value; }
        public string CarparkName { get => _carparkName; set => _carparkName = value; }
        public int TotalSlots { get => _totalSlots; set => _totalSlots = value; }
        public string CarparkLocation { get => _carparkLocation; set => _carparkLocation = value; }
        public string StartHour { get => _startHour; set => _startHour = value; }
        public string EndHour { get => _endHour; set => _endHour = value; }
        public string Region { get => _region; set => _region = value; }
        public string CarparkStatus { get => _carparkStatus; set => _carparkStatus = value; }
        public int SlotTaken { get => _slotTaken; set => _slotTaken = value; }
        public string Image { get => _image; set => _image = value; }
        public double Longtitude { get => _longtitude; set => _longtitude = value; }
        public double Latitude { get => _latitude; set => _latitude = value; }

        //Behaviour
        public Boolean removeOldCarpark(string carparkID)
        {
            int getResult = 0;
            Boolean finalResult = false;

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string query = "DELETE FROM CarparkInfo WHERE carparkID = @carparkID";
            SqlCommand cmd = new SqlCommand(query, myConnect);
            cmd.Parameters.AddWithValue("@carparkID", carparkID);
            myConnect.Open();
            getResult = cmd.ExecuteNonQuery();
            if (getResult > 0)
            {
                finalResult = true;
            }
            return finalResult;

        }

        public Boolean CreateNewCarpark(string carparkID, string carparkName, int totalSlots, string carparkLocation, string startHour, 
            string endHour, string region, string carparkStatus, string image, double latitude, double longtitude)
        {

            int getResult = 0;
            Boolean finalResult = false;
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            try
            {


                //create command
                string strCommandText = "INSERT CarparkInfo (carparkID, carparkName, totalSlots, carparkLocation, startHour, endHour, region, carparkStatus, slotTaken, image, latitude, longtitude)";
                strCommandText += "Values(@carparkID, @carparkName, @totalSlots, @carparkLocation, @startHour, @endHour, @region, @carparkStatus, @slotTaken, @image, @latitude, @longtitude)";

                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@carparkID", carparkID);
                cmd.Parameters.AddWithValue("@carparkName", carparkName);
                cmd.Parameters.AddWithValue("@totalSlots", totalSlots);
                cmd.Parameters.AddWithValue("@carparkLocation", carparkLocation);
                cmd.Parameters.AddWithValue("@startHour", startHour);
                cmd.Parameters.AddWithValue("@endHour", endHour);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@carparkStatus", carparkStatus);
                cmd.Parameters.AddWithValue("@slotTaken", 0);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@latitude", latitude);
                cmd.Parameters.AddWithValue("@longtitude", longtitude);

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
        public Boolean updateCarpark(string carparkID, string carparkStatus)
        {
            int getResult = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //create command
                string strCommandText = "Update CarparkInfo SET carparkStatus = @carparkStatus WHERE carparkID = @carparkID";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@carparkID", carparkID);
                cmd.Parameters.AddWithValue("@carparkStatus", carparkStatus);
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

        public List<CarparkInfo> searchCarpark(string searchCarparkName, string searchRegion)
        {

            int  totalSlots, slotTaken;
            string carparkID,carparkName, carparkLocation, startHour, endHour, region, carparkStatus, image;
            List<CarparkInfo> carparkList = new List<CarparkInfo>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            if (searchRegion == "All")
            {
                //create command
                string strCommandText = "SELECT * FROM CarparkInfo WHERE carparkName Like @searchCarparkName";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.Add("@searchCarparkName", SqlDbType.VarChar, 50);
                cmd.Parameters["@searchCarparkName"].Value = "%" + searchCarparkName + "%";
                myConnect.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    carparkID = dr["carparkID"].ToString();
                    carparkName = dr["carparkName"].ToString();
                    totalSlots = int.Parse(dr["totalSlots"].ToString());
                    carparkLocation = dr["carparkLocation"].ToString();
                    startHour = dr["startHour"].ToString();
                    endHour = dr["endHour"].ToString();
                    region = dr["region"].ToString();
                    carparkStatus = dr["carparkStatus"].ToString();
                    slotTaken = int.Parse(dr["slotTaken"].ToString());
                    image = dr["image"].ToString();
                    CarparkInfo a = new CarparkInfo(carparkID, carparkName, totalSlots, carparkLocation, startHour, endHour, region, carparkStatus, slotTaken, image);
                    carparkList.Add(a);
                }
                myConnect.Close();
                dr.Close();
                dr.Dispose();
            }
            else // when there is specification for region
            {
                //create command
                string strCommandText = "SELECT * FROM CarparkInfo WHERE carparkName Like @searchCarparkName AND region Like @region";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.Add("@searchCarparkName", SqlDbType.VarChar, 50);
                cmd.Parameters["@searchCarparkName"].Value = "%" + searchCarparkName + "%";
                cmd.Parameters.Add("@region", SqlDbType.VarChar, 50);
                cmd.Parameters["@region"].Value = "%" + searchRegion + "%";
                myConnect.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    carparkID = dr["carparkID"].ToString();
                    carparkName = dr["carparkName"].ToString();
                    totalSlots = int.Parse(dr["totalSlots"].ToString());
                    carparkLocation = dr["carparkLocation"].ToString();
                    startHour = dr["startHour"].ToString();
                    endHour = dr["endHour"].ToString();
                    region = dr["region"].ToString();
                    carparkStatus = dr["carparkStatus"].ToString();
                    slotTaken = int.Parse(dr["slotTaken"].ToString());
                    image = dr["image"].ToString();
                    CarparkInfo a = new CarparkInfo(carparkID, carparkName, totalSlots, carparkLocation, startHour, endHour, region, carparkStatus, slotTaken, image);
                    carparkList.Add(a);
                }
                myConnect.Close();
                dr.Close();
                dr.Dispose();
            }
            return carparkList;
        }
        public CarparkInfo getCarpark(string carparkID)
        {
            int totalSlots, slotTaken;
            string carparkName, carparkLocation, startHour, endHour, region, carparkStatus, image;
            CarparkInfo carpark = new CarparkInfo();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM CarparkInfo WHERE carparkID = @carparkID";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@carparkID", carparkID);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                carparkName = dr["carparkName"].ToString();
                totalSlots = int.Parse(dr["totalSlots"].ToString());
                carparkLocation = dr["carparkLocation"].ToString();
                startHour = dr["startHour"].ToString();
                endHour = dr["endHour"].ToString();
                region = dr["region"].ToString();
                carparkStatus = dr["carparkStatus"].ToString();
                slotTaken = int.Parse(dr["slotTaken"].ToString());
                image = dr["image"].ToString();
                carpark = new CarparkInfo(carparkID, carparkName, totalSlots, carparkLocation, startHour, endHour, region, carparkStatus, slotTaken, image);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return carpark;
        }
        public List<CarparkInfo> getAllCarpark()
        {

            int  totalSlots, slotTaken;
            string carparkID,carparkName, carparkLocation, startHour, endHour, region, carparkStatus, image;
            List<CarparkInfo> carparkList = new List<CarparkInfo>();
            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            //create command
            string strCommandText = "SELECT * FROM CarparkInfo";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                carparkID = dr["carparkID"].ToString();
                carparkName = dr["carparkName"].ToString();
                totalSlots = int.Parse(dr["totalSlots"].ToString());
                carparkLocation = dr["carparkLocation"].ToString();
                startHour = dr["startHour"].ToString();
                endHour = dr["endHour"].ToString();
                region = dr["region"].ToString();
                carparkStatus = dr["carparkStatus"].ToString();
                slotTaken = int.Parse(dr["slotTaken"].ToString());
                image = dr["image"].ToString();
                CarparkInfo a = new CarparkInfo(carparkID, carparkName, totalSlots, carparkLocation, startHour, endHour, region, carparkStatus, slotTaken, image);
                carparkList.Add(a);
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return carparkList;
        }

        public string displayLayout(string carparkID)
        {
            string image = "";

            string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;

            //create connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //create command
            string strCommandText = "SELECT * FROM CarparkInfo WHERE carparkID = @carparkID";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@carparkID", carparkID);
            myConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                image = dr["image"].ToString();
            }
            myConnect.Close();
            dr.Close();
            dr.Dispose();

            return image;
        }

        public Boolean updateSlotTaken(string carparkID)
        {
            int getResult = 0, slotTaken = 0;
            Boolean finalResult = false;
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
                //create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string strCommand = "SELECT * FROM CarparkInfo WHERE carparkID = @carparkID";
                SqlCommand cmd2 = new SqlCommand(strCommand, myConnect);
                cmd2.Parameters.AddWithValue("@carparkID", carparkID);
                myConnect.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    slotTaken = int.Parse(dr["slotTaken"].ToString());
                }
                myConnect.Close();
                dr.Close();
                dr.Dispose();

                //create command
                string strCommandText = "Update CarparkInfo SET slotTaken = @slotTaken WHERE carparkID = @carparkID";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@carparkID", carparkID);
                cmd.Parameters.AddWithValue("@slotTaken", slotTaken + 1);
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



        //public string getCarparkID(string carparkName)
        //{

        //    string strConnectionString = ConfigurationManager.ConnectionStrings["CPMDatabase"].ConnectionString;
        //    string carparkID = "";
        //    //create connection
        //    SqlConnection myConnect = new SqlConnection(strConnectionString);

        //    //create command
        //    string strCommandText = "SELECT carparkID FROM CarparkInfo WHERE carparkName = @carparkName";
        //    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        //    cmd.Parameters.AddWithValue("@carparkName", carparkName);
        //    myConnect.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        carparkID = dr["carparkID"].ToString();

        //    }
        //    myConnect.Close();
        //    dr.Close();
        //    dr.Dispose();

        //    return carparkID;

        //}

        
    }
}