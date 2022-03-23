using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestTheNine : QuestData{


    protected override string CompletionPopup => "Enable up to 9 ValFourCC(kyr join their ranks.";

    protected override string CompletionDescription => "Enable 9 ValFourCC(kyr to be raised";

    protected override void OnComplete(){
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01V"), 5)           ;//Valyr
    }


    public  thistype ( ){
      thistype this = thistype.allocate("The Nine", "Most of the ValFourCC("kyr are still in Northrend, under the influence of the Lich King, they need to join the Forsaken cause", "ReplaceableTextures\\CommandButtons\\BTNPaleValkyr.blp"");
      AddQuestItem(new QuestItemControlLegend(LEGEND_SYLVANASV, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02J"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03U"))));
      AddQuestItem(new QuestItemLegendDead(LEGEND_LICHKING));
      AddQuestItem(new QuestItemSelfExists());
      
    }


  }
}
