using MacroTools.ControlPoints;
using MacroTools.Extensions;

namespace MacroTools.Factions;

/// <summary>
/// Reusable steps for transforming a player's <see cref="Faction"/> mid-game.
/// </summary>
public static class FactionTransition
{
  /// <summary>
  /// Swaps a player from <paramref name="oldFaction"/> to <paramref name="newFaction"/>, carrying over
  /// object levels, registering the new Faction and giving its Control Points the new Faction's defenders.
  /// Doesn't touch other units, teams, or alliances.
  /// </summary>
  public static void AssignNewFaction(Faction oldFaction, Faction newFaction)
  {
    newFaction.CopyObjectLevelsFrom(oldFaction);

    var whichPlayer = oldFaction.Player;
    if (whichPlayer != null)
    {
      whichPlayer.GetPlayerData().Faction = newFaction;
    }

    FactionManager.Register(newFaction);
    if (whichPlayer != null && newFaction.ControlPointDefenderUnitTypeId != null)
    {
      ControlPointDefenderManager.RefreshDefenders(whichPlayer);
    }
  }
}
