namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy) : base(i_MaxEnergy) { }
        public virtual void FillEnergy(float i_EnergyToFill)
        {
            base.fillEnergy(i_EnergyToFill);
        }
    }
}