using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.ControlPointBased;

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
  /// <param name="unitTypeId">The unit type ID of the <see cref="ControlPoint"/> that must reach the specified level.</param>
  /// <param name="requiredLevel">The level the <see cref="ControlPoint"/> must reach.</param>
  public ObjectiveControlLevel(int unitTypeId, int requiredLevel)
  {
    _target = ControlPointManager.Instance.GetFromUnitType(unitTypeId);
    _requiredLevel = requiredLevel;
    TargetWidget = _target.Unit;
    DisplaysPosition = true;
    Position = new(_target.Unit.X, _target.Unit.Y);
  }

  public override void OnAdd(Faction whichFaction)
  {
    RefreshDescription();
    RefreshProgress();

    _target.OwnerAllianceChanged += _ => Refresh();
    _target.ControlLevelChanged += _ => Refresh();
  }

  private void Refresh()
  {
    RefreshDescription();
    RefreshProgress();
  }

  private void RefreshDescription()
  {
    Description = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Owner)
      ? Loc.Format(
          "{target} is Control Level {level} or higher ({current}/{level})",
          ("{target}", Loc.Get(_target.Name)),
          ("{level}", _requiredLevel.ToString()),
          ("{current}", ((int)_target.ControlLevel).ToString()))
      : Loc.Format(
          "{target} is Control Level {level} or higher",
          ("{target}", Loc.Get(_target.Name)),
          ("{level}", _requiredLevel.ToString()));
  }

  private void RefreshProgress()
  {
    var isOnSameTeam = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Owner);

    Progress = _target.ControlLevel >= _requiredLevel && isOnSameTeam
      ? QuestProgress.Complete
      : QuestProgress.Incomplete;
  }
}
