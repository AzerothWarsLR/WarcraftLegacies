using System.Collections.Generic;
using System.Linq;
using MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ResearchSystems
{
  /// <summary>
  /// An IncompatibleResearchSet is a list of Researchs which are mutually exclusive with each other.
  /// This means that if one of these Researchs is started, the other 2 are disabled
  /// and only re-enabled if the first research is cancelled.
  /// </summary>
  public sealed class IncompatibleResearchSet
  {
    /// <summary>
    /// Used to disable and enable techs via addition and subtraction.
    /// </summary>
    private const int BigNumber = 5000;

    private readonly List<int> _researches;

    /// <summary>
    /// Initializes a new instance of the <see cref="IncompatibleResearchSet"/> class.
    /// </summary>
    /// <param name="researches">The researches which should be mutually exclusive.</param>
    public IncompatibleResearchSet(params int[] researches)
    {
      _researches = researches.ToList();
    }

    /// <summary>
    /// Registers an <see cref="IncompatibleResearchSet"/> to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void Register(params int[] researches)
    {
      var newIncompatibleResearchSet = new IncompatibleResearchSet(researches);
      Register(newIncompatibleResearchSet);
    }
    
    /// <summary>
    /// Registers an <see cref="IncompatibleResearchSet"/> to the system, causing the reseaches contained within to be
    /// mutually exclusive.
    /// </summary>
    public static void Register(IncompatibleResearchSet incompatibleResearchSet)
    {
      foreach (var research in incompatibleResearchSet._researches)
      {
        PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsStarted, incompatibleResearchSet.DisableResearches, research);
        PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsCancelled, incompatibleResearchSet.EnableResearches, research);
      }
    }
    
    /// <summary>
    /// Disables all of the mutually exclusive researches contained within this set.
    /// </summary>
    private void DisableResearches()
    {
      foreach (var research in _researches)
      {
        if (research != GetResearched())
        {
          GetTriggerPlayer().ModObjectLimit(research, -BigNumber);
        }
      }
    }

    /// <summary>
    /// Enables all of the mutually exclusive researches contained within this set.
    /// </summary>
    private void EnableResearches()
    {
      foreach (var research in _researches)
      {
        if (research != GetResearched())
        {
          GetTriggerPlayer().ModObjectLimit(research, BigNumber);
        }
      }
    }
  }
}