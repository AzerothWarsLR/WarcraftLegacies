using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Missiles;
using WCSharp.Shared.Extensions;

namespace MacroTools.Missiles;

/// <summary>
/// Arcane orb that rotates around the caster.
/// </summary>
public sealed class DefensiveOrbMissile : OrbitalMissile
{
  /// <summary>
  /// The amount of damage the orb deals.
  /// </summary>
  public float Damage { get; init; }

  /// <summary>
  /// How long the orb has before dissipating.
  /// </summary>
  public float Duration { get; set; }

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
    {
      return;
    }

    unit.TakeDamage(Caster, Damage);
    _targetsHitCooldown.Add(new UnitHit(unit));
  }

  /// <inheritdoc />
  public override void OnPeriodic()
  {
    _targetsHitCooldown.IterateWithRemoval(cooldown =>
    {
      cooldown.Age += PeriodicEvents.SYSTEM_INTERVAL;
      if (!(cooldown.Age >= 1))
      {
        return true;
      }

      TargetsHit.Remove(cooldown.Unit);
      return false;
    });
    Duration -= PeriodicEvents.SYSTEM_INTERVAL;
    if (Duration <= 0)
    {
      Active = false;
    }
  }

  private bool IsValidTarget(unit whichUnit) =>
    !whichUnit.IsAllyTo(Caster.Owner) && whichUnit.Alive &&
    !whichUnit.IsInvulnerable && !whichUnit.IsUnitType(unittype.Ancient) &&
    !whichUnit.IsUnitType(unittype.Flying);

  private sealed class UnitHit
  {
    public float Age { get; set; }
    public unit Unit { get; }

    public UnitHit(unit unit)
    {
      Unit = unit;
    }
  }
}
