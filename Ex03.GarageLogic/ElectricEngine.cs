namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy) : base(i_MaxEnergy) { }

        public void FillEnergy(float i_TimeToCharge)
        {
            base.fillEnergy(i_TimeToCharge);
        }
    }
}