using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public void EnterNewVehicle()
        {
            //how do we knows which vehicle we want to make a new one of?
            //how do we make it extendable?
        }

        public List<string> GetAllLicenseNumbers()
        {
            //here need to choose if to filter by status
            return null;
        }

        public List<string> GetAllLicenseNumbersByStatus(GarageVehicle.VehicleStatus i_RequestedStatusFilter)
        {
            return null;
        }

        private void changeVehicleStatusByLicenseNumber(string i_LicenseNumber)
        {

        }

        private void fillTiresAirToMaxByLicenseNumber(string i_LicenseNumber)
        {

        }

        private void refuelVehicleTankByLicenseNumber(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_FuelAmountToFill)
        {

        }

        private void chargeVehicleByLicenseNumber(string i_LicenseNumber, float i_MinutesToCharge)
        {

        }

        private void/***/ GetVehicleFullDetailsByLicenseNumber(string i_LicenseNumber)
        {
            //return needs to be the details somehow... maybe some sort of form as a struct?
        }
    }
}