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
    public enum UpgradeEffect
    {
        /// <summary>Apply defense upgrade bonus.</summary>
        Rarm = 0,
        /// <summary>Apply attack upgrade bonus.</summary>
        Ratt = 1,
        /// <summary>Attack damage bonus.</summary>
        Ratx = 2,
        /// <summary>Attack damage loss bonus.</summary>
        Radl = 3,
        /// <summary>Attack dice bonus.</summary>
        Ratd = 4,
        /// <summary>Attack range bonus.</summary>
        Ratr = 5,
        /// <summary>Attack speed bonus.</summary>
        Rats = 6,
        /// <summary>Attack spill distance bonus.</summary>
        Rasd = 7,
        /// <summary>Attack spill radius bonus.</summary>
        Rasr = 8,
        /// <summary>Attack target count bonus.</summary>
        Ratc = 9,
        /// <summary>Aura data bonus.</summary>
        Raud = 10,
        /// <summary>Enable attacks.</summary>
        Renw = 11,
        /// <summary>Gold harvest bonus entangle.</summary>
        Rent = 12,
        /// <summary>Hit point bonus.</summary>
        Rhpo = 13,
        /// <summary>Hit point bonus.</summary>
        Rhpx = 14,
        /// <summary>Hit point regeneration.</summary>
        Rhpr = 15,
        /// <summary>Lumber harvest bonus.</summary>
        Rlum = 16,
        /// <summary>Magic immunity.</summary>
        Rmim = 17,
        /// <summary>Mana point bonus.</summary>
        Rman = 18,
        /// <summary>Mana point bonus.</summary>
        Rmnx = 19,
        /// <summary>Mana regeneration.</summary>
        Rmnr = 20,
        /// <summary>Gold harvest bonus.</summary>
        Rmin = 21,
        /// <summary>Movement speed bonus.</summary>
        Rmov = 22,
        /// <summary>Movement speed bonus.</summary>
        Rmvx = 23,
        /// <summary>Raise dead duration bonus.</summary>
        Rrai = 24,
        /// <summary>Enable attacks rooted.</summary>
        Rroo = 25,
        /// <summary>Sight range bonus.</summary>
        Rsig = 26,
        /// <summary>Ability level bonus.</summary>
        Rlev = 27,
        /// <summary>Spiked barricades.</summary>
        Rspi = 28,
        /// <summary>Enable attacks uprooted.</summary>
        Ruro = 29,
        /// <summary>Unit availability change.</summary>
        Rtma = 30,
        /// <summary>Defense type change.</summary>
        Rart = 31,
        /// <summary>Add ultravision.</summary>
        Rauv = 32,
        /// <summary>Spiked barricades.</summary>
        Rspp = 33
    }
}