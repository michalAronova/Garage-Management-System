using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const int k_ParametersRequiredForFullCreation = 3;
        private readonly string r_LicenseNumber;
        private readonly List<Tire> r_Tires;
        private string m_ModelName;
        protected Engine m_Engine;

        public Vehicle(string i_LicenseNumber, int i_NumberOfTires)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Tires = new List<Tire>(new Tire[i_NumberOfTires]);
        }

        public virtual void CreateTires(float i_MaxAirPressure)
        {
            for (int i = 0; i < r_Tires.Count; i++)
            {
                r_Tires[i] = new Tire(i_MaxAirPressure);
            }
        }

        private void setManufacturerAllTires(string i_ManufacturerName)
        {
            foreach (Tire tire in r_Tires)
            {
                tire.ManufacturerName = i_ManufacturerName;
            }
        }

        public void RefuelVehicle(FuelEngine.eFuelType i_FuelType, float i_FuelAmount)
        {
            if (m_Engine is ElectricEngine)
            {
                throw new ArgumentException("Cannot refuel an electric vehicle!");
            }

            (m_Engine as FuelEngine).Refuel(i_FuelType, i_FuelAmount); 
        }

        public void ChargeVehicle(float i_MinutesToCharge)
        {
            if(m_Engine is FuelEngine)
            {
                throw new ArgumentException("Cannot charge a fuel vehicle!");
            }

            (m_Engine as ElectricEngine).Charge(i_MinutesToCharge);
        }

        public void InflateAllToMax()
        {
            foreach (Tire tire in r_Tires)
            {
                tire.InflateToMax();
            }
        }

        public void InflateAllTires(float i_AirPressureToInflateWith)
        {
            foreach(Tire tire in r_Tires)
            {
                tire.Inflate(i_AirPressureToInflateWith);
            }
        }

        public virtual List<Param> GetParametersRequired()
        {
            List<Param> paramsRequired = new List<Param>();

            paramsRequired.Add(new Param("Model name", "letters and numbers", typeof(string)));
            paramsRequired.Add(new Param("Energy in engine", string.Format("{0} - {1}", m_Engine.MinEnergy, m_Engine.MaxEnergy), typeof(float)));
            paramsRequired.Add(new Param("Tires manufacturer", "letters and numbers", typeof(string)));
            paramsRequired.Add(new Param("Current tire air pressure in all tires", "numbers", typeof(float)));

            return paramsRequired;
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public Engine.eEngineType EngineType
        {
            get
            {
                return m_Engine.EngineType;
            }
        }

        public virtual void FillParams(List<object> i_Parameters)
        {
            float energyInEngine = (float)i_Parameters[1];
            string manufacturerName = (string)i_Parameters[2];
            float tirePressure = (float)i_Parameters[3];

            m_ModelName = i_Parameters[0] as string;
            m_Engine.FillEnergy(energyInEngine);
            setManufacturerAllTires(manufacturerName);
            InflateAllTires(tirePressure);
        }

        protected void CreateEngineByType(Engine.eEngineType i_EngineType, float i_MaxBatteryTime, FuelEngine.eFuelType i_FuelType, float i_MaxFuelTank)
        {
            if (i_EngineType == Engine.eEngineType.Electric)
            {
                m_Engine = new ElectricEngine(i_MaxBatteryTime);
            }
            else
            {
                m_Engine = new FuelEngine(i_FuelType, i_MaxFuelTank);
            }
        }

        public override string ToString()
        {
            string tiresData = r_Tires[0].ToString();
            string vehicleData = null;

            vehicleData = string.Format(
@"License Number: {0}
Model name: {1}
Tires info:
{2}
Engine info:
{3}", r_LicenseNumber, m_ModelName, tiresData, m_Engine.ToString());

            return vehicleData;
        }
    }
}