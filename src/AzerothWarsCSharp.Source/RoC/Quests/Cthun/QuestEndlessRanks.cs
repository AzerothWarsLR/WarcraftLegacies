using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public class QuestEndlessRanks{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07D)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "The Gates of AhnFourCC(Qiraj can now be opened";
    }

    private string operator CompletionDescription( ){
      return "Enable the Gates of AhnFourCC(Qiraj to be opened";
    }


    public  thistype ( ){
      thistype this = thistype.allocate("The Endless Army", "Before opening the Gates of AhnFourCC(Qiraj, the armies of C)thun need to darken the sky && shake the earth itself.", "ReplaceableTextures\\CommandButtons\\BTNSwarm.blp");
      this.AddQuestItem(QuestItemTrain.create(FourCC(n06I),)o00R), 24));
      this.AddQuestItem(QuestItemTrain.create(FourCC(u013),)o00R), 6));
      this.AddQuestItem(QuestItemTrain.create(FourCC(o02N), )u01H), 24));
      this.AddQuestItem(QuestItemTrain.create(FourCC(n05V), )u01G), 12));
      this.AddQuestItem(QuestItemTrain.create(FourCC(n060), )u01G), 12));
      this.AddQuestItem(QuestItemTrain.create(FourCC(h01K),)u01H), 8));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
