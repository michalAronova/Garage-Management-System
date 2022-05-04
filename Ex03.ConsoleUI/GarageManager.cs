using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private Garage m_Garage = new Garage();
        private readonly GarageUserInterface m_UserInterface = new GarageUserInterface();

        public void StartSystem()
        {
            int serviceChoice;

            m_UserInterface.PrintWelcomeMessage();
            do
            {
                serviceChoice = m_UserInterface.GetAndReturnUserChoice(Enum.GetValues(typeof(eServiceOption)), Enum.GetNames(typeof(eServiceOption)), "service");
                runService((eServiceOption)serviceChoice);
            } while (serviceChoice != (int)eServiceOption.ExitSystem);
        }

        //try
        //{
        //    serviceChoice = m_UserInterface.GetServiceChoice();
        //}
        //catch (ValueOutOfRangeException exeption)
        //{
        //    serviceChoice = m_UserInterface.GetServiceChoice();
        //}

        private void runService(eServiceOption i_ServiceChoice)
        {
            switch (i_ServiceChoice)
            {
                case eServiceOption.EnterNewVehicle:
                    enterNewVehicle();
                    break;
                case eServiceOption.ShowAllLicenseNumbers:
                    showAllLicenseNumbers();
                    break;
                case eServiceOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eServiceOption.FillTiresAirToMax:
                    fillTiresAirToMax();
                    break;
                case eServiceOption.RefuelVehicleTank:
                    refuelVehicleTank();
                    break;
                case eServiceOption.ChargeVehicle:
                    chargeVehicle();
                    break;
                case eServiceOption.ShowVehicleFullDetails:
                    showVehicleFullDetails();
                    break;
                case eServiceOption.ExitSystem:
                    m_UserInterface.PrintExitMessage();
                    break;
            }
        }

        private void enterNewVehicle()
        {
            string licenseNumber = m_UserInterface.GetValidLicenseNumber();
            bool vehicleFound = m_Garage.ChangeVehicleStatusByLicenseNumber(licenseNumber, GarageVehicle.eVehicleStatus.InFix);

            if (!vehicleFound)
            {
                //enter new vehicle
            }
            else
            {
                m_UserInterface.PrintResult("Vehicle status changed successfully", vehicleFound, licenseNumber);
            }
        }

        private void showAllLicenseNumbers()
        {
            bool toFilter = m_UserInterface.AskUserIfToFilterByStatus();
            int? filterWanted = null;
            List<string> licenseNumbersToPrintList = new List<string>();

            if (!toFilter)
            {
                licenseNumbersToPrintList = m_Garage.GetAllLicenseNumbers();
            }
            else
            {
                filterWanted = m_UserInterface.GetAndReturnUserChoice(Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)),
                    Enum.GetNames(typeof(GarageVehicle.eVehicleStatus)), "status");
                licenseNumbersToPrintList = m_Garage.GetAllLicenseNumbersByStatus((GarageVehicle.eVehicleStatus)filterWanted);
            }
            //message ?
            m_UserInterface.PrintList(licenseNumbersToPrintList);
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = m_UserInterface.GetValidLicenseNumber();
            int selectedStatus = m_UserInterface.GetAndReturnUserChoice(Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)),
                    Enum.GetNames(typeof(GarageVehicle.eVehicleStatus)), "status");
            bool vehicleFound = m_Garage.ChangeVehicleStatusByLicenseNumber(licenseNumber, (GarageVehicle.eVehicleStatus)selectedStatus);

            m_UserInterface.PrintResult("Vehicle status changed successfully", vehicleFound, licenseNumber);
        }

        private void fillTiresAirToMax()
        {
            string licenseNumber = m_UserInterface.GetValidLicenseNumber();
            bool vehicleFound = m_Garage.FillTiresAirToMaxByLicenseNumber(licenseNumber);

            m_UserInterface.PrintResult("Vehicle tires filled successfully", vehicleFound, licenseNumber);
        }

        private void refuelVehicleTank()
        {
            string licenseNumber = m_UserInterface.GetValidLicenseNumber();
            FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)m_UserInterface.GetAndReturnUserChoice
                (Enum.GetValues(typeof(FuelEngine.eFuelType)),
                Enum.GetNames(typeof(FuelEngine.eFuelType)), "fuel type");
            float amountToFuel = m_UserInterface.GetUnsigedFloatFromUser("amount to fuel");
            bool vehicleFound = m_Garage.RefuelVehicleTankByLicenseNumber(licenseNumber, fuelType, amountToFuel);
            //exeption
            m_UserInterface.PrintResult("Vehicle tank filled successfully", vehicleFound, licenseNumber);
        }

        private void chargeVehicle()
        {
            string licenseNumber = m_UserInterface.GetValidLicenseNumber();
            float amountToCharge = m_UserInterface.GetUnsigedFloatFromUser("amount to charge");
            bool vehicleFound = m_Garage.ChargeVehicleByLicenseNumber(licenseNumber, amountToCharge);
            //exeption
            m_UserInterface.PrintResult("Vehicle charged successfully", vehicleFound, licenseNumber);
        }

        private void showVehicleFullDetails()
        {
            string licenseNumber = m_UserInterface.GetValidLicenseNumber();

            m_Garage.GetVehicleFullDetailsByLicenseNumber(licenseNumber);
            //continue..
        }
    }
}