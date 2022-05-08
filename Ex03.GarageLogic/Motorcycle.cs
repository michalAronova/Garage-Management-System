using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const int k_TireNumber = 2;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaxFuelTank = 6.2f;
        private const float k_MaxBatteryTime = 2.5f;
        private const float k_MaxTirePressure = 31;
        private const int k_ParametersRequiredForFullCreation = 2;

        internal enum eLicenseType
        {
            A,
            A1,
            B1,
            B2
        }

        public Motorcycle(string i_LicenseNumber, Engine.eEngineType i_EngineType) : base(i_LicenseNumber, k_TireNumber, k_MaxTirePressure)
        {
            createEngineByType(i_EngineType);
        }

        private void createEngineByType(Engine.eEngineType i_EngineType)
        {
            base.CreateEngineByType(i_EngineType, k_MaxBatteryTime, k_FuelType, k_MaxFuelTank);
        }

        public override List<Param> GetParametersRequired()
        {
            List<Param> allRequiredParams = new List<Param>();
            string[] options = Enum.GetNames(typeof(eLicenseType));

            allRequiredParams.Add(new Param("License type", string.Join(", ",options), typeof(eLicenseType)));
            allRequiredParams.Add(new Param("Engine volume", "number", typeof(int)));
            allRequiredParams.AddRange(base.GetParametersRequired());

            return allRequiredParams;
        }

        public override void FillParams(List<object> i_Parameters)
        {
            string licenseType = i_Parameters[0] as string;
            int engineVolume = (int)i_Parameters[1];
            bool ableToParse = Enum.TryParse(licenseType, true, out m_LicenseType);

            if (!ableToParse)
            {
                throw new FormatException(string.Format("{0} is not a valid license type", licenseType));
            }

            if (engineVolume < 0)
            {
                throw new ArgumentException("Engine volume may not be negative");
            }

            m_EngineVolume = engineVolume;
            base.FillParams(i_Parameters.GetRange(k_ParametersRequiredForFullCreation, i_Parameters.Count - k_ParametersRequiredForFullCreation));
        }

        public override string ToString()
        {
            string motorcycleData = string.Format(
@"{0}
License type: {1}
Engine capacity: {2}",
base.ToString(),
m_LicenseType.ToString(),
m_EngineVolume);

            return motorcycleData;
        }
    }
}