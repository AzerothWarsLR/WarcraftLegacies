using MacroTools.Artifacts;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ArtifactBased;

namespace WarcraftLegacies.Source.Factions.Sunfury.Quests;

/// <summary>Roleplay quest that unlocks Kagani Nightstrike with the Essence of Murmur.</summary>
public sealed class QuestSilentBlade : QuestData
{
  public QuestSilentBlade(Artifact essence) : base("The Silent Blade",
    "Murmur, the living silence of Auchindoun, has been torn apart, but its essence still swallows every sound. Bring it to Kagani Nightstrike, and the prince's finest assassin will strike without a whisper.",
    @"ReplaceableTextures\CommandButtons\BTNSpell_Shadow_SummonVoidWalker.blp")
  {
    AddObjective(new ObjectiveAcquireArtifact(essence));
    ResearchId = UPGRADE_R09K_QUEST_COMPLETED_THE_HIGH_ASTROMANCER_OR_THE_SILENT_BLADE;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Wrapped in Murmur's silence, Kagani Nightstrike steps out of the shadows to serve the prince.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Learn to train Kagani Nightstrike from the {altar}",
    ("{altar}", GetObjectName(UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR)));
}
