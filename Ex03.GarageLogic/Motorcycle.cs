using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_TireNumber = 2;
        //private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
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
            //createEngineByType(i_EngineType);
        }

        //private void createEngineByType(Engine.eEngineType i_EngineType)
        //{
        //    base.CreateEngineByType(i_EngineType, k_MaxBatteryTime, k_FuelType, k_MaxFuelTank);
        //}

        public override Param[] GetParametersRequired()
        {
            Param[] baseParams = base.GetParametersRequired();
            Param[] allRequiredParams = new Param[k_ParametersRequiredForFullCreation + baseParams.Length];
            string options = Enum.GetNames(typeof(eLicenseType)).ToString();
            allRequiredParams[0] = new Param("License type", options, typeof(string));
            allRequiredParams[1] = new Param("Engine volume", "number", typeof(float));
            baseParams.CopyTo(allRequiredParams, k_ParametersRequiredForFullCreation);
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