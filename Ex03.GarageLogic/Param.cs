﻿using System;

namespace Ex03.GarageLogic
{
    public struct Param
    {
        private readonly string r_ParamName;
        private readonly string r_ParamRequirements;
        private readonly Type r_ParamType;
        
        public Param(string i_ParamName, string i_ParamRequirements, Type i_ParamType)
        {
            r_ParamName = i_ParamName;
            r_ParamRequirements = i_ParamRequirements;
            r_ParamType = i_ParamType;
        }
    }
}