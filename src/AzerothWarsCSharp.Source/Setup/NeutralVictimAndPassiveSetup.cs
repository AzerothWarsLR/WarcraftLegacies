using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class NeutralVictimAndPassiveSetup
  {
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
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        Unally(player, Player(bj_PLAYER_NEUTRAL_VICTIM));
        Unally(Player(bj_PLAYER_NEUTRAL_VICTIM), player);
      }
    }
  }
}