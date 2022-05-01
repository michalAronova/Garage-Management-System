using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_EnergyLeft;
        private readonly List<Tire> r_Tires;
        private Engine m_Engine;
        private readonly Param[] r_Parameters;

        /// <summary>
        /// vehicle get params needed will return a vector with the params we need
        /// "license number"
        /// method - that gets a string and checks that it matches the needs (if not returns exception)
        /// string - "license needs to be 8 digits"
        /// </summary>
        public Vehicle()
        {
            
        }
        public virtual List<Param> getParamsRequired()
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}