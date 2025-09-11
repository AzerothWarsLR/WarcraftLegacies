using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Shared;
using static WCSharp.Api.Blizzard;

namespace WarcraftLegacies.Source.Setup
{
  public static class NeutralVictimAndPassiveSetup
  {
    private static List<unit> _hideUnit;

    private static void Unally(player sourcePlayer, player otherPlayer)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_PASSIVE, false);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_REQUEST, false);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_RESPONSE, false);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_XP, false);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_SPELLS, false);
    }
    
    public static void Setup()
    {
      _hideUnit = Regions.HideUnitBottomLeft.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      foreach (var player in Util.EnumeratePlayers())
      {
        Unally(player, Player(bj_PLAYER_NEUTRAL_VICTIM));
        Unally(Player(bj_PLAYER_NEUTRAL_VICTIM), player);
        SetPlayerAlliance(player, Player(27), ALLIANCE_PASSIVE, true);
        SetPlayerAlliance(player, Player(27), ALLIANCE_SHARED_VISION, false);
        SetPlayerAlliance(player, Player(26), ALLIANCE_PASSIVE, true);
        SetPlayerAlliance(player, Player(26), ALLIANCE_SHARED_VISION, false);

      }
    }
  }
}