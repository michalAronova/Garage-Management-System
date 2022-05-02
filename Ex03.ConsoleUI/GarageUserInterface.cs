using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
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
            int choiceNumber;

            while (!int.TryParse(Console.ReadLine(), out choiceNumber)) { } //exeption
            if (!Enum.IsDefined(typeof(eServiceOption), choiceNumber) && choiceNumber != 0)
            {
                throw new ValueOutOfRangeException("status option invalid", Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)).Length, 0);
            }

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