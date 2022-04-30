using System;
using System.Collections.ObjectModel;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private const int k_MinAirPressure = 0; 
        private readonly float r_MaxAirPressure;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;

        public void Inflate(float i_AirToInflateWith)
        {
            float newAirPressure = m_CurrentAirPressure + i_AirToInflateWith;
            string errorMessage;

            if(i_AirToInflateWith < 0)
            {
                throw new ArgumentException("Cannot inflate negative amount");
            }
            else if(newAirPressure > r_MaxAirPressure)
            {
                errorMessage = string.Format("Current amount of air pressure is {0}. Air pressure must be between" , m_CurrentAirPressure);
                throw new ValueOutOfRangeException(errorMessage, r_MaxAirPressure, k_MinAirPressure);
            }
        }
    }
}