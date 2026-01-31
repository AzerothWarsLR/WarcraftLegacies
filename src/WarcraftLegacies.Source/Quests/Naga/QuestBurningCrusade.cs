using System.Collections.Generic;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestBurningCrusade : QuestData
{
  public QuestBurningCrusade(IEnumerable<Capital> capitalTargets) : base("The Burning Crusade",
    "With the Dark Portal now open, the forces of the Alliance pose a grave threat to Outland. Their cities must be destroyed if the Illidari are to thrive.",
    @"ReplaceableTextures\CommandButtons\BTNLordNaj.blp")
  {
    foreach (var capital in capitalTargets)
    {
      AddObjective(new ObjectiveCapitalDead(capital));
    }

    Knowledge = 25;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Stormwind and Ironforge lie shattered, their armies broken before they could reach the heart of Outland. With the Alliance in ruin, the Illidari have secured their future.";
}
