using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scourge;

/// <summary>
/// Capture <see cref="LegendNeutral.DraktharonKeep"/> control point to gain control of all buildings in the area.
/// </summary>
public sealed class QuestDrakUnlock : QuestData
{
  private readonly List<unit> _rescueUnits;
  private readonly LegendaryHero _kelthuzad;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestDrakUnlock"/> class.
  /// </summary>
  public QuestDrakUnlock(Rectangle rescueRect, LegendaryHero kelthuzad) : base(
    "Drak'tharon Keep", "Drak'tharon Keep will be the perfect place for an outpost by the sea.",
    @"ReplaceableTextures\CommandButtons\BTNUndeadShipyard.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N030_DRAK_THARON_KEEP));
    AddObjective(new ObjectiveExpire(GameTimeManager.ConvertGameTimeToTurn(660), Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R08J_QUEST_COMPLETED_DRAK_THARON_KEEP;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _kelthuzad = kelthuzad;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => $"Gain control of all buildings in Drak'tharon Keep and learn to train {_kelthuzad.Name} from the {GetObjectName(UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR)}";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => completingFaction.Player?.RescueGroup(_rescueUnits);
}
