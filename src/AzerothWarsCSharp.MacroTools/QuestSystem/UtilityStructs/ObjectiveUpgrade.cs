using WCSharp.Events;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveUpgrade : Objective
  {
    public ObjectiveUpgrade(int objectId, int upgradeFromId)
    {
      Description = "Upgrade your " + GetObjectName(upgradeFromId) + " to a " + GetObjectName(objectId);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesUpgrade, OnUpgrade, objectId);
    }

    private void OnUpgrade()
    {
      Progress = QuestProgress.Complete;
    }
  }
}