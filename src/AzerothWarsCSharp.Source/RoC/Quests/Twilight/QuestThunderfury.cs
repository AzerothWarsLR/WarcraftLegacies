using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Twilight
{
  public class QuestThunderfury{


    private string operator CompletionPopup( ){
      return "ChoFourCC(gall has found the legendary sword, Thunderfury";
    }

    private string operator CompletionDescription( ){
      return "The legendary sword Thunderfury";
    }

    private void OnComplete( ){
      UnitAddItemSafe(LEGEND_CHOGALL.Unit, ARTIFACT_THUNDERFURY.item);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Blessed Blade of the Windseeker", "The legendary sword, Thunderfury, has been lost somewhere in the Broken Isles, ChoFourCC(gall has seen it in a vision. It will be a great asto the Old Gods", "ReplaceableTextures\\CommandButtons\\BTNThunderfury2blp");
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_CHOGALL, gg_rct_Broken_Isles, "The Broken Isles"));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n05Y))));
      ;;
    }


  }
}
