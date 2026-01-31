using System.Collections.Generic;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Naga;

/// <inheritdoc/>
public sealed class QuestBrokenIsles : QuestData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBrokenIsles"/> class.
  /// </summary>
  public QuestBrokenIsles(LegendaryHero illidan) : base("The Broken Isles",
    "With Outland now under Illidan's command, the Demon Hunter has returned to the Broken Isles in search of a legendary demonic artifact: the Eye of the Dark Titan, Sargeras.",
    @"ReplaceableTextures\CommandButtons\BTNMetamorphosis.blp")
  {
    AddObjective(new ObjectiveKillUnitsInRects(new List<Rectangle>
    {
      Regions.BrokenIslesA,
      Regions.BrokenIslesB
    }, "the Broken Isles"));
    AddObjective(new ObjectiveLegendReachRect(illidan, Regions.Sargeras_Entrance, "the Tomb of Sargeras entrance"));
    ResearchId = UPGRADE_R095_QUEST_COMPLETED_THE_BROKEN_ISLES;
    Knowledge = 5;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Broken Isles have been scoured, and it is now clear that the way to the Tomb of Sargeras is closed. Illidan must return to Outland, biding his time before he is strong enough to unlock the Tomb's secrets.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Illidan learns to cast Portal to Black Temple";
}
