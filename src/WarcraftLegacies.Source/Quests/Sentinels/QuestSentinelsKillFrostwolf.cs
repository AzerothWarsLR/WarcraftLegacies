using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestSentinelsKillFrostwolf : QuestData
  {
    private const int AmaraId = Constants.UNIT_H03I_MOON_PRIESTESS_AMARA_SENTINELS_DEMI;

    public QuestSentinelsKillFrostwolf() : base("Drive Them Back",
      "The Frostwolf Clan is beginning to seize a firm foothold within the Barrens and on the plains of Mulgore. They must be driven back.",
      "ReplaceableTextures\\CommandButtons\\BTNThrall.blp")
    {
      AddObjective(new ObjectiveCapitalDead(LegendFrostwolf.LegendThunderbluff));
      ResearchId = Constants.UPGRADE_R052_QUEST_COMPLETED_DRIVE_THEM_BACK_SENTINELS;
    }

    protected override string CompletionPopup =>
      "The Frostwolves have been ousted from Kalimdor, along with their Tauren allies. They will !be missed.";

    protected override string RewardDescription => "The demihero Amara and the hero Jarod";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
      completingFaction.Player.DisplayUnitTypeAcquired(AmaraId, "You can now revive Amara from the Altar of Elders.");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(AmaraId, 1);
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}