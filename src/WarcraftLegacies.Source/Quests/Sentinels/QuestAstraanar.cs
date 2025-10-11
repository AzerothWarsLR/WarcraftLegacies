using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sentinels;

/// <summary>
/// Unlocks Abuderine
/// </summary>
public sealed class QuestAstranaar : QuestData
{
  private readonly List<unit> _rescueUnits = new();

  /// <summary>
  /// Initializes a new instance of <see cref="QuestAstranaar"/>.
  /// </summary>
  public QuestAstranaar(List<Rectangle> rescueRects) : base("Daughters of the Moon",
    "Auberdin needs to be mobilized for war. Darkshore has already been attacked by wild creatures gone mad.",
    @"ReplaceableTextures\CommandButtons\BTNShandris.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N02Z_AZUREMYST_ISLE));
    AddObjective(new ObjectiveControlPoint(UNIT_N02U_DARKSHORE));
    AddObjective(new ObjectiveControlPoint(UNIT_N064_GROVE_OF_THE_ANCIENTS));
    AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.Invasion3 }, "in Darkshore"));
    AddObjective(new ObjectiveUpgrade(UNIT_N06P_SENTINEL_ENCLAVE_SENTINELS_T3,
      UNIT_N06J_SENTINEL_OUTPOST_SENTINELS_T1));
    AddObjective(new ObjectiveExpire(480, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R03N_QUEST_COMPLETED_DAUGHTERS_OF_THE_MOON;

    foreach (var rectangle in rescueRects)
    {
      _rescueUnits.AddRange(rectangle.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable));
    }
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
     $"Control of all units in Astranaar Outpost and Auberdine and learn to train Tyrande and Naisha from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINELS_ALTAR)}";

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
    completingFaction.Player?.PlayMusicThematic("war3mapImported\\SentinelTheme.mp3");
  }
}
