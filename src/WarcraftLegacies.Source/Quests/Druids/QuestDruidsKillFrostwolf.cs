using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestDruidsKillFrostwolf : QuestData
  {
    private const int ELEMENTAL_GUARDIAN_ID = Constants.UNIT_E00X_ELEMENTAL_GUARDIAN_DRUIDS_DEMI;

    protected override string RewardFlavour =>
      "The Frostwolves have been driven from Kalimdor. Their departure reveals the existence of a powerful nature spirit that now heeds the call of the Druids.";

    protected override string RewardDescription => $"The demihero {GetObjectName(ELEMENTAL_GUARDIAN_ID)}";

    public QuestDruidsKillFrostwolf(Capital thunderBluff) : base("Natural Contest",
      "The Frostwolf Clan has arrived on the shores of Kalimdor. Though their respect of the wild spirits is to be admired, their presence cannot be tolerated.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTaurenChieftain.blp")
    {
      AddObjective(new ObjectiveCapitalDead(thunderBluff));
      ResearchId = Constants.UPGRADE_R044_QUEST_COMPLETED_NATURAL_CONTEST_DRUIDS;
    }
    
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.DisplayUnitTypeAcquired(ELEMENTAL_GUARDIAN_ID,
        "You can now train the Elemental Guardian from the Altar of Elders.");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ELEMENTAL_GUARDIAN_ID, 1);
    }
  }
}