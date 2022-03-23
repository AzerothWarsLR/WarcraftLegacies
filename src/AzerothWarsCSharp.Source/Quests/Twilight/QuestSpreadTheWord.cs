using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestSpreadTheWord : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R05F")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "The high priestess Azil is now trainable";

    protected override string CompletionDescription => "The high priestess Azil is trainable at the altar";

    protected override void OnComplete(){
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Spread the Whispers of the Old God", "The world shall hear the whispers of the Old God. Spread the visions of the end", "ReplaceableTextures\\CommandButtons\\BTNOldGodWhispers.blp");
      this.AddQuestItem(new QuestItemBuild(FourCC("o03C"), 1));
      this.AddQuestItem(new QuestItemTrain(FourCC("obot"),)o03I), 3));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
