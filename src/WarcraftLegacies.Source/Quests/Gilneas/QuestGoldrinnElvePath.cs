using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Go to the Shrine of Goldrinn on Mount Hyjal to unlock Goldrinn as a hero and join the Night Elves.
  /// </summary>
  public class QuestGoldrinnElvePath : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGoldrinnElvePath"/> class.
    /// </summary>
    public QuestGoldrinnElvePath(Artifact scytheOfElune) : base("Shrine of the Wolf God", "To understand the plight of her people, Tess will go to the Shrine of Goldrinn in Hyjal to understand what it means to be a Worgen.", "ReplaceableTextures\\CommandButtons\\BTNWorgenMoon.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendGilneas.Tess, Regions.GoldrinnHyjal, "Shrine of Goldrinn in Mount Hyjal"));
      AddObjective(new ObjectiveArtifactInRect(scytheOfElune, Regions.GoldrinnHyjal, "Shrine of Goldrinn in Mount Hyjal"));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendGilneas.Genn));
      ResearchId = Constants.UPGRADE_R07U_QUEST_COMPLETED_SHRINE_OF_THE_WOLF_GOD;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "Goldrinn has joined Gilneas.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Goldrinn will be trainable at the altar and you will join the Night Elves.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      GilneasSetup.Gilneas?.Player?.SetTeam(TeamSetup.NightElves);
    }

  }
}