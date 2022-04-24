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
    public enum MorphFlags
    {
        /// <summary>Uninterruptable.</summary>
        Uninterruptable = 1 << 0,
        /// <summary>Immediate landing.</summary>
        ImmediateLanding = 1 << 1,
        /// <summary>Immediate take off.</summary>
        ImmediateTakeOff = 1 << 2,
        /// <summary>Permanent.</summary>
        Permanent = 1 << 3,
        /// <summary>Requires payment.</summary>
        RequiresPayment = 1 << 4
    }
}