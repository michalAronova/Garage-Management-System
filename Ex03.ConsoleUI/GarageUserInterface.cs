using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;
using System.Linq;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        private const string k_InvalidInputMessage = "Invalid input! Please try again:";
        private readonly Garage r_Garage = new Garage();
        private readonly VehicleCreator r_VehicleCreator = new VehicleCreator();

        private int getUserChoice(Array i_EnumArray, string i_OptionRequired)
        {
            string menu = "Please choose number of " + i_OptionRequired + " wanted:";
            int userChoice;

            Console.Clear();
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

        private bool askUserIfToFilterByStatus()
        {
            Console.WriteLine("Please choose if you want to filter the cars shown:");

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
            input = input.ToUpper();

            while (input != "Y" && input != "N")
            {
                Console.WriteLine(k_InvalidInputMessage);
                input = Console.ReadLine();
            }

            return input == "Y";
        }

        private float getUnsignedFloatFromUser(string i_Message)
        {
            float input;

            Console.WriteLine("Please enter " + i_Message + ":");
            while (!float.TryParse(Console.ReadLine(), out input) || input < 0)
            {
                Console.WriteLine(k_InvalidInputMessage);
            }
            
            return input;
        }

        private void printList(List<string> i_ListToPrint)
        {
            foreach(string stringInList in i_ListToPrint)
            {
                Console.WriteLine(stringInList);
            }
        }

        private string getValidLicenseNumber()
        {
            string licenseNumber = null;
            bool validInput = true;
            int licenseNumberLength = 0;

            Console.WriteLine("Please enter license number (1 to 8 numbers):");
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
                    Console.WriteLine(k_InvalidInputMessage);
                }
            } while (!validInput);

            return licenseNumber;
        }

        private void printWelcomeMessage()
        {
            Console.WriteLine("Welcome to The Garage :)");
            System.Threading.Thread.Sleep(3000);
        }

        private void printExitMessage()
        {
            Console.WriteLine("Goodbye, hope to see you again soon :)");
        }

        private void printResult(string result , bool i_VehicleFound, string i_LicenseNumber)
        {
            string message = i_VehicleFound ? result : "License number " + i_LicenseNumber + " Not found!";

            Console.WriteLine(message);
            System.Threading.Thread.Sleep(3000);
        }

        public void StartSystem()
        {
            int? serviceChoice = null;

            printWelcomeMessage();
            do
            {
                try
                {
                    serviceChoice = getUserChoice(Enum.GetValues(typeof(eServiceOption)), "service");
                    runService((eServiceOption)serviceChoice);
                    Console.WriteLine("Service completed :)");
                    if((eServiceOption)serviceChoice != eServiceOption.ExitSystem)
                    {
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message);
                }
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
                    printExitMessage();
                    break;
            }
        }

        private void enterNewVehicle()
        {
            string licenseNumber = getValidLicenseNumber();
            bool vehicleFound = r_Garage.ChangeVehicleStatusByLicenseNumber(licenseNumber, GarageVehicle.eVehicleStatus.InFix);
            int selectedVehicle;

            if (!vehicleFound)
            {
                selectedVehicle = getUserChoice(Enum.GetValues(typeof(VehicleCreator.eVehicleType)), "vehicle type");
                createAndEnterNewGarageVehicle(licenseNumber, (VehicleCreator.eVehicleType)selectedVehicle);
            }
            else
            {
                printResult("Vehicle status changed successfully", vehicleFound, licenseNumber);
            }
        }
        private void createAndEnterNewGarageVehicle(string i_LicenseNumber, VehicleCreator.eVehicleType i_VehicleType)
        {
            Vehicle newVehicle = createVehicleAndEnterParams(i_LicenseNumber, i_VehicleType);
            GarageVehicle newGarageVehicle = null;
            string ownerName = null, ownerPhoneNumber = null;

            getOwnerDetails(out ownerName, out ownerPhoneNumber);
            newGarageVehicle = new GarageVehicle(newVehicle, ownerName, ownerPhoneNumber);
            r_Garage.EnterNewVehicle(newGarageVehicle);
        }

        private Vehicle createVehicleAndEnterParams(string i_LicenseNumber, VehicleCreator.eVehicleType i_VehicleType)
        {
            List<Param> requiredParams;
            Vehicle newVehicle = r_VehicleCreator.CreateVehicle(i_LicenseNumber, i_VehicleType, out requiredParams);
            List<Object> enteredParams = getParamsFromUser(requiredParams);

            newVehicle.FillParams(enteredParams.ToList());

            return newVehicle;
        }

        private List<Object> getParamsFromUser(List<Param> i_RequiredParams)
        {
            String curr = null;
            bool paramIsNotValid = true;
            List<Object> parameters = new List<Object>();
            Type type = null;
            MethodInfo parseMethod = null;

            Console.WriteLine("Please enter the following info:");
            foreach(Param parameter in i_RequiredParams)
            {
                Console.WriteLine(string.Format("{0} ({1})", parameter.Name, parameter.Requirements));
                curr = Console.ReadLine();
                type = parameter.Type;
                parseMethod = parameter.Type == typeof(string) ? null : type.GetMethod("Parse", new Type[] { typeof(string) });
                if (parseMethod != null) {
                    while (paramIsNotValid)
                    {
                        try
                        {
                            parameters.Add(parseMethod.Invoke(null, new Object[] { curr }));
                            paramIsNotValid = !true;
                        }
                        catch (TargetInvocationException i_TargetInvocationException)
                        {
                            Console.WriteLine("Invalid {0}. Please try again", parameter.Name);
                            curr = Console.ReadLine();
                        }
                    }

                    paramIsNotValid = true;
                }
                else
                {
                    parameters.Add(curr);
                }
            }

            return parameters;
        }

        private void getOwnerDetails(out string i_OwnerName, out string i_OwnerPhoneNumber)
        {
            Console.WriteLine("Please enter owner's name:");
            i_OwnerName = Console.ReadLine();
            while (!i_OwnerName.All(isLetterOrWhiteSpace))
            {
                Console.WriteLine(k_InvalidInputMessage);
                i_OwnerName = Console.ReadLine();
            }

            Console.WriteLine("Please enter owner's phone number:");
            i_OwnerPhoneNumber = Console.ReadLine();
            while (!i_OwnerPhoneNumber.All(char.IsDigit))
            {
                Console.WriteLine(k_InvalidInputMessage);
                i_OwnerPhoneNumber = Console.ReadLine();
            }
        }

        private bool isLetterOrWhiteSpace(char i_CharToCheck)
        {
            return (char.IsLetter(i_CharToCheck)) || (char.IsWhiteSpace(i_CharToCheck));
        }

        private void showAllLicenseNumbers()
        {
            bool toFilter = askUserIfToFilterByStatus();
            int? statusToFilterBy = null;
            List<string> licenseNumbersToPrintList = new List<string>();
            string filterStr = null;

            if (!toFilter)
            {
                licenseNumbersToPrintList = r_Garage.GetAllLicenseNumbers();
                filterStr = "All";
            }
            else
            {
                statusToFilterBy = getUserChoice(Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)), "status");
                licenseNumbersToPrintList = r_Garage.GetAllLicenseNumbersByStatus((GarageVehicle.eVehicleStatus)statusToFilterBy);
                filterStr = Enum.GetName(typeof(GarageVehicle.eVehicleStatus), (GarageVehicle.eVehicleStatus)statusToFilterBy);
                filterStr = insertSpacesToStr(filterStr).ToString();
            }

            Console.WriteLine("{0} vehicles License numbers:", filterStr);
            printList(licenseNumbersToPrintList);
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = getValidLicenseNumber();
            int selectedStatus = getUserChoice(Enum.GetValues(typeof(GarageVehicle.eVehicleStatus)), "status");
            bool vehicleFound = r_Garage.ChangeVehicleStatusByLicenseNumber(licenseNumber, (GarageVehicle.eVehicleStatus)selectedStatus);

            printResult("Vehicle status changed successfully", vehicleFound, licenseNumber);
        }

        private void fillTiresAirToMax()
        {
            string licenseNumber = getValidLicenseNumber();
            bool vehicleFound = r_Garage.FillTiresAirToMaxByLicenseNumber(licenseNumber);

            printResult("Vehicle tires filled successfully", vehicleFound, licenseNumber);
        }

        private void refuelVehicleTank()
        {
            string licenseNumber = getValidLicenseNumber();
            FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)getUserChoice(Enum.GetValues(typeof(FuelEngine.eFuelType)), "fuel type");
            float amountToFuel = getUnsignedFloatFromUser("amount to fuel");
            bool vehicleFound = r_Garage.RefuelVehicleTankByLicenseNumber(licenseNumber, fuelType, amountToFuel);

            printResult("Vehicle tank filled successfully", vehicleFound, licenseNumber);
        }

        private void chargeVehicle()
        {
            string licenseNumber = getValidLicenseNumber();
            float amountToCharge = getUnsignedFloatFromUser("amount to charge");
            bool vehicleFound = r_Garage.ChargeVehicleByLicenseNumber(licenseNumber, amountToCharge);

            printResult("Vehicle charged successfully", vehicleFound, licenseNumber);
        }

        private void showVehicleFullDetails()
        {
            string licenseNumber = getValidLicenseNumber();

            Console.WriteLine(r_Garage.GetVehicleFullDetailsByLicenseNumber(licenseNumber));
        }
    }
}