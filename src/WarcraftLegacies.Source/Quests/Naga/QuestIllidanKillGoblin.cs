using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  public sealed class QuestIllidanKillGoblin : QuestData
  {
    public QuestIllidanKillGoblin() : base("Clean Sea",
      "The Goblins have been expanding aggressively on the sea. Destroying their trade hub would please the Deep Sea Lord, Naj'entus",
      "ReplaceableTextures\\CommandButtons\\BTNLordNaj.blp")
    {
      AddObjective(new ObjectiveCapitalDead(LegendGoblin.KezanTradingCenter));
      ResearchId = Constants.UPGRADE_R08W_QUEST_COMPLETED_CLEAN_SEA;
    }

    protected override string CompletionPopup =>
      "The Goblins trade center has been destroyed! Without it, the goblin naval power will disperse";

    protected override string RewardDescription => "The hero Naj'entus will join you!";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}