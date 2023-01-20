using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.LegendSystem;
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
    private readonly Capital _exodar;
    private readonly Capital _exodarGenerator;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRepairExodarHull"/> class.
    /// </summary>
    public QuestRepairExodarHull(Rectangle rescueRect, Capital exodar, Capital exodarGenerator) : base("A New Home",
      "After the disastrous voyage through the Twisting Nether, the Exodar crash-landed on Azuremyst Isle. Its hull must be repaired in order to get inside.",
      "ReplaceableTextures\\CommandButtons\\BTNDraeneiVaultOfRelics.blp")
    {
      _exodar = exodar;
      _exodarGenerator = exodarGenerator;
      Required = true;
      AddObjective(new ObjectiveUnitAlive(exodar.Unit));
      AddObjective(new ObjectiveUnitReachesFullHealth(exodar.Unit));
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.AzuremystAmbient }, "on Azuremyst Isle"));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      ResearchId = Constants.UPGRADE_R099_QUEST_COMPLETED_A_NEW_HOME;
      SetUnitTimeScale(exodar.Unit, 0);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Exodar's hull is repaired. It can now be entered again.";

    /// <inheritdoc/>
    protected override string PenaltyFlavour => "The Exodar is destroyed. It can never be repaired again.";

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
      SetUnitTimeScale(_exodar.Unit, 1);
      _exodar.Unit?.SetInvulnerable(true);
      _exodarGenerator.Unit?.SetInvulnerable(false);
    }
  }
}