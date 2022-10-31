using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for setting up anything related to the Neutral Hostile computer player.
  /// </summary>
  public static class NeutralHostileSetup
  {
    /// <summary>
    /// Grants all units controlled by Illidan to Neutral Hostile, then gives the actual Illidan hero back to Illidan.
    /// </summary>
    public static void Setup()
    {
      if (IllidanSetup.Illidan == null) return;
      if (IllidanSetup.Illidan.Player == null) return;
      foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(IllidanSetup.Illidan.Player).EmptyToList())
      {
        unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      if (LegendNaga.LegendIllidan.Unit != null) 
        LegendNaga.LegendIllidan.Unit.SetOwner(IllidanSetup.Illidan.Player);
    }
  }
}