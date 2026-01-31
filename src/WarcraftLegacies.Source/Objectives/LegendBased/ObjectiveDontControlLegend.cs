using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Do not gain control of a particular <see cref="Legend"/>.
/// </summary>
public sealed class ObjectiveDontControlLegend : Objective
{
  private readonly Legend _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveDontControlLegend"/> class.
  /// </summary>
  public ObjectiveDontControlLegend(LegendaryHero target)
  {
    _target = target;
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
      Progress = QuestProgress.Failed;
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
      Progress = QuestProgress.Failed;
    }
  }
}
