using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased;

/// <summary>
/// Do not gain control of a particular <see cref="Capital"/>.
/// </summary>
public sealed class ObjectiveDontControlCapital : Objective
{
  private readonly Capital _target;
  private readonly QuestProgress _incompleteState;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveDontControlCapital"/> class.
  /// </summary>
  /// <param name="target">The Capital which should not be controlled.</param>
  /// <param name="canFail">If true, the Objective will be failed when the Capital is taken.</param>
  public ObjectiveDontControlCapital(Capital target, bool canFail)
  {
    _target = target;
    _incompleteState = canFail ? QuestProgress.Failed : QuestProgress.Incomplete;
    Description = $"You don't control {target.Name}";
    if (target.Unit != null)
    {
      TargetWidget = target.Unit;
    }

    DisplaysPosition = target.Unit.Owner == player.NeutralAggressive;
    target.ChangedOwner += OnTargetChangeOwner;
    Position = new(_target.Unit.X, _target.Unit.Y);
  }

  public override void OnAdd(Faction whichFaction)
  {
    if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = _incompleteState;
    }
    else
    {
      Progress = QuestProgress.Complete;
    }
  }

  private void OnTargetChangeOwner(object? sender, LegendChangeOwnerEventArgs legendChangeOwnerEventArgs)
  {
    if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = _incompleteState;
    }
    else
    {
      Progress = QuestProgress.Complete;
    }
  }
}
