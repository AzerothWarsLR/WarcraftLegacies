using MacroTools.ArtifactSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Acquire the <see cref="ArtifactSetup.EyeOfSargeras"/> to unlock Coilfang Summoners
  /// </summary>
  public sealed class QuestEyeofSargeras : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestEyeofSargeras"/> class.
    /// </summary>
    /// <param name="eyeOfSargeras"></param>
    public QuestEyeofSargeras(Artifact eyeOfSargeras) : base("The Eye of Sargeras",
      "The Eye of Sargeras is an extremely powerful artifact, it could be the key to satiate Illidan's thirst for power.",
      "ReplaceableTextures\\CommandButtons\\BTNEyeOfSargeras.blp")
    {
      AddObjective(new ObjectiveLegendHasArtifact(LegendNaga.LegendIllidan, eyeOfSargeras));
      ResearchId = FourCC("R094");
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The Eye of Sargeras' power needs to be channeled by powerful arcanists, the Summoners will be the perfect vessels.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Gain the Eye of Sargeras and the ability to train Coilfang Summoners";
  }
}