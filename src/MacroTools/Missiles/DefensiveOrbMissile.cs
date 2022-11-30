using System.Linq;
using MacroTools.Extensions;
using MacroTools.Wrappers;
using WCSharp.Events;
using static War3Api.Common;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace MacroTools.Missiles
{
  /// <summary>
  /// Arcane orb that rotates around the caster.
  /// </summary>
  public sealed class DefensiveOrbMissile : OrbitalMissile
  {
    /// <summary>
    /// The radius in which orbs do damage.
    /// </summary>
    public float DamageRadius { get; init; }
    
    /// <summary>
    /// The amount of damage the orb deals.
    /// </summary>
    public float Damage { get; init; }
    
    /// <inheritdoc />
    public DefensiveOrbMissile(unit caster, unit target) : base(caster, target)
    {
      TargetImpactZ = 50;
      EffectScale = 1.0f;
      Interval = PeriodicEvents.SYSTEM_INTERVAL;
    }

    /// <inheritdoc />
    public override void OnCollision(unit unit)
    {
      if (IsUnitEnemy(unit, CastingPlayer)) 
        Detonate();
    }

    private bool IsValidTarget(unit whichUnit)
    {
      return IsUnitAlly(whichUnit, Caster.OwningPlayer()) || !UnitAlive(whichUnit) ||
             BlzIsUnitInvulnerable(whichUnit) || IsUnitType(whichUnit, UNIT_TYPE_STRUCTURE) ||
             IsUnitType(whichUnit, UNIT_TYPE_ANCIENT);
    }
    
    private void Detonate()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRange(new Point(MissileX, MissileY), DamageRadius).EmptyToList().Where(IsValidTarget))
        unit.TakeDamage(Caster, Damage, attackType: ATTACK_TYPE_MAGIC, damageType: DAMAGE_TYPE_MAGIC);
    }
  }
}