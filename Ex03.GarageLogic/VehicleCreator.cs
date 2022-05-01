using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public enum eVehicleType
        {
            Car = 1,
            Motorcycle,
            Truck,
        }

        public enum eEngineType
        {
            Electric = 1,
            NonElectric,
        }

        public List<Param> getParamsForCreation(eVehicleType i_VehicleType, eEngineType i_EngineType)
        {
            ///
        }

        public Vehicle CreateVehicle(eVehicleType i_VehicleType, eEngineType i_EngineType)
        {

        }

        private List<Param> getParamsForCar()
        {

        }

        private List<Param> getParamsMotorcycle()
        {

        }

        private List<Param> getElectricParams()
        {

        }
    }
}