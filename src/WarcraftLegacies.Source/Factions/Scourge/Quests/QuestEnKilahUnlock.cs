using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Scourge.Quests;

/// <summary>
/// Capture EnKilah's control point to gain control of all buildings and units in the area.
/// </summary>
public sealed class QuestEnKilahUnlock : QuestData
{
  private readonly RescueBase _base;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestEnKilahUnlock"/> class.
  /// </summary>
  public QuestEnKilahUnlock(Rectangle rescueRect) : base(
    "Temple City of En'kilah", "The temple city of En'kilah will be the perfect place for an outpost near the Borean Tundra.",
    @"ReplaceableTextures\CommandButtons\BTNNerubianZiggurat.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N09H_EN_KILAH));
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveSelfExists());
    _base = new RescueBase(rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures), true);
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "The temple city of En'kilah is now under the control of the Scourge.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all buildings in En'Kilah";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    _base.Rescue(rescuer);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player != null)
    {
      _base.Rescue(completingFaction.Player);
    }
  }

  /// <summary>
  /// Gives En'kilah to <paramref name="newOwner"/>, rebuilding any of its structures that have been destroyed.
  /// If the quest hasn't finished yet, it no longer gives En'kilah to anyone.
  /// </summary>
  public void HandOver(player newOwner) => _base.HandOver(newOwner);
}
