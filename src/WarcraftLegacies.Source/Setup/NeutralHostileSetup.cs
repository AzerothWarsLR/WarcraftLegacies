using MacroTools.Utils;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up anything related to the Neutral Hostile computer player.
/// </summary>
public static class NeutralHostileSetup
{
  /// <summary>
  /// Grants all units controlled by Illidan to Neutral Hostile, except for those in <see cref="Regions.IllidanStartingPosition"/>.
  /// </summary>
  public static void Setup()
  {
    foreach (var unit in GlobalGroup.EnumUnitsOfPlayer(Player(20)))
    {
      var whichPlayer = Player(PLAYER_NEUTRAL_AGGRESSIVE);
      SetUnitOwner(unit, whichPlayer, true);
    }
  }
}
