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
    public enum UnitRace
    {
        /// <summary>Human.</summary>
        Human = 0,
        /// <summary>Orc.</summary>
        Orc = 1,
        /// <summary>Undead.</summary>
        Undead = 2,
        /// <summary>Night elf.</summary>
        Nightelf = 3,
        /// <summary>Demon.</summary>
        Demon = 4,
        /// <summary>Creep.</summary>
        Creeps = 5,
        /// <summary>Critter.</summary>
        Critters = 6,
        /// <summary>Other.</summary>
        Other = 7,
        /// <summary>Commoner.</summary>
        Commoner = 8,
        /// <summary>Naga.</summary>
        Naga = 9,
        /// <summary>None.</summary>
        Unknown = 10
    }
}