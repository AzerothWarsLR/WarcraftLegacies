using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    [FlagsAttribute]
    public enum InteractionFlags
    {
        /// <summary>Any unit w inventory.</summary>
        AnyUnitWInventory = 1 << 0,
        /// <summary>Any Non Building.</summary>
        AnyNonBuilding = 1 << 1,
        /// <summary>Any.</summary>
        Any = 1 << 2
    }
}