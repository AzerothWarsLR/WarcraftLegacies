using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public class QuestThunderfury{


    protected override string CompletionPopup => 
      return "ChoFourCC(gall has found the legendary sword, Thunderfury";
    }

    protected override string CompletionDescription => 
      return "The legendary sword Thunderfury";
    }

    protected override void OnComplete(){
      GeneralHelpers.UnitAddItemSafe(LEGEND_CHOGALL.Unit, ARTIFACT_THUNDERFURY.item);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Blessed Blade of the Windseeker", "The legendary sword, Thunderfury, has been lost somewhere in the Broken Isles, ChoFourCC(gall has seen it in a vision. It will be a great asto the Old Gods", "ReplaceableTextures\\CommandButtons\\BTNThunderfury2blp");
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_CHOGALL, gg_rct_Broken_Isles, "The Broken Isles"));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n05Y))));
      ;;
    }


  }
}
