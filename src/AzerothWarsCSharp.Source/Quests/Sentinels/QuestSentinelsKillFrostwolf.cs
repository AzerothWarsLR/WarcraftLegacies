using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestSentinelsKillFrostwolf : QuestData
  {
    private static readonly int AmaraId = FourCC("h03I");

    public QuestSentinelsKillFrostwolf() : base("Drive Them Back",
      "The Frostwolf Clan is beginning to seize a firm foothold within the Barrens && on the plains of Mulgore. They must be driven back.",
      "ReplaceableTextures\\CommandButtons\\BTNThrall.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendFrostwolf.LegendThunderbluff));
      ResearchId = FourCC("R052");
    }

    protected override string CompletionPopup =>
      "The Frostwolves have been ousted from Kalimdor, along with their Tauren allies. They will !be missed.";

    protected override string RewardDescription => "The demihero Amara && the hero Jarod";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, AmaraId, "You can now revive Amara from the Altar of Elders.");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(AmaraId, 1);
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}