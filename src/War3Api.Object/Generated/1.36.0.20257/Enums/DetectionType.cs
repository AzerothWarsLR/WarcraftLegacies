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
    public enum DetectionType
    {
        /// <summary>None.</summary>
        None = 0,
        /// <summary>Invisible.</summary>
        Invisible = 1,
        /// <summary>Burrowed.</summary>
        Burrowed = 2,
        /// <summary>Both.</summary>
        Both = 3
    }
}