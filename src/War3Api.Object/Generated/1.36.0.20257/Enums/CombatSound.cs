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
    public enum CombatSound
    {
        /// <summary>Axe medium chop.</summary>
        AxeMediumChop = 0,
        /// <summary>Metal heavy bash.</summary>
        MetalHeavyBash = 1,
        /// <summary>Metal heavy chop.</summary>
        MetalHeavyChop = 2,
        /// <summary>Metal heavy slice.</summary>
        MetalHeavySlice = 3,
        /// <summary>Metal light chop.</summary>
        MetalLightChop = 4,
        /// <summary>Metal light slice.</summary>
        MetalLightSlice = 5,
        /// <summary>Metal medium bash.</summary>
        MetalMediumBash = 6,
        /// <summary>Metal medium chop.</summary>
        MetalMediumChop = 7,
        /// <summary>Metal medium slice.</summary>
        MetalMediumSlice = 8,
        /// <summary>Rock heavy bash.</summary>
        RockHeavyBash = 9,
        /// <summary>Wood heavy bash.</summary>
        WoodHeavyBash = 10,
        /// <summary>Wood light bash.</summary>
        WoodLightBash = 11,
        /// <summary>Wood medium bash.</summary>
        WoodMediumBash = 12
    }
}