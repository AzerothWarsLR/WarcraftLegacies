using MacroTools.ArtifactSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestEyeofSargeras : QuestData
{
  public QuestEyeofSargeras(Artifact eyeOfSargeras, LegendaryHero illidan) : base("The Eye of Sargeras",
    "The Eye of Sargeras is an extremely powerful artifact, it could be the key to satiate Illidan's thirst for power.",
    @"ReplaceableTextures\CommandButtons\BTNKazzakIon.blp")
  {
    AddObjective(new ObjectiveLegendHasArtifact(illidan, eyeOfSargeras));
  }

  public override string RewardFlavour =>
    "The Eye of Sargeras' power needs to be channeled by powerful arcanists, the Naga Sea Witch will be the perfect vessels.";
}
