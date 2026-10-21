using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when one <see cref="LegendaryHero"/> inflicts damage near another while their owners are enemies.
/// </summary>
public sealed class ObjectiveLegendFightsLegend : Objective
{
  private const float Range = 500;

  public ObjectiveLegendFightsLegend(LegendaryHero damagingLegendaryHero, LegendaryHero enemyLegendaryHero)
  {
    SetDescription(
      "{attacker} has fought {target}",
      ("{attacker}", Loc.Get(damagingLegendaryHero.Name)),
      ("{target}", Loc.Get(enemyLegendaryHero.Name)));
    damagingLegendaryHero.DealtDamage += () =>
    {
      var attacker = damagingLegendaryHero.Unit;
      var enemy = enemyLegendaryHero.Unit;
      if (attacker == null || enemy == null || !enemy.Alive || enemy.IsAllyTo(attacker.Owner))
      {
        return;
      }

      if (MathEx.GetDistanceBetweenPoints(attacker.GetPosition(), enemy.GetPosition()) < Range)
      {
        Progress = QuestProgress.Complete;
      }
    };
  }
}
