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
    public enum StackFlags
    {
        /// <summary>Damage.</summary>
        Damage = 1 << 0,
        /// <summary>Movement.</summary>
        Movement = 1 << 1,
        /// <summary>Attack rate.</summary>
        AttackRate = 1 << 2,
        /// <summary>Kill unit.</summary>
        KillUnit = 1 << 3
    }
}