using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

public sealed class ObjectiveUpgrade : Objective
{
  public ObjectiveUpgrade(int objectId, int upgradeFromId)
  {
    SetDescription(
      "Upgrade your {from} to a {to}",
      ("{from}", GetObjectName(upgradeFromId)),
      ("{to}", GetObjectName(objectId)));
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesUpgrade, OnUpgrade, objectId);
  }

  private void OnUpgrade()
  {
    Progress = QuestProgress.Complete;
  }
}
