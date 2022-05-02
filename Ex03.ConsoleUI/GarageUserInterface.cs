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
        public eServiceOption GetAndReturnService()
        {
            //try cache?
            printServiceMenu();
            return getServiceChoice();
        }

        public int GetAndReturnFilterByStatus()
        {
            //try cache?
            printFilterMenu();
            return getStatusChoice();
            
        }

        private void printServiceMenu()
        {
            string welcomeMessage = 
@"Welcome to The Garage. 
Please choose the number of the service you wish to perform:";
            StringBuilder menuString = appendAllServices();

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(@"{0}
{1}", welcomeMessage, menuString);
        }

        private StringBuilder appendAllServices()
        {
            StringBuilder servicesToString = new StringBuilder();
            int serviceNum = 1;

            foreach(string serviceName in Enum.GetNames(typeof(eServiceOption)))
            {
                servicesToString.Append(string.Format("#{0} - ", serviceNum));
                serviceNum++;
                servicesToString.Append(insertSpacesToStr(serviceName));
                servicesToString.AppendLine();
            }

            return servicesToString;
        }

        private StringBuilder insertSpacesToStr(string i_StringToEdit)
        {
            StringBuilder EditedString = new StringBuilder(i_StringToEdit[0].ToString());

            for (int i = 1; i < i_StringToEdit.Length; i++)
            {
                if (char.IsUpper(i_StringToEdit[i]))
                {
                    EditedString.Append(' ');
                }

                EditedString.Append(i_StringToEdit[i]);
            }

            return EditedString;
        }

        private T printAndGetChoice<T>(string[] i_Options, string i_RequiredChoice)
        {
            T choice;
            return choice;
        }

        private bool performService(eServiceChoice i_ServiceChoice)
        private eServiceOption getServiceChoice() //refactor?
        {
            eServiceOption userServiceChoice;
            int choiceNumber;

            while (!int.TryParse(Console.ReadLine(), out choiceNumber)) { } //exeption
            if (Enum.IsDefined(typeof(eServiceOption), choiceNumber))
            {
                userServiceChoice = (eServiceOption)choiceNumber;
            }
            else
            {
                //throw exeption refactor
                throw new ValueOutOfRangeException("Service option invalid", Enum.GetValues(typeof(eServiceOption)).Length, 1);
            }

            return userServiceChoice;
        }

        private int getStatusChoice() //refactor?
        {
            Vehicle newVehicle = null;
            ///ask what type vehicle from the enum and what type engine from the enum
            /// createVehicle - UI
            List<string> ownerDetails = getOwnerDetails();
            GarageVehicle newGarageVehicle = new GarageVehicle(newVehicle, ownerDetails[0], ownerDetails[1]); //maybe not readable?
            /// ask for owner details -> call for GarageVehicle constructor to create
            /// enter to the garage - send the vehicle and its type
        }
            int choiceNumber;

        private Vehicle createVehicle(VehicleCreator.eVehicleType i_VehicleType, VehicleCreator.eEngineType i_EngineType)
        {
            ///params...
            ///
            ///
            /// here we call create vehicle - of vehicle creator
        }
            while (!int.TryParse(Console.ReadLine(), out choiceNumber)) { } //exeption
            if (!Enum.IsDefined(typeof(eServiceOption), choiceNumber) && choiceNumber != 0)
            {
                throw new ValueOutOfRangeException("status option invalid", Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)).Length, 0);
            }

        private List<string> getOwnerDetails()
        {
            //ask for owner name + owner phone, return as list
            return null;
        }
        private void printAllLicenseNumbers()
        {
            //here need to choose if to filter by status
            return choiceNumber;
        }

        //        if (!userInputIsNumber)
        //            {
        //                throw new FormatException("Error: your choice may only be an integer!");
        //    }
        //            else if(choiceNumber< 1 || choiceNumber> r_ServicesNames.Length)
        //            {
        //                errorMessage = string.Format("There is no available #{0} service. Please choose a number between", choiceNumber);
        //                throw new ValueOutOfRangeException(errorMessage, r_ServicesNames.Length, 1);
        //}

        private void printFilterMenu()
        {
            string filterMenuString = "Please choose filter wanted:";
            StringBuilder menu = appendAllFilters();

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(@"{0}
{1}", filterMenuString, menu);

        }

        private StringBuilder appendAllFilters()
        {
            StringBuilder vehicleStatusToString = new StringBuilder("#0 - All");
            int statusNum = 1;
            string vehicleStr = string.Format(" vehicles{0}", (Environment.NewLine));

            vehicleStatusToString.Append(vehicleStr);
            foreach (string statusName in Enum.GetNames(typeof(GarageVehicle.eVehicleStatus)))
            {
                vehicleStatusToString.Append(string.Format("#{0} - ", statusNum));
                statusNum++;
                vehicleStatusToString.Append(insertSpacesToStr(statusName));
                vehicleStatusToString.Append(vehicleStr);
            }

            return vehicleStatusToString;
        }

        public void PrintList(List<string> i_ListToPrint)
        {
            foreach(string stringInList in i_ListToPrint)
            {
                Console.WriteLine(stringInList);
            }
        }

        public void PrintExitMessage()
        {
            Console.WriteLine("Goodbye, hope to see you again soon :)");
        }
    }
}