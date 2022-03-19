using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Legion
{
  public class QuestLegionCaptureSunwell{

  
    private const int RESEARCH_ID = FourCC(R054);
  


    protected override string CompletionPopup => 
      return "The Sunwell has been captured by the Scourge. It now writhes with necromantic energy.";
    }

    protected override string CompletionDescription => 
      return "A research improving your Dreadlords";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
      DisplayResearchAcquired(this.Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Fall of Silvermoon", "The Sunwell is the source of the High ElvesFourCC( immortality && magical prowess. Under control of the Scourge, it would be the source of immense necromantic power.", "ReplaceableTextures\\CommandButtons\\BTNOrbOfCorruption.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false));
      ;;
    }


  }
}
