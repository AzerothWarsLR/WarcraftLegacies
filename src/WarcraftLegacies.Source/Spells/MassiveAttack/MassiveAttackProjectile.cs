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

  public MassiveAttackProjectile(unit caster, float targetX, float targetY) : base(caster, targetX, targetY)
  {
    CasterZ = 50;
    TargetImpactZ = 50;
    Speed = 700;
    EffectString = @"Abilities\Spells\Orc\Shockwave\ShockwaveMissile.mdl";
    CollisionRadius = 100f;
  }

  public override void OnImpact()
  {
    UnitDamageTarget(Caster, Target, Damage, true, false, AttackType, DamageType, WEAPON_TYPE_WHOKNOWS);
  }
}