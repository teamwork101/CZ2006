using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLParkingHistory
    {
        //initialise a DAL object for easier access 
        ParkingHistory parkingHistData = new ParkingHistory();

        //Method 1 : Get the entry time of a specific record
        public string getEntryTime(int recordID)
        {
            return parkingHistData.getEntryTime(recordID);
        }

        //Method 2 : Display Parking History record
        public List<ParkingHistory> displayRecord(string username)
        {
            return parkingHistData.displayRecord(username);
        }

        public List<ParkingHistory> displayRecordByVehicle(string username, string vehicleNo)
        {
            return parkingHistData.displayRecordByVehicle(username, vehicleNo);
        }
        public void sendNotification(string username, string phoneNum, string vehicleNo, string exitTime)
        {
            parkingHistData.sendNotification(username, phoneNum, vehicleNo, exitTime);
        }

        public double calculateTotalCost(String username, string entryTime, string exitTime, int rateID)
        {
            return 0.0;
        }

        public Boolean createRecord(string username, string vehicleNo, string carparkID, int rateID, string entryTime, string exitTime, string entryDate, string exitDate, string totalCost)
        {
            return parkingHistData.createRecord(username, vehicleNo, carparkID, rateID, entryTime, exitTime, entryDate, exitDate, totalCost);
        }
    }
}