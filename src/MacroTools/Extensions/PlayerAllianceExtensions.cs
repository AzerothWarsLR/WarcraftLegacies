using System;
using MacroTools.Factions;

namespace MacroTools.Extensions;

public static class PlayerAllianceExtensions
{
  /// <summary>
  /// Sets a player's alliance state towards another player.
  /// </summary>
  public static void SetAllianceState(this player sourcePlayer, player otherPlayer, AllianceState allianceState)
  {
    // Prevent players from attempting to ally with themselves.
    if (sourcePlayer == otherPlayer)
    {
      return;
    }

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
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedControl, flag);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedControlAdvanced, flag);
  }

  private static void SetPlayerAllianceStateAlly(this player sourcePlayer, player otherPlayer, bool flag)
  {
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.Passive, flag);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.HelpRequest, flag);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.HelpResponse, flag);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedExperience, flag);
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedSpells, flag);
  }

  private static void SetPlayerAllianceStateVision(this player sourcePlayer, player otherPlayer, bool flag) =>
    sourcePlayer.SetAlliance(otherPlayer, alliancetype.SharedVision, flag);
}
