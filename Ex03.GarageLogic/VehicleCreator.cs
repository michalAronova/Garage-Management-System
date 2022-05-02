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
            Fuel,
        }

        public void getParamsForCreation(eVehicleType i_VehicleType) //should i get a string here and see if it matches an enum
                                                                    //or get an enum here and check the match in the UI?
        {
            List<Param> paramsRequiredForCreation;
            if (i_VehicleType == eVehicleType.Car)
            {
                //need to create car to get car's required parameters
            }
            else if (i_VehicleType == eVehicleType.Motorcycle)
            {
                //as above
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                //as above

            }
        }

        public Vehicle CreateVehicle(eVehicleType i_VehicleType, eEngineType i_EngineType)
        {

        }

        private List<Param> getParamsCar()
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