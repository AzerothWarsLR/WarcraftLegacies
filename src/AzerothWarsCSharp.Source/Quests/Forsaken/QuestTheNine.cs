using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestTheNine : QuestData{


    protected override string CompletionPopup => 
      return "Enable up to 9 ValFourCC(kyr join their ranks.";
    }

    protected override string CompletionDescription => 
      return "Enable 9 ValFourCC(kyr to be raised";
    }

    protected override void OnComplete(){
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01V"), 5)           ;//Valyr
    }


    public  thistype ( ){
      thistype this = thistype.allocate("The Nine", "Most of the ValFourCC("kyr are still in Northrend, under the influence of the Lich King, they need to join the Forsaken cause", "ReplaceableTextures\\CommandButtons\\BTNPaleValkyr.blp"");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_SYLVANASV, false));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02J"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03U"))));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_LICHKING));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
