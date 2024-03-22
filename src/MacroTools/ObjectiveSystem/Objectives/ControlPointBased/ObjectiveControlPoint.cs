using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  public sealed class ObjectiveControlPoint : Objective
  {
    private readonly ControlPoint _target;
    
    /// <summary>
    /// Initializes a new instance of <see cref="ObjectiveControlPoint"/> using a unit type ID.
    /// </summary>
    public ObjectiveControlPoint(int controlPointUnitType)
    {
      _target = ControlPointManager.Instance.GetFromUnitType(controlPointUnitType);
      Description = $"Your team controls {_target.Name}";
      TargetWidget = _target.Unit;
      DisplaysPosition = true;
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
      
      _target.OwnerAllianceChanged += OnTargetTeamChanged;
    }

    private void OnTargetTeamChanged(object? sender, ControlPoint controlPoint)
    {
      Progress = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }
  }
}