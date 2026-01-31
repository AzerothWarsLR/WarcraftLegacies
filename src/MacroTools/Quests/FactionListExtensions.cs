using System.Collections.Generic;
using MacroTools.Factions;

namespace MacroTools.Quests;

/// <summary>
/// Extension for a list of factions
/// </summary>
public static class FactionListExtensions
{
  /// <summary>
  /// Checks if any one the <see cref="Faction"/>s in <paramref name="factionList"/> are controlled by player
  /// <paramref name="whichPlayer"/>.
  /// </summary>
  public static bool Contains(this List<Faction> factionList, player? whichPlayer)
  {
    if (whichPlayer == null)
    {
      return false;
    }

    foreach (var faction in factionList)
    {
      if (faction.Player == whichPlayer)
      {
        return true;
      }
    }

    return false;
  }
}
