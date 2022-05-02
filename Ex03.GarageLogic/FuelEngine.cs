using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuel)
            : base(i_MaxFuel)
        {
            r_FuelType = i_FuelType;
        }

        public void FillEnergy(float i_EnergyToFill, eFuelType i_FuelType)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format("Incorrect fuel type, required: {0}", r_FuelType));
            }
            base.fillEnergy(i_EnergyToFill);
        }
        
    }
}