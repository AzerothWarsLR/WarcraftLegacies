using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public enum TargetType
    {
        /// <summary>Ground.</summary>
        Ground = 0,
        /// <summary>Air.</summary>
        Air = 1,
        /// <summary>Structure.</summary>
        Structure = 2,
        /// <summary>Ward.</summary>
        Ward = 3
    }
}