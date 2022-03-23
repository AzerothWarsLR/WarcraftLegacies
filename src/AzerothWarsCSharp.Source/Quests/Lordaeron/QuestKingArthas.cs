//Prince Arthas goes to the Frozen Throne after it)s destroyed. He becomes King Arthas, gets the Crown of Lordaeron, and Terenas dies.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestKingArthas : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R08A")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. King Terenas Menethil proudly abdicates in favor of his son.";

    protected override string CompletionDescription => "Arthas gains 2000 experience && the Crown of Lordaeron, && he can no longer permanently die";

    protected override void OnComplete(){
      BlzSetUnitName(LEGEND_ARTHAS.Unit, "King of Lordaeron");
      BlzSetUnitName(gg_unit_nemi_0019, "King Emeritus Terenas Menethil");
      RemoveUnit(gg_unit_nemi_0019);
      AddHeroXP(LEGEND_ARTHAS.Unit, 2000, true);
      GeneralHelpers.UnitAddItemSafe(LEGEND_ARTHAS.Unit, ARTIFACT_CROWNLORDAERON.item);
      LEGEND_ARTHAS.ClearUnitDependencies();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Line of Succession", "Arthas Menethil is the one true heir of the Kingdom of Lordaeron. The only thing standing in the way of his coronation is the world-ending threat of the Scourge.", "ReplaceableTextures\\CommandButtons\\BTNArthas.blp");
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_CAPITALPALACE));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_ARTHAS, true));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_LICHKING));
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_ARTHAS, Regions.King_Arthas_crown.Rect, "King Terenas"));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
