using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives
{
  public class ObjectiveResearch : Objective
  {
    public ObjectiveResearch(int researchId, int structureId)
    {
      Description = "Research " + GetObjectName(researchId) + " from the " + GetObjectName(structureId);
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, OnAnyResearch, researchId);
    }

    private void OnAnyResearch()
    {
      if (EligibleFactions.Contains(GetOwningPlayer(GetTriggerUnit()))) Progress = QuestProgress.Complete;
    }
  }
}