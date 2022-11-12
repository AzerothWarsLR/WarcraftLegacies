using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static WarcraftLegacies.Source.Setup.ArtifactSetup;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// Acquire Fragments to assemble Zin'rokh.
  /// </summary>
  public sealed class QuestZinrokhAssembly : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZinrokhAssembly"/> class.
    /// </summary>
    public QuestZinrokhAssembly() : base("Destroyer of Worlds", "When Hakkar the Soulflayer was defeated long ago, Zin'rokh was shattered and spread throughout the Troll tribes. The legendary blade could be reforged if its pieces could be unified once more.", @"ReplaceableTextures\CommandButtons\BTNHSZin'Rokhv1.blp")
    {
      AddObjective(new ObjectiveAcquireArtifact(AzureFragment));
      AddObjective(new ObjectiveAcquireArtifact(BronzeFragment));
      AddObjective(new ObjectiveAcquireArtifact(EmeraldFragment));
      AddObjective(new ObjectiveAcquireArtifact(ObsidianFragment));
      AddObjective(new ObjectiveAcquireArtifact(RubyFragment));
      Global = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      $"{AzureFragment?.OwningPlayer?.GetFaction()?.ColoredName ?? ""} has assembled Zin'rokh, Destroyer of Worlds!";
    
    /// <inheritdoc/>
    protected override string RewardDescription => "Reforge Zin'rokh, Destroyer of Worlds from its Shards";
    
    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var azureFragmentHolder = AzureFragment?.OwningUnit;
      AzureFragment?.Dispose();
      BronzeFragment?.Dispose();
      EmeraldFragment?.Dispose();
      ObsidianFragment?.Dispose();
      RubyFragment?.Dispose();
      if (ArtifactZinrokh != null) 
        azureFragmentHolder?.AddItemSafe(ArtifactZinrokh.Item);
    }
  }
}