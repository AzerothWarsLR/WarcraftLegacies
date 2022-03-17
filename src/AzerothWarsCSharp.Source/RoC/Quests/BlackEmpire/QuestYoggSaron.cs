public class QuestYoggSaron{

  
    private const int RESEARCH_ID = FourCC(R07R);
  


    private string operator CompletionPopup( ){
      return "Yogg-Saron has been awoken";
    }

    private string operator CompletionDescription( ){
      return "The old god Yogg-Saron will join the Black Empire && enable to train Forgotten ones";
    }

    private void OnComplete( ){
      UnitRescue(gg_unit_U02C_2829, this.Holder.Player)  ;//Yogg
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Fiend of a Thousand Faces", "Yogg-Saron was imprisoned beneath Northrend by the Titans countless millenia ago. ", "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n053))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00I))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n02S))));
      this.ResearchId = RESEARCH_ID;
      ;;
    }


}
