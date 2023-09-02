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
    public enum DoodadCategory
    {
        /// <summary>Props.</summary>
        Props = 'O',
        /// <summary>Structures.</summary>
        Structures = 'S',
        /// <summary>Water.</summary>
        Water = 'W',
        /// <summary>Cliff terrain.</summary>
        CliffTerrain = 'C',
        /// <summary>Environment.</summary>
        Environment = 'E',
        /// <summary>Cinematic.</summary>
        Cinematic = 'Z'
    }
}