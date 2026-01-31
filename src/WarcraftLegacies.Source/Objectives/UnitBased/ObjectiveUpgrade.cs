using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

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
