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
    public enum RegenType
    {
        /// <summary>None.</summary>
        None = 0,
        /// <summary>Always.</summary>
        Always = 1,
        /// <summary>Only while on blight.</summary>
        Blight = 2,
        /// <summary>Only during the day.</summary>
        Day = 3,
        /// <summary>Only during the night.</summary>
        Night = 4
    }
}