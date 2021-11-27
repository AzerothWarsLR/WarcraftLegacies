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
    public enum TeamColor
    {
        /// <summary>Match owning player.</summary>
        MatchOwningPlayer = -1,
        /// <summary>Player 1 red.</summary>
        Player1Red = 0,
        /// <summary>Player 2 blue.</summary>
        Player2Blue = 1,
        /// <summary>Player 3 teal.</summary>
        Player3Teal = 2,
        /// <summary>Player 4 purple.</summary>
        Player4Purple = 3,
        /// <summary>Player 5 yellow.</summary>
        Player5Yellow = 4,
        /// <summary>Player 6 orange.</summary>
        Player6Orange = 5,
        /// <summary>Player 7 green.</summary>
        Player7Green = 6,
        /// <summary>Player 8 pink.</summary>
        Player8Pink = 7,
        /// <summary>Player 9 gray.</summary>
        Player9Gray = 8,
        /// <summary>Player 10 light blue.</summary>
        Player10LightBlue = 9,
        /// <summary>Player 11 dark green.</summary>
        Player11DarkGreen = 10,
        /// <summary>Player 12 brown.</summary>
        Player12Brown = 11,
        /// <summary>Player 13 maroon.</summary>
        Player13Maroon = 12,
        /// <summary>Player 14 navy.</summary>
        Player14Navy = 13,
        /// <summary>Player 15 turquoise.</summary>
        Player15Turquoise = 14,
        /// <summary>Player 16 violet.</summary>
        Player16Violet = 15,
        /// <summary>Player 17 wheat.</summary>
        Player17Wheat = 16,
        /// <summary>Player 18 peach.</summary>
        Player18Peach = 17,
        /// <summary>Player 19 mint.</summary>
        Player19Mint = 18,
        /// <summary>Player 20 lavender.</summary>
        Player20Lavender = 19,
        /// <summary>Player 21 coal.</summary>
        Player21Coal = 20,
        /// <summary>Player 22 snow.</summary>
        Player22Snow = 21,
        /// <summary>Player 23 emerald.</summary>
        Player23Emerald = 22,
        /// <summary>Player 24 peanut.</summary>
        Player24Peanut = 23,
        /// <summary>Neutral hostile.</summary>
        NeutralHostile = 24
    }
}