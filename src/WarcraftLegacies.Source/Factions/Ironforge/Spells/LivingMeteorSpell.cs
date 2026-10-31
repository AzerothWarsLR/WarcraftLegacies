using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Calls down a meteor that damages enemies where it lands, then rolls onward and burns enemies in its path.</summary>
public sealed class LivingMeteorSpell : Spell
{
  public required LeveledAbilityField<float> ImpactDamage { get; init; }
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required LeveledAbilityField<float> RollDistance { get; init; }
  public required float Radius { get; init; }
  public required float FallHeight { get; init; }
  public required float FallSpeed { get; init; }
  public required float RollSpeed { get; init; }
  public required float BurnInterval { get; init; }
  public required string MeteorPath { get; init; }
  public required float MeteorScale { get; init; }

  public LivingMeteorSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = caster.GetAbilityLevel(Id);
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    var startX = MathEx.GetPolarOffsetX(targetPoint.X, -FallHeight / 2, angle);
    var startY = MathEx.GetPolarOffsetY(targetPoint.Y, -FallHeight / 2, angle);
    MissileSystem.Add(new FallingMeteorMissile(caster.Owner, startX, startY, targetPoint.X, targetPoint.Y)
    {
      Caster = caster,
      Spell = this,
      Level = level,
      Angle = angle,
      EffectString = MeteorPath,
      EffectScale = MeteorScale,
      Speed = FallSpeed,
      CasterLaunchZ = FallHeight,
      Active = true
    });
  }

  /// <summary>Damages enemies around the point.</summary>
  public void DamageArea(unit caster, float x, float y, float damage)
  {
    foreach (var victim in GlobalGroup.EnumUnitsInRange(x, y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      caster.DealDamage(victim, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }
}

/// <summary>The meteor from <see cref="LivingMeteorSpell"/> falling towards its target point.</summary>
public sealed class FallingMeteorMissile : BasicMissile
{
  public required LivingMeteorSpell Spell { get; init; }
  public required int Level { get; init; }
  public required float Angle { get; init; }

  public FallingMeteorMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  /// <inheritdoc />
  public override void OnImpact()
  {
    Spell.DamageArea(Caster, TargetX, TargetY, Spell.ImpactDamage.GetValue(Level));
    var distance = Spell.RollDistance.GetValue(Level);
    var endX = MathEx.GetPolarOffsetX(TargetX, distance, Angle);
    var endY = MathEx.GetPolarOffsetY(TargetY, distance, Angle);
    MissileSystem.Add(new RollingMeteorMissile(CastingPlayer, TargetX, TargetY, endX, endY)
    {
      Caster = Caster,
      Spell = Spell,
      DamagePerTick = Spell.DamagePerSecond.GetValue(Level) * Spell.BurnInterval,
      EffectString = Spell.MeteorPath,
      EffectScale = Spell.MeteorScale,
      Speed = Spell.RollSpeed,
      Interval = Spell.BurnInterval,
      Active = true
    });
  }
}

/// <summary>The meteor from <see cref="LivingMeteorSpell"/> rolling onward after it lands.</summary>
public sealed class RollingMeteorMissile : BasicMissile
{
  public required LivingMeteorSpell Spell { get; init; }
  public required float DamagePerTick { get; init; }

  public RollingMeteorMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  /// <inheritdoc />
  public override void OnPeriodic() => Spell.DamageArea(Caster, MissileX, MissileY, DamagePerTick);
}
