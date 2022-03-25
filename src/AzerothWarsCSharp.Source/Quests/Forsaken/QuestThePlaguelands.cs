using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestThePlaguelands : QuestData
  {
    public QuestThePlaguelands() : base("The Plaguelands",
      "The ravaged lands of Lordaeron must be conquered by the Forsaken, their survival depends on it",
      "ReplaceableTextures\\CommandButtons\\BTNNathanosBlightcaller.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendForsaken.LegendNathanos, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01F"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n044"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01H"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03P"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new QuestItemSelfExists());
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The ravaged lands of Lordaeron are now under the control of the Forsaken && able to train up to 4 ValFourCC(kyr join their ranks. 500 gold was plundered.";

    protected override string CompletionDescription => "Enable 4 ValFourCC(kyr to be raised && grants 500 gold";

    protected override void OnComplete()
    {
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01V"), 2); //Valyr
      AdjustPlayerStateBJ(500, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
    }
  }
}