namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InFix;

        public enum eVehicleStatus
        {
            InFix,
            Fixed,
            PaidFor
        }

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        public string LicenseNumber
        {
            get
            {
                return r_Vehicle.LicenseNumber;
            }
        }
    }
}