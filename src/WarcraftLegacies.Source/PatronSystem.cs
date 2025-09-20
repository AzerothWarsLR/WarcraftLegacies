using System;
using MacroTools.Systems;
using WCSharp.Shared.Data;

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

  private static void SetupPatron(string name, PatronTier tier, Point position, PreplacedUnitSystem preplacedUnitSystem)
  {
    var unit = preplacedUnitSystem.GetUnit(TierToUnitType(tier), position);
    BlzSetUnitName(unit, $"{name} - Tier {(int)tier} Patron");
  }

  /// <summary>
  /// Renames some units on the map to be named after Patreon Patrons.
  /// </summary>
  public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
  {
    SetupPatron("bredbrodak", PatronTier.Two, new Point(16925, 14799), preplacedUnitSystem);
    SetupPatron("Dromoka", PatronTier.Two, new Point(13245, 5359), preplacedUnitSystem);
    SetupPatron("Eagleman", PatronTier.Two, new Point(15276, 2550), preplacedUnitSystem);
  }
}
