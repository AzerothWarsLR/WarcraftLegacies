using MacroTools.QuestSystem;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Bring any hero to the Echo Isles to unlock the base.
  /// </summary>
  public sealed class QuestMammoth : QuestData
  {
    private readonly LegendaryHero _rexxar;

    /// <inheritdoc />
    public QuestMammoth(LegendaryHero rexxar) : base("Lone Wanderer",
      "Rexxar is always looking to discover new wilds and new creatures, the Borean Tundra offer a perfect ground to explore.",
      @"ReplaceableTextures/CommandButtons/BTNRevealingLightnewalt.blp")
    {
      _rexxar = rexxar;
      AddObjective(new ObjectiveLegendInRect(rexxar, Regions.Borean_Tundra, "Borean Tundra"));
      ResearchId = Constants.UPGRADE_R0AA_QUEST_COMPLETED_LONE_WANDERER;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Rexxar has tamed the mammoths of the Borean Tundra and has taught the Frostwolf to ride them into battle.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(Constants.UNIT_H0CO_MAMMOTH_WRANGLER_FROSTWOLF)}s from the {GetObjectName(Constants.UNIT_OBEA_BEASTIARY_FROSTWOLF_SPECIALIST)}";

  }
}