using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Lordaeron;

/// <summary>
/// Wait long enough, get Tyr Hand.
/// </summary>
public sealed class QuestTyrHand : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestTyrHand"/> class.
  /// </summary>
  /// <param name="stratholme"></param>
  /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
  public QuestTyrHand(Capital stratholme, Rectangle rescueRect) : base("The Fortified City",
    "The city of Tyr's Hand is considered impregnable, but they will be reluctant to join the war.",
    @"ReplaceableTextures\CommandButtons\BTNHumanBarracks.blp")
  {
    AddObjective(new ObjectiveEitherOf(new ObjectiveCapitalDead(stratholme),
      new ObjectiveTurn(14)));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    ResearchId = UPGRADE_R023_QUEST_COMPLETED_THE_FORTIFIED_CITY;

  }

  /// <inheritdoc />
  public override string RewardFlavour => "The city-fortress of Tyr's Hand has decided to join us! Renowed for their siege engineers, we can now build siege workshops.";

  /// <inheritdoc />
  protected override string RewardDescription => $"Gain control of all units in Tyr's Hand, learn to train Garithos from the {GetObjectName(UNIT_HALT_ALTAR_OF_KINGS_LORDAERON_ALTAR)}, and learn to build {GetObjectName(UNIT_H094_SIEGE_WORKSHOP_LORDAERON_SIEGE)}s";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) =>
    completingFaction.Player.RescueGroup(_rescueUnits);
}
