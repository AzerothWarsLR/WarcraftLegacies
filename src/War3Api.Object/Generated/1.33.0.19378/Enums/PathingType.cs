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
    public enum PathingType
    {
        /// <summary>Unblighted.</summary>
        Blighted = 0,
        /// <summary>Buildable.</summary>
        Unbuildable = 1,
        /// <summary>Air pathable.</summary>
        Unflyable = 2,
        /// <summary>Ground pathable.</summary>
        Unwalkable = 3,
        /// <summary>Amphibious pathable.</summary>
        Unamph = 4,
        /// <summary>Sea pathable.</summary>
        Unfloat = 5
    }
}