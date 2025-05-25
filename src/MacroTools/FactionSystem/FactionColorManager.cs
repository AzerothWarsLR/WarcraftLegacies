using System;
using System.Collections.Generic;
using War3Api;

namespace MacroTools.FactionSystem
{
  public static class ColorManager
  {
    private static readonly Dictionary<Common.playercolor, bool> ColorAvailability = new();
    private static readonly Dictionary<Common.playercolor, string> ColorHexMap = new();

    static ColorManager()
    {
      ColorAvailability[Common.PLAYER_COLOR_RED] = true;
      ColorAvailability[Common.PLAYER_COLOR_BLUE] = true;
      ColorAvailability[Common.PLAYER_COLOR_CYAN] = true;
      ColorAvailability[Common.PLAYER_COLOR_PURPLE] = true;
      ColorAvailability[Common.PLAYER_COLOR_YELLOW] = true;
      ColorAvailability[Common.PLAYER_COLOR_ORANGE] = true;
      ColorAvailability[Common.PLAYER_COLOR_GREEN] = true;
      ColorAvailability[Common.PLAYER_COLOR_PINK] = true;
      ColorAvailability[Common.PLAYER_COLOR_LIGHT_GRAY] = true;
      ColorAvailability[Common.PLAYER_COLOR_LIGHT_BLUE] = true;
      ColorAvailability[Common.PLAYER_COLOR_AQUA] = true;
      ColorAvailability[Common.PLAYER_COLOR_BROWN] = true;
      ColorAvailability[Common.PLAYER_COLOR_MAROON] = true;
      ColorAvailability[Common.PLAYER_COLOR_NAVY] = true;
      ColorAvailability[Common.PLAYER_COLOR_TURQUOISE] = true;
      ColorAvailability[Common.PLAYER_COLOR_VIOLET] = true;
      ColorAvailability[Common.PLAYER_COLOR_WHEAT] = true;
      ColorAvailability[Common.PLAYER_COLOR_PEACH] = true;
      ColorAvailability[Common.PLAYER_COLOR_MINT] = true;
      ColorAvailability[Common.PLAYER_COLOR_LAVENDER] = true;
      ColorAvailability[Common.PLAYER_COLOR_COAL] = true;
      ColorAvailability[Common.PLAYER_COLOR_EMERALD] = true;
      ColorAvailability[Common.PLAYER_COLOR_PEANUT] = true;

      ColorHexMap[Common.PLAYER_COLOR_RED] = "|cffff0303";
      ColorHexMap[Common.PLAYER_COLOR_BLUE] = "|cff0042ff";
      ColorHexMap[Common.PLAYER_COLOR_CYAN] = "|cff1be7ba";
      ColorHexMap[Common.PLAYER_COLOR_PURPLE] = "|cff550081";
      ColorHexMap[Common.PLAYER_COLOR_YELLOW] = "|cfffefc00";
      ColorHexMap[Common.PLAYER_COLOR_ORANGE] = "|cfffe890d";
      ColorHexMap[Common.PLAYER_COLOR_GREEN] = "|cff21bf00";
      ColorHexMap[Common.PLAYER_COLOR_PINK] = "|cffe45caf";
      ColorHexMap[Common.PLAYER_COLOR_LIGHT_GRAY] = "|cff939596";
      ColorHexMap[Common.PLAYER_COLOR_LIGHT_BLUE] = "|cff7ebff1";
      ColorHexMap[Common.PLAYER_COLOR_AQUA] = "|cff00ebff";
      ColorHexMap[Common.PLAYER_COLOR_BROWN] = "|cff4f2b05";
      ColorHexMap[Common.PLAYER_COLOR_MAROON] = "|cff9c0000";
      ColorHexMap[Common.PLAYER_COLOR_NAVY] = "|cff0000c3";
      ColorHexMap[Common.PLAYER_COLOR_TURQUOISE] = "|cff00ebff";
      ColorHexMap[Common.PLAYER_COLOR_VIOLET] = "|cffbd00ff";
      ColorHexMap[Common.PLAYER_COLOR_WHEAT] = "|cffecce87";
      ColorHexMap[Common.PLAYER_COLOR_PEACH] = "|cfff7a58b";
      ColorHexMap[Common.PLAYER_COLOR_MINT] = "|cffbfff81";
      ColorHexMap[Common.PLAYER_COLOR_LAVENDER] = "|cffdbb8eb";
      ColorHexMap[Common.PLAYER_COLOR_COAL] = "|cff4f5055";
      ColorHexMap[Common.PLAYER_COLOR_EMERALD] = "|cff00781e";
      ColorHexMap[Common.PLAYER_COLOR_PEANUT] = "|cffa56f34";
    }

    public static bool IsColorAvailable(Common.playercolor color)
    {
      return ColorAvailability.ContainsKey(color) && ColorAvailability[color];
    }

    public static void AssignColor(Common.playercolor color)
    {
      if (IsColorAvailable(color))
      {
        ColorAvailability[color] = false;
      }
      else
      {
        throw new InvalidOperationException($"Color {color} is already in use!");
      }
    }

    public static void ReleaseColor(Common.playercolor color)
    {
      if (ColorAvailability.ContainsKey(color))
      {
        ColorAvailability[color] = true;
      }
      else
      {
        throw new InvalidOperationException($"Tried to release color {color} but it is not managed.");
      }
    }

    public static string GetColorHexCode(Common.playercolor color)
    {
      if (ColorHexMap.ContainsKey(color))
      {
        return ColorHexMap[color];
      }
      else
      {
        return "|cffffffff"; // Default to white
      }
    }

    public static Common.playercolor GetFallbackColor()
    {
      foreach (var kvp in ColorAvailability)
      {
        if (kvp.Value)
        {
          return kvp.Key;
        }
      }

      throw new InvalidOperationException("No colors are available to assign.");
    }

    public static Common.playercolor AssignPreferredColorOrFallback(Common.playercolor[] preferredColors)
    {
      foreach (var color in preferredColors)
      {
        if (IsColorAvailable(color))
        {
          AssignColor(color);
          return color;
        }
      }

      var fallbackColor = GetFallbackColor();
      AssignColor(fallbackColor);
      return fallbackColor;
    }
  }
}