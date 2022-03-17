public class QuestBlueDragons{

  
    private const int RESEARCH_ID = FourCC(R00U);
    private const int DRAGON_ID = FourCC(n0AC);
    private const int MANADAM_ID = FourCC(R00N);
  


    private string operator CompletionPopup( ){
      return "The Nexus has been captured. The Blue Dragonflight fights for " + this.Holder.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Learn to train Blue Dragons";
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, DRAGON_ID, "You can now train Blue Dragons from Military Quarters && the Nexus.");
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(DRAGON_ID, 6);
      this.Holder.ModObjectLimit(MANADAM_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Blue Dragonflight", "The Blue Dragons of Northrend are the wardens of magic on Azeroth. They might be convinced to willingly join the mages of Dalaran.", "ReplaceableTextures\\CommandButtons\\BTNAzureDragon.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NEXUS, false));
      ;;
    }


}
