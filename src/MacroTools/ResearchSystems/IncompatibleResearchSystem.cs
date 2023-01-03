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
    /// Registers an <see cref="IncompatibleResearchSystem"/> to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void Register(params int[] researches)
    {
      foreach (var outerResearch in researches)
      {
        PlayerUnitEvents.Register(ResearchEvent.IsStarted, () =>
        {
          foreach (var innerResearch in researches)
          {
            if (innerResearch != GetResearched())
            {
              GetTriggerPlayer().ModObjectLimit(innerResearch, -BigNumber);
            }
          }
        }, outerResearch);
        
        PlayerUnitEvents.Register(ResearchEvent.IsCancelled, () =>
        {
          foreach (var innerResearch in researches)
          {
            if (innerResearch != GetResearched())
            {
              GetTriggerPlayer().ModObjectLimit(innerResearch, BigNumber);
            }
          }
        }, outerResearch);
      }
    }
  }
}