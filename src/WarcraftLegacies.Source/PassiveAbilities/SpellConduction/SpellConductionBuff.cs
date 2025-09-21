using System.Linq;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Events;

namespace WarcraftLegacies.Source.PassiveAbilities.SpellConduction;

/// <summary>
/// A percentage of damage this unit takes is redirected to the caster.
/// </summary>
public sealed class SpellConductionBuff : PassiveBuff
{
  /// <summary>
  /// How much damage to redirect to the caster.
  /// </summary>
  public required float RedirectionPercentage { get; init; }

  /// <summary>
  /// Attack types that can be redirected.
  /// </summary>
  public required attacktype[] RedirectableAttackTypes { get; init; }

  /// <inheritdoc />
  public SpellConductionBuff(unit caster, unit target) : base(caster, target)
  {
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    PlayerUnitEvents.Register(UnitEvent.IsDamaged, OnDamageTaken, Target);
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    PlayerUnitEvents.Unregister(UnitEvent.IsDamaged, OnDamageTaken, Target);
  }

  private void OnDamageTaken()
  {
    if (!Caster.Alive)
    {
      return;
    }

    var attackType = @event.AttackType;
    if (!IsRedirectableAttackType(attackType))
    {
      return;
    }

    var eventDamage = @event.Damage;

    @event.Damage = eventDamage * (1 - RedirectionPercentage);
    DamageCaster(@event.DamageSource, eventDamage);
  }

  private void DamageCaster(unit damager, float eventDamage) =>
    Caster.TakeDamage(damager, eventDamage * RedirectionPercentage, false, true, attacktype.Chaos,
      damagetype.Universal, @event.WeaponType);

  private bool IsRedirectableAttackType(attacktype attackType) => RedirectableAttackTypes.Contains(attackType);
}
