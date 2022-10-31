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
  public sealed class QuestLivingShadow : QuestData
  {
    public QuestLivingShadow() : base("The Living Embodiment of Shadow",
      "The Dark Fortress looming over the Twilight Highlands is a beacon of darkness. Destroy it and clear the surrounding lands of evil.",
      "ReplaceableTextures\\CommandButtons\\BTNShadow Orb.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendLordaeron.LegendUther, Regions.TwilightOutside, "Twilight Citadel"));
      AddObjective(new ObjectiveLegendDead(LegendTwilight.LegendTwilightcitadel));
    }

    protected override string CompletionPopup =>
      "Uther has discovered the Living Embodiment of Shadow in the ruins of the Twilight Citadel";

    protected override string RewardDescription => "The Living Shadow and the Ashbringer Quest discovery";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendLordaeron.LegendUther.Unit.AddItemSafe(ArtifactSetup.ArtifactLivingshadow.Item);
      LordaeronSetup.Lordaeron.AddQuest(LordaeronQuestSetup.TheAshbringer);
      LordaeronQuestSetup.TheAshbringer.Progress = QuestProgress.Incomplete;
    }
  }
}