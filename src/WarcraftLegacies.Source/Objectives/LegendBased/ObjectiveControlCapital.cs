using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when your team controls a particular <see cref="Capital"/>.
/// </summary>
public sealed class ObjectiveControlCapital : Objective
{
  private readonly bool _failOnControlLoss;
  private readonly bool _onlyYou;
  private readonly Legend _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveControlCapital"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Capital"/> that needs to be controlled to complete the objective.</param>
  /// <param name="failOnControlLoss">If true, the objective will fail when control of the capital is lost for the tirst time.</param>
  /// <param name="onlyYou">If true, only the quest holder controlling the capital counts, not its allies.</param>
  public ObjectiveControlCapital(Capital target, bool failOnControlLoss, bool onlyYou = false)
  {
    _target = target;
    _onlyYou = onlyYou;
    SetDescription("You control {target}", ("{target}", Loc.Get(target.Name)));
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
    if (_target.Unit != null && IsController(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
    _target.ChangedOwner += _ => RecalculateProgress();
    _target.UnitChanged += _ => RecalculateProgress();

    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(_target.Unit, unitevent.Death);
    deathTrigger.AddAction(() => { Progress = QuestProgress.Failed; });
  }

  private void RecalculateProgress()
  {
    if (_target.Unit != null && IsController(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
    else
    {
      Progress = _failOnControlLoss ? QuestProgress.Failed : QuestProgress.Incomplete;
    }
  }

  private bool IsController(player owner)
  {
    if (!_onlyYou)
    {
      return IsPlayerOnSameTeamAsAnyEligibleFaction(owner);
    }

    foreach (var eligibleFaction in EligibleFactions)
    {
      if (eligibleFaction.Player == owner)
      {
        return true;
      }
    }

    return false;
  }
}
