using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class ObjectiveResearch : Objective
  {
    public ObjectiveResearch(int researchId, int structureId)
    {
      Description = "Research " + GetObjectName(researchId) + " from the " + GetObjectName(structureId);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, OnAnyResearch, researchId);
    }

    private void OnAnyResearch()
    {
      if (EligibleFactions.Contains(GetOwningPlayer(GetTriggerUnit()))) Progress = QuestProgress.Complete;
    }
  }
}