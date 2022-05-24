using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public static class FactionListExtensions
  {
    public static bool Contains(this List<Faction> factionList, player? whichPlayer)
    {
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
}