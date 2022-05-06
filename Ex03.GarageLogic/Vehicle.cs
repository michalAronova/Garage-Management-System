using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const int   k_ParametersRequiredForFullCreation = 3;

        private readonly string r_LicenseNumber;
        private readonly List<Tire> r_Tires;
        private string m_ModelName;
        protected Engine m_Engine; // readonly


        public Vehicle(string i_LicenseNumber, int i_NumberOfTires)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Tires = new List<Tire>(i_NumberOfTires);
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

        public void InflateByTire(int i_TireToInflate, float i_AirPressureToInflateWith)
        {
            r_Tires[i_TireToInflate].Inflate(i_AirPressureToInflateWith);
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public virtual void FillParams(List<object> i_Parameters)
        {
            float energyInEngine = (float)i_Parameters[1];
            string manufacturerName = (string)i_Parameters[2];
            float tirePressure = (float)i_Parameters[3];

            m_ModelName = i_Parameters[0] as string;
            m_Engine.fillEnergy(energyInEngine);
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}