using MacroTools.Artifacts;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completes when a particular <see cref="Legend"/> has a particular <see cref="Artifact"/>.
/// </summary>
public sealed class ObjectiveLegendHasArtifact : Objective
{
  private readonly Artifact _targetArtifact;
  private readonly Legend _targetLegend;
  private readonly QuestProgress _progressOnArtifactLoss;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveLegendHasArtifact"/> class.
  /// </summary>
  public ObjectiveLegendHasArtifact(Legend targetLegend, Artifact targetArtifact, bool failOnArtifactLoss = false)
  {
    Description = targetLegend is LegendaryHero legendaryHero
      ? $"{legendaryHero.Name} has {targetArtifact.Item.Name}"
      : $"{targetLegend.Unit!.Name} has {targetArtifact.Item.Name}";

    _targetLegend = targetLegend;
    _targetArtifact = targetArtifact;
    _progressOnArtifactLoss = failOnArtifactLoss ? QuestProgress.Failed : QuestProgress.Incomplete;
  }

  public override void OnAdd(Faction whichFaction)
  {
    if (_targetArtifact.OwningUnit != null && _targetArtifact.OwningUnit == _targetLegend.Unit)
    {
      Progress = QuestProgress.Complete;
    }

    _targetArtifact.OwnerChanged += OnArtifactOwnerChanged;
    _targetArtifact.Disposed += (_, _) => Progress = QuestProgress.Failed;
  }

  private void OnArtifactOwnerChanged(object? sender, Artifact artifact)
  {
    Progress = _targetArtifact.OwningUnit != null && _targetArtifact.OwningUnit == _targetLegend.Unit
      ? QuestProgress.Complete
      : _progressOnArtifactLoss;
  }
}
