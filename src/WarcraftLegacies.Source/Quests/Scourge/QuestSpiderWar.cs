using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scourge;

public sealed class QuestSpiderWar : QuestData
{
  private const int QuestResearchId = UPGRADE_R03A_QUEST_COMPLETED_WAR_OF_THE_SPIDER;
  private readonly List<unit> _rescueUnits;

  public QuestSpiderWar(Rectangle rescueRect) : base("War of the Spider",
    "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.",
    @"ReplaceableTextures\CommandButtons\BTNNerubianQueen.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N08D_ICECROWN_GLACIER));
    AddObjective(new ObjectiveControlPoint(UNIT_N00G_BOREAN_TUNDRA));
    AddObjective(new ObjectiveControlPoint(UNIT_N09H_EN_KILAH));
    AddObjective(new ObjectiveUpgrade(UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, UNIT_UNP1_HALLS_OF_THE_DEAD_SCOURGE_T2));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Northrend and the Icecrown Citadel is now under full control of the Lich King and the Scourge.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Gain control of a base in Icecrown";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
    completingFaction.Player?.PlayMusicThematic("war3mapImported\\ScourgeTheme.mp3");
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(QuestResearchId, 1);
  }
}
