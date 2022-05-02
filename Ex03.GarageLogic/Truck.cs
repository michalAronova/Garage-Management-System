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

        private bool m_Refrigerating;
        private float m_CargoVolume;

        private readonly List<Param> r_Parameters;

        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, k_TireNumber)
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTank);
            r_Parameters = new List<Param>(2);
            r_Parameters[0] = new Param("Is it carrying refrigerated content", "yes/no", typeof(bool));
            r_Parameters[1] = new Param("Cargo volume", "number", typeof(float));
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