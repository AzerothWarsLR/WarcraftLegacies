using System;
using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Extensions
{
  /// <summary>
  /// A set of helpful extension methods for dealing with Warcraft 3's native player class.
  /// </summary>
  public static class PlayerExtensions
  {
    /// <summary>
    /// Set the number of extra <see cref="ControlPoint.ControlLevel"/>s the player gets each turn.
    /// </summary>
    /// <returns></returns>
    public static player SetControlLevelPerTurnBonus(this player whichPlayer, int value)
    {
      PlayerData.ByHandle(whichPlayer).ControlLevelPerTurnBonus = value;
      return whichPlayer;
    }
    
    /// <summary>
    /// Returns the number of extra <see cref="ControlPoint.ControlLevel"/>s the player gets each turn.
    /// </summary>
    /// <returns></returns>
    public static int GetControlLevelPerTurnBonus(this player whichPlayer)
    {
      return PlayerData.ByHandle(whichPlayer).ControlLevelPerTurnBonus;
    }
    
    /// <summary>
    /// Pings the minimap for the player.
    /// </summary>
    /// <param name="whichPlayer">Who to display the ping to.</param>
    /// <param name="position">Where to ping.</param>
    /// <param name="duration">How long the ping should last.</param>
    /// <returns>The same player that was passed in.</returns>
    public static player PingLocation(this player whichPlayer, Point position, float duration)
    {
      if (GetLocalPlayer() == whichPlayer)
        PingMinimap(position.X, position.Y, duration);
      return whichPlayer;
    }
    
    /// <summary>
    /// Replaces the minimap background texture with the specified one.
    /// </summary>
    public static void ChangeMinimapTerrainTexture(this player whichPlayer, string texturePath)
    {
      if (GetLocalPlayer() == whichPlayer) BlzChangeMinimapTerrainTex(texturePath);
    }

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

    /// <summary>
    /// Returns the maximum number of units the player can build of the given type, or the maximum research level
    /// the player can achieve for the given type.
    /// </summary>
    /// <param name="player">The player in question.</param>
    /// <param name="objectId">The unit type ID or research ID we want to know about.</param>
    public static int GetObjectLimit(this player player, int objectId) => GetPlayerTechMaxAllowed(player, objectId);

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
    /// Rescues all <paramref name="units"/> for <paramref name="newOwningPlayer"/>.
    /// </summary>
    /// <param name="newOwningPlayer">The player who should own the units after being rescued</param>
    /// <param name="units">The units to rescue.</param>
    public static void RescueGroup(this player newOwningPlayer, List<unit> units)
    {
      foreach (var unit in units) 
        unit.Rescue(newOwningPlayer);
    }

    /// <summary>
    /// Returns the amount of food the player is using.
    /// </summary>
    public static int GetFoodUsed(this player whichPlayer) =>
      GetPlayerState(whichPlayer, PLAYER_STATE_RESOURCE_FOOD_USED);

    /// <summary>
    /// Returns the player's food cap.
    /// </summary>
    public static int GetFoodCap(this player whichPlayer) =>
      GetPlayerState(whichPlayer, PLAYER_STATE_RESOURCE_FOOD_CAP);

    /// <summary>
    /// Returns player's food cap ceiling.
    /// </summary>
    public static int GetFoodCapCeiling(this player whichPlayer) =>
      GetPlayerState(whichPlayer, PLAYER_STATE_FOOD_CAP_CEILING);

    /// <summary>
    ///   Determines whether or not the player can see or use the specified ability.
    /// </summary>
    internal static void SetAbilityAvailability(this player player, int ability, bool value)
    {
      SetPlayerAbilityAvailable(player, ability, value);
    }

    internal static void SetObjectLevel(this player player, int objectId, int level, bool isResearch = false)
    {
      PlayerData.ByHandle(player).SetObjectLevel(objectId, level, isResearch);
    }

    internal static void ModObjectLimit(this player player, int objectId, int limit)
    {
      PlayerData.ByHandle(player).ModObjectLimit(objectId, limit);
    }
    
    internal static void SetColor(this player whichPlayer, playercolor color, bool changeExisting)
    {
      SetPlayerColor(whichPlayer, color);
      if (!changeExisting) return;
      foreach (var unit in CreateGroup().EnumUnitsOfPlayer(whichPlayer).EmptyToList())
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

    public static void DisplayHint(this player whichPlayer, string msg ){
      DisplayTextToPlayer(whichPlayer, 0, 0, $"\n|cff00ff00HINT|r - {msg}");
      if (GetLocalPlayer() == whichPlayer){
        StartSound(SoundLibrary.Hint);
      }
    }

    public static void DisplayHeroReward(this unit whichUnit, int strength, int agility, int intelligence, int experience ){
      var display = $"\n|cff00ff00HERO REWARD EARNED -{GetHeroProperName(whichUnit)}|r";
      if (strength > 0){
        display = $"{display}\n+{I2S(strength)} Strength";
      }
      if (agility > 0){
        display = $"{display}\n+{I2S(agility)} Agility";
      }
      if (intelligence > 0){
        display = $"{display}\n+{I2S(intelligence)} Intelligence";
      }
      if (experience > 0){
        display = $"{display}\n+{I2S(experience)} Experience";
      }
      DisplayTextToPlayer(GetOwningPlayer(whichUnit), 0, 0, display);
      if (GetLocalPlayer() == GetOwningPlayer(whichUnit)){
        StartSound(SoundLibrary.Hint);
      }
    }

    public static void DisplayUnitLimit(this Faction whichFaction, int unitTypeId ){
      DisplayTextToPlayer(whichFaction.Player, 0, 0,
        $"\n|cff00ff00UNIT LIMIT CHANGED - {GetObjectName(unitTypeId)}|r\nYou can now train up to {whichFaction.GetObjectLimit(unitTypeId)} {GetObjectName(unitTypeId)}s.");
      if (GetLocalPlayer() == whichFaction.Player){
        StartSound(SoundLibrary.Hint);
      }
    }

    public static void DisplayResearchAcquired(this player whichPlayer, int researchId, int researchLevel ){
      DisplayTextToPlayer(whichPlayer, 0, 0,
        $"\n|cff00ff00RESEARCH ACQUIRED - {GetObjectName(researchId)}|r\n{BlzGetAbilityExtendedTooltip(researchId, researchLevel)}");
      if (GetLocalPlayer() == whichPlayer){
        StartSound(SoundLibrary.Hint);
      }
    }

    public static void DisplayUnitTypeAcquired(this player whichPlayer, int unitId, string flavor ){
      DisplayTextToPlayer(whichPlayer, 0, 0,
        $"\n|cff00ff00NEW UNIT ACQUIRED - {GetObjectName(unitId)}\n|r{flavor}");
      if (GetLocalPlayer() == whichPlayer){
        StartSound(SoundLibrary.Hint);
      }
    }
    
    /// <summary>
    /// Indicates to the player that they have acquired a new <see cref="Power"/>.
    /// </summary>
    public static void DisplayPowerAcquired(this player whichPlayer, Power power){
      DisplayTextToPlayer(whichPlayer, 0, 0,
        $"\n|cff00ff00NEW POWER ACQUIRED - {power.Name}\n|r{power.Description}");
      if (GetLocalPlayer() == whichPlayer){
        StartSound(SoundLibrary.Hint);
      }
    }
  }
}