using System.Linq;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

public sealed class ObjectiveLegendMeetsAnyLegend : Objective
{
  public ObjectiveLegendMeetsAnyLegend(LegendaryHero damagingLegendaryHero, params LegendaryHero[] legendaryHeroesInRange)
  {
    SetDescription(
      "{attacker} has dealt damage within 500 units of {target}",
      ("{attacker}", Loc.Get(damagingLegendaryHero.Name)),
      ("{target}", string.Join(", ", legendaryHeroesInRange.Select(x => Loc.Get(x.Name)))));
    damagingLegendaryHero.DealtDamage += () =>
    {
      if (damagingLegendaryHero.Unit == null)
      {
        return;
      }

      foreach (var legendaryHeroInRange in legendaryHeroesInRange)
      {
        if (legendaryHeroInRange.Unit != null && MathEx.GetDistanceBetweenPoints(damagingLegendaryHero.Unit.GetPosition(),
              legendaryHeroInRange.Unit.GetPosition()) < 500)
        {
          Progress = QuestProgress.Complete;
          return;
        }
      }
    };
  }
}
