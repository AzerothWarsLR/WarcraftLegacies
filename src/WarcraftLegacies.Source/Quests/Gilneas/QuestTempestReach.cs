﻿using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Capture control points close to Tempest Reach to gain control of it.
  /// </summary>
  public sealed class QuestTempestReach: QuestData
  {
    private List<unit> RescueUnits { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTempestReach"/> class.
    /// </summary>
    public QuestTempestReach() : base("Tempest Reach", "The first settlement we need to capture is Tempest Reach, just south of our location.", @"ReplaceableTextures\CommandButtons\BTNGilneasFarm.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N084_TEMPEST_REACH));
      AddObjective(new ObjectiveExpire(670, Title));
      AddObjective(new ObjectiveSelfExists());
      RescueUnits = Regions.GilneasUnlock1.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Tempest Reach has been liberated.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all buildings in Tempest Reach.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.Player?.RescueGroup(RescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(RescueUnits);
    }
  }
}
