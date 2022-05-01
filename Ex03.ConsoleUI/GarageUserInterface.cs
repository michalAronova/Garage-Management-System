using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        private readonly string[] r_ServicesNames = ///get from logic so its modular
            {
                "Enter new vehicle to the garage",
                "Show all license numbers in the garage",
                "Change a vehicle's status", "Fill a vehicle's tires to maximum",
                "Refuel a vehicle", "Charge a vehicle", 
                "Show a vehicle's full details", "Exit the system"
            };
        private Garage m_Garage = new Garage();
        private readonly VehicleCreator r_VehicleCreator = new VehicleCreator();
        public void StartSystem()
        {
            bool runSystem = true;
            eServiceChoice serviceChoice;

            while (runSystem)
            {
                //clear screen//
                printMenu();
                serviceChoice = getServiceChoice();
                runSystem = performService(serviceChoice);
            }
        }

        private void printMenu()
        {
            string welcomeMessage = 
@"Welcome to The Garage. 
Please choose the number of the service you wish to perform:";
            StringBuilder menu = new StringBuilder(welcomeMessage);
            appendAllServices(menu);
            Console.WriteLine(menu.ToString());
        }

        private void appendAllServices(StringBuilder i_AppendTo)
        {
            int serviceNum = 1;
            foreach(string serviceName in r_ServicesNames)
            {
                i_AppendTo.Append(string.Format("#{0} - ", serviceNum));
                serviceNum++;
                i_AppendTo.Append(serviceName);
                i_AppendTo.AppendLine();
            }
        }

        private eServiceChoice getServiceChoice()
        {
            eServiceChoice userServiceChoice = eServiceChoice.invalid; ///////////////<<<<maybe not okay to give this "default"
            string choiceString;
            int choiceNumber;
            bool userInputIsNumber;
            string errorMessage;
            choiceString = Console.ReadLine();
            userInputIsNumber = int.TryParse(choiceString, out choiceNumber);
            if (!userInputIsNumber)
            {
                throw new FormatException("Error: your choice may only be an integer!");
            }
            else if(choiceNumber < 1 || choiceNumber > r_ServicesNames.Length)
            {
                errorMessage = string.Format("There is no available #{0} service. Please choose a number between", choiceNumber);
                throw new ValueOutOfRangeException(errorMessage, r_ServicesNames.Length, 1);
            }

            switch (choiceNumber)
            {
                case 1:
                    userServiceChoice = eServiceChoice.enterNewVehicle;
                    break;
                case 2:
                    userServiceChoice = eServiceChoice.showAllLicenseNumbers;
                    break;
                case 3:
                    userServiceChoice = eServiceChoice.changeVehicleStatus;
                    break;
                case 4:
                    userServiceChoice = eServiceChoice.fillTiresAirToMax;
                    break;
                case 5:
                    userServiceChoice = eServiceChoice.refuelVehicleTank;
                    break;
                case 6:
                    userServiceChoice = eServiceChoice.chargeVehicle;
                    break;
                case 7:
                    userServiceChoice = eServiceChoice.changeVehicleStatus;
                    break;
                case 8:
                    userServiceChoice = eServiceChoice.exitSystem;
                    break;

            }
            return userServiceChoice;
        }

        private T printAndGetChoice<T>(string[] i_Options, string i_RequiredChoice)
        {
            T choice;
            return choice;
        }

        private bool performService(eServiceChoice i_ServiceChoice)
        {
            bool runSystem = true;
            switch (i_ServiceChoice)
            {
                case eServiceChoice.enterNewVehicle:
                    enterNewVehicle();
                    break;
                case eServiceChoice.showAllLicenseNumbers:
                    printAllLicenseNumbers();
                    break;
                case eServiceChoice.changeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eServiceChoice.fillTiresAirToMax:
                    fillTiresAirToMax();
                    break;
                case eServiceChoice.refuelVehicleTank:
                    refuelVehicleTank();
                    break;
                case eServiceChoice.chargeVehicle:
                    chargeVehicle();
                    break;
                case eServiceChoice.showVehicleFullDetails:
                    printVehicleFullDetails();
                    break;
                case eServiceChoice.exitSystem:
                    Console.WriteLine("Goodbye, hope to see you again soon :)");
                    runSystem = !runSystem;
                    break;
            }
            return runSystem;
        }

        private void enterNewVehicle()
        {
            Vehicle newVehicle = null;
            ///ask what type vehicle from the enum and what type engine from the enum
            /// createVehicle - UI
            List<string> ownerDetails = getOwnerDetails();
            GarageVehicle newGarageVehicle = new GarageVehicle(newVehicle, ownerDetails[0], ownerDetails[1]); //maybe not readable?
            /// ask for owner details -> call for GarageVehicle constructor to create
            /// enter to the garage - send the vehicle and its type
        }

        private Vehicle createVehicle(VehicleCreator.eVehicleType i_VehicleType, VehicleCreator.eEngineType i_EngineType)
        {
            ///params...
            ///
            ///
            /// here we call create vehicle - of vehicle creator
        }

        private List<string> getOwnerDetails()
        {
            //ask for owner name + owner phone, return as list
            return null;
        }
        private void printAllLicenseNumbers()
        {
            //here need to choose if to filter by status
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