using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Setup
{
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
      foreach (var unit in CreateGroup().EnumUnitsOfPlayer(Player(20)).EmptyToList())
          unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}