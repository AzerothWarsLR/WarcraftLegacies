using MacroTools.LegendSystem;
using MacroTools.QuestSystem;


namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  /// <summary>
  /// Starts completed, and fails if another player acquires the specified <see cref="Capital"/>.
  /// </summary>
  public sealed class NoOtherPlayerGetsCapital : Objective
  {
    private readonly Capital _target;

    /// <summary>
    /// Initializes a new instance of the <see cref="NoOtherPlayerGetsCapital"/> class.
    /// </summary>
    /// <param name="target">The objective fails when this <see cref="Capital"/> is acquired by anyone but the objective holder.</param>
    public NoOtherPlayerGetsCapital(Capital target)
    {
      _target = target;
      Description = $"No other player has acquired {target.Unit.Name}";
    }

    /// <inheritdoc/>
    internal override void OnAdd(FactionSystem.Faction faction)
    {
      Progress = QuestProgress.Complete;
      var trigger = CreateTrigger();
      trigger.RegisterUnitEvent(_target.Unit, EVENT_UNIT_CHANGE_OWNER);
      trigger.AddAction(() =>
        {
          if (GetTriggerUnit().Owner != faction.Player) 
            Progress = QuestProgress.Failed;
        });
    }
  }
}