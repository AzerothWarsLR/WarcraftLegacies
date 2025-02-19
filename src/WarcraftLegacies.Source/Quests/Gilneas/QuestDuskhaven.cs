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
  /// Capture control points close to Duskhaven to gain control of it.
  /// </summary>
  public sealed class QuestDuskhaven : QuestData
  {
    private List<unit> RescueUnits { get;}

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestDuskhaven"/> class.
    /// </summary>
    public QuestDuskhaven() : base("Duskhaven", "The next town is located at the western coast of Gilneas.", @"ReplaceableTextures\CommandButtons\BTNGilneasTownHall.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N031_DUSKHAVEN));
      AddObjective(new ObjectiveControlPoint(UNIT_N06V_BLACKWALD));
      AddObjective(new ObjectiveExpire(660, "Duskhaven"));
      AddObjective(new ObjectiveSelfExists());
      RescueUnits = Regions.GilneasUnlock4.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Duskhaven has been liberated.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all buildings in Duskhaven.";

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
