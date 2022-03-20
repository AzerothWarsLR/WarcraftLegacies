using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public class QuestIntoTheVoid : QuestData{

  
    private const int QUESTRESEARCH_ID = FourCC(R084)   ;//This research is given when the quest is completed
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Zakajz the Corruptor has been awakened from the Tomb of Tyr && has rejoined his master YoggFourCC(Saron";
    }

    protected override string CompletionDescription => 
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
