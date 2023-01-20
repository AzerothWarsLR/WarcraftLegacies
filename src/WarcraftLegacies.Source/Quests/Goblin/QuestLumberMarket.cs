using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  public sealed class QuestLumberMarket : QuestData
  {
    protected override string RewardFlavour => "The World Tree is ours, our lumber supplies will never run out!";

    protected override string RewardDescription =>
      "Shredders will gain cleaving attack and 500 hit points. You will gain 30000 lumber.";

    public QuestLumberMarket(Capital nordrassil) : base("Lumber Market Krash",
      "The World Tree would provide enough lumber to completely crash the lumber market, forcing our Shredders to specialise more on war.",
      "ReplaceableTextures\\CommandButtons\\BTNJunkGolem.blp")
    {
      AddObjective(new ObjectiveControlCapital(nordrassil, false));
      ResearchId = Constants.UPGRADE_R07Z_QUEST_COMPLETED_LUMBER_MARKET_CRASH;
    }
    
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 30000);
    }
  }
}