
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.BlackEmpire
{
  public class QuestBladeOfTheBlackEmpire{


    private string operator CompletionPopup( ){
      return "Herald Volazj has found the Black Blade, XalFourCC(alath.";
    }

    private string operator CompletionDescription( ){
      return "XalFourCC(alath will be ours && the Tomb of Tyr quest will be revealed";
    }

    private void OnComplete( ){
      UnitAddItemSafe(LEGEND_VOLAZJ.Unit, ARTIFACT_XALATATH.item);
      FACTION_BLACKEMPIRE.AddQuest(TOMB_OF_TYR);
      TOMB_OF_TYR.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Blade of the Black Empire", "XalFourCC(alath is one of the oldest && most powerful entities serving the Old Gods, living inside a cursed blade. A human priestess stole it long ago; the blade is entombed with her in Duskwood Crypt.", "ReplaceableTextures\\CommandButtons\\BTNmidnightGS.blp");
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_VOLAZJ, gg_rct_DuskwoodCrypt, "Duskwood Graveyard Crypt"));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DUSKWOODGRAVEYARD, false));
      ;;
    }


  }
}
