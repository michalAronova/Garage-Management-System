using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private const int k_MinAirPressure = 0; 
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;
        private readonly List<Param> r_Parameters;

        public Tire(float i_MaxAirPressure, string i_ManufacturerName)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            r_ManufacturerName = i_ManufacturerName;
            r_Parameters = new List<Param>(2);
            r_Parameters[0] = new Param("Manufacturer name", "name", typeof(string));
            r_Parameters[1] = new Param("Current air pressure", "number", typeof(float));
        }

        public void Inflate(float i_AirToInflateWith)
        {
            float newAirPressure = m_CurrentAirPressure + i_AirToInflateWith;
            string errorMessage;

            if(newAirPressure > r_MaxAirPressure)
            {
                errorMessage = string.Format("Request exceeds inflation bound. Current amount of air pressure is {0}. Air pressure must be between" , m_CurrentAirPressure);
                throw new ValueOutOfRangeException(errorMessage, r_MaxAirPressure, k_MinAirPressure);
            }

            m_CurrentAirPressure = newAirPressure;
        }
    }
}