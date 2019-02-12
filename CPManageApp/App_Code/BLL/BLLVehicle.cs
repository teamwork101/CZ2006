using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.App_Code.BLL
{
    public class BLLVehicle
    {
        Vehicle vehicleDatalayer = new Vehicle();

        //Method 1 : To add a new vehicle into the user’s vehicle collection
        public Boolean addVehicle(string username, string vehicleNo, string vehicleType)
        {
            return vehicleDatalayer.addVehicle(username, vehicleNo, vehicleType);
        }

        //Method 2 : To remove a vehicle from the user’s vehicle collection
        public Boolean removeVehicle(string username, string vehicleNo)
        {
            return vehicleDatalayer.removeVehicle(username, vehicleNo);
        }

        //Method 3: To display the user’s vehicle collection
        public List<Vehicle> getAllVehicles(string username)
        {
            return vehicleDatalayer.getAllVehicles(username);
        }

        //Method 4 : To Check if this vehicle is a archived data in the Vehicle Data. 
        //It is also used as a re-activation for user to add back this vehicle information.
        public Boolean unarchiveVehicle(string username, string vehicleNo)
        {
            return vehicleDatalayer.unarchiveVehicle(username, vehicleNo);
        }

        //Method 5 : To update a specific vehicle information
        public Boolean updateVehicle(string username, string vehicleNo, string vehicleType)
        {
            return vehicleDatalayer.updateVehicle(username, vehicleNo, vehicleType);
        }
    }
}