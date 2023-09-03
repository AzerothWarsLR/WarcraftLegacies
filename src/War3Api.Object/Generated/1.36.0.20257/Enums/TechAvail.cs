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
    [ObsoleteAttribute]
    internal enum TechAvail
    {
        /// <summary>Available.</summary>
        Available = -1,
        /// <summary>Unavailable.</summary>
        Unavailable = 1
    }
}