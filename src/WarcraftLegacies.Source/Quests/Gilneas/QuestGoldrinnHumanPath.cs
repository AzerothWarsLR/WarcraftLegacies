using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Go to the Shrine of Goldrinn in Duskwood in order to unlock Goldrinn as a hero
  /// </summary>
  public class QuestGoldrinnHumanPath : QuestData
  {
    private QuestData QuestToFailOnCompletion { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGoldrinnHumanPath"/> class.
    /// </summary>
    public QuestGoldrinnHumanPath(QuestData questToFailOnCompletion, Artifact scytheOfElune) : base("The Twilight Grove", "To understand the plight of her people, Tess will go to the Shrine of Goldrinn in Duskwood to understand what it means to be a Worgen.", "ReplaceableTextures\\CommandButtons\\BTNWorgenHunger.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendGilneas.Tess, Regions.GoldrinnDuskwood, "Shrine of Goldrinn in Duskwood"));
      AddObjective(new ObjectiveArtifactInRect(scytheOfElune, Regions.GoldrinnDuskwood, "Shrine of Goldrinn in Duskwood"));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendGilneas.Genn));
      ResearchId = Constants.UPGRADE_R07U_QUEST_COMPLETED_SHRINE_OF_THE_WOLF_GOD;
      QuestToFailOnCompletion = questToFailOnCompletion;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "Goldrinn has joined Gilneas and they remain in the Alliance.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Goldrinn will be trainable at the altar.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      QuestToFailOnCompletion.Progress = QuestProgress.Failed;
    }
  }
}
