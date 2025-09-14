using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.Save;
using MacroTools.Utils;
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
    /// Queues the <see cref="IHasPlayableDialogue"/> for this player, playing it the next time there is nothing else playing.
    /// </summary>
    public static void QueueDialogue(this player whichPlayer, IHasPlayableDialogue dialogue) =>
      PlayerData.ByHandle(whichPlayer).QueueDialogue(dialogue);

    /// <summary>
    /// Set the number of extra <see cref="ControlPoint.ControlLevel"/>s the player gets each turn.
    /// </summary>
    /// <returns></returns>
    public static void SetControlLevelPerTurnBonus(this player whichPlayer, float value)
    {
      PlayerData.ByHandle(whichPlayer).ControlLevelPerTurnBonus = value;
    }

    /// <summary>
    /// Returns the number of extra <see cref="ControlPoint.ControlLevel"/>s the player gets each turn.
    /// </summary>
    public static float GetControlLevelPerTurnBonus(this player whichPlayer) =>
      PlayerData.ByHandle(whichPlayer).ControlLevelPerTurnBonus;

    /// <summary>
    /// Pings the minimap for the player.
    /// </summary>
    /// <param name="whichPlayer">Who to display the ping to.</param>
    /// <param name="position">Where to ping.</param>
    /// <param name="duration">How long the ping should last.</param>
    /// <returns>The same player that was passed in.</returns>
    public static void PingLocation(this player whichPlayer, Point position, float duration)
    {
      if (GetLocalPlayer() == whichPlayer)
        PingMinimap(position.X, position.Y, duration);
    }

    /// <summary>
    /// Returns the maximum number of units the player can build of the given type, or the maximum research level
    /// the player can achieve for the given type.
    /// </summary>
    /// <param name="player">The player in question.</param>
    /// <param name="objectId">The unit type ID or research ID we want to know about.</param>
    public static int GetObjectLimit(this player player, int objectId) =>
      PlayerData.ByHandle(player).GetObjectLimit(objectId);

    /// <summary>Returns the number of <see cref="ControlPoint"/>s a player controls.</summary>
    public static int GetControlPointCount(this player player) => PlayerData.ByHandle(player).ControlPoints.Count;

    /// <summary>Returns the number of <see cref="ControlPoint"/>s a player controls.</summary>
    public static List<ControlPoint> GetControlPoints(this player player) => PlayerData.ByHandle(player).ControlPoints;

    /// <summary>Returns the player's <see cref="Team"/>.</summary>
    public static Team? GetTeam(this player player) => PlayerData.ByHandle(player).Team;

    /// <summary>Sets the player's <see cref="Team"/>.</summary>
    public static void SetTeam(this player player, Team? whichTeam) => PlayerData.ByHandle(player).SetTeam(whichTeam);

    /// <summary>Returns the player's <see cref="Faction"/>.</summary>
    public static Faction? GetFaction(this player player) => PlayerData.ByHandle(player).Faction;

    /// <summary>Sets the player's <see cref="Faction"/>.</summary>
    public static void SetFaction(this player player, Faction faction) => PlayerData.ByHandle(player).Faction = faction;

    /// <summary>Returns the player's gold income, including any bonuses.</summary>
    public static float GetTotalIncome(this player player) => PlayerData.ByHandle(player).TotalIncome;

    /// <summary>Returns the player's bonus gold income.</summary>
    public static float GetBonusIncome(this player player) => PlayerData.ByHandle(player).BonusIncome;

    /// <summary>Returns the player's gold income, without any bonuses.</summary>
    public static float GetBaseIncome(this player player) => PlayerData.ByHandle(player).BaseIncome;

    /// <summary>Modifies the player's bonus income.</summary>
    public static void AddBonusIncome(this player player, float value) =>
      PlayerData.ByHandle(player).BonusIncome += value;

    /// <summary>
    /// Rescues all <paramref name="units"/> for <paramref name="newOwningPlayer"/>.
    /// </summary>
    /// <param name="newOwningPlayer">The player who should own the units after being rescued</param>
    /// <param name="units">The units to rescue.</param>
    public static void RescueGroup(this player? newOwningPlayer, List<unit> units)
    {
      newOwningPlayer ??= Player(PLAYER_NEUTRAL_AGGRESSIVE);

      foreach (var unit in units)
        unit.Rescue(newOwningPlayer);
    }

    internal static void SetObjectLevel(this player player, int objectId, int level) =>
      PlayerData.ByHandle(player).SetObjectLevel(objectId, level);

    internal static void ModObjectLimit(this player player, int objectId, int limit) =>
      PlayerData.ByHandle(player).ModObjectLimit(objectId, limit);

    internal static void SetObjectLimit(this player player, int objectId, int limit) =>
      PlayerData.ByHandle(player).SetObjectLimit(objectId, limit);

    internal static void SetColorAndChangeExisting(this player whichPlayer, playercolor color)
    {
      SetPlayerColor(whichPlayer, color);
      foreach (var unit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
        SetUnitColor(unit, color);
    }

    internal static PlayerData GetPlayerData(this player player) =>
      PlayerData.ByHandle(player);

    /// <summary>
    /// Safely removes all of the player's units.
    /// <para>Units that cannot be safely removed are instead turned hostile.</para>
    /// </summary>
    public static void RemoveAllUnits(this player whichPlayer)
    {
      var hostilePlayer = Player(PLAYER_NEUTRAL_AGGRESSIVE);
      foreach (var unit in GlobalGroup
                 .EnumUnitsOfPlayer(whichPlayer))
      {
        if (unit.IsRemovable())
          unit.SafelyRemove();
        else
          SetUnitOwner(unit, hostilePlayer, true);
      }
    }

    /// <summary>
    /// Selects the specified unit for the player.
    /// </summary>
    public static void Select(this player whichPlayer, unit whichUnit)
    {
      if (GetLocalPlayer() == whichPlayer)
        SelectUnit(whichUnit, true);
    }

    /// <summary>
    /// Flashes the quest menu for the player.
    /// </summary>
    public static void FlashQuests(this player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        FlashQuestDialogButton();
    }

    /// <summary>
    /// Returns cross-game settings set by the player.
    /// </summary>
    internal static PlayerSettings GetPlayerSettings(this player whichPlayer) =>
      PlayerData.ByHandle(whichPlayer).PlayerSettings;
  }
}