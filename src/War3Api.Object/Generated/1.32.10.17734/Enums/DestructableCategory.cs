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
    public enum DestructableCategory
    {
        /// <summary>Trees destructibles.</summary>
        TreesDestructibles = 'D',
        /// <summary>Pathing blockers.</summary>
        PathingBlockers = 'P',
        /// <summary>Bridges ramps.</summary>
        BridgesRamps = 'B'
    }
}