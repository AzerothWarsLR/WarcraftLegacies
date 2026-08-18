using System.Collections.Generic;
using System.Linq;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Shared.UnitTraits.BonusDamageAttack;

public sealed class BonusDamageOnAttack : UnitTrait, IAppliesEffectOnDamage
{
  public required IReadOnlyList<DamageCondition> Conditions { get; init; }

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

    if (rule.Effect != null)
    {
      effect.Create(rule.Effect, target, "origin").Dispose();
    }

    @event.Damage += rule.Damage;
  }
}
