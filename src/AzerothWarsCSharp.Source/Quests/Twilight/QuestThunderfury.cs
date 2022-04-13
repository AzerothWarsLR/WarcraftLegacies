using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestThunderfury : QuestData
  {
    public QuestThunderfury() : base("Blessed Blade of the Windseeker", "The legendary sword, Thunderfury, has been lost somewhere in the Broken Isles, Cho'gall has seen it in a vision. It will be a great asset to the Old Gods", "ReplaceableTextures\\CommandButtons\\BTNThunderfury2.blp")
    {
      AddQuestItem(new QuestItemLegendInRect(LegendFelHorde.LegendChogall, Regions.Broken_Isles, "The Broken Isles"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n05Y"))));
    }
    
    protected override string CompletionPopup => "Cho'gall has found the legendary sword, Thunderfury";

    protected override string RewardDescription => "The legendary sword Thunderfury";

    protected override void OnComplete()
    {
      UnitAddItemSafe(LegendFelHorde.LegendChogall.Unit, ArtifactSetup.ArtifactThunderfury.Item);
    }
  }
}