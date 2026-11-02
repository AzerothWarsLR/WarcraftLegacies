using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Legends;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Gives friendly units near the hero extra armor while they are below half health, on top of the aura's own armor.</summary>
public sealed class CrownOfArathor
{
  private const float Interval = 0.5f;

  private readonly Dictionary<unit, int> _bonusArmor = new();

  public required LegendaryHero Hero { get; init; }
  public required int AuraAbilityId { get; init; }
  public required int BuffAbilityId { get; init; }
  public required float Radius { get; init; }

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
    var wounded = new Dictionary<unit, int>();
    if (hero != null && level > 0)
    {
      foreach (var ally in GlobalGroup.EnumUnitsInRange(hero.X, hero.Y, Radius))
      {
        if (ally.Alive && ally.IsAllyTo(hero.Owner) && !ally.IsUnitType(unittype.Structure) &&
            ally.UnitType != DummyCasterManager.UnitTypeId && ally.Life < ally.MaxLife / 2)
        {
          wounded[ally] = level;
        }
      }
    }

    var expired = new List<unit>();
    foreach (var pair in _bonusArmor)
    {
      if (!wounded.ContainsKey(pair.Key))
      {
        expired.Add(pair.Key);
      }
    }

    foreach (var ally in expired)
    {
      SetBonus(ally, 0);
    }

    foreach (var pair in wounded)
    {
      SetBonus(pair.Key, pair.Value);
    }
  }

  private void SetBonus(unit ally, int armor)
  {
    var current = 0;
    if (_bonusArmor.TryGetValue(ally, out var previous))
    {
      current = previous;
    }

    if (current == armor)
    {
      return;
    }

    BlzSetUnitArmor(ally, BlzGetUnitArmor(ally) + armor - current);
    if (armor == 0)
    {
      _bonusArmor.Remove(ally);
      ally.RemoveAbility(BuffAbilityId);
      return;
    }

    _bonusArmor[ally] = armor;
    if (ally.GetAbilityLevel(BuffAbilityId) == 0)
    {
      ally.AddAbility(BuffAbilityId);
    }
  }
}
