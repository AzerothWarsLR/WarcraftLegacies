public class QuestDrektharsSpellbook{


    private string operator CompletionPopup( ){
      return "The World Tree, Nordrassil, has been captured by the forces of the Horde. DrekFourCC(thar has gifted Warchief Thrall his magical spellbook for this achievement.";
    }

    private string operator CompletionDescription( ){
      return "DrekFourCC(thar)s Spellbook";
    }

    private void OnComplete( ){
      ARTIFACT_DREKTHARSSPELLBOOK.setStatus(ARTIFACT_STATUS_GROUND);
      UnitAddItemSafe(LEGEND_THRALL.Unit, ARTIFACT_DREKTHARSSPELLBOOK.item);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("DrektharFourCC(s Spellbook", "The savage Night Elves threaten the safety of the entire Horde. Capture their World Tree && bring Thrall to its roots.", "ReplaceableTextures\\CommandButtons\\BTNSorceressMaster.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NORDRASSIL, false));
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_THRALL, gg_rct_Drekthars_Spellbook, "Nordrassil"));
      ;;
    }


}
