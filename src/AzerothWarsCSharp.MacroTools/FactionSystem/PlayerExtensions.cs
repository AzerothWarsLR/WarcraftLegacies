using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public static class PlayerExtensions
  {
    public static void SetColor(this player whichPlayer, playercolor color, bool changeExisting)
    {
      SetPlayerColor(whichPlayer, color);
      if (changeExisting)
      {
        foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(whichPlayer).EmptyToList())
        {
          SetUnitColor(unit, color);
        }
      }
    }

    public static void SetAllianceState(this player sourcePlayer, player otherPlayer, AllianceState allianceState)
    {
      // Prevent players from attempting to ally with themselves.
      if (sourcePlayer == otherPlayer)
      {
        return;
      }

      if (allianceState == AllianceState.UnalliedVision)
      {
        sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, false);
        sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
        sourcePlayer.SetPlayerAllianceStateControl(otherPlayer, false);
        sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, false);
      }
      else if (allianceState == AllianceState.AlliedVision)
      {
        sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, true);
        sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
        sourcePlayer.SetPlayerAllianceStateControl(otherPlayer, false);
        sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, false);
      }
      else if (allianceState == AllianceState.AlliedAdvUnits)
      {
        sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, true);
        sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
        sourcePlayer.SetPlayerAllianceStateControl(otherPlayer, true);
        sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, true);
      }
    }

    public static void SetPlayerAllianceStateAlly(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_PASSIVE, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_REQUEST, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_RESPONSE, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_XP, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_SPELLS, flag);
    }

    public static void SetPlayerAllianceStateVision(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_VISION, flag);
    }

    public static void SetPlayerAllianceStateControl(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_CONTROL, flag);
    }

    public static void SetPlayerAllianceStateFullControl(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_ADVANCED_CONTROL, flag);
    }

    public static void AdjustPlayerState(this player player, playerstate playerState, int value)
    {
      SetPlayerState(player, playerState, GetPlayerState(player, playerState) + value);
    }

    public static int GetObjectLimit(this player player, int objectId)
    {
      return PlayerData.ByHandle(player).GetObjectLimit(objectId);
    }

    internal static void SetControlPointCount(this player player, int value)
    {
      PlayerData.ByHandle(player).ControlPointCount = value;
    }

    public static int GetControlPointCount(this player player)
    {
      return PlayerData.ByHandle(player).ControlPointCount;
    }

    public static void AddGold(this player player, float gold)
    {
      PlayerData.ByHandle(player).AddGold(gold);
    }

    public static void SetObjectLevel(this player player, int objectId, int level)
    {
      PlayerData.ByHandle(player).SetObjectLevel(objectId, level);
    }

    public static void ModObjectLimit(this player player, int objectId, int limit)
    {
      PlayerData.ByHandle(player).ModObjectLimit(objectId, limit);
    }

    public static Faction? GetFaction(this player player)
    {
      return PlayerData.ByHandle(player).Faction;
    }

    public static void SetFaction(this player player, Faction faction)
    {
      PlayerData.ByHandle(player).Faction = faction;
    }

    public static float GetTotalIncome(this player player)
    {
      return PlayerData.ByHandle(player).TotalIncome;
    }

    public static float GetBonusIncome(this player player)
    {
      return PlayerData.ByHandle(player).BonusIncome;
    }
    
    public static float GetBaseIncome(this player player)
    {
      return PlayerData.ByHandle(player).BaseIncome;
    }

    public static void SetBaseIncome(this player player, float value)
    {
      PlayerData.ByHandle(player).BaseIncome = value;
    }

    public static void AddBonusIncome(this player player, float value)
    {
      PlayerData.ByHandle(player).BonusIncome += value;
    }
  }
}