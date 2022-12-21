using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives
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