using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
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
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_R038_QUEST_COMPLETED_OUTSKIRTS;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Dalaran outskirs are now secure, the mages will join Dalaran.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Control of all units in Dalaran, enables Antonidas to be trained at the Altar and you can now build Refuges";

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
      completingFaction.Player.RescueGroup(_rescueUnits);
      completingFaction.Player.PlayMusicThematic("war3mapImported\\DalaranTheme.mp3");
    }
  }
}