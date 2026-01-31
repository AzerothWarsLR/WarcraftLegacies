using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Objective that is completed when one <see cref="LegendaryHero"/> inflicts damage while in range of another <see cref="LegendaryHero"/>.
/// </summary>
public sealed class ObjectiveLegendMeetsLegend : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveLegendMeetsLegend"/> class.
  /// </summary>
  public ObjectiveLegendMeetsLegend(LegendaryHero damagingLegendaryHero, LegendaryHero legendaryHeroInRange)
  {
    Description = $"{damagingLegendaryHero.Name} has dealt damage within 500 units of {legendaryHeroInRange.Name}";
    damagingLegendaryHero.DealtDamage += (_, _) =>
    {
      if (damagingLegendaryHero.Unit == null || legendaryHeroInRange.Unit == null)
      {
        return;
      }

      if (MathEx.GetDistanceBetweenPoints(damagingLegendaryHero.Unit.GetPosition(),
            legendaryHeroInRange.Unit.GetPosition()) < 500)
      {
        Progress = QuestProgress.Complete;
      }
    };
  }
}
