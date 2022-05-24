using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestThePlaguelands : QuestData
  {
    public QuestThePlaguelands() : base("The Plaguelands",
      "The ravaged lands of Lordaeron must be conquered by the Forsaken, their survival depends on it",
      "ReplaceableTextures\\CommandButtons\\BTNNathanosBlightcaller.blp")
    {
      AddQuestItem(new ObjectiveControlLegend(LegendForsaken.LegendNathanos, false));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01F"))));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n044"))));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01H"))));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n03P"))));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new ObjectiveSelfExists());
    }

    //Todo: includes mechanics, should just be flavour
    protected override string CompletionPopup =>
      "The ravaged lands of Lordaeron are now under the control of the Forsaken and able to train up to 4 Val'kyr join their ranks. 500 gold was plundered.";

    protected override string RewardDescription => "Enable 4 Val'kyr to be raised and grants 500 gold";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(Constants.UNIT_U01V_VAL_KYR_FORSAKEN, 2);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 500);
    }
  }
}