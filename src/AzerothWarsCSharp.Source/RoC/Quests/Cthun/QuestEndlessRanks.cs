using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public sealed class QuestEndlessRanks : QuestData
  {
    protected override string CompletionPopup => "The Gates of Ahn'qiraj can now be opened";

    protected override string CompletionDescription => "Enable the Gates of Ahn'qiraj to be opened";
    
    public QuestEndlessRanks() : base("The Endless Army",
      "Before opening the Gates of Ahn'qiraj, the armies of C'thunn need to darken the sky and shake the earth itself.",
      "ReplaceableTextures\\CommandButtons\\BTNSwarm.blp")
    {
      AddQuestItem(new QuestItemTrain(FourCC("n06I"), FourCC("o00R"), 24));
      AddQuestItem(new QuestItemTrain(FourCC("u013"), FourCC("o00R"), 6));
      AddQuestItem(new QuestItemTrain(FourCC("o02N"), FourCC("u01H"), 24));
      AddQuestItem(new QuestItemTrain(FourCC("n05V"), FourCC("u01G"), 12));
      AddQuestItem(new QuestItemTrain(FourCC("n060"), FourCC("u01G"), 12));
      AddQuestItem(new QuestItemTrain(FourCC("h01K"), FourCC("u01H"), 8));
      ResearchId = FourCC("R07D");
    }
  }
}