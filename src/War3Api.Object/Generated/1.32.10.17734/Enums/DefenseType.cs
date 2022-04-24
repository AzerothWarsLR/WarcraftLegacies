using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Enums
{
    public enum DefenseType
    {
        /// <summary>Normal.</summary>
        Normal = 0,
        /// <summary>Small.</summary>
        Small = 1,
        /// <summary>Medium.</summary>
        Medium = 2,
        /// <summary>Large.</summary>
        Large = 3,
        /// <summary>Fortified.</summary>
        Fort = 4,
        /// <summary>Hero.</summary>
        Hero = 5,
        /// <summary>Divine.</summary>
        Divine = 6,
        /// <summary>Unarmored.</summary>
        None = 7
    }
}