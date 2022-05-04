﻿using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public enum eVehicleType
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            Truck,
        }

        public Vehicle CreateVehicle(out List<Param> i_RequiredParams, string i_LicenseNum, eVehicleType i_VehicleType)
        {
            List<Param> paramsRequiredForCreation;
            Vehicle vehicle;
        
            if (i_VehicleType == eVehicleType.ElectricCar)
            {
                vehicle = new Car(i_LicenseNum, Engine.eEngineType.Electric);
            }
            else if (i_VehicleType == eVehicleType.FuelCar)
            {
                vehicle = new Car(i_LicenseNum, Engine.eEngineType.Fuel);
            }
            else if(i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                vehicle = new Motorcycle(i_LicenseNum, Engine.eEngineType.Electric);
            }
            else if (i_VehicleType == eVehicleType.FuelMotorcycle)
            {
                vehicle = new Motorcycle(i_LicenseNum, Engine.eEngineType.Fuel);
            }
            else
            {
                vehicle = new Truck(i_LicenseNum);
            }

            i_RequiredParams = vehicle.Parameters;
            return vehicle;
        }
    }
}