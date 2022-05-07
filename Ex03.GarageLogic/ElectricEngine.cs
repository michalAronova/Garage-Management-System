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

        public override string ToString()
        {
            string electricityData = string.Format(
@"Battery time left in hours: {0}
Max battery time in hours: {1}", base.CurrentEnergy, base.MaxEnergy);

            return electricityData;
        }
    }
}