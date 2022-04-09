using WCSharp.Events;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemResearch : QuestItemData
  {
    public QuestItemResearch(int researchId, int structureId)
    {
      Description = "Research " + GetObjectName(researchId) + " from the " + GetObjectName(structureId);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, OnAnyResearch, researchId);
    }

    private void OnAnyResearch()
    {
      if (Holder.Player == GetOwningPlayer(GetTriggerUnit()))
      {
        Progress = QuestProgress.Complete;
      }
    }
  }
}