using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.Display; namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestDruidsKillFrostwolf : QuestData
  {
    private const int RESEARCH_ID = Constants.UPGRADE_R044_QUEST_COMPLETED_NATURAL_CONTEST_DRUIDS;
    private const int ELEMENTAL_GUARDIAN_ID = Constants.UNIT_E00X_ELEMENTAL_GUARDIAN_DRUIDS_DEMI;

    protected override string CompletionPopup =>
      "The Frostwolves have been driven from Kalimdor. Their departure reveals the existence of a powerful nature spirit that now heeds the call of the Druids.";

    protected override string RewardDescription => "The demihero " + GetObjectName(ELEMENTAL_GUARDIAN_ID);

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, ELEMENTAL_GUARDIAN_ID,
        "You can now train the Elemental Guardian from the Altar of Elders.");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ELEMENTAL_GUARDIAN_ID, 1);
      Holder.ModObjectLimit(RESEARCH_ID, Faction.UNLIMITED);
    }

    public QuestDruidsKillFrostwolf() : base("Natural Contest",
      "The Frostwolf Clan has arrived on the shores of Kalimdor. Though their respect of the wild spirits is to be admired, their presence cannot be tolerated.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTaurenChieftain.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendFrostwolf.LegendThunderbluff));
    }
  }
}