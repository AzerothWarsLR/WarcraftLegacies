using System;
using AzerothWarsCSharp.MacroTools.Wrappers;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public static class PlayerExtensions
  {
    public static void ApplyCameraField(this player whichPlayer, camerafield whichField, float value, float duration)
    {
      if (GetLocalPlayer() != whichPlayer) return;
      SetCameraField(whichField, value, duration);
    }

    /// <summary>
    ///   Changes the player's view to come out of a certain camera.
    /// </summary>
    public static void SetupCamera(this player whichPlayer, camerasetup whichSetup, bool doPan, float duration)
    {
      if (GetLocalPlayer() != whichPlayer) return;
      CameraSetupApplyForceDuration(whichSetup, doPan, duration);
    }

    /// <summary>
    ///   Prevents the player from moving their camera out of the provided area.
    /// </summary>
    public static void SetCameraLimits(this player whichPlayer, rect rect)
    {
      if (GetLocalPlayer() != whichPlayer) return;
      var minX = GetRectMinX(rect);
      var minY = GetRectMinY(rect);
      var maxX = GetRectMaxX(rect);
      var maxY = GetRectMaxY(rect);
      SetCameraBounds(minX, minY, minX, maxY, maxX, maxY, maxX, minY);
    }

    public static void SetAllianceState(this player sourcePlayer, player otherPlayer, AllianceState allianceState)
    {
      // Prevent players from attempting to ally with themselves.
      if (sourcePlayer == otherPlayer) return;

      switch (allianceState)
      {
        case AllianceState.Unallied:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateControl(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, false);
          break;
        case AllianceState.AlliedVision:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateControl(otherPlayer, false);
          sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, false);
          break;
        case AllianceState.AlliedAdvUnits:
          sourcePlayer.SetPlayerAllianceStateAlly(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateVision(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateControl(otherPlayer, true);
          sourcePlayer.SetPlayerAllianceStateFullControl(otherPlayer, true);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(allianceState), allianceState, null);
      }
    }

    public static void AdjustPlayerState(this player player, playerstate playerState, int value)
    {
      SetPlayerState(player, playerState, GetPlayerState(player, playerState) + value);
    }

    public static int GetObjectLimit(this player player, int objectId)
    {
      return PlayerData.ByHandle(player).GetObjectLimit(objectId);
    }

    public static int GetControlPointCount(this player player)
    {
      return PlayerData.ByHandle(player).ControlPointCount;
    }

    public static void AddGold(this player player, float gold)
    {
      PlayerData.ByHandle(player).AddGold(gold);
    }

    public static void AddLumber(this player player, float lumber)
    {
      PlayerData.ByHandle(player).AddLumber(lumber);
    }

    public static Team? GetTeam(this player player)
    {
      return PlayerData.ByHandle(player).Team;
    }

    public static void SetTeam(this player player, Team whichTeam)
    {
      PlayerData.ByHandle(player).Team = whichTeam;
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

    public static float GetLumberIncome(this player player)
    {
      return PlayerData.ByHandle(player).LumberIncome;
    }

    public static void SetBaseIncome(this player player, float value)
    {
      PlayerData.ByHandle(player).BaseIncome = value;
    }

    public static void AddBonusIncome(this player player, float value)
    {
      PlayerData.ByHandle(player).BonusIncome += value;
    }

    public static void AddLumberIncome(this player player, float value)
    {
      PlayerData.ByHandle(player).LumberIncome += value;
    }
    
    internal static void SetControlPointCount(this player player, int value)
    {
      PlayerData.ByHandle(player).ControlPointCount = value;
    }
    
    /// <summary>
    ///   Determines whether or not the player can see or use the specified ability.
    /// </summary>
    internal static void SetAbilityAvailability(this player player, int ability, bool value)
    {
      SetPlayerAbilityAvailable(player, ability, value);
    }

    internal static void SetObjectLevel(this player player, int objectId, int level)
    {
      PlayerData.ByHandle(player).SetObjectLevel(objectId, level);
    }

    internal static void ModObjectLimit(this player player, int objectId, int limit)
    {
      PlayerData.ByHandle(player).ModObjectLimit(objectId, limit);
    }
    
    internal static void SetColor(this player whichPlayer, playercolor color, bool changeExisting)
    {
      SetPlayerColor(whichPlayer, color);
      if (!changeExisting) return;
      foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(whichPlayer).EmptyToList())
        SetUnitColor(unit, color);
    }
    
    internal static PlayerData GetPlayerData(this player player)
    {
      return PlayerData.ByHandle(player);
    }

    private static void SetPlayerAllianceStateAlly(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_PASSIVE, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_REQUEST, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_HELP_RESPONSE, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_XP, flag);
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_SPELLS, flag);
    }

    private static void SetPlayerAllianceStateVision(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_VISION, flag);
    }

    private static void SetPlayerAllianceStateControl(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_CONTROL, flag);
    }

    private static void SetPlayerAllianceStateFullControl(this player sourcePlayer, player otherPlayer, bool flag)
    {
      SetPlayerAlliance(sourcePlayer, otherPlayer, ALLIANCE_SHARED_ADVANCED_CONTROL, flag);
    }
  }
}