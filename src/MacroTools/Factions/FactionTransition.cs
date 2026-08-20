using MacroTools.Extensions;

namespace MacroTools.Factions;

/// <summary>
/// Reusable steps for transforming a player's <see cref="Faction"/> mid-game.
/// </summary>
public static class FactionTransition
{
  /// <summary>
  /// Swaps a player from <paramref name="oldFaction"/> to <paramref name="newFaction"/>, carrying over
  /// object levels and registering the new Faction. Doesn't touch units, teams, or alliances.
  /// </summary>
  public static void AssignNewFaction(Faction oldFaction, Faction newFaction)
  {
    newFaction.CopyObjectLevelsFrom(oldFaction);

    if (oldFaction.Player != null)
    {
      oldFaction.Player.GetPlayerData().Faction = newFaction;
    }

    FactionManager.Register(newFaction);
  }
}
