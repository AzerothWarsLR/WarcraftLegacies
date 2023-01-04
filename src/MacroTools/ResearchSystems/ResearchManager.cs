using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ResearchSystems
{
  /// <summary>
  /// Responsible for registering <see cref="Research"/>es.
  /// </summary>
  public static class ResearchManager
  {
    private static readonly List<Research> RegisteredResearches = new();
    
    /// <summary>
    /// Used to disable and enable techs via addition and subtraction.
    /// </summary>
    private const int BigNumber = 5000;

    /// <summary>
    /// Registers a  <see cref="Research"/>, causing its <see cref="Research.OnResearch"/> function to be executed when researched.
    /// </summary>
    public static void Register(Research research, Research[]? otherResearches = null)
    {
      if (RegisteredResearches.Contains(research))
        throw new InvalidOperationException($"{GetObjectName(research.ResearchTypeId)} has already been registered.");
      RegisteredResearches.Add(research);
      
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
      {
        try
        {
          var triggerPlayer = GetTriggerPlayer();
          if (otherResearches == null || !ShouldRefund(triggerPlayer, research, otherResearches))
          {
            research.OnResearch(triggerPlayer);
            return;
          }
          triggerPlayer.AddGold(research.GoldCost);
          triggerPlayer.AddLumber(research.LumberCost);
          triggerPlayer.SetObjectLevel(research.ResearchTypeId, 0);
        }
        catch (Exception ex)
        {
          Logger.LogWarning(ex.ToString());
        }
      }, research.ResearchTypeId);
    }
    
    /// <summary>
    /// Registers a set of incompatible researches to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void RegisterIncompatibleSet(params int[] researchTypeIds)
    {
      var researches = researchTypeIds.Select(x => new BasicResearch(x, 0, 0) as Research).ToArray();
      RegisterIncompatibleSet(researches);
    }

    /// <summary>
    /// Registers a set of incompatible researches to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void RegisterIncompatibleSet(params Research[] researches)
    {
      foreach (var outerResearch in researches)
      {
        SetupStartedTrigger(outerResearch, researches);
        SetupCancelledTrigger(outerResearch, researches);
        Register(outerResearch, researches);
      }
    }

    private static void SetupStartedTrigger(Research outerResearch, Research[] researches)
    {
      PlayerUnitEvents.Register(ResearchEvent.IsStarted, () =>
      {
        try
        {
          foreach (var otherResearch in researches)
            if (otherResearch.ResearchTypeId != outerResearch.ResearchTypeId && GetTriggerPlayer().GetObjectLevel(otherResearch.ResearchTypeId) < 1)
              GetTriggerPlayer().ModObjectLimit(otherResearch.ResearchTypeId, -BigNumber, true);
        }
        catch (Exception ex)
        {
          Logger.LogWarning(ex.ToString());
        }
      }, outerResearch.ResearchTypeId);
    }

    private static void SetupCancelledTrigger(Research outerResearch, Research[] researches)
    {
      PlayerUnitEvents.Register(ResearchEvent.IsCancelled, () =>
      {
        try
        {
          foreach (var otherResearch in researches)
            if (otherResearch.ResearchTypeId != outerResearch.ResearchTypeId && GetTriggerPlayer().GetObjectLevel(otherResearch.ResearchTypeId) < 1)
              GetTriggerPlayer().ModObjectLimit(otherResearch.ResearchTypeId, BigNumber, true);
        }
        catch (Exception ex)
        {
          Logger.LogWarning(ex.ToString());
        }
      }, outerResearch.ResearchTypeId);
    }

    /// <summary>
    /// Returns true if any other research in the group has already been researched.
    /// </summary>
    private static bool ShouldRefund(player researchingPlayer, Research primaryResearch, IEnumerable<Research> otherResearches) => 
      otherResearches.Any(x => GetPlayerTechCount(researchingPlayer, x.ResearchTypeId, true) > 0 && x != primaryResearch);
  }
}