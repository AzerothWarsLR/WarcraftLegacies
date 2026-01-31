using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;

namespace WarcraftLegacies.Source.Quests.Skywall;

/// <summary>
/// Kill some creeps to gain an outpost and 1 forgotten one.
/// </summary>
public sealed class QuestEmissary : QuestData
{

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestEmissary"/> class.
  /// </summary>
  public QuestEmissary() : base("Emissary of the Firelands",
    "Ragnaros and the Firelands will join the Old Gods, we need to make contact with them.",
    @"ReplaceableTextures\CommandButtons\BTNHeroAvatarOfFlame.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N025_UN_GORO_CRATER));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_RSW2_QUEST_COMPLETED_EMISSARY_OF_THE_FIRELANDS;

  }

  /// <inheritdoc />
  protected override string RewardDescription => $"Learn to train Ragnaros from the {GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_SKYWALL_ALTAR)} and learn to build the Magma Complex";

}
