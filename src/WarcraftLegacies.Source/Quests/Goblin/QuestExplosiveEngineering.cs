using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  /// <inheritdoc />
  public sealed class QuestExplosiveEngineering : QuestData
  {
    /// <inheritdoc/>
    public override string RewardFlavour => "With the first Bilgewater-owned offshore oil rig now completed, Chief Engineer Gazlowe begins his long journey back home.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Learn to train Gazlowe from the {GetObjectName(UNIT_O03O_ALTAR_OF_INDUSTRY_GOBLIN_ALTAR)}";

    /// <summary>
    /// Initializees a new instance of the <see cref="QuestExplosiveEngineering"/> class.
    /// </summary>
    public QuestExplosiveEngineering() : base("Explosive Engineering",
      "Chief Engineer Gazlowe out at sea, overseeing the construction of the cartel's first offshore oil rig. He will return home when the first one has been constructed.",
      @"ReplaceableTextures\CommandButtons\BTNHeroTinker.blp")
    {
      AddObjective(new ObjectiveBuild(UNIT_O04R_OIL_RIG_GOBLIN_OTHER, 1));
      ResearchId = UPGRADE_R01F_QUEST_COMPLETED_EXPLOSIVE_ENGINEERING_FROSTWOLF;
      
    }
  }
}