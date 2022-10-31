using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestThePlaguelands : QuestData
  {
    public QuestThePlaguelands() : base("The Plaguelands",
      "The ravaged lands of Lordaeron must be conquered by the Forsaken, their survival depends on it",
      "ReplaceableTextures\\CommandButtons\\BTNNathanosBlightcaller.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendForsaken.Nathanos, false));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01F"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n044"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01H"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n03P"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01M"))));
      AddObjective(new ObjectiveSelfExists());
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