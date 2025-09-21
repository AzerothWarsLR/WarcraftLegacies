using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Naga;

/// <summary>
/// Bring <see cref="LegendIllidan.Illidan"/> to <see cref="LegendFelHorde.BlackTemple"/> to gain control of it.
/// </summary>
public sealed class QuestBlackTemple : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBlackTemple"/> class.
  /// </summary>
  public QuestBlackTemple(QuestData prerequisite, Rectangle rescueRect, LegendaryHero illidan) : base("Return to Outland",
    "Illidan's servants in Outland have been left to their own devices for too long; he must return swiftly if he is to prepare them for the coming war.",
    @"ReplaceableTextures\CommandButtons\BTNWarpPortal.blp")
  {
    var questCompleteObjective = new ObjectiveQuestComplete(prerequisite)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    };

    AddObjective(questCompleteObjective);
    AddObjective(new ObjectiveLegendInRect(illidan, Regions.IllidanBlackTempleUnlock, "Black Temple"));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R09Y_QUEST_COMPLETED_RETURN_TO_OUTLAND;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    Knowledge = 5;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "Illidan returns triumphant to Black Temple, the seat of his power. The orcs and demons of Outland hail his coming.";

  /// <inheritdoc />
  protected override string RewardDescription => "Gain control of the Black Temple and learn to train Lady Vashj from the Altar of the Betrayer";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
    completingFaction.Player?.PlayMusicThematic("IllidansTheme");
  }
}
