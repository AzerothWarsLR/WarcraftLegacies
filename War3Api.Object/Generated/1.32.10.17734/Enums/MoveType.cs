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
    public enum MoveType
    {
        /// <summary>Foot.</summary>
        Foot = 0,
        /// <summary>Horse.</summary>
        Horse = 1,
        /// <summary>Fly.</summary>
        Fly = 2,
        /// <summary>Hover.</summary>
        Hover = 3,
        /// <summary>Float.</summary>
        Float = 4,
        /// <summary>Amphibious.</summary>
        Amph = 5
    }
}