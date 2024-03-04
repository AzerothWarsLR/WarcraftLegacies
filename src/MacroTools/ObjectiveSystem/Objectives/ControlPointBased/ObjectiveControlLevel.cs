using MacroTools.ControlPointSystem;
using MacroTools.QuestSystem;


namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  /// <summary>
  /// Completed when a <see cref="ControlPoint"/> has a certain <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public sealed class ObjectiveControlLevel : Objective
  {
    private readonly ControlPoint _target;
    private readonly int _requiredLevel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveControlLevel"/> class.
    /// </summary>
    /// <param name="target">The <see cref="ControlPoint"/> that must reach the specified level.</param>
    /// <param name="requiredLevel">The level the <see cref="ControlPoint"/> must reach.</param>
    public ObjectiveControlLevel(ControlPoint target, int requiredLevel)
    {
      _target = target;
      _requiredLevel = requiredLevel;
      TargetWidget = target.Unit;
      DisplaysPosition = true;
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }

    internal override void OnAdd(FactionSystem.Faction whichFaction)
    {
      RefreshDescription();
      RefreshProgress();
      
      _target.OwnerAllianceChanged += (_, _) => Refresh();
      _target.ControlLevelChanged += (_, _) => Refresh();
    }

    private void Refresh()
    {
      RefreshDescription();
      RefreshProgress();
    }

    private void RefreshDescription()
    {
      Description = IsPlayerAlliedToAnyEligibleFaction(_target.Owner)
        ? $"{_target.Name} is Control Level {_requiredLevel} or higher ({(int)_target.ControlLevel}/{_requiredLevel})"
        : $"{_target.Name} is Control Level {_requiredLevel} or higher";
    }

    private void RefreshProgress()
    {
      var isOnSameTeam = IsPlayerAlliedToAnyEligibleFaction(_target.Owner);

      Progress = _target.ControlLevel >= _requiredLevel && isOnSameTeam
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }
  }
}