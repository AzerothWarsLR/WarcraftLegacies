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
    [FlagsAttribute]
    public enum SilenceFlags
    {
        /// <summary>Melee.</summary>
        Melee = 1 << 0,
        /// <summary>Ranged.</summary>
        Ranged = 1 << 1,
        /// <summary>Special.</summary>
        Special = 1 << 2,
        /// <summary>Spells.</summary>
        Spells = 1 << 3
    }
}