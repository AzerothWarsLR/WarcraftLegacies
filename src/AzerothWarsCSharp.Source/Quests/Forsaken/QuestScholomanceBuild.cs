using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestScholomanceBuild : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R04Z")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Putress is now trainable.";

    protected override string CompletionDescription => "Putress is trainable at the altar";

    protected override void OnComplete(){
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  QuestScholomanceBuild ( ){

      this.AddQuestItem(new QuestItemBuild(FourCC("u011"), 2));
      this.AddQuestItem(new QuestItemBuild(FourCC("h08C"), 20));
      this.AddQuestItem(new QuestItemBuild(FourCC("u014"), 1));
      this.AddQuestItem(new QuestItemBuild(FourCC("u01J"), 2));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("h08B"), )h089)));
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
