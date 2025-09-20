using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun;

/// <summary>
/// Kill some Murlocs to take control of the Tanaris Outpost.
/// </summary>
public sealed class QuestTanarisOutpost : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestTanarisOutpost"/> class.
  /// </summary>
  /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
  public QuestTanarisOutpost(Rectangle rescueRect) : base("The Noxious Lair",
    "The sands of Tanaris call for the Hive, but first I must eliminate the Trolls of Zul'farrak.",
    @"ReplaceableTextures/CommandButtons/BTNScorpion.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N020_TANARIS));
    AddObjective(new ObjectiveControlPoint(UNIT_N092_ZUL_FARRAK));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

  }

  /// <inheritdoc />
  public override string RewardFlavour => "With Zul'farrak under my control, I can extend the Hive to the sands of Tanaris.";

  /// <inheritdoc />
  protected override string RewardDescription => "Control of all units in the Noxious Lair";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) =>
    completingFaction.Player.RescueGroup(_rescueUnits);
}
