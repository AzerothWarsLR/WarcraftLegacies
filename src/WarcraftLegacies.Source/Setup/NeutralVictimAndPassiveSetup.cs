using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Setup;

public static class NeutralVictimAndPassiveSetup
{
  private static List<unit> _hideUnit;

  private static void Unally(player sourcePlayer, player otherPlayer)
  {
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.Passive, false);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.HelpRequest, false);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.HelpResponse, false);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedExperience, false);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedSpells, false);
  }

  public static void Setup()
  {
    _hideUnit = Regions.HideUnitBottomLeft.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    foreach (var player in Util.EnumeratePlayers())
    {
      Unally(player, player.NeutralVictim);
      Unally(player.NeutralVictim, player);
      player.SetAlliance(player.Create(27), alliancetype.Passive, true);
      player.SetAlliance(player.Create(27), alliancetype.SharedVision, false);
      player.SetAlliance(player.Create(26), alliancetype.Passive, true);
      player.SetAlliance(player.Create(26), alliancetype.SharedVision, false);

    }
  }
}
