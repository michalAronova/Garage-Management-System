using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private const float k_MinEnergy = 0;
        private float r_MaxEnergy; //readonly
        private float m_currentEnergy = 0;

        public enum eEngineType
        {
            Electric,
            Fuel,
        }

        public Engine() //temp
        {
        }

        public Engine(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
        }

        internal void FillEnergy(float i_EnergyToFill) //using this in the vehicle fillParams which
                                                       //is the only reason its internal and not private...
        {
            if(getMaxFillPossible() < i_EnergyToFill)
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
            ///set
            ///{
            ///    FillEnergy(value); ////??????? should this be like this?
            ///}
        }
        public abstract eEngineType EngineType
        {
            get;
        }

        public abstract List<string> GetDetails();
    }
}