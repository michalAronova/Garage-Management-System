using System.Collections.Generic;
using System.Security.Cryptography;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        private readonly List<Tire> r_Tires;
        private string m_ModelName;
        protected readonly Engine r_Engine;

        private readonly List<Param> r_Parameters;

        public Vehicle(string i_LicenseNumber, int i_NumberOfTires)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Tires = new List<Tire>(i_NumberOfTires);

            r_Parameters = new List<Param>();
            r_Parameters.Add(new Param("Model name", "name", typeof(string)));
            r_Parameters.Add(new Param("Energy left in engine", "float", typeof(int)));
            r_Parameters.Add(new Param("Current tire air pressure in all tires", "number", typeof(float)));
        }

        public virtual void createTires(float i_MaxAirPressure, string i_Manufacturer, float i_CurrentAirPressure)
        {
            for(int i = 0; i < r_Tires.Count; i++)
            {
                r_Tires[i] = new Tire(i_MaxAirPressure, i_Manufacturer);
            }
            InflateAllTires(i_CurrentAirPressure);
        }
        public void InflateAllTires(float i_AirPressureToInflateWith)
        {
            foreach(Tire tire in r_Tires)
            {
                tire.Inflate(i_AirPressureToInflateWith);
            }
        }

        public void InflateByTire(int i_TireToInflate, float i_AirPressureToInflateWith)
        {
            r_Tires[i_TireToInflate].Inflate(i_AirPressureToInflateWith);
        }
        public virtual List<Param> Parameters
        {
            get
            {
                return r_Parameters;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public int numberOfBaseParams
        {
            get
            {
                return r_Parameters.Count;
            }
        }

        //protected void CreateEngineByType(Engine.eEngineType i_EngineType, float i_MaxBatteryTime, FuelEngine.eFuelType i_FuelType, float i_MaxFuelTank)
        //{
        //    if (i_EngineType == Engine.eEngineType.Electric)
        //    {
        //        //m_Engine = new ElectricEngine(i_MaxBatteryTime);
        //    }
        //    else
        //    {
        //        //m_Engine = new FuelEngine(i_FuelType, i_MaxFuelTank);
        //    }
        //}

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