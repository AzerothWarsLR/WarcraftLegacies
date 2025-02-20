using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Bring the exodar to full health in order to unlock the base inside
  /// </summary>
  public sealed class QuestRepairExodarHull : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRepairExodarHull"/> class.
    /// </summary>
    public QuestRepairExodarHull(Rectangle rescueRect, Legend exodar) : base("A New Home",
      "After the disastrous voyage through the Twisting Nether, the Exodar crash-landed on Azuremyst Isle. Its hull must be repaired before its facilities can be reactivated.",
      @"ReplaceableTextures\CommandButtons\BTNDraeneiVaultOfRelics.blp")
    {
      
      AddObjective(new ObjectiveUpgrade(UNIT_O051_DIVINE_CITADEL_DRAENEI_T3, UNIT_O02P_CRYSTAL_HALL_DRAENEI_T1));
      AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.AzuremystAmbient }, "on Azuremyst Isle"));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      ResearchId = UPGRADE_R099_QUEST_COMPLETED_A_NEW_HOME;
      SetUnitTimeScale(exodar.Unit, 0);
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "The Exodar's hull has been repaired. Its systems thrum to life, pulsating with crystalline energy.";

    /// <inheritdoc/>
    public override string PenaltyFlavour => "The Exodar is destroyed. It can never be repaired again.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Gain control of all units in the Exodar and learn to train Nobundo from the {GetObjectName(UNIT_O058_ALTAR_OF_LIGHT_DRAENEI_ALTAR)}";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }
  }
}