using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.BlackEmpire;

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
  /// <param name= "prerequisite">What quest is required to complete this.</param>
  public QuestWakingCity(QuestData prerequisite, Rectangle rescueRect) : base("The Waking City",
    "Adventurers from Azeroth are threatening me, your god. Annihilate them.",
    @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_NNYA_NY_ALOTHA_THE_WAKING_CITY));
    AddObjective(new ObjectiveQuestComplete(prerequisite));
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveUpgrade(UNIT_N0AT_CATHEDRAL_OF_MADNESS_NZOTH_T3, UNIT_N0AR_TWISTING_HALLS_NZOTH_T1));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll,
      filterUnit => filterUnit.UnitType != FourCC("ngol"));
    ResearchId = UPGRADE_RBIT_QUEST_COMPLETED_THE_WAKING_CITY;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "With the adventurer party destroyed, no one stands in my way.";

  /// <inheritdoc />
  protected override string RewardDescription => $"Gain control of all buildings in Ny'lotha, learn to build the {GetObjectName(UNIT_N0AX_MUTATION_CIRCLE_NZOTH_SPECIALIST)}, and gain control of N'zoth";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
    var nzoth = AllLegends.BlackEmpire.Nzoth.Unit;
    if (nzoth != null)
    {
      UnitTypeTraitRegistry.ForceOnCreated(nzoth);
    }
  }
}
