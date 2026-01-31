using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when your team controls a particular <see cref="Capital"/>.
/// </summary>
public sealed class ObjectiveControlCapital : Objective
{
  private readonly bool _failOnControlLoss;
  private readonly Legend _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveControlCapital"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Capital"/> that needs to be controlled to complete the objective.</param>
  /// <param name="failOnControlLoss">If true, the objective will fail when control of the capital is lost for the tirst time.</param>
  public ObjectiveControlCapital(Capital target, bool failOnControlLoss)
  {
    _target = target;
    Description = $"You control {target.Name}";
    _failOnControlLoss = failOnControlLoss;
    if (target.Unit != null)
    {
      TargetWidget = target.Unit;
    }

    DisplaysPosition = true;
    Position = _target.Unit?.GetPosition();
  }

  public override void OnAdd(Faction whichFaction)
  {
    if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
    _target.ChangedOwner += (_, _) => { RecalculateProgress(); };
    _target.UnitChanged += (_, _) => { RecalculateProgress(); };

    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(_target.Unit, unitevent.Death);
    deathTrigger.AddAction(() => { Progress = QuestProgress.Failed; });
  }

  private void RecalculateProgress()
  {
    if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
    else
    {
      Progress = _failOnControlLoss ? QuestProgress.Failed : QuestProgress.Incomplete;
    }
  }
}
