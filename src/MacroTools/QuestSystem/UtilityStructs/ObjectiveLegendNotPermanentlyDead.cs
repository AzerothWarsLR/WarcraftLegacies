using MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
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
    public ObjectiveLegendNotPermanentlyDead(Legend target)
    {
      _target = target;
      Description = IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE)
        ? $"{target.Name} is intact"
        : $"{target.Name} is alive";

      target.PermanentlyDied += OnAnyUnitDeath;
      PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, OnAnyUnitTrain);
    }

    private void OnAnyUnitDeath(object? sender, Legend legend)
    {
      Progress = QuestProgress.Failed;
    }

    private void OnAnyUnitTrain()
    {
      if (!ProgressLocked && _target.Unit == GetTrainedUnit())
        Progress = QuestProgress.Complete;
    }

    internal override void OnAdd(Faction whichFaction)
    {
      if (UnitAlive(_target.Unit)) Progress = QuestProgress.Complete;
    }
  }
}