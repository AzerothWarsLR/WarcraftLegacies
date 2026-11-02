using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;

/// <summary>Destroy the Great Forge to unlock Blackrock Forging.</summary>
public sealed class QuestTheGreatForge : QuestData
{
  public QuestTheGreatForge(Capital theGreatForge) : base("The Great Forge",
    "The Blackrock smiths say the secrets of the dwarves' Great Forge would let them temper armor no axe can split. Tear it down and carry off what its forgemasters knew.",
    @"ReplaceableTextures\CommandButtons\BTNTenebriousArmor.blp")
  {
    AddObjective(new ObjectiveCapitalDead(theGreatForge));
    ResearchId = UPGRADE_R11L_QUEST_COMPLETED_THE_GREAT_FORGE_MAGHAR;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Great Forge lies in ruins. Blackrock smiths pick through the wreckage and learn to work the dwarves' steel.";

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "Learn to research {upgrade} from the {building}",
    ("{upgrade}", GetObjectName(UPGRADE_R11F_BLACKROCK_FORGING_MAGHAR)),
    ("{building}", GetObjectName(UNIT_O20F_FORTRESS_MAGHAR_T3)));
}
