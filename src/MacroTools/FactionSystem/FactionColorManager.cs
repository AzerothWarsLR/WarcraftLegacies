using System.Collections.Generic;

namespace MacroTools.FactionSystem;

public static class ColorManager
{
  private static readonly Dictionary<playercolor, string> _colorHexMap = new();

  static ColorManager()
  {
    _colorHexMap[playercolor.Red] = "|cffff0303";
    _colorHexMap[playercolor.Blue] = "|cff0042ff";
    _colorHexMap[playercolor.Cyan] = "|cff1be7ba";
    _colorHexMap[playercolor.Purple] = "|cff550081";
    _colorHexMap[playercolor.Yellow] = "|cfffefc00";
    _colorHexMap[playercolor.Orange] = "|cfffe890d";
    _colorHexMap[playercolor.Green] = "|cff21bf00";
    _colorHexMap[playercolor.Pink] = "|cffe45caf";
    _colorHexMap[playercolor.LightGray] = "|cff939596";
    _colorHexMap[playercolor.LightBlue] = "|cff7ebff1";
    _colorHexMap[playercolor.Aqua] = "|c00006400";
    _colorHexMap[playercolor.Brown] = "|cff4f2b05";
    _colorHexMap[playercolor.Maroon] = "|cff9c0000";
    _colorHexMap[playercolor.Navy] = "|cff0000c3";
    _colorHexMap[playercolor.Turquoise] = "|cff00ebff";
    _colorHexMap[playercolor.Violet] = "|cffbd00ff";
    _colorHexMap[playercolor.Wheat] = "|cffecce87";
    _colorHexMap[playercolor.Peach] = "|cfff7a58b";
    _colorHexMap[playercolor.Mint] = "|cffbfff81";
    _colorHexMap[playercolor.Lavender] = "|cffdbb8eb";
    _colorHexMap[playercolor.Coal] = "|cff4f5055";
    _colorHexMap[playercolor.Emerald] = "|cff00781e";
    _colorHexMap[playercolor.Peanut] = "|cffa56f34";
  }

  public static string GetColorHexCode(playercolor color) =>
    _colorHexMap.TryGetValue(color, out var value)
      ? value
      : "|cff4f5055"; // Default to Coal if no colors can be found freely available.
}
