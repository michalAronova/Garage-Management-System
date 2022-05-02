namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InFix;

        public enum eVehicleStatus
        {
            InFix = 1,
            Fixed,
            PaidFor
        }

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerNumber)
        {
            m_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerNumber = i_OwnerNumber;
        }
    }
}