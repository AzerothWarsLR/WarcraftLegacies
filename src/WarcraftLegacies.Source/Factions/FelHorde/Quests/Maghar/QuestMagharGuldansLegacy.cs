using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;

/// <summary>Find Gul'dan's corpse so the Mag'har can turn his betrayal against the demons.</summary>
public sealed class QuestMagharGuldansLegacy : QuestData
{
  public QuestMagharGuldansLegacy() : base("Gul'dan's Legacy",
    "Gul'dan sold the orcs to the demons and drowned them in fel blood. His body lies in the Tomb of Sargeras. Find it, and let every Mag'har see what the Legion's promises are worth.",
    @"ReplaceableTextures\CommandButtons\BTNGuldan.blp")
  {
    AddObjective(new ObjectiveAnyUnitInRect(Regions.GuldansCorpse, "Gul'dan's corpse in the Tomb of Sargeras", true));
    ResearchId = UPGRADE_R11M_QUEST_COMPLETED_GUL_DAN_S_LEGACY_MAGHAR;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Gul'dan's bones are scattered across the tomb floor. The Mag'har swear the Legion will pay for every orc it ever enslaved.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Mag'har units and heroes deal 10% more damage to demons and to the Burning Legion";
}
