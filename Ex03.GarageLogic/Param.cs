using System;

namespace Ex03.GarageLogic
{
    public struct Param
    {
        private readonly string r_ParamName;
        private readonly string r_ParamRequirements;
        
        public Param(string i_ParamName, string i_ParamRequirements)
        {
            r_ParamName = i_ParamName;
            r_ParamRequirements = i_ParamRequirements;
        }
    }
}