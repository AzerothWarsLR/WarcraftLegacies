using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestDrakUnlock : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R08J");

    public QuestDrakUnlock() : base(
      "DrakFourCC("taron Keep", "Drak")taron)s Keep will be the place for an outpost by the sea.",
      "ReplaceableTextures\\CommandButtons\\BTNUndeadShipyard.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n030"))));
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.legendDraktharonkeep, false));
      AddQuestItem(new QuestItemExpire(1140));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QuestResearchId;
      ;
      ;
    }


    protected override string CompletionPopup => "DrakFourCC(taron Keep is now under the control of the Scourge.";

    protected override string CompletionDescription => "Control of all buildings in DrakFourCC("
    private taron Keep")";

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