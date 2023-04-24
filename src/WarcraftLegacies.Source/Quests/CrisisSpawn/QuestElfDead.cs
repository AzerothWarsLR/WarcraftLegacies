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
  /// Once the elves are dead, Cthun becomes available
  /// </summary>
  public sealed class QuestElfDead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The Night Elves are defeated, C'thun is awakening in the sands of Ahn'qiraj";

    /// <inheritdoc/>
    protected override string RewardDescription => "The C'thun faction will become available to pick as a crisis";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestElfDead"/> class.
    /// </summary>
    public QuestElfDead() : base("Night Elves are Defeated",
      "With the Night Elves eliminated, something stirs in the sands of Ahn'qiraj",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveFactionDefeated(DruidsSetup.Druids));
      AddObjective(new ObjectiveFactionDefeated(SentinelsSetup.Sentinels));
      AddObjective(new ObjectiveFactionDefeated(DraeneiSetup.Draenei));
      ResearchId = Constants.UPGRADE_R091_QUEST_COMPLETED_HORDE_OR_NIGHT_ELF_DEFEATED;
      Required = true;
    }

  }
}