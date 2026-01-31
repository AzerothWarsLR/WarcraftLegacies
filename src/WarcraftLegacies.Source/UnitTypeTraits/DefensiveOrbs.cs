using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Events;
using WCSharp.Missiles;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// The hero gains arcane orbs when casting abilities, which then collide with enemy units to deal damage.
/// </summary>
public sealed class DefensiveOrbs : UnitTrait, IEffectOnSpellEffect
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// The radius in which the orbs orbit.
  /// </summary>
  public float OrbitRadius { get; init; }

  /// <summary>
  /// The time it takes for the orbs to complete a full rotation.
  /// </summary>
  public float OrbitalPeriod { get; init; }

  /// <summary>
  /// The appearance of the orbs.
  /// </summary>
  public string OrbEffectPath { get; init; } = "";

  /// <summary>
  /// The amount of damage dealt by each orb when they explode.
  /// </summary>
  public LeveledAbilityField<float> Damage { get; init; } = new();

  /// <summary>
  /// The collision radius for the orbs.
  /// </summary>
  public LeveledAbilityField<float> CollisionRadius { get; init; } = new();

  /// <summary>
  /// How long orbs last before detonating.
  /// </summary>
  public float OrbDuration { get; init; }

  /// <summary>
  /// Only abilities in this list generate defensive orbs.
  /// </summary>
  public List<int> AbilityWhitelist { get; init; } = new();

  /// <inheritdoc />
  public DefensiveOrbs(int abilityTypeId) => _abilityTypeId = abilityTypeId;

  /// <inheritdoc />
  public void OnSpellEffect()
  {
    var caster = @event.Unit;
    var abilityLevel = caster.GetAbilityLevel(_abilityTypeId);
    if (abilityLevel == 0 || !AbilityWhitelist.Contains(@event.SpellAbilityId))
    {
      return;
    }

    var newOrb = new DefensiveOrbMissile(caster, caster)
    {
      OrbitalPeriod = OrbitalPeriod,
      CollisionRadius = CollisionRadius.Base + CollisionRadius.PerLevel * abilityLevel,
      EffectString = OrbEffectPath,
      Range = OrbitRadius,
      Damage = Damage.Base + Damage.PerLevel * abilityLevel,
      Duration = OrbDuration
    };
    MissileSystem.Add(newOrb);
  }
}

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
