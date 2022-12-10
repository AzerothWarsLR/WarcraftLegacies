using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestDruidsKillFrostwolf : QuestData
  {
    private const int RESEARCH_ID = Constants.UPGRADE_R044_QUEST_COMPLETED_NATURAL_CONTEST_DRUIDS;
    private const int ELEMENTAL_GUARDIAN_ID = Constants.UNIT_E00X_ELEMENTAL_GUARDIAN_DRUIDS_DEMI;

    protected override string CompletionPopup =>
      "The Frostwolves have been driven from Kalimdor. Their departure reveals the existence of a powerful nature spirit that now heeds the call of the Druids.";

    protected override string RewardDescription => "The demihero " + GetObjectName(ELEMENTAL_GUARDIAN_ID);

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, RESEARCH_ID, 1);
      completingFaction.Player.DisplayUnitTypeAcquired(ELEMENTAL_GUARDIAN_ID,
        "You can now train the Elemental Guardian from the Altar of Elders.");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ELEMENTAL_GUARDIAN_ID, 1);
      whichFaction.ModObjectLimit(RESEARCH_ID, Faction.UNLIMITED);
    }

    public QuestDruidsKillFrostwolf() : base("Natural Contest",
      "The Frostwolf Clan has arrived on the shores of Kalimdor. Though their respect of the wild spirits is to be admired, their presence cannot be tolerated.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTaurenChieftain.blp")
    {
      if (LegendFrostwolf.LegendThunderbluff != null)
        AddObjective(new ObjectiveCapitalDead(LegendFrostwolf.LegendThunderbluff));
    }
  }
}