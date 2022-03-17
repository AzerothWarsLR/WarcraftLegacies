public class QuestLegionKillLordaeron{


    private string operator CompletionPopup( ){
      return "The Kingdom of Lordaeron has fallen, eliminating AzerothFourCC(s vanguard against the Legion.";
    }

    private string operator CompletionDescription( ){
      return "Tichondrius gains 15 Strength, Agility && Intelligence";
    }

    private void OnComplete( ){
      DisplayHeroReward(LEGEND_TICHONDRIUS.Unit, 15, 15, 15, 0);
      AddHeroAttributes(LEGEND_TICHONDRIUS.Unit, 15, 15, 15);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Token Resistance", "The Kingdom of Lordaeron must be eliminated to pave the way for the LegionFourCC(s arrival.", "ReplaceableTextures\\CommandButtons\\BTNTichondrius.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_CAPITALPALACE));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STRATHOLME));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_TYRSHAND));
      ;;
    }


}
