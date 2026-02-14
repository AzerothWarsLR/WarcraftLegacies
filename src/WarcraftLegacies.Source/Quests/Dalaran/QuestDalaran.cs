using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Dalaran;

/// <summary>
/// Dalaran acquires the city of Dalaran.
/// </summary>
public sealed class QuestDalaran : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestDalaran(Rectangle rescueRect) : base("Outskirts",
    "The territories of Dalaran are fragmented, secure the lands and protect Dalaran citizens.",
    @"ReplaceableTextures\CommandButtons\BTNArcaneCastle.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N018_DURNHOLDE));
    AddObjective(new ObjectiveUpgrade(UNIT_H068_OBSERVATORY_DALARAN_T3, UNIT_H065_REFUGE_DALARAN_T1));
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R038_QUEST_COMPLETED_OUTSKIRTS;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Control of all units in Dalaran, enables Antonidas to be trained at the Altar and you can now build Refuges";

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
    completingFaction.Player.PlayMusicThematic("war3mapImported\\DalaranTheme.mp3");
  }
}
