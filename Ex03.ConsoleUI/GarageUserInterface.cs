using System;
using System.Runtime.InteropServices;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUserInterface
    {
        private Garage m_Garage;
        public void StartSystem()
        {
            m_Garage = new Garage();
            bool runSystem = true;
            eActionChoice actionChoice;

            while (runSystem)
            {
                //clear screen//
                printMenu();
                actionChoice = getActionChoice();
                runSystem = performAction(actionChoice);
            }
        }

        private void printMenu()
        {

        }

        private eActionChoice getActionChoice()
        {
            eActionChoice userActionChoice = eActionChoice.invalid; ///////////////<<<<maybe not okay to give this "default"
            string choiceString;
            int choiceNumber;
            bool userInputIsNumber;
            choiceString = Console.ReadLine();
            userInputIsNumber = int.TryParse(choiceString, out choiceNumber);
            if (!userInputIsNumber || choiceNumber < 1 || choiceNumber > 8)
            {
                //??? need to see video to see how to throw exception here :)
            }

            switch (choiceNumber)
            {
                case 1:
                    userActionChoice = eActionChoice.enterNewVehicle;
                    break;
                case 2:
                    userActionChoice = eActionChoice.showAllLicenseNumbers;
                    break;
                case 3:
                    userActionChoice = eActionChoice.changeVehicleStatus;
                    break;
                case 4:
                    userActionChoice = eActionChoice.fillTiresAirToMax;
                    break;
                case 5:
                    userActionChoice = eActionChoice.refuelVehicleTank;
                    break;
                case 6:
                    userActionChoice = eActionChoice.chargeVehicle;
                    break;
                case 7:
                    userActionChoice = eActionChoice.changeVehicleStatus;
                    break;
                case 8:
                    userActionChoice = eActionChoice.exitSystem;
                    break;

            }
            return userActionChoice;
        }

        private bool performAction(eActionChoice i_ActionChoice)
        {
            bool runSystem = true;
            switch (i_ActionChoice)
            {
                case eActionChoice.enterNewVehicle:
                    enterNewVehicle();
                    break;
                case eActionChoice.showAllLicenseNumbers:
                    printAllLicenseNumbers();
                    break;
                case eActionChoice.changeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eActionChoice.fillTiresAirToMax:
                    fillTiresAirToMax();
                    break;
                case eActionChoice.refuelVehicleTank:
                    refuelVehicleTank();
                    break;
                case eActionChoice.chargeVehicle:
                    chargeVehicle();
                    break;
                case eActionChoice.showVehicleFullDetails:
                    printVehicleFullDetails();
                    break;
                case eActionChoice.exitSystem:
                    Console.WriteLine("Goodbye, hope to see you again soon :)");
                    runSystem = !runSystem;
                    break;
            }
            return runSystem;
        }

        private void enterNewVehicle()
        {

        }

        private void printAllLicenseNumbers()
        {

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