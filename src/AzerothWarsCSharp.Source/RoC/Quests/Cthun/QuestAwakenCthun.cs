using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public class QuestAwakenCthun{

  
    private const int QUEST_RESEARCH_ID = FourCC(R06A)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "CFourCC(thun, Old God of madness && chaos, has awakened from his slumber. Azeroth itself shrinks back in fear as this unfathomably evil entity unleashes its singular gaze for the first time in millenia.";
    }

    private string operator CompletionDescription( ){
      return "Gain control of CFourCC(thun && the ability to train Wasps" ;//Todo: from where?
    }

    private void OnComplete( ){
      SetUnitInvulnerable(gg_unit_U00R_0609, false);
      PauseUnitBJ(false, gg_unit_U00R_0609) ;//Todo: no point using the BJ
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Awakening of CFourCC(thun", "The Old God C)thun slumbers beneath the ruins of Ahn)qiraj. Skeram will need to awaken him with an unholy ritual.", "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp");
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_CthunSummon, "CFourCC(thun", LEGEND_SKERAM, 420, 270));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
