using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageVehicle> m_GarageVehicles = new Dictionary<string, GarageVehicle>();

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_GarageVehicles.ContainsKey(i_LicenseNumber);
        }

        public void EnterNewVehicle(GarageVehicle i_NewGarageVehicle)
        {
            m_GarageVehicles.Add(i_NewGarageVehicle.LicenseNumber, i_NewGarageVehicle);
        }

        public List<string> GetAllLicenseNumbers()
        {
            List<string> allLicenseNumbers = new List<string>();
            foreach(KeyValuePair<string,GarageVehicle> garageVehiclePair in m_GarageVehicles)
            {
                allLicenseNumbers.Add(garageVehiclePair.Key);
            }
            return allLicenseNumbers;
        }

        public List<string> GetAllLicenseNumbersByStatus(GarageVehicle.eVehicleStatus i_RequestedStatusFilter)
        {
            List<string> allLicenseNumbersByStatus = new List<string>();
            foreach (KeyValuePair<string, GarageVehicle> garageVehiclePair in m_GarageVehicles)
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
                m_GarageVehicles[i_LicenseNumber].VehicleStatus = i_SelectedVehicleStatus;
            }
            return vehicleFound;
        }

        public bool FillTiresAirToMaxByLicenseNumber(string i_LicenseNumber)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            if(vehicleFound)
            {
                m_GarageVehicles[i_LicenseNumber].Vehicle.InflateAllToMax();
            }

            return vehicleFound;
        }

        public bool RefuelVehicleTankByLicenseNumber(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_FuelAmountToFill)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            Vehicle foundVehicle;
            if(vehicleFound)
            {
                m_GarageVehicles[i_LicenseNumber].Vehicle.RefuelVehicle(i_FuelType, i_FuelAmountToFill);
            }

            return vehicleFound;
        }

        public bool ChargeVehicleByLicenseNumber(string i_LicenseNumber, float i_MinutesToCharge)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            if(vehicleFound)
            {
                m_GarageVehicles[i_LicenseNumber].Vehicle.ChargeVehicle(i_MinutesToCharge);
            }

            return vehicleFound;
        }

        public List<string> GetVehicleFullDetailsByLicenseNumber(string i_LicenseNumber)
        {
            GarageVehicle.DetailsForm vehicleFullDetails = new List<string>();
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            if(vehicleFound)
            {
                //vehicleFullDetails = m_GarageVehicles[i_LicenseNumber].GetFullDetails();
                //still not sure hot to return this. struct? becase maybe list of strings is too "specific"
            }
            //if not found - throw exception? or - output parameter? maybe the list as output (similar to tryParse...)
            return vehicleFullDetails;
        }
    }
}