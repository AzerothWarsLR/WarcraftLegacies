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
    public enum ChannelType
    {
        /// <summary>Instant no target.</summary>
        InstantNoTarget = 0,
        /// <summary>Unit target.</summary>
        UnitTarget = 1,
        /// <summary>Point target.</summary>
        PointTarget = 2,
        /// <summary>Unit or point target.</summary>
        UnitOrPointTarget = 3
    }
}