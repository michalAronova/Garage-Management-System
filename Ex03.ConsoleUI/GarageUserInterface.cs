using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        public int GetAndReturnUserChoice(Array i_eNumArray, string[] i_eNumNamesArray, string i_OptionRequired)
        {
            string menu = "Please chose number of " + i_OptionRequired + " wanted:";

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(menu);
            printUserOptions(i_eNumNamesArray, i_eNumArray);

            return getUserChoice(i_eNumNamesArray.Length, i_OptionRequired);
        }

        private int getUserChoice(int i_MaxValue, string i_OptionRequired)
        {
            int choiceNumber;

            while (!int.TryParse(Console.ReadLine(), out choiceNumber)) { } //exeption?
            if (choiceNumber < 1 || choiceNumber > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_OptionRequired + " option invalid", i_MaxValue, 1); //refactor
            }

            return choiceNumber;
        }

        private void printUserOptions(string[] i_eNumNamesArray, Array i_eNumArray)
        {
            for (int i = 0; i < i_eNumArray.Length; i++)
            {
                Console.WriteLine("#{0} - {1}", (int)i_eNumArray.GetValue(i), insertSpacesToStr(i_eNumNamesArray[i]));
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

        //private T printAndGetChoice<T>(string[] i_Options, string i_RequiredChoice)
        //{
        //    T choice;
        //    return choice;
        //}

        private bool getBoolFromUser()
        {
            Console.WriteLine("Plase enter Y/N:");
            string input = Console.ReadLine();

            while (input != "Y" && input != "N")
            {
                Console.WriteLine("Wrong input! please try again");
                input = Console.ReadLine();
            }

            return input == "Y";
        }

        public float GetUnsigedFloatFromUser(string i_Message)
        {
            float input;
            Console.WriteLine("Please enter " + i_Message + ":");
            while (!float.TryParse(Console.ReadLine(), out input) || input < 0) //exeption?
            {
                Console.WriteLine("Wrong input! please try again");
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

            Console.WriteLine("Please enter licence number:");
            do
            {
                licenseNumber = Console.ReadLine();
                licenseNumberLength = licenseNumber.Length;
                validInput = (licenseNumberLength > 0) && (licenseNumberLength < 9);
                for(int i = 0; i < licenseNumberLength && validInput; i++)
                {
                    validInput = char.IsDigit(licenseNumber[i]);
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
    }
}