using System;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source;

/// <summary>
/// Responsible for renaming units on the map to their appropriate Patreon Patron.
/// </summary>
public static class PatronSystem
{
  private static int TierToUnitType(PatronTier tier)
  {
    if (tier == PatronTier.One)
    {
      return UNIT_NHMC_PATRONS_FOOTMAN_TIER_1_PATRON;
    }

    if (tier == PatronTier.Two)
    {
      return UNIT_NFRO_PATRONS_KNIGHT_TIER_2_PATRON;
    }

    throw new ArgumentOutOfRangeException(nameof(tier), tier, null);
  }

  private static void SetupPatron(string name, PatronTier tier, int x, int y)
  {
    var unit = PreplacedWidgets.Units.GetClosest(TierToUnitType(tier), x, y);
    unit.Name = $"{name} - Tier {(int)tier} Patron";
  }

  /// <summary>
  /// Renames some units on the map to be named after Patreon Patrons.
  /// </summary>
  public static void Setup()
  {
    SetupPatron("bredbrodak", PatronTier.Two, 16925, 14799);
    SetupPatron("Dromoka", PatronTier.Two, 13245, 5359);
    SetupPatron("Eagleman", PatronTier.Two, 15276, 2550);
  }
}
