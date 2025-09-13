using MacroTools.QuestSystem;
using WCSharp.Events;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  public sealed class ObjectiveUpgrade : Objective
  {
    public ObjectiveUpgrade(int objectId, int upgradeFromId)
    {
      Description = "Upgrade your " + GetObjectName(upgradeFromId) + " to a " + GetObjectName(objectId);
      PlayerUnitEvents.Register(UnitTypeEvent.FinishesUpgrade, OnUpgrade, objectId);
    }

    private void OnUpgrade()
    {
      Progress = QuestProgress.Complete;
    }
  }
}