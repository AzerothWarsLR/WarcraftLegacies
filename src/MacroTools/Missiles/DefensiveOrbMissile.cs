using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Wrappers;
using WCSharp.Events;
using static War3Api.Common;
using WCSharp.Missiles;
using WCSharp.Shared.Extensions;

namespace MacroTools.Missiles
{
  /// <summary>
  /// Arcane orb that rotates around the caster.
  /// </summary>
  public sealed class DefensiveOrbMissile : OrbitalMissile
  {
    /// <summary>
    /// The amount of damage the orb deals.
    /// </summary>
    public float Damage { get; init; }

    private readonly List<UnitHit> _targetsHitCooldown = new();

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
      if (!IsValidTarget(unit)) 
        return;
      unit.TakeDamage(Caster, Damage, attackType: ATTACK_TYPE_MAGIC, damageType: DAMAGE_TYPE_MAGIC);
      _targetsHitCooldown.Add(new UnitHit(unit));
    }

    /// <inheritdoc />
    public override void OnPeriodic()
    {
      _targetsHitCooldown.IterateWithRemoval(cooldown =>
      {
        cooldown.Age += PeriodicEvents.SYSTEM_INTERVAL;
        if (!(cooldown.Age >= 1)) 
          return true;
        TargetsHit.Remove(cooldown.Unit);
        return false;
      });
    }

    private bool IsValidTarget(unit whichUnit)
    {
      return IsUnitAlly(whichUnit, Caster.OwningPlayer()) || !UnitAlive(whichUnit) ||
             BlzIsUnitInvulnerable(whichUnit) || IsUnitType(whichUnit, UNIT_TYPE_STRUCTURE) ||
             IsUnitType(whichUnit, UNIT_TYPE_ANCIENT);
    }

    private class UnitHit
    {
      public float Age { get; set; }
      public unit Unit { get; }

      public UnitHit(unit unit)
      {
        Unit = unit;
      }
    }
  }
}