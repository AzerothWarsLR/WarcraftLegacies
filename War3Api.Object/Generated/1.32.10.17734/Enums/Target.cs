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
    public enum Target
    {
        /// <summary>Air.</summary>
        Air = 0,
        /// <summary>Alive.</summary>
        Alive = 1,
        /// <summary>Allied.</summary>
        Allies = 2,
        /// <summary>Dead.</summary>
        Dead = 3,
        /// <summary>Debris.</summary>
        Debris = 4,
        /// <summary>Enemy.</summary>
        Enemies = 5,
        /// <summary>Ground.</summary>
        Ground = 6,
        /// <summary>Hero.</summary>
        Hero = 7,
        /// <summary>Invulnerable.</summary>
        Invulnerable = 8,
        /// <summary>Item.</summary>
        Item = 9,
        /// <summary>Mechanical.</summary>
        Mechanical = 10,
        /// <summary>Neutral.</summary>
        Neutral = 11,
        /// <summary>None.</summary>
        None = 12,
        /// <summary>Non Hero.</summary>
        Nonhero = 13,
        /// <summary>Non suicidal.</summary>
        Nonsapper = 14,
        /// <summary>Not self.</summary>
        Notself = 15,
        /// <summary>Organic.</summary>
        Organic = 16,
        /// <summary>Player units.</summary>
        Player = 17,
        /// <summary>Suicidal.</summary>
        Sapper = 18,
        /// <summary>Self.</summary>
        Self = 19,
        /// <summary>Structure.</summary>
        Structure = 20,
        /// <summary>Terrain.</summary>
        Terrain = 21,
        /// <summary>Tree.</summary>
        Tree = 22,
        /// <summary>Vulnerable.</summary>
        Vulnerable = 23,
        /// <summary>Wall.</summary>
        Wall = 24,
        /// <summary>Ward.</summary>
        Ward = 25,
        /// <summary>Ancient.</summary>
        Ancient = 26,
        /// <summary>Non Ancient.</summary>
        Nonancient = 27,
        /// <summary>Friend.</summary>
        Friend = 28,
        /// <summary>Bridge.</summary>
        Bridge = 29,
        /// <summary>Decoration.</summary>
        Decoration = 30
    }
}