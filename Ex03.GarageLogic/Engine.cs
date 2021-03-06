namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private const float k_MinEnergy = 0;
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy = 0;

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
                    string.Format("Request exceeds bound. Current amount of energy is {0}. Energy must be between {1} and {2}",
                    m_CurrentEnergy, k_MinEnergy, r_MaxEnergy), r_MaxEnergy, k_MinEnergy);
            }

            m_CurrentEnergy += i_EnergyToFill;
        }

        internal void SetEnergy(float i_EnergyToSet)
        {
            if (r_MaxEnergy < i_EnergyToSet)
            {
                throw new ValueOutOfRangeException(
                    string.Format("Request exceeds bound. Current amount of energy is {0}. Energy must be between {1} and {2}",
                    m_CurrentEnergy, k_MinEnergy, r_MaxEnergy), r_MaxEnergy, k_MinEnergy);
            }

            m_CurrentEnergy = i_EnergyToSet;
        }

        private float getMaxFillPossible()
        {
            return r_MaxEnergy - m_CurrentEnergy;
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
                return m_CurrentEnergy;
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