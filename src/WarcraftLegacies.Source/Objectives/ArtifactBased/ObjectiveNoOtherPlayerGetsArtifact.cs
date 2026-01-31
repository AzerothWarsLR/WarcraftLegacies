using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.ArtifactBased;

/// <summary>
/// Starts completed, and fails if another player acquires the specified <see cref="Artifact"/>.
/// </summary>
public sealed class ObjectiveNoOtherPlayerGetsArtifact : Objective
{
  private readonly Artifact _target;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveNoOtherPlayerGetsArtifact"/> class.
  /// </summary>
  /// <param name="target">The objective fails when this Artifact is acquired by anyone but the objective holder.</param>
  public ObjectiveNoOtherPlayerGetsArtifact(Artifact target)
  {
    _target = target;
    Description = $"No other player has acquired {target.Item.Name}";
  }

  /// <inheritdoc/>
  public override void OnAdd(Faction faction)
  {
    Progress = QuestProgress.Complete;
    _target.OwnerChanged += (_, _) =>
    {
      RefreshProgress(faction);
    };
  }

  private void RefreshProgress(Faction whichFaction)
  {
    Progress = _target.OwningPlayer?.GetPlayerData().Faction == whichFaction ? QuestProgress.Complete : QuestProgress.Failed;
  }
}
