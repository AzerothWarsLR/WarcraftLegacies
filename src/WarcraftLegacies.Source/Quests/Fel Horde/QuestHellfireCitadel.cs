using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Fel_Horde;

/// <summary>
/// Drive the Draenai out of Outland, take control of various control points in outland and upgrade main to t3 in order to unlock Hellfire Citadel.
/// </summary>
public sealed class QuestHellfireCitadel : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestHellfireCitadel"/> class.
  /// </summary>
  /// <param name="rescueRect">Units in this area start invulnerable then get rescued when the quest is complete.</param>
  public QuestHellfireCitadel(Rectangle rescueRect) : base("The Citadel",
    "The clans holding Hellfire Citadel do not respect Kargath's authority yet, Magtheridon is being kept alive by Illidan, if we break him, he could serve us well.",
    @"ReplaceableTextures\CommandButtons\BTNFelOrcFortress.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_MD01_WEST_ZANGARMARSH));
    AddObjective(new ObjectiveControlPoint(UNIT_N00B_NAGRAND));
    AddObjective(new ObjectiveControlPoint(UNIT_N0CV_HALAAR));
    AddObjective(new ObjectiveUpgrade(UNIT_O030_FORTRESS_FEL_T3, UNIT_O02Y_GREAT_HALL_FEL_T1));
    AddObjective(new ObjectiveExpire(10, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R00P_QUEST_COMPLETED_THE_CITADEL;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);

  }

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Control of all units in Hellfire Citadel and enable Magtheridon to be trained at the altar";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player?.RescueGroup(_rescueUnits);
    completingFaction.Player?.PlayMusicThematic("war3mapImported\\FelTheme.mp3");
  }

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
