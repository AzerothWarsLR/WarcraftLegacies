using System.Collections.Generic;

namespace MacroTools.FactionSystem
{
  public static class ColorManager
  {
    private static readonly Dictionary<playercolor, string> ColorHexMap = new();

    static ColorManager()
    {
      ColorHexMap[PLAYER_COLOR_RED] = "|cffff0303";
      ColorHexMap[PLAYER_COLOR_BLUE] = "|cff0042ff";
      ColorHexMap[PLAYER_COLOR_CYAN] = "|cff1be7ba";
      ColorHexMap[PLAYER_COLOR_PURPLE] = "|cff550081";
      ColorHexMap[PLAYER_COLOR_YELLOW] = "|cfffefc00";
      ColorHexMap[PLAYER_COLOR_ORANGE] = "|cfffe890d";
      ColorHexMap[PLAYER_COLOR_GREEN] = "|cff21bf00";
      ColorHexMap[PLAYER_COLOR_PINK] = "|cffe45caf";
      ColorHexMap[PLAYER_COLOR_LIGHT_GRAY] = "|cff939596";
      ColorHexMap[PLAYER_COLOR_LIGHT_BLUE] = "|cff7ebff1";
      ColorHexMap[PLAYER_COLOR_AQUA] = "|c00006400";
      ColorHexMap[PLAYER_COLOR_BROWN] = "|cff4f2b05";
      ColorHexMap[PLAYER_COLOR_MAROON] = "|cff9c0000";
      ColorHexMap[PLAYER_COLOR_NAVY] = "|cff0000c3";
      ColorHexMap[PLAYER_COLOR_TURQUOISE] = "|cff00ebff";
      ColorHexMap[PLAYER_COLOR_VIOLET] = "|cffbd00ff";
      ColorHexMap[PLAYER_COLOR_WHEAT] = "|cffecce87";
      ColorHexMap[PLAYER_COLOR_PEACH] = "|cfff7a58b";
      ColorHexMap[PLAYER_COLOR_MINT] = "|cffbfff81";
      ColorHexMap[PLAYER_COLOR_LAVENDER] = "|cffdbb8eb";
      ColorHexMap[PLAYER_COLOR_COAL] = "|cff4f5055";
      ColorHexMap[PLAYER_COLOR_EMERALD] = "|cff00781e";
      ColorHexMap[PLAYER_COLOR_PEANUT] = "|cffa56f34";
    }

    public static string GetColorHexCode(playercolor color) =>
      ColorHexMap.ContainsKey(color)
        ? ColorHexMap[color]
        : "|cff4f5055"; // Default to Coal if no colors can be found freely available.
  }
}