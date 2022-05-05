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
        protected readonly Engine r_Engine;
        

        public Vehicle(string i_LicenseNumber, int i_NumberOfTires)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Tires = new List<Tire>(i_NumberOfTires);

            r_Parameters = new List<Param>();
            r_Parameters.Add(new Param("Model name", "name", typeof(string)));
            r_Parameters.Add(new Param("Energy left in engine", "float", typeof(int)));
            r_Parameters.Add(new Param("Current tire air pressure in all tires", "number", typeof(float)));
        }

        public virtual void CreateTires(float i_MaxAirPressure, string i_Manufacturer, float i_CurrentAirPressure)
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

        public virtual Param[] GetParametersRequired()
        {
            Param[] paramsRequired = new Param[k_ParametersRequiredForFullCreation];
            paramsRequired[0] = new Param("Model name", "name", typeof(string));
            paramsRequired[1] = new Param("Energy in engine", string.Format("{0} - {1}", r_Engine.MinEnergy, r_Engine.MaxEnergy), typeof(float));
            paramsRequired[2] = new Param("Current tire air pressure in all tires", string.Format("{0} - {1}", r_Tires[0].MinAirPressure, r_Tires[0].MaxAirPressure), typeof(float));
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
            /// 1. model name - string (
            /// 2. energy left - int (not above max)
            /// 3. tire air pressure in all - float (not above max)
            m_ModelName = i_Parameters[0] as string;
            int energyInEngine = (int)i_Parameters[1];
            float tirePressure = (float)i_Parameters[2];
            r_Engine.fillEnergy(energyInEngine);
            InflateAllTires(tirePressure);
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