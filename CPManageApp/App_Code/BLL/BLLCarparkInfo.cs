using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLCarparkInfo
    {
        CarparkInfo carparkInfoData = new CarparkInfo();

        //Method 1 : Remove an existing Carpark
        public Boolean RemoveOldCarpark(string carparkID)
        {
            return carparkInfoData.removeOldCarpark(carparkID);
        }

        //Method 2 : Create a new Carpark
        public Boolean CreateNewCarpark(string carparkID, string carparkName, int totalSlots, string carparkLocation, string startHour, string endHour, string region, string carparkStatus,string image, double latitude, double longtitude)
        {
            return carparkInfoData.CreateNewCarpark(carparkID,carparkName, totalSlots, carparkLocation, startHour, endHour,region, carparkStatus, image, latitude, longtitude);
        }

        //Method 3 : To Update a capark status
        public Boolean UpdateCarpark(string carparkID, string carparkStatus)
        {
            return carparkInfoData.updateCarpark(carparkID, carparkStatus);
        }

        //Method 4 : To Search a carpark’s information
        public List<CarparkInfo> searchCarpark(string searchCarparkName, string searchRegion)
        {
            return carparkInfoData.searchCarpark(searchCarparkName, searchRegion);
        }

        //Method 5 : To retrieve a carpark’s information
        public CarparkInfo getCarpark(string carparkID)
        {
            return carparkInfoData.getCarpark(carparkID);
        }

        //Method 6 : To retrieve all carpark’s information
        public List<CarparkInfo> getAllCarpark()
        {
            return carparkInfoData.getAllCarpark();
        }

        public string displayLayout(string carparkID)
        {
            return carparkInfoData.displayLayout(carparkID);
        }

        public Boolean updateSlotTaken(string carparkID)
        {
            return carparkInfoData.updateSlotTaken(carparkID);
        }
    }
}