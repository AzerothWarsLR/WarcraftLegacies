using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed while a specific <see cref="Legend"/> is not permanently dead, failed otherwise.
/// </summary>
public sealed class ObjectiveLegendNotPermanentlyDead : Objective
{
  private readonly Legend _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveLegendNotPermanentlyDead"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Legend"/> to check death status for.</param>
  public ObjectiveLegendNotPermanentlyDead(LegendaryHero target)
  {
    _target = target;
    Description = target.Unit.IsUnitType(unittype.Structure)
      ? Loc.Format("{target} is intact", ("{target}", Loc.Get(target.Name)))
      : Loc.Format("{target} is alive", ("{target}", Loc.Get(target.Name)));

    target.Died += OnTargetDied;
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, OnAnyUnitTrain);
  }

  private void OnTargetDied(LegendDiedEventArgs eventArgs)
  {
    if (eventArgs.Permanent)
    {
      Progress = QuestProgress.Failed;
    }
  }

  private void OnAnyUnitTrain()
  {
    if (!ProgressLocked && _target.Unit == @event.TrainedUnit)
    {
      Progress = QuestProgress.Complete;
    }
  }

  public override void OnAdd(Faction whichFaction)
  {
    if (_target.Unit.Alive)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
