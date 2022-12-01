using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Illidan gets the Skull of Gul'dan and does cool stuff with it.
  /// </summary>
  public sealed class QuestADestinyofFlameandSorrow : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestADestinyofFlameandSorrow"/> class.
    /// </summary>
    public QuestADestinyofFlameandSorrow(Artifact artifactSkullOfGuldan) : base("A Destiny of Flame and Sorrow",
      "The Skull of Gul'dan calls for Illidan. If he could harness it's power, he would gain immeasureable power",
      @"ReplaceableTextures\CommandButtons\BTNMetamorphosis.blp")
    {
      AddObjective(new ObjectiveLegendHasArtifact(LegendNaga.LegendIllidan, artifactSkullOfGuldan));
      ResearchId = Constants.UPGRADE_R095_QUEST_COMPLETED_A_DESTINY_OF_FLAME_AND_SORROW;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The Skull of Gul'dan has given Illidan Demonic power beyond measure";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You can now cast Metamorphosis with Illidan";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      LegendNaga.LegendIllidan.Unit?.SetSkin(Constants.UNIT_EEVI_BETRAYER_NAGA);
    }
  }
}