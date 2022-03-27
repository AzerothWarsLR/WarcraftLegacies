using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestScholomanceBuild : QuestData
  {
    protected override string CompletionPopup => "Putress is now trainable.";

    protected override string CompletionDescription => "Putress is trainable at the altar";

    public QuestScholomanceBuild() : base()
    {
      this.AddQuestItem(new QuestItemBuild(FourCC("u011"), 2));
      this.AddQuestItem(new QuestItemBuild(FourCC("h08C"), 20));
      this.AddQuestItem(new QuestItemBuild(FourCC("u014"), 1));
      this.AddQuestItem(new QuestItemBuild(FourCC("u01J"), 2));
      AddQuestItem(new QuestItemUpgrade(FourCC("h08B"), FourCC("h089")));
      ResearchId = FourCC("R04Z");
    }
  }
}