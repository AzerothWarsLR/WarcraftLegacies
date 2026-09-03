using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Zandalar.Quests;

/// <summary>
/// Fully upgrade your main to unlock Zan
/// </summary>
public sealed class QuestZandalar : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestZandalar"/> class
  /// </summary>
  /// <param name="rescueRect"></param>
  public QuestZandalar(Rectangle rescueRect) : base("City of Gold", "We need to regain control of our land.",
    @"ReplaceableTextures\CommandButtons\BTNBloodTrollMage.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N092_ZUL_FARRAK));
    AddObjective(new ObjectiveControlPoint(UNIT_N0BK_LOST_CITY_OF_THE_TOL_VIR));
    AddObjective(new ObjectiveControlPoint(UNIT_N025_UN_GORO_CRATER));
    AddObjective(new ObjectiveUpgrade(UNIT_O03Z_FORTRESS_CREEP_T3, UNIT_O03Y_STRONGHOLD_CREEP_T2));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_MD34_QUEST_COMPLETED_CITY_OF_GOLD;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The City of Gold is now yours to command and has joined the Zandalari";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Control of all units in Dazar'alor and enables the Rasthakan to be trained";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }
}
