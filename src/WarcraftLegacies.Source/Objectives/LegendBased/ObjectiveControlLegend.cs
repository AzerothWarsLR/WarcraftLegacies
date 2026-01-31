using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Retain control of a particular <see cref="Legend"/>.
/// </summary>
public sealed class ObjectiveControlLegend : Objective
{
  private readonly bool _canFail;
  private readonly Legend _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveControlLegend"/> class.
  /// </summary>
  public ObjectiveControlLegend(LegendaryHero target, bool canFail)
  {
    _target = target;
    Description = $"You control {target.Name}";
    _canFail = canFail;
    if (target.Unit != null)
    {
      TargetWidget = target.Unit;
    }

    DisplaysPosition = target.Unit.Owner == player.NeutralAggressive;
    target.ChangedOwner += OnTargetChangeOwner;
    target.PermanentlyDied += OnTargetPermaDeath;
    Position = new(_target.Unit.X, _target.Unit.Y);
  }

  public override void OnAdd(Faction whichFaction)
  {
    if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
  }

  private void OnTargetChangeOwner(object? sender, LegendChangeOwnerEventArgs legendChangeOwnerEventArgs)
  {
    if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
    else
    {
      Progress = _canFail ? QuestProgress.Failed : QuestProgress.Incomplete;
    }
  }

  private void OnTargetPermaDeath(object? sender, Legend legend)
  {
    if (_canFail)
    {
      Progress = QuestProgress.Failed;
    }
  }
}
