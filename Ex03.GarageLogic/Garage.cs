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
            return null;
        }

        public List<string> GetAllLicenseNumbersByStatus(GarageVehicle.eVehicleStatus i_RequestedStatusFilter)
        {
            return null;
        }

        public bool ChangeVehicleStatusByLicenseNumber(string i_LicenseNumber, GarageVehicle.eVehicleStatus i_SelectedVehicleStatus)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            // if yes change status

            return vehicleFound;
        }

        public bool FillTiresAirToMaxByLicenseNumber(string i_LicenseNumber)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            // if yes fill air

            return vehicleFound;
        }

        public bool RefuelVehicleTankByLicenseNumber(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_FuelAmountToFill)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            // if yes...

            return vehicleFound;
        }

        public bool ChargeVehicleByLicenseNumber(string i_LicenseNumber, float i_MinutesToCharge)
        {
            bool vehicleFound = IsVehicleInGarage(i_LicenseNumber);
            // if yes...

            return vehicleFound;
        }

        public void/***/ GetVehicleFullDetailsByLicenseNumber(string i_LicenseNumber)
        {
            //return needs to be the details somehow... maybe some sort of form as a struct?
        }
    }
}