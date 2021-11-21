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
    public enum DeathType
    {
        /// <summary>Can t raise does not decay.</summary>
        CanTRaiseDoesNotDecay = 0,
        /// <summary>Can raise does not decay.</summary>
        CanRaiseDoesNotDecay = 1,
        /// <summary>Can t raise does decay.</summary>
        CanTRaiseDoesDecay = 2,
        /// <summary>Can raise does decay.</summary>
        CanRaiseDoesDecay = 3
    }
}