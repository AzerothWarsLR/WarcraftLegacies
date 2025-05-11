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
    public QuestSubduing() : base("Subduing Neptulon",
      "Neptulon is refusing to join us, we will force him to",
      @"ReplaceableTextures\CommandButtons\BTNTidelord.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N00P_THE_ABYSS, 5));
      AddObjective(new ObjectiveControlLevel(UNIT_N02P_MAK_ARA, 5));
      AddObjective(new ObjectiveControlLevel(UNIT_N04B_GISHAN_CAVERNS, 5));
      AddObjective(new ObjectiveControlLevel(UNIT_N028_DROWNED_REACHES, 5));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_RSW3_QUEST_COMPLETED_SUBDUING_NEPTULON;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "Neptulon has been subdued";

    /// <uz />
    protected override string RewardDescription => $"Learn to train Neptulon from the {GetObjectName(UNIT_N078_ALTAR_OF_ELEMENTS_ELEMENTAL_ALTAR)},Tidal Lords from the {GetObjectName(UNIT_N07N_PAVILION_ELEMENTAL_MAGIC)},and unlocks the {GetObjectName(Constants.ABILITY_A0Y4_EARTH_PROTECTION_ELEMENTAL_LORD)} for {GetObjectName(Constants.UNIT_N08S_ELEMENTAL_LORD_ELEMENTAL)}.";
  }
}