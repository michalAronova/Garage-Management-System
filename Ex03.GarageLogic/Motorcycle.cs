using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_TireNumber = 2;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaxFuelTank = 6.2f;
        private const float k_MaxBatteryTime = 2.5f;
        private const float k_MaxTirePressure = 31;

        enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            B2
        }

        private eLicenseType m_LicenseType;
        private int engineVolume;

        private List<Param> r_Parameters;

        public Motorcycle(string i_LicenseNumber, Engine.eEngineType i_EngineType) : base(i_LicenseNumber, k_TireNumber)
        {
            string options = Enum.GetNames(typeof(eLicenseType)).ToString();
            createEngineByType(i_EngineType);
            r_Parameters = new List<Param>(2);
            r_Parameters[0] = new Param("License type", options, typeof(string));
            r_Parameters[1] = new Param("Engine volume", "number", typeof(float));
        }

        private void createEngineByType(Engine.eEngineType i_EngineType)
        {
            base.CreateEngineByType(i_EngineType, k_MaxBatteryTime, k_FuelType, k_MaxFuelTank);
        }

        public List<Param> Parameters
        {
            get
            {
                List<Param> allParams = base.Parameters.Concat(r_Parameters).ToList();
                return allParams;
            }
        }
    }
}