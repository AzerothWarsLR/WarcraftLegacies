using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Legends;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Gives friendly units near the hero extra armor while they are below half health, on top of the aura's own armor.</summary>
public sealed class CrownOfArathor
{
  private const float Interval = 0.5f;

  private readonly HashSet<unit> _boosted = new();

  public required LegendaryHero Hero { get; init; }
  public required int AuraAbilityId { get; init; }
  public required int BonusAbilityId { get; init; }
  public required float Radius { get; init; }
  public required int MaximumLevel { get; init; }

  /// <summary>Starts checking nearby units.</summary>
  public void Register()
  {
    var check = timer.Create();
    check.Start(Interval, true, Update);
  }

  private void Update()
  {
    var hero = Hero.Unit;
    var level = hero == null || !hero.Alive ? 0 : hero.GetAbilityLevel(AuraAbilityId);
    var stillBoosted = new HashSet<unit>();
    if (hero != null && level > 0)
    {
      foreach (var ally in GlobalGroup.EnumUnitsInRange(hero.X, hero.Y, Radius))
      {
        if (!ally.Alive || !ally.IsAllyTo(hero.Owner) || ally.IsUnitType(unittype.Structure) ||
            ally.UnitType == DummyCasterManager.UnitTypeId || ally.Life >= ally.MaxLife / 2)
        {
          continue;
        }

        if (ally.GetAbilityLevel(BonusAbilityId) != level)
        {
          AuraLevel.SetLevel(ally, BonusAbilityId, level, MaximumLevel);
        }

        stillBoosted.Add(ally);
      }
    }

    foreach (var unit in _boosted)
    {
      if (!stillBoosted.Contains(unit))
      {
        unit.RemoveAbility(BonusAbilityId);
      }
    }

    _boosted.Clear();
    foreach (var unit in stillBoosted)
    {
      _boosted.Add(unit);
    }
  }
}
