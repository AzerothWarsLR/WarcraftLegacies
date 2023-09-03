
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// boats will be unlocked at a certain turn
  /// </summary>
  public sealed class QuestNavigation : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestNavigation"/> class.
    /// </summary>

    public QuestNavigation() : base("Navigation",
      "The rough waters of Azeroth will require time to master.",
      @"ReplaceableTextures\CommandButtons\BTNHumanTransport.blp")
    {
      AddObjective(new ObjectiveTime(780));
      ResearchId = Constants.UPGRADE_R068_QUEST_COMPLETED_NAVIGATION;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Boats will be trainable.";

    /// <inheritdoc/>
    protected override string RewardFlavour => "Navigation has become available.";

  }
}