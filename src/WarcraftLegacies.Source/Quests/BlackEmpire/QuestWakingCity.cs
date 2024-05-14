using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{ 
  /// <summary>
  /// Kill some creeps to gain Nzoth and unlock Nyalotha.
  /// </summary>
  public sealed class QuestWakingCity : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWakingCity"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestWakingCity(QuestData prerequisite, Rectangle rescueRect) : base("The Waking City",
      "Adventurers from Azeroth are threatening our God N'zoth, we need to annihilate them.",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_NNYA_NY_ALOTHA_THE_WAKING_CITY));
      AddObjective(new ObjectiveQuestComplete(prerequisite));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll,
        filterUnit => filterUnit.GetTypeId() != FourCC("ngme"));
      ResearchId = UPGRADE_RBIT_QUEST_COMPLETED_THE_WAKING_CITY;

    }

    /// <inheritdoc />
    public override string RewardFlavour => "With the adventurer party destroyed, we have saved N'zoth";

    /// <inheritdoc />
    protected override string RewardDescription => $"Control of all buildings in Ny'lotha, enable to build the {GetObjectName(UNIT_N0AX_MUTATION_CIRCLE_YOGG_SPECIALIST)} and gain control of N'zoth";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player.RescueGroup(_rescueUnits);
  }
}