using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_Refrigerating;
        private float m_CargoVolume;
        private const int k_TireNumber = 16;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
        private const float k_MaxFuelTank = 120f;
        private const float k_MaxTirePressure = 24;
        private const int   k_ParametersRequiredForFullCreation = 2;

        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, k_TireNumber, k_MaxTirePressure)
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTank);
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
            float cargoVolume = (float)i_Parameters[1];
            
            m_Refrigerating = (bool)i_Parameters[0];
            if (cargoVolume < 0)
            {
                throw new ArgumentException("Cargo volume may not be negative");
            }

            m_CargoVolume = cargoVolume;
            base.FillParams(i_Parameters.GetRange(k_ParametersRequiredForFullCreation, i_Parameters.Count - k_ParametersRequiredForFullCreation));
        }

        public override string ToString()
        {
            string truckData = string.Format(
@"{0}
Specific info:
Is refrigerating: {1}
Volume of cargo: {2}",
base.ToString(),
m_Refrigerating,
m_CargoVolume);

            return truckData;
        }
    }
}