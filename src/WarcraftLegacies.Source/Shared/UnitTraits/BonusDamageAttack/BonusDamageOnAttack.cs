using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Shared.UnitTraits.BonusDamageAttack;

public sealed class BonusDamageOnAttack : UnitTrait, IAppliesEffectOnDamage
{
  public required IReadOnlyList<DamageCondition> Conditions { get; init; }

  public float ProcChance { get; init; } = 1f;

  public damagetype? DamageType { get; init; } = null;

  public void OnDealsDamage()
  {
    var target = @event.Unit;

    if (!@event.IsAttack)
    {
      return;
    }

    var rule = Conditions.FirstOrDefault(x => x.Condition(target));

    if (rule == null)
    {
      return;
    }

    var procChance = ProcChance;

    if (GetRandomReal(0, 1) >= procChance)
    {
      return;
    }

    if (DamageType != null)
    {
      @event.DamageType = DamageType;
    }

    if (rule.Effect != null)
    {
      effect.Create(rule.Effect, target, "origin").Dispose();
    }

    target.TakeDamage(@event.DamageSource, rule.Damage, false, false, attacktype.Normal, DamageType);
  }
}
