using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestSpreadTheWord : QuestData
  {
    public QuestSpreadTheWord() : base("Spread the Whispers of the Old God",
      "The world shall hear the whispers of the Old God. Spread the visions of the end",
      "ReplaceableTextures\\CommandButtons\\BTNOldGodWhispers.blp")
    {
      AddQuestItem(new QuestItemBuild(FourCC("o03C"), 1));
      AddQuestItem(new QuestItemTrain(FourCC("obot"), FourCC("o03I"), 3));
      ResearchId = FourCC("R05F");
    }
    
    protected override string CompletionPopup => "The high priestess Azil is now trainable";

    protected override string RewardDescription => "The high priestess Azil is trainable at the altar";
  }
}