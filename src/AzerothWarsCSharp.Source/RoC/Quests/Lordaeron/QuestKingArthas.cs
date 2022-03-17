//Prince Arthas goes to the Frozen Throne after it)s destroyed. He becomes King Arthas, gets the Crown of Lordaeron, and Terenas dies.

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Lordaeron
{
  public class QuestKingArthas{

  
    private const int QUEST_RESEARCH_ID = FourCC(R08A)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. King Terenas Menethil proudly abdicates in favor of his son.";
    }

    private string operator CompletionDescription( ){
      return "Arthas gains 2000 experience && the Crown of Lordaeron, && he can no longer permanently die";
    }

    private void OnComplete( ){
      BlzSetUnitName(LEGEND_ARTHAS.Unit, "King of Lordaeron");
      BlzSetUnitName(gg_unit_nemi_0019, "King Emeritus Terenas Menethil");
      RemoveUnit(gg_unit_nemi_0019);
      AddHeroXP(LEGEND_ARTHAS.Unit, 2000, true);
      UnitAddItemSafe(LEGEND_ARTHAS.Unit, ARTIFACT_CROWNLORDAERON.item);
      LEGEND_ARTHAS.ClearUnitDependencies();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Line of Succession", "Arthas Menethil is the one true heir of the Kingdom of Lordaeron. The only thing standing in the way of his coronation is the world-ending threat of the Scourge.", "ReplaceableTextures\\CommandButtons\\BTNArthas.blp");
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_CAPITALPALACE));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, true));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING));
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_ARTHAS, gg_rct_King_Arthas_crown, "King Terenas"));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
