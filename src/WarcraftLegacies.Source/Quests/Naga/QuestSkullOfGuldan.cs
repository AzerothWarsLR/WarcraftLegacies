using MacroTools.ArtifactSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Acquire the <see cref="ArtifactSetup.EyeOfSargeras"/> to unlock Coilfang Summoners
  /// </summary>
  public sealed class QuestSkullOfGuldan : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestEyeofSargeras"/> class.
    /// </summary>
    public QuestSkullOfGuldan(Artifact skullofGuldan, LegendaryHero illidan) : base("A Destiny of Flame and Sorrow",
      "The Skull of Gul'dan would give Illidan immeasurable power",
      "ReplaceableTextures\\CommandButtons\\BTNEyeOfSargeras.blp")
    {
      AddObjective(new ObjectiveLegendHasArtifact(illidan, skullofGuldan));
      ResearchId = Constants.UPGRADE_R095_QUEST_COMPLETED_A_DESTINY_OF_FLAME_AND_SORROW;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Skull of Gul'dan is an artifact of immeasurable deamonic power. It would grant Illidan the power he has always craved";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Gain the Skull of Gul'dan and the ability to cast Metamorphosis";
  }
}