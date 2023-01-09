using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
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
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRepairExodarHull"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area start invulnerable and are rescued when the quest is completed.</param>
    public QuestRepairExodarHull(Rectangle rescueRect) : base("A New Home",
      "After the disastrous voyage through the Twisting Nether, the Exodar crash-landed on Azuremyst Isle. Its hull must be repaired in order to get inside.",
      "ReplaceableTextures\\CommandButtons\\BTNDraeneiVaultOfRelics.blp")
    {
      Required = true;
      AddObjective(new ObjectiveUnitAlive(LegendDraenei.LegendExodar.Unit));
      AddObjective(new ObjectiveUnitReachesFullHealth(LegendDraenei.LegendExodar.Unit));
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.AzuremystAmbient }, "on Azuremyst Isle"));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      ResearchId = Constants.UPGRADE_R099_QUEST_COMPLETED_A_NEW_HOME;
      SetUnitTimeScale(LegendDraenei.LegendExodar.Unit, 0);
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
      SetUnitTimeScale(LegendDraenei.LegendExodar.Unit, 1);
      LegendDraenei.LegendExodar.Unit?.SetInvulnerable(true);
      LegendDraenei.LegendExodarGenerator.Unit?.SetInvulnerable(false);
    }
  }
}