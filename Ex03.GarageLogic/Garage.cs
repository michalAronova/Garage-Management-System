using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> r_GarageVehicles = new Dictionary<string, GarageVehicle>();

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_GarageVehicles.ContainsKey(i_LicenseNumber);
        }

        public void EnterNewVehicle(GarageVehicle i_NewGarageVehicle)
        {
            r_GarageVehicles.Add(i_NewGarageVehicle.LicenseNumber, i_NewGarageVehicle);
        }

        public List<string> GetAllLicenseNumbers()
        {
            List<string> allLicenseNumbers = new List<string>();

            foreach(KeyValuePair<string,GarageVehicle> garageVehiclePair in r_GarageVehicles)
            {
                allLicenseNumbers.Add(garageVehiclePair.Key);
            }

            return allLicenseNumbers;
        }

        public List<string> GetAllLicenseNumbersByStatus(GarageVehicle.eVehicleStatus i_RequestedStatusFilter)
        {
            List<string> allLicenseNumbersByStatus = new List<string>();

            foreach (KeyValuePair<string, GarageVehicle> garageVehiclePair in r_GarageVehicles)
            {
                if(garageVehiclePair.Value.VehicleStatus == i_RequestedStatusFilter)
                {
                    allLicenseNumbersByStatus.Add(garageVehiclePair.Key);
                }
            }

            return allLicenseNumbersByStatus;
        }

        public bool ChangeVehicleStatusByLicenseNumber(string i_LicenseNumber, GarageVehicle.eVehicleStatus i_SelectedVehicleStatus)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);

            if(vehicleFound)
            {
                r_GarageVehicles[i_LicenseNumber].VehicleStatus = i_SelectedVehicleStatus;
            }

            return vehicleFound;
        }

        public bool FillTiresAirToMaxByLicenseNumber(string i_LicenseNumber)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);

            if(vehicleFound)
            {
                r_GarageVehicles[i_LicenseNumber].Vehicle.InflateAllToMax();
            }

            return vehicleFound;
        }

        public bool RefuelVehicleTankByLicenseNumber(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_FuelAmountToFill)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);

            if(vehicleFound)
            {
                r_GarageVehicles[i_LicenseNumber].Vehicle.RefuelVehicle(i_FuelType, i_FuelAmountToFill);
            }

            return vehicleFound;
        }

        public bool ChargeVehicleByLicenseNumber(string i_LicenseNumber, float i_MinutesToCharge)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);

            if(vehicleFound)
            {
                r_GarageVehicles[i_LicenseNumber].Vehicle.ChargeVehicle(i_MinutesToCharge);
            }

            return vehicleFound;
        }

        public string GetVehicleFullDetailsByLicenseNumber(string i_LicenseNumber)
        {
            string fullData = null;

            if (IsVehicleInGarage(i_LicenseNumber))
            {
                fullData = r_GarageVehicles[i_LicenseNumber].ToString();
            }
            else
            {
                throw new ArgumentException("Couldn't find this license number.");
            }

            return fullData;
        }
    }
}