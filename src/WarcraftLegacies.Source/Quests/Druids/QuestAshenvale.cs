using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Druids;

/// <summary>
/// Get Cenarius and some treants.
/// </summary>
public sealed class QuestAshenvale : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestAshenvale"/> class.
  /// </summary>
  /// <param name="ashenvaleRect">Units in this rectangle start invulnerable and are rescued when the quest is completed.</param>
  public QuestAshenvale(Rectangle ashenvaleRect) : base("The Spirits of Ashenvale",
    "The forest needs healing. Regain control of it to awaken it.",
    @"ReplaceableTextures\CommandButtons\BTNKeeperC.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N07C_FELWOOD));
    AddObjective(new ObjectiveControlPoint(UNIT_N01Q_NORTHERN_ASHENVALE));
    AddObjective(new ObjectiveExpire(600, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R06R_QUEST_COMPLETED_THE_SPIRITS_OF_ASHENVALE;
    _rescueUnits = ashenvaleRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

  }

  /// <inheritdoc />
  public override string RewardFlavour => "Ashenvale has awakened!";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Control of all units in Ashenvale";

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
    completingFaction.Player?.RescueGroup(_rescueUnits);
    completingFaction.Player?.PlayMusicThematic("war3mapImported\\DruidTheme.mp3");
  }
}
