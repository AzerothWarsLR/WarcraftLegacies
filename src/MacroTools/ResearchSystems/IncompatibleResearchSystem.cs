using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ResearchSystems
{
  /// <summary>
  /// A system for making a set of researches mutually exclusive with each other.
  /// This means that if one of the researches is started, the others are disabled,
  /// and only re-enabled if the first research is cancelled.
  /// </summary>
  public static class IncompatibleResearchSystem
  {
    /// <summary>
    /// Used to disable and enable techs via addition and subtraction.
    /// </summary>
    private const int BigNumber = 5000;

    /// <summary>
    /// Registers a set of incompatible researches to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void Register(params int[] researchTypeIds)
    {
      var researches = researchTypeIds.Select(x => new BasicResearch(x, 0, 0) as Research).ToArray();
      Register(researches);
    }
    
    /// <summary>
    /// Registers a set of incompatible researches to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void Register(params Research[] researches)
    {
      foreach (var outerResearch in researches)
      {
        SetupStartedTrigger(outerResearch, researches);
        SetupCancelledTrigger(outerResearch, researches);
        SetupFinishedTrigger(outerResearch, researches);
      }
    }

    private static void SetupStartedTrigger(Research outerResearch, Research[] researches)
    {
      PlayerUnitEvents.Register(ResearchEvent.IsStarted, () =>
      {
        try
        {
          foreach (var otherResearch in researches)
            if (otherResearch.ResearchTypeId != outerResearch.ResearchTypeId)
              GetTriggerPlayer().ModObjectLimit(otherResearch.ResearchTypeId, -BigNumber);
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
            if (otherResearch.ResearchTypeId != outerResearch.ResearchTypeId)
              GetTriggerPlayer().ModObjectLimit(otherResearch.ResearchTypeId, BigNumber);
        }
        catch (Exception ex)
        {
          Logger.LogWarning(ex.ToString());
        }
      }, outerResearch.ResearchTypeId);
    }

    private static void SetupFinishedTrigger(Research research, Research[] otherResearches)
    {
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
      {
        try
        {
          var triggerPlayer = GetTriggerPlayer();
          Console.WriteLine($"Processing {GetObjectName(research.ResearchTypeId)}");
          if (!ShouldRefund(triggerPlayer, research, otherResearches))
          {
            Console.WriteLine($"Don't refund {GetObjectName(research.ResearchTypeId)}");
            return;
          }
          research.OnUnresearch(triggerPlayer);
          triggerPlayer.AddGold(research.GoldCost);
          triggerPlayer.AddLumber(research.LumberCost);
          CreateTimer().Start(0.3f, false, () =>
          {
            Console.WriteLine($"Refund {GetObjectName(research.ResearchTypeId)}");
            triggerPlayer.SetObjectLevel(research.ResearchTypeId, 0);
            DestroyTimer(GetExpiredTimer());
          });
        }
        catch (Exception ex)
        {
          Logger.LogWarning(ex.ToString());
        }
      }, research.ResearchTypeId);
    }

    /// <summary>
    /// Returns true if any other research in the group has already been researched.
    /// </summary>
    private static bool ShouldRefund(player researchingPlayer, Research primaryResearch, IEnumerable<Research> otherResearches) => 
      otherResearches.Any(x => GetPlayerTechCount(researchingPlayer, x.ResearchTypeId, true) > 0 && x != primaryResearch);
  }
}