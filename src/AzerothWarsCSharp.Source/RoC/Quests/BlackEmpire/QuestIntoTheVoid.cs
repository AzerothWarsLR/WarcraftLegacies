using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.BlackEmpire
{
  public class QuestIntoTheVoid{

  
    private const int QUESTRESEARCH_ID = FourCC(R084)   ;//This research is given when the quest is completed
  



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Zakajz the Corruptor has been awakened from the Tomb of Tyr && has rejoined his master YoggFourCC(Saron";
    }

    private string operator CompletionDescription( ){
      return "Gain the hero Zakajz the Corruptor";
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Tomb of Tyr", "Long ago, Zakajz the Corruptor was killed by the Keeper Tyr && entombed with him. Only XalFourCC(atath, the Black Blade, is powerful enough to summon him.", "ReplaceableTextures\\CommandButtons\\BTNGeneralVezax.blp");
      this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_XALATATH));
      this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_XALATATH, gg_rct_TyrsFall, "TyrFourCC(s Fall"));
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_TyrsFall, "The Tomb of Tyr", LEGEND_VOLAZJ, 120, 170));
      this.ResearchId = QUESTRESEARCH_ID;
      ;;
    }


  }
}
