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
    public enum VersionFlags
    {
        /// <summary>Reign of chaos.</summary>
        ReignOfChaos = 1 << 0,
        /// <summary>The frozen throne.</summary>
        TheFrozenThrone = 1 << 1
    }
}