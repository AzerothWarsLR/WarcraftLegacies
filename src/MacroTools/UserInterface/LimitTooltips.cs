namespace MacroTools.UserInterface;

/// <summary>
/// Keeps the limit shown in a unit's training tooltip in step with limit changes made during the game.
/// <para>The limit line is written into the tooltip when the map is built, so it otherwise keeps showing the
/// starting limit.</para>
/// </summary>
public static class LimitTooltips
{
  private const string LimitColor = "|cff99b4d1";
  private const string Digits = "0123456789";

  /// <summary>
  /// Adds <paramref name="change"/> to the limit shown in <paramref name="unitTypeId"/>'s tooltip, for
  /// <paramref name="whichPlayer"/> only.
  /// </summary>
  public static void ShiftShownLimit(player whichPlayer, int unitTypeId, int change)
  {
    if (player.LocalPlayer != whichPlayer)
    {
      return;
    }

    var tooltip = BlzGetAbilityExtendedTooltip(unitTypeId, 0);
    var numberStart = -1;
    var segmentStart = tooltip.IndexOf(LimitColor);
    while (segmentStart >= 0)
    {
      var digit = FindDigit(tooltip, segmentStart + LimitColor.Length);
      var segmentEnd = tooltip.IndexOf("|r", segmentStart);
      if (digit >= 0 && (segmentEnd < 0 || digit < segmentEnd))
      {
        numberStart = digit;
      }

      segmentStart = tooltip.IndexOf(LimitColor, segmentStart + LimitColor.Length);
    }

    if (numberStart < 0)
    {
      return;
    }

    var numberEnd = numberStart;
    while (numberEnd < tooltip.Length && Digits.IndexOf(tooltip.Substring(numberEnd, 1)) >= 0)
    {
      numberEnd++;
    }

    var shownLimit = S2I(tooltip.Substring(numberStart, numberEnd - numberStart)) + change;
    BlzSetAbilityExtendedTooltip(unitTypeId, tooltip.Substring(0, numberStart) + shownLimit + tooltip.Substring(numberEnd), 0);
  }

  private static int FindDigit(string text, int from)
  {
    for (var i = from; i < text.Length; i++)
    {
      if (Digits.IndexOf(text.Substring(i, 1)) >= 0)
      {
        return i;
      }
    }

    return -1;
  }
}
