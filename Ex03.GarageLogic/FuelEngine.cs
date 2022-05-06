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
                throw new ArgumentException("Incorrect fuel Type!");
            }

            base.FillEnergy(i_FuelAmount);
        }
        public override List<string> GetDetails() //////////?????
        {
            List<string> details = new List<string>();
            details.Add(string.Format("Current fuel amount: {0}", base.CurrentEnergy));
            details.Add(r_FuelType.ToString());
            return details;
        }

        public override eEngineType EngineType
        {
            get
            {
                return eEngineType.Fuel;
            }
        }
    }
}