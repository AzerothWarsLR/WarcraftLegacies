using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WarcraftLegacies.Source.Shared.UnitTraits;
using WCSharp.Effects;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Spells;

public sealed class SunfireBarrageEffectSettings
{
  public string? FireballPath { get; init; }
  public float FireballScale { get; init; } = 1;
  public string? FireballExplosionPath { get; init; }
  public float FireballExplosionScale { get; init; } = 1;
  public string? OrbExplosionPath { get; init; }
  public float OrbExplosionScale { get; init; } = 1;
}

public sealed class SunfireBarrageSpell : Spell
{
  public required LeveledAbilityField<float> FireballDamage { get; init; }
  public required LeveledAbilityField<float> OrbDamage { get; init; }
  public required float OrbBlastRadius { get; init; }
  public required float FireballSpeed { get; init; }
  public required float OrbSpeed { get; init; }
  public required SunfireBarrageEffectSettings Effects { get; init; }

  public SunfireBarrageSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var areaRadius = caster.GetAbility(Id).GetAreaOfEffect_aare(level - 1);

    MissileSystem.Add(new SunfireMissile(caster.Owner, caster.X, caster.Y, targetPoint.X, targetPoint.Y)
    {
      Caster = caster,
      Damage = FireballDamage.GetValue(level),
      BlastRadius = areaRadius,
      ExplosionPath = Effects.FireballExplosionPath,
      ExplosionScale = Effects.FireballExplosionScale,
      EffectString = Effects.FireballPath,
      EffectScale = Effects.FireballScale,
      Speed = FireballSpeed,
      Arc = 0.2f,
      CasterLaunchZ = 100,
      TargetImpactZ = 0,
      Active = true
    });

    foreach (var orb in DefensiveOrbs.TakeOrbs(caster))
    {
      var angle = GetRandomReal(0, 2 * MathEx.Pi);
      var distance = areaRadius * SquareRoot(GetRandomReal(0, 1));
      MissileSystem.Add(new SunfireMissile(caster.Owner, orb.X, orb.Y, targetPoint.X + distance * Cos(angle),
        targetPoint.Y + distance * Sin(angle))
      {
        Caster = caster,
        Damage = OrbDamage.GetValue(level),
        BlastRadius = OrbBlastRadius,
        ExplosionPath = Effects.OrbExplosionPath,
        ExplosionScale = Effects.OrbExplosionScale,
        EffectString = orb.EffectPath,
        EffectScale = 1,
        Speed = OrbSpeed,
        Arc = 0.15f,
        CasterLaunchZ = 50,
        TargetImpactZ = 0,
        Active = true
      });
    }
  }
}

public sealed class SunfireMissile : BasicMissile
{
  public float Damage { get; init; }
  public float BlastRadius { get; init; }
  public string? ExplosionPath { get; init; }
  public float ExplosionScale { get; init; } = 1;

  public SunfireMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY)
    : base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  public override void OnImpact()
  {
    if (ExplosionPath != null)
    {
      var explosion = effect.Create(ExplosionPath, MissileX, MissileY);
      explosion.Scale = ExplosionScale;
      EffectSystem.Add(explosion, 1.5f);
    }

    foreach (var unit in GlobalGroup.EnumUnitsInRange(MissileX, MissileY, BlastRadius))
    {
      if (IsEnemy(unit))
      {
        Caster.DealDamage(unit, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
    }
  }

  private bool IsEnemy(unit target)
  {
    return target.Alive
           && !target.IsInvulnerable
           && target.IsEnemyTo(Caster.Owner)
           && !target.IsUnitType(unittype.Structure)
           && target.UnitType != DummyCasterManager.UnitTypeId;
  }
}
