using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestObjectives
{
  public class QuestObjectiveKillUnit : QuestObjective
  {
    private readonly trigger _trigger;

    private void OnUnitKilled()
    {
      Progress = ParentFaction != null && GetOwningPlayer(GetKillingUnit()) == ParentFaction.Player
        ? QuestProgress.Complete
        : QuestProgress.Failed;
    }
    
    public QuestObjectiveKillUnit(unit target)
    {
      _trigger = CreateTrigger();
      TriggerRegisterUnitEvent(_trigger, target, EVENT_UNIT_DEATH);
      TriggerAddAction(_trigger, OnUnitKilled);
      Description = $"Kill {GetUnitName(target)}";
      Target = target;
    }

    ~QuestObjectiveKillUnit()
    {
      DestroyTrigger(_trigger);
    }
  }
}