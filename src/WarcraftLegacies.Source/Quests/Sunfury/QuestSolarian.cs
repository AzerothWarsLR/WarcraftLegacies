using MacroTools.ArtifactSystem;
using MacroTools.ObjectiveSystem.Objectives.ArtifactBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Sunfury
{
  /// <summary>
  /// The druids gets Solarian
  /// </summary>
  public sealed class QuestSolarian : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSolarian"/> class.
    /// </summary>
    /// <param name="essence">Required to complete the quest.</param>
    public QuestSolarian(Artifact essence) : base("The High Astromancer",
      "The Astromancers research the Void. There would be no better artifact to study than the Essence of Murmur, a powerful Void Lord",
      "ReplaceableTextures\\CommandButtons\\BTNSpell_Shadow_SummonVoidWalker.blp")
    {
      AddObjective(new ObjectiveAcquireArtifact(essence));
      Required = true;
      ResearchId = Constants.UPGRADE_R09K_QUEST_COMPLETED_THE_HIGH_ASTROMANCER;
    }

    /// <inheritdoc />
    protected override string RewardFlavour => "The Essence of Murmur has been studied.";

    /// <inheritdoc />
    protected override string RewardDescription => "Unlock Solarian, the High Astromancer at the altar.";

  }
}