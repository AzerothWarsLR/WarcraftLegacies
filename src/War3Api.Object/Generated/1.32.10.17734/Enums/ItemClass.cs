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
    public enum ItemClass
    {
        /// <summary>Permanent.</summary>
        Permanent = 0,
        /// <summary>Charged.</summary>
        Charged = 1,
        /// <summary>Power up.</summary>
        PowerUp = 2,
        /// <summary>Artifact.</summary>
        Artifact = 3,
        /// <summary>Purchasable.</summary>
        Purchasable = 4,
        /// <summary>Campaign.</summary>
        Campaign = 5,
        /// <summary>Miscellaneous.</summary>
        Miscellaneous = 6
    }
}