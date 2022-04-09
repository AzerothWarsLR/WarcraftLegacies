using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemKillUnit : QuestItemData, IHasPosition
  {
    public bool DisplaysPosition => IsUnitType(Target, UNIT_TYPE_STRUCTURE) || Environment.IsPlayerNeutralHostile(GetOwningPlayer(Target));
    
    public Point Position => new(GetUnitX(Target), GetUnitY(Target));

    public QuestItemKillUnit(unit unitToKill)
    {
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, unitToKill, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, OnUnitDeath);
      Target = unitToKill;
      TargetWidget = Target;
      InitializeDescription();
    }

    public unit Target { get; }

    private void OnUnitDeath()
    {
      Progress = Holder.Team.ContainsPlayer(GetOwningPlayer(GetKillingUnit())) ? QuestProgress.Complete : QuestProgress.Failed;
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
  }
}