using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  public sealed class QuestSurvivorsShattrah : QuestData
  {
    public QuestSurvivorsShattrah() : base("The Survivors of Shattrah",
      "The Shattrah massacre was swift and brutal, if (the Draenei hold long enough in Outland, they might regroup with some of the survivors.",
      "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp")
    {
      AddObjective(new ObjectiveTime(420));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R082_QUEST_COMPLETED_THE_SURVIVORS_OF_SHATTRAH;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The hero Maraad is now trainable at the Altar";

    /// <inheritdoc />
    protected override string RewardDescription => "Maraad will join the survivors on the Exodar";
  }
}