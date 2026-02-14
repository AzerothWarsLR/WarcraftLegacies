using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Lordaeron;

public sealed class QuestHearthglen : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestHearthglen"/> class.
  /// </summary>
  public QuestHearthglen(Rectangle hearthglenArea) : base("Hearthglen",
    "The village of Hearthglen is under siege from the restless dead. The people there must be saved.",
    @"ReplaceableTextures\CommandButtons\BTNutherAlt.blp")
  {
    AddObjective(new ObjectiveHostilesInAreaAreDead(new[] { hearthglenArea }, "in Hearthglen"));
    AddObjective(new ObjectiveExpire(GameTimeManager.ConvertGameTimeToTurn(660), Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = hearthglenArea.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

  }

  /// <inheritdoc />
  public override string RewardFlavour => "The walking corpses assailing Hearthglen have been put back to rest, and Hearthglen lives to see another day.";

  /// <inheritdoc />
  protected override string RewardDescription => "Control of all units in Hearthglen";

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
