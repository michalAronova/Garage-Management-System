using System;
using System.Collections.Generic;

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

        public void Refuel(eFuelType i_FuelType, float i_FuelAmount)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format("Incorrect fuel Type! {0} needed.", r_FuelType.ToString()));
            }

            base.FillEnergy(i_FuelAmount);
        }

        public override eEngineType EngineType
        {
            get
            {
                return eEngineType.Fuel;
            }
        }

        public override string ToString()
        {
            string fuelData = string.Format(
@"Fuel Type: {0}
Current amount of fuel: {1}
Max amount of fuel: {2}", r_FuelType.ToString(), base.CurrentEnergy, base.MaxEnergy);

            return fuelData;
        }
    }
}