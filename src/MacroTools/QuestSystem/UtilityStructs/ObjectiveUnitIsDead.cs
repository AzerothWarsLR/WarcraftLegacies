using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  public class ObjectiveUnitIsDead : Objective
  {
    public ObjectiveUnitIsDead(unit unitToKill)
    {
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, unitToKill, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, OnUnitDeath);
      Target = unitToKill;
      TargetWidget = Target;
      InitializeDescription();
      DisplaysPosition = IsUnitType(Target, UNIT_TYPE_STRUCTURE) ||
                         GetOwningPlayer(Target) == Player(PLAYER_NEUTRAL_AGGRESSIVE);
    }

    public override Point Position => new(GetUnitX(Target), GetUnitY(Target));

    public unit Target { get; }

    private void OnUnitDeath()
    {
      Progress = QuestProgress.Complete;
    }

    private void InitializeDescription()
    {
      if (IsUnitType(Target, UNIT_TYPE_STRUCTURE) || IsUnitType(Target, UNIT_TYPE_ANCIENT))
      {
        Description = GetUnitName(Target) + "has been destroyed.";
        return;
      }

      Description = GetUnitName(Target) + "is dead.";
    }
  }
}