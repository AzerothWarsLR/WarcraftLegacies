public class QuestClosePortal{



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Khadgar has closed the Dark Portal definately";
    }

    private string operator CompletionDescription( ){
      return "Close the Dark Portal from both sides";
    }

    private void OnComplete( ){
      RemoveUnit(gg_unit_n036_2719);
      RemoveUnit(gg_unit_n036_2720);
      RemoveUnit(gg_unit_n036_1065);

      RemoveUnit(gg_unit_n036_0778);
      RemoveUnit(gg_unit_n036_3291);
      RemoveUnit(gg_unit_n036_3292);

      RemoveUnit(gg_unit_n05J_3375);
      RemoveUnit(gg_unit_n05J_3370);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Seal the Dark Portal", "The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once && for all.", "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp");
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_ClosePortal, "The Dark Portal", LEGEND_KHADGAR, 480, 270));
      ;;
    }


}
