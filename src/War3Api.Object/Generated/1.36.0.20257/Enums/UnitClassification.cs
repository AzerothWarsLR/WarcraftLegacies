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
    public enum UnitClassification
    {
        /// <summary>Giant.</summary>
        Giant = 0,
        /// <summary>Undead.</summary>
        Undead = 1,
        /// <summary>Summoned.</summary>
        Summoned = 2,
        /// <summary>Mechanical.</summary>
        Mechanical = 3,
        /// <summary>Worker.</summary>
        Peon = 4,
        /// <summary>Suicidal.</summary>
        Sapper = 5,
        /// <summary>Town hall.</summary>
        Townhall = 6,
        /// <summary>Tree.</summary>
        Tree = 7,
        /// <summary>Ward.</summary>
        Ward = 8,
        /// <summary>Ancient.</summary>
        Ancient = 9,
        /// <summary>Walkable.</summary>
        Standon = 10,
        /// <summary>Neutral.</summary>
        Neutral = 11,
        /// <summary>Tauren.</summary>
        Tauren = 12
    }
}