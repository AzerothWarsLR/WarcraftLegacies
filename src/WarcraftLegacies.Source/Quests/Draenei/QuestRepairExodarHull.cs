using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Bring the exodar to full health in order to unlock the base inside
  /// </summary>
  public class QuestRepairExodarHull : QuestData
  {
    private readonly QuestData _questToFailOnFail;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRepairExodarHull"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area start invulnerable and are rescued when the quest is completed.</param>
    /// <param name="questToFailOnFail">This quest will fail upon failing <see cref="QuestRepairExodarHull"/>.</param>
    public QuestRepairExodarHull(Rectangle rescueRect, QuestData questToFailOnFail) : base("A New Home",
      "After the disastrous voyage through the Twisting Nether, the Exodar crash-landed on Azuremyst Isle. Its hull must be repaired in order to get inside.",
      "ReplaceableTextures\\CommandButtons\\BTNDraeneiVaultOfRelics.blp")
    {
      Required = true;
      AddObjective(new ObjectiveUnitAlive(LegendDraenei.LegendExodar.Unit));
      AddObjective(new ObjectiveUnitReachesFullHealth(LegendDraenei.LegendExodar.Unit));
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.AzuremystAmbient }, "on Azuremyst Isle"));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      ResearchId = Constants.UPGRADE_R099_QUEST_COMPLETED_A_NEW_HOME; // Change this to current quest;
      _questToFailOnFail = questToFailOnFail;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "The Exodar's hull is repaired. It can now be entered again.";

    /// <inheritdoc/>
    protected override string FailurePopup => "The Exodar is destroyed. It can never be repaired again.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Gain access to the Exodar's interior";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction whichFaction) => _questToFailOnFail.Progress = QuestProgress.Failed;
  }
}