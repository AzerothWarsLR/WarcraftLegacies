using System.Collections.Generic;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Spells.MassiveAttack;

/// <summary>
/// A very simple Shockwave projectile with configurable range and damage.
/// </summary>
public sealed class MassiveAttackProjectile : BasicMissile
{
  public required float Damage { get; init; }

  public required attacktype AttackType { get; init; }

  public required damagetype DamageType { get; init; }

  /// <summary>
  /// Units that have already been hit by the projectile and thus cannot be hit again.
  /// </summary>
  public List<unit> Hits { get; } = new();

  public MassiveAttackProjectile(unit caster, float targetX, float targetY) : base(caster, targetX, targetY)
  {
    CasterZ = 50;
    TargetImpactZ = 50;
    Speed = 700;
    EffectString = @"Abilities\Spells\Orc\Shockwave\ShockwaveMissile.mdl";
    CollisionRadius = 150f;
  }

  public override void OnCollision(unit unit)
  {
    if (!IsValidTarget(Caster, unit))
    {
      return;
    }

    Caster.DealDamage(unit, Damage, false, false, AttackType, DamageType, weapontype.WhoKnows);
    Hits.Add(unit);
  }

  private bool IsValidTarget(unit target, unit caster) =>
    target.Alive &&
    !target.IsUnitType(unittype.Structure) &&
    !target.IsUnitType(unittype.Ancient) &&
    !caster.Owner.IsAlly(target.Owner)
    | Hits.Contains(target);
}
