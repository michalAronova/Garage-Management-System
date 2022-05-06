using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy) : base(i_MaxEnergy) { }

        public void Charge(float i_MinutesToCharge)
        {
            base.FillEnergy(i_MinutesToCharge);
        }

        public override eEngineType EngineType
        {
            get
            {
                return eEngineType.Electric;
            }
        }

        public override List<string> GetDetails() //////////?????
        {
            List<string> details = new List<string>();
            details.Add(string.Format("Current charge: {0}", base.CurrentEnergy));
            return details;
        }
    }
}