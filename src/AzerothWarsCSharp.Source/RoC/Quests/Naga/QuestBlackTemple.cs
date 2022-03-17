public class QuestBlackTemple{



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Illidan has killed Magtheridon && subjugated the Fel Horde, the Illidari grow strong.";
    }

    private string operator CompletionDescription( ){
      return "The Fel Horde will join us && Magtheridon will die";
    }

    private void OnComplete( ){
      if (FACTION_NAGA.Team == TEAM_NAGA){
        FACTION_FEL_HORDE.Team = TEAM_NAGA;
      }
      RemoveUnit(LEGEND_MAGTHERIDON.Unit);
      FACTION_FEL_HORDE.ModObjectLimit(FourCC(Nmag), -UNLIMITED)           ;//Magtheridon
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Lord of Outland", "The Fel Horde is weak && complacent. The Illidari will easily subjugate them into IllidanFourCC(s service.", "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_BLACKTEMPLE, false));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00R))));
      this.AddQuestItem(QuestItemResearch.create(FourCC(R063), )n055)));
      ;;
    }


}
