using AzerothWarsCSharp.MacroTools.Libraries;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveKillUnit : Objective
  {
    public ObjectiveKillUnit(unit unitToKill)
    {
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, unitToKill, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, OnUnitDeath);
      Target = unitToKill;
      TargetWidget = Target;
      InitializeDescription();
      DisplaysPosition = IsUnitType(Target, UNIT_TYPE_STRUCTURE) ||
                         Environment.IsPlayerNeutralHostile(GetOwningPlayer(Target));
    }

    public override Point Position => new(GetUnitX(Target), GetUnitY(Target));

    public unit Target { get; }

    private void OnUnitDeath()
    {
      Progress = Holder.Team.ContainsPlayer(GetOwningPlayer(GetKillingUnit()))
        ? QuestProgress.Complete
        : QuestProgress.Failed;
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