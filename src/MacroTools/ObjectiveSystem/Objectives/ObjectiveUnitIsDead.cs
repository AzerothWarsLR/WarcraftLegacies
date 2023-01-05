using MacroTools.Extensions;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives
{
  public sealed class ObjectiveUnitIsDead : Objective
  {
    public ObjectiveUnitIsDead(unit unitToKill)
    {
      CreateTrigger()
        .RegisterUnitEvent(unitToKill, EVENT_UNIT_DEATH)
        .AddAction(() => { Progress = QuestProgress.Complete; });
      Target = unitToKill;
      TargetWidget = Target;
      InitializeDescription();
      DisplaysPosition = IsUnitType(Target, UNIT_TYPE_STRUCTURE) ||
                         GetOwningPlayer(Target) == Player(PLAYER_NEUTRAL_AGGRESSIVE);
    }

    public override Point Position => new(GetUnitX(Target), GetUnitY(Target));

    public unit Target { get; }
    
    private void InitializeDescription()
    {
      if (IsUnitType(Target, UNIT_TYPE_STRUCTURE) || IsUnitType(Target, UNIT_TYPE_ANCIENT))
      {
        Description = $"{GetUnitName(Target)} has been destroyed";
        return;
      }

      Description = $"{GetUnitName(Target)} is dead";
    }
  }
}