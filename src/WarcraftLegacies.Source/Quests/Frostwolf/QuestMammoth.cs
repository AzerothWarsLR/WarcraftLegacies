using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Frostwolf;

/// <summary>
/// Bring rexxar to the borean tundra to unlock mammoths
/// </summary>
public sealed class QuestMammoth : QuestData
{
  /// <inheritdoc />
  public QuestMammoth(LegendaryHero rexxar) : base("Lone Wanderer",
    "Rexxar's wanderlust has brought him into contact with all kinds of beasts. Yet there is one major landmass he has never ventured to: the cold expanse of Northrend. Surely the wild things roam free even there.",
    @"ReplaceableTextures/CommandButtons/BTNRevealingLightnewalt.blp")
  {
    AddObjective(new ObjectiveLegendInRect(rexxar, Regions.Borean_Tundra, "Borean Tundra"));
    ResearchId = UPGRADE_R0AA_QUEST_COMPLETED_LONE_WANDERER;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Rexxar ventures north into lands once thought incompatible with life, and discovers the paradise of furred megafauna that is the Borean Tundra. He tames the woolly mammoths there, and teaches the Frostwolf to ride them into battle.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    $"Learn to train {GetObjectName(UNIT_H0CO_MAMMOTH_WRANGLER_FROSTWOLF)}s from the {GetObjectName(UNIT_OBEA_BEASTIARY_FROSTWOLF_SPECIALIST)}";

}
