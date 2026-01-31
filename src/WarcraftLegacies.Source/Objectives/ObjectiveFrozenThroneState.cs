using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.FactionMechanics.Scourge;

namespace WarcraftLegacies.Source.Objectives;

/// <summary>
/// Completed when the Frozen Throne gets into a certain state.
/// </summary>
public sealed class ObjectiveFrozenThroneState : Objective
{
  private readonly FrozenThroneState _desiredState;

  /// <summary>
  /// The state of the Frozen Throne when the quest was completed.
  /// </summary>
  public FrozenThroneState State { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveFrozenThroneState"/> class.
  /// </summary>
  /// <param name="desiredState">The Objective is completed when the Throne changes to this state.</param>
  public ObjectiveFrozenThroneState(FrozenThroneState desiredState)
  {
    Description = $"The Frozen Throne is {desiredState}";
    _desiredState = desiredState;
  }

  public override void OnAdd(Faction whichFaction)
  {
    TheFrozenThrone.FrozenThroneStateChanged += (_, state) =>
    {
      Progress = state == _desiredState ? QuestProgress.Complete : QuestProgress.Failed;
      State = state;
    };
  }
}
