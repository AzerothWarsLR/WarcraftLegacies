using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  /// <summary>
  /// Nzoth unlocks his ultimate by spending skill points.
  /// </summary>
  public sealed class QuestAscension : QuestData
  {
    private const int Ultimate = ABILITY_ANMC_MIND_CONFUSION_NZOTH;
    
    /// <inheritdoc />
    public QuestAscension(LegendaryHero nzoth) : base("Ascension",
      "I have been scheming behind the backs of the other old gods  for eons, now my time has come. I will rule the world.",
      @"ReplaceableTextures\CommandButtons\BTNMind Crush.blp")
    {
      AddObjective(new ObjectiveSpendSkillPoints(nzoth, 5));
      ResearchId = UPGRADE_RBAW_QUEST_COMPLETED_ASCENSION;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "The World of Azeroth is mine.";
    
    /// <inheritdoc />
    protected override string RewardDescription => $"N'zoth learn to cast {GetObjectName(Ultimate)}";
  }
}