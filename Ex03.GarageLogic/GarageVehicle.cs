using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InFix;

        //below is possible solution to the get all details in garage
        public struct DetailsForm //a lot of code duplication :(
        {
            private string m_OwnerName;
            private string m_OwnerPhoneNumber;
            private eVehicleStatus m_VehicleStatus;
            //private VehicleDetails m_VehicleDetails;
        }

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

        public List<string> GetFullDetails() //////////?????
        {
            List<string> fullDetails = new List<string>();
            fullDetails.Add(string.Format("Owner name: {0}", r_OwnerName));
            fullDetails.Add(string.Format("Owner phone number: {0}", r_OwnerPhoneNumber));
            fullDetails.AddRange(r_Vehicle.GetDetails());
            return fullDetails;
        }

        public string LicenseNumber
        {
            get
            {
                return r_Vehicle.LicenseNumber;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
    }
}