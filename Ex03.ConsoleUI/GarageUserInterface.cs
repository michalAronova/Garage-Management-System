using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using System.Linq;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        private const string k_invalidInputMessage = "Invalid input! Please try again:";
        private Garage m_Garage = new Garage();
        private readonly VehicleCreator r_VehicleFactory = new VehicleCreator();

        public int GetUserChoice(Array i_EnumArray, string i_OptionRequired)
        {
            string menu = "Please chose number of " + i_OptionRequired + " wanted:";
            int userChoice;

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(menu);
            printUserOptions(i_EnumArray);
            userChoice = getUserChoice(i_EnumArray.Length, i_OptionRequired);
            
            return (int)i_EnumArray.GetValue(userChoice - 1);
        }

        private int getUserChoice(int i_MaxValue, string i_OptionRequired)
        {
            int choiceNumber;

            while (!int.TryParse(Console.ReadLine(), out choiceNumber) || choiceNumber < 1 || choiceNumber > i_MaxValue)
            {
                Console.WriteLine("Invalid {0} choice! Please try again", i_OptionRequired);
            }

            return choiceNumber;
        }

        private void printUserOptions(Array i_EnumArray)
        {
            object value;

            for (int i = 0; i < i_EnumArray.Length; i++)
            {
                value = i_EnumArray.GetValue(i);
                Console.WriteLine("#{0} - {1}", i + 1, insertSpacesToStr(value.ToString()));
            }
        }

        public bool AskUserIfToFilterByStatus()
        {
            Console.WriteLine("Please chose if you want to filter the cars shown:");

            return getBoolFromUser();
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

        private bool getBoolFromUser()
        {
            Console.WriteLine("Please enter Y/N:");
            string input = Console.ReadLine();

            while (input != "Y" && input != "N")
            {
                Console.WriteLine(k_invalidInputMessage);
                input = Console.ReadLine();
            }

            return input == "Y";
        }

        public float GetPositiveFloatFromUser(string i_Message)
        {
            float input;
            Console.WriteLine("Please enter " + i_Message + ":");
            while (!float.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.WriteLine(k_invalidInputMessage);
            }
            
            return input;
        }

        public void PrintList(List<string> i_ListToPrint)
        {
            foreach(string stringInList in i_ListToPrint)
            {
                Console.WriteLine(stringInList);
            }
        }

        public string GetValidLicenseNumber()
        {
            string licenseNumber = null;
            bool validInput = true;
            int licenseNumberLength = 0;

            Console.WriteLine("Please enter license number:");
            do
            {
                licenseNumber = Console.ReadLine();
                licenseNumberLength = licenseNumber.Length;
                validInput = (licenseNumberLength > 0) && (licenseNumberLength < 9);
                for(int i = 0; i < licenseNumberLength && validInput; i++)
                {
                    validInput = char.IsDigit(licenseNumber[i]);
                }

                if (!validInput)
                {
                    Console.WriteLine(k_invalidInputMessage);
                }
            } while (!validInput);

            return licenseNumber;
        }

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to The Garage :)");
            System.Threading.Thread.Sleep(3000);
        }

        public void PrintExitMessage()
        {
            Console.WriteLine("Goodbye, hope to see you again soon :)");
        }

        public void PrintResult(string result , bool i_VehicleFound, string i_LicenseNumber)
        {
            string message = i_VehicleFound ? result : "License number " + i_LicenseNumber + " Not found!";

            Console.WriteLine(message);
            System.Threading.Thread.Sleep(3000);
        }

        public void StartSystem()
        {
            int serviceChoice;

            PrintWelcomeMessage();
            do
            {
                serviceChoice = GetUserChoice(Enum.GetValues(typeof(eServiceOption)), "service");
                runService((eServiceOption)serviceChoice);
            } while (serviceChoice != (int)eServiceOption.ExitSystem);
        }

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
                    PrintExitMessage();
                    break;
            }
        }

        private void enterNewVehicle()
        {
            string licenseNumber = GetValidLicenseNumber();
            bool vehicleFound = m_Garage.ChangeVehicleStatusByLicenseNumber(licenseNumber, GarageVehicle.eVehicleStatus.InFix);

            if (!vehicleFound)
            {
                ///enter new vehicle
                /// createVehicleAndEnterParams();
            }
            else
            {
                PrintResult("Vehicle status changed successfully", vehicleFound, licenseNumber);
            }
        }

        /// <summary>
        /// createVehicleAndEnterParams();
        /// 1. ask for type
        /// 2. create from creator and get params in output parameter
        /// 3. ask for above params (do parsing)
        /// 4. fill params(receives list/array of objects) (need to have such method in vehicles)
        ///                                          --> 
        /// 5. return vehicle
        /// </summary>

        private void showAllLicenseNumbers()
        {
            bool toFilter = AskUserIfToFilterByStatus();
            int? statusToFilterBy = null;
            List<string> licenseNumbersToPrintList = new List<string>();
            string filterStr = null;

            if (!toFilter)
            {
                licenseNumbersToPrintList = m_Garage.GetAllLicenseNumbers();
                filterStr = "All";
            }
            else
            {
                statusToFilterBy = GetUserChoice(Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)), "status");
                licenseNumbersToPrintList = m_Garage.GetAllLicenseNumbersByStatus((GarageVehicle.eVehicleStatus)statusToFilterBy);
                filterStr = Enum.GetName(typeof(GarageVehicle.eVehicleStatus), (GarageVehicle.eVehicleStatus)statusToFilterBy);
                filterStr = insertSpacesToStr(filterStr).ToString();
            }

            Console.WriteLine("{0} vehicles License numbers:", filterStr);
            PrintList(licenseNumbersToPrintList);
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = GetValidLicenseNumber();
            int selectedStatus = GetUserChoice(Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)), "status");
            bool vehicleFound = m_Garage.ChangeVehicleStatusByLicenseNumber(licenseNumber, (GarageVehicle.eVehicleStatus)selectedStatus);

            PrintResult("Vehicle status changed successfully", vehicleFound, licenseNumber);
        }

        private void fillTiresAirToMax()
        {
            string licenseNumber = GetValidLicenseNumber();
            bool vehicleFound = m_Garage.FillTiresAirToMaxByLicenseNumber(licenseNumber);

            PrintResult("Vehicle tires filled successfully", vehicleFound, licenseNumber);
        }

        private void refuelVehicleTank()
        {
            string licenseNumber = GetValidLicenseNumber();
            FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)GetUserChoice(Enum.GetValues(typeof(FuelEngine.eFuelType)), "fuel type");
            float amountToFuel = GetPositiveFloatFromUser("amount to fuel");
            bool vehicleFound = m_Garage.RefuelVehicleTankByLicenseNumber(licenseNumber, fuelType, amountToFuel);
            //exeption from logic
            PrintResult("Vehicle tank filled successfully", vehicleFound, licenseNumber);
        }

        private void chargeVehicle()
        {
            string licenseNumber = GetValidLicenseNumber();
            float amountToCharge = GetPositiveFloatFromUser("amount to charge");
            bool vehicleFound = m_Garage.ChargeVehicleByLicenseNumber(licenseNumber, amountToCharge);
            //exeption from logic
            PrintResult("Vehicle charged successfully", vehicleFound, licenseNumber);
        }

        private void showVehicleFullDetails()
        {
            string licenseNumber = GetValidLicenseNumber();

            m_Garage.GetVehicleFullDetailsByLicenseNumber(licenseNumber);
            //continue..
        }
    }
}