using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace TestMap.Source.Quests
{
  public sealed class ExampleQuestB : QuestData
  {
    public ExampleQuestB(QuestData otherQuest) : base("Better Quest", "Don't complete that other quest, he sucks.", "ReplaceableTextures\\CommandButtons\\BTNPaladin.blp")
    {
      AddObjective(new ObjectiveDontCompleteQuest(otherQuest));
      AddObjective(new ObjectiveBuild(FourCC("hbar"), 1));
    }

    protected override string RewardDescription => "No idea.";
    protected override string CompletionPopup => "Thanks for completing me instead of that other quest!";
  }
}