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
    public enum AiBuffer
    {
        /// <summary>None.</summary>
        _ = 0,
        /// <summary>Hall.</summary>
        Townhall = 1,
        /// <summary>Resource.</summary>
        Resource = 2,
        /// <summary>Factory.</summary>
        Factory = 3,
        /// <summary>General.</summary>
        Buffer = 4
    }
}