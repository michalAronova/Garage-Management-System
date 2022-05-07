using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private const int k_MinAirPressure = 0; 
        private string m_ManufacturerName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;

        public Tire(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
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

        public void InflateToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MinAirPressure
        {
            get
            {
                return k_MinAirPressure;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public override string ToString()
        {
            string tireData = string.Format(
@"Manufacturer name: {0}
Current air pressure: {1}
Max air pressure: {2}",
m_ManufacturerName,
m_CurrentAirPressure,
r_MaxAirPressure);

            return tireData;
        }
    }
}