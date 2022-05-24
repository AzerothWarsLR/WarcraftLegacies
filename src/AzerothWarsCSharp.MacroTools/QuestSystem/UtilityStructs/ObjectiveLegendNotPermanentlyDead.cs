using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveLegendNotPermanentlyDead : Objective
  {
    private readonly Legend _target;

    public ObjectiveLegendNotPermanentlyDead(Legend target)
    {
      _target = target;
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE))
        Description = target.Name + " is intact";
      else
        Description = target.Name + " is alive";

      target.PermanentlyDied += OnAnyUnitDeath;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, OnAnyUnitTrain);
    }

    private void OnAnyUnitDeath(object? sender, Legend legend)
    {
      Progress = QuestProgress.Failed;
    }

    private void OnAnyUnitTrain()
    {
      if (!ProgressLocked && _target.UnitType == GetUnitTypeId(GetTriggerUnit()))
        Progress = QuestProgress.Complete;
    }

    internal override void OnAdd()
    {
      if (UnitAlive(_target.Unit)) Progress = QuestProgress.Complete;
    }
  }
}