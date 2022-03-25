using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestThunderfury : QuestData
  {
    public QuestThunderfury()
    {
      thistype this = thistype.allocate("Blessed Blade of the Windseeker",
        "The legendary sword, Thunderfury, has been lost somewhere in the Broken Isles, ChoFourCC("gall has seen it in a vision
          .It will be a great asto the Old Gods", "ReplaceableTextures\\CommandButtons\\BTNThunderfury2blp");
      AddQuestItem(new QuestItemLegendInRect(LEGEND_CHOGALL, Regions.BrokenIsles.Rect, "The Broken Isles"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n05Y"))));
    }


    protected override string CompletionPopup => "ChoFourCC(gall has found the legendary sword, Thunderfury";

    protected override string CompletionDescription => "The legendary sword Thunderfury";

    protected override void OnComplete()
    {
      UnitAddItemSafe(LEGEND_CHOGALL.Unit, ARTIFACT_THUNDERFURY.Item);
    }
  }
}