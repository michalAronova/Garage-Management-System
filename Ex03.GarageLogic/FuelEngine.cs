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

        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergy)
            : base(i_MaxEnergy)
        {
            r_FuelType = i_FuelType;
        }

        public void FillEnergy(eFuelType i_FuelType, float i_FuelAmount)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Incorrect fuel Type!");
            }

            base.fillEnergy(i_FuelAmount);
        }
    }
}