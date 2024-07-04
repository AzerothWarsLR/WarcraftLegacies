using System.Collections.Generic;
using MacroTools.Extensions;
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
      return;
    
    UnitDamageTarget(Caster, unit, Damage, false, false, AttackType, DamageType, WEAPON_TYPE_WHOKNOWS);
    Hits.Add(unit);
  }
  
  private bool IsValidTarget(unit target, unit caster) =>
    UnitAlive(target) &&
    !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
    !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
    !IsPlayerAlly(caster.OwningPlayer(), target.OwningPlayer())
    |Hits.Contains(target);
}