using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when the <see cref="LegendaryHero"/> is trained, by anyone.
/// </summary>
public sealed class ObjectiveLegendaryHeroTrained : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveLegendaryHeroTrained"/> class.
  /// </summary>
  public ObjectiveLegendaryHeroTrained(LegendaryHero target)
  {
    target.ChangedOwner += OnTargetChangeOwner;
  }

  private void OnTargetChangeOwner(object? sender, LegendChangeOwnerEventArgs e)
  {
    Progress = QuestProgress.Complete;
  }
}
