using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestThePlaguelands : QuestData
  {
    public QuestThePlaguelands() : base("The Plaguelands",
      "The ravaged lands of Lordaeron must be conquered by the Forsaken, their survival depends on it",
      "ReplaceableTextures\\CommandButtons\\BTNNathanosBlightcaller.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendForsaken.LegendNathanos, false));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01F"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n044"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01H"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n03P"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new QuestItemSelfExists());
    }

    //Todo: includes mechanics, should just be flavour
    protected override string CompletionPopup =>
      "The ravaged lands of Lordaeron are now under the control of the Forsaken and able to train up to 4 Val'kyr join their ranks. 500 gold was plundered.";

    protected override string RewardDescription => "Enable 4 Val'kyr to be raised and grants 500 gold";

    protected override void OnComplete()
    {
      Holder.ModObjectLimit(Constants.UNIT_U01V_VAL_KYR_FORSAKEN, 2);
      AdjustPlayerStateBJ(500, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
    }
  }
}