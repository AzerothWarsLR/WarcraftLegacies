using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when a specific <see cref="Capital"/> is dead.
/// </summary>
public sealed class ObjectiveCapitalDead : Objective
{
  private readonly Capital _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveCapitalDead"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Capital"/> that has to die for this objective to be completed.</param>
  public ObjectiveCapitalDead(Capital target)
  {
    _target = target;
    TargetWidget = target.Unit;
    SetDescription("{target} is destroyed", ("{target}", Loc.Get(target.Unit.Name)));
    DisplaysPosition = true;
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(target.Unit, unitevent.Death);
    deathTrigger.AddAction(() => Progress = QuestProgress.Complete);

    Position = new(target.Unit.X, target.Unit.Y);
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    if (_target.Unit != null && !_target.Unit.Alive)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
