using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>
/// Hurls a hammer that flies out then returns to the caster, damaging and stunning enemies in its path. Enemies
/// can be hit once on the way out and again on the return.
/// </summary>
internal sealed class Stormbolt : Spell
{
  /// <summary>Damage dealt per enemy hit at each level.</summary>
  public required LeveledAbilityField<float> Damage { get; init; }

  /// <summary>Ability used by the dummy caster to apply the stun.</summary>
  public required int StunAbilityId { get; init; }

  public Stormbolt(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var ability = caster.GetAbility(Id);
    var level = caster.GetAbilityLevel(Id);
    var index = level - 1;

    var speed = ability.MissileSpeed;
    var range = ability.GetCastRange_aran(index);

    var casterX = caster.X;
    var casterY = caster.Y;

    var angle = Atan2(targetPoint.Y - casterY, targetPoint.X - casterX);
    var targetX = casterX + range * Cos(angle);
    var targetY = casterY + range * Sin(angle);

    MissileSystem.Add(new Projectile(caster, targetX, targetY)
    {
      Damage = Damage.GetValue(level),
      StunAbilityId = StunAbilityId,
      Speed = speed,
      Level = level
    });
  }

  private sealed class Projectile : BasicMissile
  {
    private const string EffectModel = @"Abilities\Spells\Human\StormBolt\StormBoltMissile.mdl";
    private const float ProjectileCollisionSize = 80;
    private const float TeleportCheckInterval = 0.1f;

    public required float Damage { get; init; }
    public required int StunAbilityId { get; init; }
    public required int Level { get; init; }

    private readonly float _teleportThresholdSq;

    internal Projectile(unit caster, float targetX, float targetY) : base(caster, targetX, targetY)
    {
      EffectString = EffectModel;
      CollisionRadius = ProjectileCollisionSize;
      Mode = FlightMode.FollowTerrain;

      // Treat movement beyond twice the cast range as a teleport.
      var dx = targetX - CasterX;
      var dy = targetY - CasterY;
      _teleportThresholdSq = 4 * (dx * dx + dy * dy);
    }

    public override void OnImpact()
    {
      // Fires at the target point and again upon return; a set interval means we're returning, so expire.
      if (Interval > 0)
      {
        return;
      }

      // Home onto the caster; the system tracks the unit and handles its death.
      Active = true;
      Target = Caster;

      // A non-zero Interval triggers OnPeriodic and signals we're returning.
      Interval = TeleportCheckInterval;

      // Let enemies be struck again on the return.
      TargetsHit.Clear();
    }

    public override void OnPeriodic()
    {
      if (Target == null)
      {
        return;
      }

      // If the caster teleports away, stop homing and redirect the hammer back to the origin.
      var dx = Caster.X - CasterX;
      var dy = Caster.Y - CasterY;
      if (dx * dx + dy * dy > _teleportThresholdSq)
      {
        Target = null;

        // TargetX/Y can't be used; the system moves them to follow the caster before calling OnPeriodic.
        TargetX = CasterX;
        TargetY = CasterY;
      }
    }

    public override void OnDispose()
    {
      // Move the effect below the terrain to suppress its death animation at the caster on return.
      if (Effect != null)
      {
        Effect.SetZ(-1000f);
      }
    }

    public override void OnCollision(unit unit)
    {
      if (!IsValidTarget(unit))
      {
        return;
      }

      DummyCasterManager
        .GetGlobalDummyCaster()
        .CastUnit(Caster, StunAbilityId, ORDER_THUNDERBOLT, Level, unit, DummyCastOriginType.Target);

      unit.TakeDamage(Caster, Damage);
    }

    private bool IsValidTarget(unit unit) => unit.Alive && !unit.IsUnitType(unittype.Structure) && !CastingPlayer.IsAlly(unit.Owner);
  }
}
