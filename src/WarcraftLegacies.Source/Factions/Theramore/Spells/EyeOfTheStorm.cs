using System.Collections.Generic;
using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>When the unit casts a spell, nearby allied ranged units have a chance to attack faster for a short time.</summary>
public sealed class EyeOfTheStorm : UnitTrait, IEffectOnSpellEffect
{
  private readonly Dictionary<unit, Haste> _hastened = new();

  public required float Radius { get; init; }
  public required int ChancePercent { get; init; }
  public required float Duration { get; init; }
  public required int AttackSpeedAbilityId { get; init; }
  public required string EffectPath { get; init; }

  /// <inheritdoc />
  public void OnSpellEffect()
  {
    var caster = @event.Unit;
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!nearby.Alive || nearby.IsUnitType(unittype.Structure) || !nearby.IsUnitType(unittype.RangedAttacker) ||
          (nearby.Owner != caster.Owner && !nearby.IsAllyTo(caster.Owner)) || GetRandomInt(1, 100) > ChancePercent)
      {
        continue;
      }

      Hasten(nearby);
    }
  }

  private void Hasten(unit target)
  {
    if (_hastened.TryGetValue(target, out var haste))
    {
      haste.Expiry.Dispose();
    }
    else
    {
      target.AddAbility(AttackSpeedAbilityId);
      haste = new Haste(effect.Create(EffectPath, target, "overhead"));
      _hastened[target] = haste;
    }

    var expiry = timer.Create();
    haste.Expiry = expiry;
    expiry.Start(Duration, false, () =>
    {
      expiry.Dispose();
      haste.Visual.Dispose();
      _hastened.Remove(target);
      target.RemoveAbility(AttackSpeedAbilityId);
    });
  }

  private sealed class Haste
  {
    public Haste(effect visual) => Visual = visual;

    public effect Visual { get; }

    public timer Expiry { get; set; } = null!;
  }
}
