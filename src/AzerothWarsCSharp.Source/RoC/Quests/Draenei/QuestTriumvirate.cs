public class QuestTriumvirate{


    private boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Velen has liberated Argus && re-assembled the Crown of Triumvirate";
    }

    private string operator CompletionDescription( ){
      return "You gain the powerful item, the Crown of the Triumvirate";
    }

    private void OnComplete( ){
      UnitAddItemSafe(LEGEND_VELEN.Unit, ARTIFACT_CROWNTRIUMVIRATE.item);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Crown of the Triumvirate", "Eons ago, the council that led the Eredar was the Triumvirate. If Velen could reconquer Argus, he could reform the Crown of the Triumvirate", "ReplaceableTextures\\CommandButtons\\BTNNeverMeltingCrown.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0BH))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0BL))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n09X))));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_VELEN));
      ;;
    }


}
