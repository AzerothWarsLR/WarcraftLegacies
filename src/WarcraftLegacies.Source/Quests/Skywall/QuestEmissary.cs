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
  public sealed class QuestEmissary : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestEmissary"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestEmissary() : base("Emissary of the Firelands",
      "Ragnaros and the Firelands will join the Old Gods, we need to make contact with them.",
      @"ReplaceableTextures\CommandButtons\BTNHeroAvatarOfFlame.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N0BD_ULDUM));
      AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.UldumAmbiance }, "in Uldum"));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_RSW2_QUEST_COMPLETED_EMISSARY_OF_THE_FIRELANDS;

    }

    /// <inheritdoc />
    public override string RewardFlavour => "Ragnaros has joined us";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train Ragnaros from the {GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_ELEMENTAL_ALTAR)} and learn to build the Magma Complex";

  }
}