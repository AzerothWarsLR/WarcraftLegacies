using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Skywall;

/// <summary>
/// Kill some creeps to gain an outpost and 1 forgotten one.
/// </summary>
public sealed class QuestVortexPinnacle : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestVortexPinnacle"/> class.
  /// </summary>
  /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
  public QuestVortexPinnacle(Rectangle rescueRect) : base("The Vortex Pinnacle",
    "We have lost contact with the Elemental Realm, conquer Uldum to access the Vortex Pinnacle.",
    @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N0BD_ULDUM));
    AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.UldumAmbiance }, "in Uldum"));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveUpgrade(UNIT_N06R_GREAT_ALCAZAR_SKYWALL_T3, UNIT_N05Q_HOLDFAST_SKYWALL_T1));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll,
      filterUnit => filterUnit.UnitType != UNIT_NGME_GOBLIN_MERCHANT);
    ResearchId = UPGRADE_RSW1_QUEST_COMPLETED_THE_VORTEX_PINNACLE;

  }

  /// <inheritdoc />
  protected override string RewardDescription => $"Gain Control of all buildings in the Vortex Pinnacle, learn to train Al-Akir from the {GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_SKYWALL_ALTAR)}";

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
