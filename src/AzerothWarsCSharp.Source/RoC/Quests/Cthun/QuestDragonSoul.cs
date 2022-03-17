public class QuestDragonSoul{


    private string operator CompletionPopup( ){
      return "Skeram will be granted the Dragon Soul";
    }

    private string operator CompletionDescription( ){
      return "The Dragon Soul will be granted to Skeram";
    }

    private void OnComplete( ){
      UnitAddItemSafe(LEGEND_SKERAM.Unit, ARTIFACT_DEMONSOUL.item);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Dragon Soul", "The Dragon Soul was lost in the Blackrock Mountain long ago. Skeram might be powerful enough to restore it.", "ReplaceableTextures\\CommandButtons\\BTNBrokenAmulet.blp");
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_DragonSoulChannel, "Burning Steppe", LEGEND_SKERAM, 240, 160));
      ;;
    }


}
