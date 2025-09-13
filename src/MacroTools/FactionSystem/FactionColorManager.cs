using System;
using System.Collections.Generic;

namespace MacroTools.FactionSystem
{
  public static class ColorManager
  {
    private static readonly Dictionary<playercolor, bool> ColorAvailability = new();
    private static readonly Dictionary<playercolor, string> ColorHexMap = new();

    static ColorManager()
    {
      ColorAvailability[PLAYER_COLOR_RED] = true;
      ColorAvailability[PLAYER_COLOR_BLUE] = true;
      ColorAvailability[PLAYER_COLOR_CYAN] = true;
      ColorAvailability[PLAYER_COLOR_PURPLE] = true;
      ColorAvailability[PLAYER_COLOR_YELLOW] = true;
      ColorAvailability[PLAYER_COLOR_ORANGE] = true;
      ColorAvailability[PLAYER_COLOR_GREEN] = true;
      ColorAvailability[PLAYER_COLOR_PINK] = true;
      ColorAvailability[PLAYER_COLOR_LIGHT_GRAY] = true;
      ColorAvailability[PLAYER_COLOR_LIGHT_BLUE] = true;
      ColorAvailability[PLAYER_COLOR_AQUA] = true;
      ColorAvailability[PLAYER_COLOR_BROWN] = true;
      ColorAvailability[PLAYER_COLOR_MAROON] = true;
      ColorAvailability[PLAYER_COLOR_NAVY] = true;
      ColorAvailability[PLAYER_COLOR_TURQUOISE] = true;
      ColorAvailability[PLAYER_COLOR_VIOLET] = true;
      ColorAvailability[PLAYER_COLOR_WHEAT] = true;
      ColorAvailability[PLAYER_COLOR_PEACH] = true;
      ColorAvailability[PLAYER_COLOR_MINT] = true;
      ColorAvailability[PLAYER_COLOR_LAVENDER] = true;
      ColorAvailability[PLAYER_COLOR_COAL] = true;
      ColorAvailability[PLAYER_COLOR_EMERALD] = true;
      ColorAvailability[PLAYER_COLOR_PEANUT] = true;

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

    public static bool IsColorAvailable(playercolor color)
    {
      return ColorAvailability.ContainsKey(color) && ColorAvailability[color];
    }

    public static void AssignColor(playercolor color)
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

    public static void ReleaseColor(playercolor color)
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

    public static string GetColorHexCode(playercolor color)
    {
      if (ColorHexMap.ContainsKey(color))
      {
        return ColorHexMap[color];
      }
      else
      {
        return "|cff4f5055"; // Default to Coal if no colors can be found freely available.
      }
    }

    public static playercolor GetFallbackColor()
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

    public static playercolor AssignPreferredColorOrFallback(playercolor[] preferredColors)
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