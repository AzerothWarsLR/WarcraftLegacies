using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Cthun;

/// <summary>
/// C'thun unlocks his ultimate by spending skill points.
/// </summary>
public sealed class QuestAwakening : QuestData
{
  private const int Ultimate = ABILITY_ZBIM_INSPIRE_MADNESS_C_THUN;

  /// <inheritdoc />
  public QuestAwakening(LegendaryHero cthun) : base("Awakening",
    "I have only recently awoken, wielding but a shadow of my might during the days of the Black Empire. I must reclaim my powers.",
    @"ReplaceableTextures\CommandButtons\BTNMind Crush.blp")
  {
    AddObjective(new ObjectiveSpendSkillPoints(cthun, 5));
    ResearchId = UPGRADE_ZBAW_QUEST_COMPLETED_AWAKENING;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "My singular gaze opens wide, pouring into the minds of all those unfortunate enough to inhabit Azeroth during my imminent reign.";

  /// <inheritdoc />
  protected override string RewardDescription => $"C'thun learn to cast {GetObjectName(Ultimate)}";
}
