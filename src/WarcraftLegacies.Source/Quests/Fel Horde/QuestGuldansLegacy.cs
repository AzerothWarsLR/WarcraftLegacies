using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestGuldansLegacy : QuestData
  {
    protected override string RewardDescription =>
      "Unlock the Blood Runes and Demonic construction researches in the War Mill";

    protected override string CompletionPopup =>
      "Gul'dan's remains have been located within the Tomb of Sargeras. His eldritch knowledge may now be put to purpose.";

    public QuestGuldansLegacy() : base("Gul'dans Legacy",
      "The Orc Warlock Gul'dan is ultimately responsible for the formation of the Fel Horde. Though long dead, his teachings could still be extracted from his body.",
      "ReplaceableTextures\\CommandButtons\\BTNGuldan.blp")
    {
      AddObjective(new ObjectiveAnyUnitInRect(Regions.GuldansCorpse, "Gul'dan's corpse in the Tomb of Sargeras", true));
      ResearchId = Constants.UPGRADE_R041_QUEST_COMPLETED_GUL_DANS_LEGACY_FEL_HORDE;
    }
  }
}