using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Goblin
{
  public class QuestLumberMarket{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07Z)   ;//This research is given when the quest is completed
  



    private string operator CompletionPopup( ){
      return "The World Tree is ours, our lumber supplies will never run out!";
    }

    private string operator CompletionDescription( ){
      return "Shredders will gain cleaving attack && 500 hit points. You will gain 30000 lumber.";
    }

    private void OnComplete( ){
      AdjustPlayerStateBJ( 30000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Lumber Market Krash", "The World Tree would provide enough lumber to completely crash the lumber market, forcing our Shredders to specialise more on war.", "ReplaceableTextures\\CommandButtons\\BTNJunkGolem.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NORDRASSIL, false));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
