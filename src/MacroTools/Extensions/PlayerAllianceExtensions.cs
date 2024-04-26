using System;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Extensions
{
  public static class PlayerAllianceExtensions
  {
    /// <summary>
    /// Sets a player's alliance state towards another player.
    /// </summary>
    public static void SetAllianceState(this player sourcePlayer, player otherPlayer, AllianceState allianceState)
    {
      // Prevent players from attempting to ally with themselves.
      if (sourcePlayer == otherPlayer) return;

      switch (allianceState)
      {
        case AllianceState.Unallied:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, false);
          break;
        case AllianceState.Allied:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, false);
          break;
        case AllianceState.AlliedVision:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
          break;
        case AllianceState.UnalliedVision:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(allianceState), allianceState, null);
      }
      
      PlayerData.ByHandle(sourcePlayer).SignalAllianceChange();
    }
    
    /// <summary>
    /// Sets whether or not one player controls another player.
    /// </summary>
    public static void SetPlayerAllianceStateFullControl(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_CONTROL, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_ADVANCED_CONTROL, flag);
    }

    private static void SetPlayerAllianceStateAlly(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_PASSIVE, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_REQUEST, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_RESPONSE, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_XP, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_SPELLS, flag);
    }

    private static void SetPlayerAllianceStateVision(this player sourcePlayer, player otherPlayer, bool flag) =>
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_VISION, flag);
  }
}