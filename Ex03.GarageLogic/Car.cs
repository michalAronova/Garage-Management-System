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
            Blue
        }

        private eColor m_CarColor;
        private int m_DoorNumber;

        private const int k_TireNumber = 4;
        private const int k_MinDoors = 2;
        private const int k_MaxDoors = 5;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxFuelTank = 38;
        private const float k_MaxBatteryTime = 3.3f;
        private const float k_MaxTirePressure = 29;
        private const int   k_ParametersRequiredForFullCreation = 2;


        public Car(string i_LicenseNumber, Engine.eEngineType i_EngineType) : base(i_LicenseNumber, k_TireNumber)
        {
            createEngineByType(i_EngineType);
            base.CreateTires(k_MaxTirePressure);
        }

        public override List<Param> GetParametersRequired()
        {
            List<Param> allRequiredParams = new List<Param>();
            string[] options = Enum.GetNames(typeof(eColor));

            allRequiredParams.Add(new Param("Car color", string.Join(", ", options), typeof(string)));
            allRequiredParams.Add(new Param("Number of doors", string.Format("{0} - {1}", k_MinDoors, k_MaxDoors), typeof(int)));
            allRequiredParams.AddRange(base.GetParametersRequired());

            return allRequiredParams;
        }

        public override void FillParams(List<object> i_Parameters)
        {
            //assuming the car color gets sent as a string -> check if it's in the enum
            //car door need to check that it between min and max
            string carColor = i_Parameters[0] as string;
            int carDoorNum = (int)i_Parameters[1];
            bool ableToParse =  Enum.TryParse(carColor, true, out m_CarColor);
            if(!ableToParse)
            {
                throw new ArgumentException(string.Format("{0} is not a valid car color", carColor));
            }
            if(carDoorNum < k_MinDoors || carDoorNum > k_MaxDoors)
            {
                throw new ArgumentException(string.Format("{0} exceeds car door number bound.", carDoorNum));
            }
            m_DoorNumber = carDoorNum;
            base.FillParams(i_Parameters.GetRange(k_ParametersRequiredForFullCreation, i_Parameters.Count - k_ParametersRequiredForFullCreation));
        }

        private void createEngineByType(Engine.eEngineType i_EngineType)
        {
            base.CreateEngineByType(i_EngineType, k_MaxBatteryTime, k_FuelType, k_MaxFuelTank);
        }
    }
}