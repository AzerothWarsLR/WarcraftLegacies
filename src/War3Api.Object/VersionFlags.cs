using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
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