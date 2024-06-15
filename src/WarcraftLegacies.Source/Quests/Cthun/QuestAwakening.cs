using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// C'thun unlocks his ultimate by spending skill points.
  /// </summary>
  public sealed class QuestAwakening : QuestData
  {
    private const int Ultimate = ABILITY_ZBIM_INSPIRE_MADNESS_C_THUN;
    
    /// <inheritdoc />
    public QuestAwakening(LegendaryHero cthun) : base("Awakening",
      "The Old God C'thun, only recently awoken, wields but a shadow of his might during the days of the Black Empire.",
      @"ReplaceableTextures\CommandButtons\BTNMind Crush.blp")
    {
      AddObjective(new ObjectiveSpendSkillPoints(cthun, 5));
      ResearchId = UPGRADE_ZBAW_QUEST_COMPLETED_AWAKENING;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "C'thun's singular gaze opens wide, pouring into the minds of all those unfortunate enough to inhabit Azeroth during his imminent reign.";
    
    /// <inheritdoc />
    protected override string RewardDescription => $"C'thun learns to cast {GetObjectName(Ultimate)}";
  }
}