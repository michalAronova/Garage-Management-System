using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            White,
            Green,
            Blue,
        }

        private eColor r_CarColor;
        private int r_DoorNumber;
        private const int k_TireNumber = 4;
        private const int k_MinDoors = 2;
        private const int k_MaxDoors = 5;

        private readonly List<Param> r_Parameters;

        public Car()
        {
            string options = Enum.GetNames(typeof(eColor)).ToString();
            r_Parameters = new List<Param>(2);
            r_Parameters[0] = new Param("car color", options);
            r_Parameters[1] = new Param("number of doors", string.Format("{0} - {1}", k_MinDoors, k_MaxDoors));
        }

        public override List<Param> getParamsRequired()
        {
            base.getParamsRequired().AddRange(r_Parameters);
            return base.getParamsRequired();
        }
        
    }
}