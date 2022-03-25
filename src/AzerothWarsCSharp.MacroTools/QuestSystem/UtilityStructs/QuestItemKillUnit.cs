namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemKillUnit : QuestItemData
  {
    private static group targets = CreateGroup();
    private static int count = 0;
    private static thistype[] byIndex;

    private X()
    {
      if (IsUnitType(Target, UNIT_TYPE_STRUCTURE) || IsPlayerNeutralHostile(GetOwningPlayer(Target)))
        return GetUnitX(Target);
      return 0;
    }

    private Y()
    {
      if (IsUnitType(Target, UNIT_TYPE_STRUCTURE) || IsPlayerNeutralHostile(GetOwningPlayer(Target)))
        return GetUnitY(Target);
      return 0;
    }

    public QuestItemKillUnit(unit unitToKill)
    {
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, unitToKill, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, thistype.OnAnyUnitDeath);
      Target = unitToKill;
      InitializeDescription();
      GroupAddUnit(thistype.targets, unitToKill);
      this.targetWidget = unitToKill;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
    }

    public unit Target { get; }

    float operator

    float operator

    private void OnUnitDeath()
    {
      if (Holder.Team.ContainsPlayer(GetOwningPlayer(GetKillingUnit())))
        Progress = QUEST_PROGRESS_COMPLETE;
      else
        Progress = QUEST_PROGRESS_FAILED;
    }

    private void InitializeDescription()
    {
      if (IsUnitType(Target, UNIT_TYPE_STRUCTURE) || IsUnitType(Target, UNIT_TYPE_ANCIENT))
      {
        Description = "Destroy " + GetUnitName(Target);
        return;
      }

      Description = "Kill " + GetUnitName(Target);
    }

    private static void OnAnyUnitDeath()
    {
      var i = 0;
      thistype loopItem;
      while (true)
      {
        if (i == thistype.count) break;
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerUnit()) loopItem.OnUnitDeath();
        i = i + 1;
      }
    }
  }
}