using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// With South Alliance destroyed, The Twilight Hammer can reveal themselves in the Highlands
  /// </summary>
  public sealed class QuestSADead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The Twilight Hammer can reveal themselves in the Twilight Highlands";

    /// <inheritdoc/>
    protected override string RewardDescription => "The Twilight Hammer faction will become available to pick as a crisis";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSADead"/> class.
    /// </summary>
    public QuestSADead() : base("South Alliance is Defeated",
      "With the South Alliance eliminated, The Twilight Highlands have a raise in activity",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveFactionDefeated(IronforgeSetup.Ironforge));
      AddObjective(new ObjectiveFactionDefeated(StormwindSetup.Stormwind));
      AddObjective(new ObjectiveFactionDefeated(KultirasSetup.Kultiras));
      ResearchId = Constants.UPGRADE_R09B_QUEST_COMPLETED_SOUTH_ALLIANCE_OR_ILLIDARI_DEFEATED;
      Required = true;
    }

  }
}