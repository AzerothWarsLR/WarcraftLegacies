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
    public enum WeaponType
    {
        /// <summary>Normal.</summary>
        Normal = 0,
        /// <summary>Instant.</summary>
        Instant = 1,
        /// <summary>Artillery.</summary>
        Artillery = 2,
        /// <summary>Artillery line.</summary>
        Aline = 3,
        /// <summary>Missile.</summary>
        Missile = 4,
        /// <summary>Missile splash.</summary>
        Msplash = 5,
        /// <summary>Missile bounce.</summary>
        Mbounce = 6,
        /// <summary>Missile line.</summary>
        Mline = 7
    }
}