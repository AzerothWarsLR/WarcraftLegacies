using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.DialogueSystem;
using MacroTools.Save;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions;

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
  public static void PingLocation(this player whichPlayer, Point position, float duration)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      PingMinimap(position.X, position.Y, duration);
    }
  }

  /// <summary>
  /// Rescues all <paramref name="units"/> for <paramref name="newOwningPlayer"/>.
  /// </summary>
  /// <param name="newOwningPlayer">The player who should own the units after being rescued</param>
  /// <param name="units">The units to rescue.</param>
  public static void RescueGroup(this player? newOwningPlayer, List<unit> units)
  {
    newOwningPlayer ??= player.NeutralAggressive;

    foreach (var unit in units)
    {
      unit.Rescue(newOwningPlayer);
    }
  }

  internal static void SetColorAndChangeExisting(this player whichPlayer, playercolor color)
  {
    whichPlayer.Color = color;
    foreach (var unit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      unit.SetColor(color);
    }
  }

  public static PlayerData GetPlayerData(this player player) => PlayerData.ByHandle(player);

  /// <summary>
  /// Safely removes all of the player's units.
  /// <para>Units that cannot be safely removed are instead turned hostile.</para>
  /// </summary>
  public static void RemoveAllUnits(this player whichPlayer)
  {
    var hostilePlayer = player.NeutralAggressive;
    foreach (var unit in GlobalGroup
               .EnumUnitsOfPlayer(whichPlayer))
    {
      if (unit.IsRemovable())
      {
        unit.SafelyRemove();
      }
      else
      {
        unit.SetOwner(hostilePlayer);
      }
    }
  }

  /// <summary>
  /// Selects the specified unit for the player.
  /// </summary>
  public static void Select(this player whichPlayer, unit whichUnit)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      whichUnit.Select();
    }
  }

  /// <summary>
  /// Flashes the quest menu for the player.
  /// </summary>
  public static void FlashQuests(this player whichPlayer)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      FlashQuestDialogButton();
    }
  }

  /// <summary>
  /// Returns cross-game settings set by the player.
  /// </summary>
  internal static PlayerSettings GetPlayerSettings(this player whichPlayer) =>
    PlayerData.ByHandle(whichPlayer).PlayerSettings;
}
