
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
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
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R04R_FORTIFIED_HULLS_UNIVERSAL_UPGRADE, Constants.UNIT_HBLA_BLACKSMITH_LORDAERON_RESEARCH));
      ResearchId = Constants.UPGRADE_R068_QUEST_COMPLETED_NAVIGATION;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Boats will be trainable.";

    /// <inheritdoc/>
    protected override string RewardFlavour => "Your faction has mastered navigation and the art of boat building";

  }
}