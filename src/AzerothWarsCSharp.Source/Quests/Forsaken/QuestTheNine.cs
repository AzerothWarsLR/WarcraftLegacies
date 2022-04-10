using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestTheNine : QuestData
  {
    public QuestTheNine() : base("The Nine",
      "Most of the Val'kyr are still in Northrend, under the influence of the Lich King, they need to join the Forsaken cause",
      "ReplaceableTextures\\CommandButtons\\BTNPaleValkyr.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendForsaken.LegendSylvanasv, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02J"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03U"))));
      AddQuestItem(new QuestItemLegendDead(LegendScourge.LegendLichking));
      AddQuestItem(new QuestItemSelfExists());
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "Enable up to 9 Val'kyr join their ranks.";

    protected override string RewardDescription => "Enable 9 Val'kyr to be raised";

    protected override void OnComplete()
    {
      Holder.ModObjectLimit(Constants.UNIT_U01V_VAL_KYR_FORSAKEN, 5);
    }
  }
}