using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;


namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  public sealed class ObjectiveControlPoint : Objective
  {
    private readonly ControlPoint _target;

    public ObjectiveControlPoint(ControlPoint target)
    {
      _target = target;
      Description = $"Your team controls {target.Name}";
      TargetWidget = target.Unit;
      DisplaysPosition = true;
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = IsPlayerAlliedToAnyEligibleFaction(_target.Unit.OwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
      
      _target.OwnerAllianceChanged += OnTargetTeamChanged;
    }

    private void OnTargetTeamChanged(object? sender, ControlPoint controlPoint)
    {
      Progress = IsPlayerAlliedToAnyEligibleFaction(_target.Unit.OwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }
  }
}