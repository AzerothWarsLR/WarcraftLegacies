using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Skywall
{ 
  /// <summary>
  /// Capture points and get Npetulond and tidelords
  /// </summary>
  public sealed class QuestSubduing : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSubduing"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestSubduing() : base("Subduing Neptulon",
      "Neptulon is refusing to join us, we will force him to",
      @"ReplaceableTextures\CommandButtons\BTNTidelord.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N00P_THE_ABYSS));
      AddObjective(new ObjectiveControlPoint(UNIT_N02P_MAK_ARA));
      AddObjective(new ObjectiveControlPoint(UNIT_N04B_GISHAN_CAVERNS));
      AddObjective(new ObjectiveControlPoint(UNIT_N028_DROWNED_REACHES));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_RSW3_QUEST_COMPLETED_SUBDUING_NEPTULON;

    }

    /// <inheritdoc />
    public override string RewardFlavour => "Neptulon has been subdued";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train Ragnaros from the {GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_ELEMENTAL_ALTAR)} and learn to build the Magma Complex";

  }
}