using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_TireNumber = 16;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
        private const float k_MaxFuelTank = 120f;
        private const float k_MaxTirePressure = 24;
        private const int   k_ParametersRequiredForFullCreation = 2;

        private bool m_Refrigerating;
        private float m_CargoVolume;

        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, k_TireNumber)
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTank);
            base.CreateTires(k_MaxTirePressure);
        }

        public override List<Param> GetParametersRequired()
        {
            List<Param> allRequiredParams = new List<Param>();

            allRequiredParams.Add(new Param("Is it carrying refrigerated content", "true/false", typeof(bool)));
            allRequiredParams.Add(new Param("Cargo volume", "number", typeof(float)));
            allRequiredParams.AddRange(base.GetParametersRequired());

            return allRequiredParams;
        }

        public override void FillParams(List<object> i_Parameters)
        {
            //assuming UI will make sure I get a boolean for the refrigiration
            //and get float for cargo volume -> there is no limit so only check that it is not negative basically
            m_Refrigerating = (bool)i_Parameters[0];
            float cargoVolume = (float)i_Parameters[1];
            if(cargoVolume < 0)
            {
                throw new ArgumentException("Cargo volume may not be negative");
            }
            m_CargoVolume = cargoVolume;
            base.FillParams(i_Parameters.GetRange(k_ParametersRequiredForFullCreation, i_Parameters.Count - k_ParametersRequiredForFullCreation));
        }
    }
}