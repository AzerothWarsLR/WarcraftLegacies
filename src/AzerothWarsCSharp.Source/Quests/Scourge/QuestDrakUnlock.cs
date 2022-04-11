using AzerothWarsCSharp.MacroTools.Factions;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestDrakUnlock : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R08J");

    public QuestDrakUnlock() : base(
      "Draktharon's Keep", "Drak'tharon's Keep will be the place for an outpost by the sea.",
      "ReplaceableTextures\\CommandButtons\\BTNUndeadShipyard.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n030"))));
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      AddQuestItem(new QuestItemExpire(1140));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QuestResearchId;
      ;
      ;
    }


    protected override string CompletionPopup => "DrakFourCC(taron Keep is now under the control of the Scourge.";

    protected override string RewardDescription => "Control of all buildings in Drak'tharon Keep";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.DrakUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.DrakUnlock.Rect, Holder.Player);
    }
  }
}