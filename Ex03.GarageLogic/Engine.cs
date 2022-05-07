using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private const float k_MinEnergy = 0;
        private readonly float r_MaxEnergy;
        private float m_currentEnergy = 0;

        public enum eEngineType
        {
            Electric,
            Fuel,
        }

        public Engine(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
        }

        internal void FillEnergy(float i_EnergyToFill)
        {
            if (getMaxFillPossible() < i_EnergyToFill)
            {
                throw new ValueOutOfRangeException(
                    string.Format("Request exceeds bound. Current amount of energy is {0}. Energy must be between", m_currentEnergy),
                    r_MaxEnergy,
                    k_MinEnergy);
            }

            m_currentEnergy += i_EnergyToFill;
        }

        private float getMaxFillPossible()
        {
            return r_MaxEnergy - m_currentEnergy;
        }

        public float MinEnergy
        {
            get
            {
                return k_MinEnergy;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_currentEnergy;
            }
            set
            {
                FillEnergy(value);
            }
        }

        public abstract eEngineType EngineType
        {
            get;
        }
    }
}