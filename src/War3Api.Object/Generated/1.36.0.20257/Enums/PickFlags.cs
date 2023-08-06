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
    public enum PickFlags
    {
        /// <summary>Hall.</summary>
        Hall = 1 << 0,
        /// <summary>Resource.</summary>
        Resource = 1 << 1,
        /// <summary>Factory.</summary>
        Factory = 1 << 2,
        /// <summary>General.</summary>
        General = 1 << 3
    }
}