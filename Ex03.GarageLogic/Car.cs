using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            White,
            Green,
            Blue,
        }

        private eColor r_CarColor;
        private int r_DoorNumber;

        private const int k_TireNumber = 4;
        private const int k_MinDoors = 2;
        private const int k_MaxDoors = 5;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxFuelTank = 38;
        private const float k_MaxBatteryTime = 3.3f;
        private const float k_MaxTirePressure = 29;

        private readonly List<Param> r_Parameters;

        public Car(string i_LicenseNumber, Engine.eEngineType i_EngineType) : base(i_LicenseNumber, k_TireNumber)
        {
            string options = Enum.GetNames(typeof(eColor)).ToString();
            createEngineByType(i_EngineType);
            r_Parameters = new List<Param>();
            r_Parameters.Add(new Param("car color", options, typeof(string)));
            r_Parameters.Add(new Param("number of doors", string.Format("{0} - {1}", k_MinDoors, k_MaxDoors), typeof(int)));
        }

        public override List<Param> Parameters
        {
            get
            {
                List<Param> allParams = base.Parameters.Concat(r_Parameters).ToList();
                return allParams;
            }
        }
        
        private void createEngineByType(Engine.eEngineType i_EngineType)
        {
            //base.CreateEngineByType(i_EngineType, k_MaxBatteryTime, k_FuelType, k_MaxFuelTank);
        }
    }
}