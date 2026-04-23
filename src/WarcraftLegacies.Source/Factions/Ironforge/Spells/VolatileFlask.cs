using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Missiles;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

public sealed class VolatileFlask : Spell
{
  public float Damage { get; init; }
  public float AoE { get; init; }
  public float MaxDamage { get; init; }

  public VolatileFlask(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var missile = new VolatileFlaskProjectile(caster, targetPoint.X, targetPoint.Y)
    {
      Damage = Damage,
      AoE = AoE,
      MaxDamage = MaxDamage
    };

    MissileSystem.Add(missile);
  }
}

public sealed class VolatileFlaskProjectile : BasicMissile
{
  public float Damage { get; init; }
  public float AoE { get; init; }
  public float MaxDamage { get; init; }

  private float _totalDamage;

  public VolatileFlaskProjectile(unit caster, float targetX, float targetY)
    : base(caster, targetX, targetY)
  {
    Speed = 900;
    Arc = 0.15f;
    EffectString = @"Abilities\\spells\\other\\acidbomb\\bottlemissile.mdx"";";
    EffectScale = 1.0f;
    CollisionRadius = 0;
    CasterLaunchZ = 50;
    TargetImpactZ = 50;
    Active = true;
  }

  public override void OnImpact()
  {
    var fx = effect.Create(@"Abilities\\Spells\\Orc\\LiquidFire\\Liquidfire.mdl", MissileX, MissileY);
    fx.Scale = 0.7f;
    EffectSystem.Add(fx, 1.0f);

    var dummy = DummyCasterManager.GetGlobalDummyCaster();

    foreach (var u in GlobalGroup.EnumUnitsInRange(new Point(MissileX, MissileY), AoE))
    {
      if (!u.Alive)
      {
        continue;
      }

      if (_totalDamage + Damage > MaxDamage)
      {
        break;
      }

      u.Damage(Caster, Damage, attacktype.Magic);
      _totalDamage += Damage;

      var angle = MathEx.GetAngleBetweenPoints(MissileX, MissileY, u.X, u.Y);
      var x = MathEx.GetPolarOffsetX(MissileX, 50, angle);
      var y = MathEx.GetPolarOffsetY(MissileY, 50, angle);

      dummy.SetFacing(angle);

      dummy.CastPointFromCaster(
        Caster,
        ABILITY_TP26_BREATH_OF_FIRE_VOLATILE_FLASK_DUMMY,
        ORDER_BREATH_OF_FIRE,
        1,
        x,
        y
      );
    }
  }
}
