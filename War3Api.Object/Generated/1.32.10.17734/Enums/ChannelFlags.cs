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
    public enum ChannelFlags
    {
        /// <summary>Visible.</summary>
        Visible = 1 << 0,
        /// <summary>Targeting image.</summary>
        TargetingImage = 1 << 1,
        /// <summary>Physical spell.</summary>
        PhysicalSpell = 1 << 2,
        /// <summary>Universal spell.</summary>
        UniversalSpell = 1 << 3,
        /// <summary>Unique cast.</summary>
        UniqueCast = 1 << 4
    }
}