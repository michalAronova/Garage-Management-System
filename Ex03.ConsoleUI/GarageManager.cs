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
            eServiceOption serviceChoice;

            do
            {
                serviceChoice = m_UserInterface.GetAndReturnService();
                runService(serviceChoice);
            } while (serviceChoice != eServiceOption.ExitSystem);
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
                    //enterNewVehicle();
                    break;
                case eServiceOption.ShowAllLicenseNumbers:
                    showAllLicenseNumbers();
                    break;
                case eServiceOption.ChangeVehicleStatus:
                    //changeVehicleStatus();
                    break;
                case eServiceOption.FillTiresAirToMax:
                    //fillTiresAirToMax();
                    break;
                case eServiceOption.RefuelVehicleTank:
                    //refuelVehicleTank();
                    break;
                case eServiceOption.ChargeVehicle:
                    //chargeVehicle();
                    break;
                case eServiceOption.ShowVehicleFullDetails:
                    //printVehicleFullDetails();
                    break;
                case eServiceOption.ExitSystem:
                    m_UserInterface.PrintExitMessage();
                    break;
            }
        }

        private void enterNewVehicle()
        {

        }

        private void showAllLicenseNumbers()
        {
            int filterWanted = m_UserInterface.GetAndReturnFilterByStatus(); //maybe generic func gets int between min max
            List<string> licenseNumbersToPrintList = new List<string>();

            if (filterWanted == 0)
            {
                licenseNumbersToPrintList = m_Garage.GetAllLicenseNumbers();
            }
            else
            {
                licenseNumbersToPrintList = m_Garage.GetAllLicenseNumbersByStatus((GarageVehicle.eVehicleStatus)filterWanted);
            }
            //message ?
            m_UserInterface.PrintList(licenseNumbersToPrintList);
        }

        private void changeVehicleStatus()
        {

        }

        private void fillTiresAirToMax()
        {

        }

        private void refuelVehicleTank()
        {

        }

        private void chargeVehicle()
        {

        }

        private void printVehicleFullDetails()
        {

        }
    }
}