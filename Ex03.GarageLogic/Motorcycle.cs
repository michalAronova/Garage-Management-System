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
        private const int k_ParametersRequiredForFullCreation = 2;

        enum eLicenseType
        {
            A,
            A1,
            B1,
            B2
        }

        private eLicenseType m_LicenseType;
        private float m_EngineVolume;

        public Motorcycle(string i_LicenseNumber, Engine.eEngineType i_EngineType) : base(i_LicenseNumber, k_TireNumber)
        {
            createEngineByType(i_EngineType);
            base.CreateTires(k_MaxTirePressure);
        }

        private void createEngineByType(Engine.eEngineType i_EngineType)
        {
            base.CreateEngineByType(i_EngineType, k_MaxBatteryTime, k_FuelType, k_MaxFuelTank);
        }

        public override List<Param> GetParametersRequired()
        {
            List<Param> allRequiredParams = new List<Param>();
            string[] options = Enum.GetNames(typeof(eLicenseType));

            allRequiredParams.Add(new Param("License type", string.Join(", ",options), typeof(string)));
            allRequiredParams.Add(new Param("Engine volume", "number", typeof(float)));
            allRequiredParams.AddRange(base.GetParametersRequired());

            return allRequiredParams;
        }

        public override void FillParams(List<object> i_Parameters)
        {
            string licenseType = i_Parameters[0] as string;
            float engineVolume = (float)i_Parameters[1];
            bool ableToParse = Enum.TryParse(licenseType, true, out m_LicenseType);
            if (!ableToParse)
            {
                throw new ArgumentException(string.Format("{0} is not a valid license type", licenseType));
            }
            if (engineVolume < 0)
            {
                throw new ArgumentException("Engine volume may not be negative");
            }

            m_EngineVolume = engineVolume;
            base.FillParams(i_Parameters.GetRange(k_ParametersRequiredForFullCreation, i_Parameters.Count - k_ParametersRequiredForFullCreation));
        }
    }
}