using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestSentinelsKillWarsong : QuestData
  {
    public QuestSentinelsKillWarsong() : base("Green-skinned Brutes",
      "The Warsong Clan has arrived near Ashenvale and begun threatening the wilds. These invaders must be repelled.",
      "ReplaceableTextures\\CommandButtons\\BTNRaider.blp")
    {
      AddQuestItem(new ObjectiveLegendDead(LegendWarsong.LegendStonemaul));
      ResearchId = Constants.UPGRADE_R007_QUEST_COMPLETED_GREEN_SKINNED_BRUTES_SENTINELS;
    }
    
    protected override string CompletionPopup =>
      "The Warsong presence on Kalimdor has been eliminated. The land has been protected from their misbegotten race.";

    protected override string RewardDescription => "Enable the Watcher Bastion to be built";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}