using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public enum FullFlags
    {
        /// <summary>Never.</summary>
        Never = 0,
        /// <summary>Life only.</summary>
        LifeOnly = 1,
        /// <summary>Mana only.</summary>
        ManaOnly = 2,
        /// <summary>Always.</summary>
        Always = 3
    }
}