using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Bring <see cref="LegendLordaeron.Uther"/> to the <see cref="LegendTwilight.LegendTwilightcitadel"/> and destroy it to gain the <see cref="ArtifactSetup.ArtifactLivingshadow"/>
  /// </summary>
  public sealed class QuestLivingShadow : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestLivingShadow"/> cla
    /// </summary>
    public QuestLivingShadow() : base("The Living Embodiment of Shadow",
      "The Dark Fortress looming over the Twilight Highlands is a beacon of darkness. Destroy it and clear the surrounding lands of evil.",
      "ReplaceableTextures\\CommandButtons\\BTNShadow Orb.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendLordaeron.Uther, Regions.TwilightOutside, "Twilight Citadel"));
      AddObjective(new ObjectiveLegendDead(LegendTwilight.LegendTwilightcitadel));
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "Uther has discovered the Living Embodiment of Shadow in the ruins of the Twilight Citadel";

    /// <inheritdoc/>
    protected override string RewardDescription => "The Living Shadow and the Ashbringer Quest discovery";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      LegendLordaeron.Uther.Unit.AddItemSafe(ArtifactSetup.ArtifactLivingshadow.Item);
      LordaeronSetup.Lordaeron.AddQuest(LordaeronQuestSetup.TheAshbringer);
      LordaeronQuestSetup.TheAshbringer.Progress = QuestProgress.Incomplete;
    }
  }
}