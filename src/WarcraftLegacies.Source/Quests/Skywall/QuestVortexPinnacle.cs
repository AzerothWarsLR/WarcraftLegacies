using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Skywall
{ 
  /// <summary>
  /// Kill some creeps to gain an outpost and 1 forgotten one.
  /// </summary>
  public sealed class QuestVortexPinnacle : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestVortexPinnacle"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestVortexPinnacle(Rectangle rescueRect) : base("The Vortex Pinnacle",
      "We have lost contact with the Elemental Realm, conquer Uldum to access the Vortex Pinnacle.",
      @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N0BD_ULDUM));
      AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.UldumAmbiance }, "in Uldum"));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveUpgrade(UNIT_N06R_GREAT_ALCAZAR_ELEMENTAL_T3, UNIT_N05Q_HOLDFAST_ELEMENTAL_T1));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll,
        filterUnit => filterUnit.GetTypeId() != FourCC("ngme"));
      ResearchId = UPGRADE_RSW1_QUEST_COMPLETED_THE_VORTEX_PINNACLE;

    }

    /// <inheritdoc />
    public override string RewardFlavour => "The Vortex Pinnacle and Al-Akir have joined us";

    /// <inheritdoc />
    protected override string RewardDescription => $"Gain Control of all buildings in the Vortex Pinnacle, learn to train Al-Akir from the {GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_ELEMENTAL_ALTAR)}";

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