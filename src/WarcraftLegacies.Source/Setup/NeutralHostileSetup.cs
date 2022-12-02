using MacroTools.Extensions;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

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
      if (IllidanSetup.Illidan?.Player == null) return;
      foreach (var unit in CreateGroup().EnumUnitsOfPlayer(IllidanSetup.Illidan.Player).EmptyToList())
        if (!Regions.IllidanStartingPosition.Contains(unit.GetPosition()))
          unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}