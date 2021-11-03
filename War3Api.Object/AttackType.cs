using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public enum AttackType
    {
        /// <summary>None.</summary>
        Unknown = 0,
        /// <summary>Normal.</summary>
        Normal = 1,
        /// <summary>Pierce.</summary>
        Pierce = 2,
        /// <summary>Siege.</summary>
        Siege = 3,
        /// <summary>Spells.</summary>
        Spells = 4,
        /// <summary>Chaos.</summary>
        Chaos = 5,
        /// <summary>Magic.</summary>
        Magic = 6,
        /// <summary>Hero.</summary>
        Hero = 7
    }
}