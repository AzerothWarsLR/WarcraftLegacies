using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Hurls a javelin in a line that slows every enemy it pierces and hits harder with each one.</summary>
public sealed class StormJavelinSpell : Spell
{
  public required float Damage { get; init; }
  public required float DamagePerPierce { get; init; }
  public required float Range { get; init; }
  public required float Speed { get; init; }
  public required float CollisionRadius { get; init; }
  public required int SlowAbilityId { get; init; }
  public required string JavelinPath { get; init; }
  public required string HitEffectPath { get; init; }

  public StormJavelinSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    MissileSystem.Add(new StormJavelinMissile(caster, MathEx.GetPolarOffsetX(caster.X, Range, angle),
      MathEx.GetPolarOffsetY(caster.Y, Range, angle))
    {
      Spell = this,
      EffectString = JavelinPath,
      Speed = Speed,
      CollisionRadius = CollisionRadius,
      Active = true
    });
  }

  /// <summary>Damages and slows an enemy the javelin passes through.</summary>
  public void Pierce(unit caster, unit victim, int pierced)
  {
    effect.Create(HitEffectPath, victim, "chest").Dispose();
    caster.DealDamage(victim, Damage + DamagePerPierce * pierced, false, false, attacktype.Normal, damagetype.Magic,
      weapontype.WhoKnows);
    if (victim.Alive)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, SlowAbilityId, ORDER_SLOW, 1, victim, DummyCastOriginType.Target);
    }
  }
}

/// <summary>The javelin from <see cref="StormJavelinSpell"/>.</summary>
public sealed class StormJavelinMissile : BasicMissile
{
  private int _pierced;

  public required StormJavelinSpell Spell { get; init; }

  public StormJavelinMissile(unit caster, float targetX, float targetY) : base(caster, targetX, targetY)
  {
    Mode = FlightMode.FollowTerrain;
  }

  /// <inheritdoc />
  public override void OnCollision(unit unit)
  {
    if (!CastFilters.IsTargetEnemyAndAliveUnits(Caster, unit) || unit.UnitType == DummyCasterManager.UnitTypeId)
    {
      return;
    }

    Spell.Pierce(Caster, unit, _pierced);
    _pierced++;
  }
}
