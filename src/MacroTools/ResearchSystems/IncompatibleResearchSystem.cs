using System;
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
      var researches = researchTypeIds.Select(x => new BasicResearch(x) as Research).ToArray();
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
        PlayerUnitEvents.Register(ResearchEvent.IsStarted, () =>
        {
          try
          {
            foreach (var innerResearch in researches)
              if (innerResearch.ResearchTypeId != GetResearched())
                GetTriggerPlayer().ModObjectLimit(innerResearch.ResearchTypeId, -BigNumber);
          }
          catch (Exception ex)
          {
            Logger.LogWarning(ex.ToString());
          }
        }, outerResearch.ResearchTypeId);

        PlayerUnitEvents.Register(ResearchEvent.IsCancelled, () =>
        {
          try
          {
            foreach (var innerResearch in researches)
              if (innerResearch.ResearchTypeId != GetResearched())
                GetTriggerPlayer().ModObjectLimit(innerResearch.ResearchTypeId, BigNumber);
          }
          catch (Exception ex)
          {
            Logger.LogWarning(ex.ToString());
          }
        }, outerResearch.ResearchTypeId);

        PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
        {
          try
          {
            foreach (var innerResearch in researches)
              if (innerResearch.ResearchTypeId != GetResearched())
              {
                innerResearch.OnUnresearch(GetTriggerPlayer());
                GetTriggerPlayer().SetObjectLevel(innerResearch.ResearchTypeId, 0);
              }
          }
          catch (Exception ex)
          {
            Logger.LogWarning(ex.ToString());
          }
        }, outerResearch.ResearchTypeId);
      }
    }
  }
}