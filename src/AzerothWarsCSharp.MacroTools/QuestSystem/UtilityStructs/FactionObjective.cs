using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public abstract class FactionObjective : Objective
  {
    protected List<Faction> EligibleFactions { get; } = new();

    public bool IsPlayerOnSameTeamAsAnyEligibleFaction(player whichPlayer)
    {
      foreach (var eligibleFaction in EligibleFactions)
      {
        if (eligibleFaction.Team == whichPlayer.GetFaction()?.Team)
        {
          return true;
        }
      }
      return false;
    }
    
    internal void AddEligibleFaction(Faction faction)
    {
      EligibleFactions.Add(faction);
    }
  }
}