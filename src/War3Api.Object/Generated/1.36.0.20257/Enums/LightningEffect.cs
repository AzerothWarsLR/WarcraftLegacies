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
    public enum LightningEffect
    {
        /// <summary>Chain lightning primary.</summary>
        CLPB = 0,
        /// <summary>Chain lightning secondary.</summary>
        CLSB = 1,
        /// <summary>Mana burn.</summary>
        MBUR = 2,
        /// <summary>Lightning attack.</summary>
        CHIM = 3,
        /// <summary>Finger of death.</summary>
        AFOD = 4,
        /// <summary>Healing wave primary.</summary>
        HWPB = 5,
        /// <summary>Healing wave secondary.</summary>
        HWSB = 6,
        /// <summary>Mana flare.</summary>
        MFPB = 7,
        /// <summary>Drain life and mana.</summary>
        DRAB = 8,
        /// <summary>Drain life.</summary>
        DRAL = 9,
        /// <summary>Drain mana.</summary>
        DRAM = 10,
        /// <summary>Forked lighting.</summary>
        FORK = 11,
        /// <summary>Spirit link.</summary>
        SPLK = 12,
        /// <summary>Aerial shackles.</summary>
        LEAS = 13
    }
}