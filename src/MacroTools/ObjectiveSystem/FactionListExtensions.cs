using System.Collections.Generic;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem
{
  /// <summary>
  /// Extension for a list of factions
  /// </summary>
  public static class FactionListExtensions
  {
    /// <summary>
    /// Checks if any one the factions in <paramref name="factionList"/> are controlled by player <paramref name="whichPlayer"/>
    /// </summary>
    /// <param name="factionList"></param>
    /// <param name="whichPlayer"></param>
    /// <returns></returns>
    public static bool? Contains(this List<Faction> factionList, player? whichPlayer)
    {
      foreach (var faction in factionList)
      {
        if (faction.Player == null)
        {
          continue;
        }
        else if (faction.Player == Player(PLAYER_NEUTRAL_PASSIVE) || faction.Player == Player(PLAYER_NEUTRAL_AGGRESSIVE))
        {
          return null;
        }
        if (faction.Player == whichPlayer)
        {
          return true;
        }
      }
      return false;
    }
  }
}