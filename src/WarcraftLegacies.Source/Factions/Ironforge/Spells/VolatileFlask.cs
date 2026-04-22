using System;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

public sealed class VolatileFlask : Spell
{
  public float Damage { get; init; }
  public float AoE { get; init; }
  public float IgniteDuration { get; init; }
  public float IgniteTickInterval { get; init; }
  public float IgniteDamagePerTick { get; init; }
  public float MaxDamage { get; init; }
  public float CastDistance { get; init; } = 600;

  public VolatileFlask(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    float totalDamage = 0;

    foreach (var u in GlobalGroup.EnumUnitsInRange(targetPoint, AoE))
    {
      if (!u.Alive)
        continue;

      if (totalDamage + Damage > MaxDamage)
        break;

      u.Damage(caster, Damage, attacktype.Magic);
      totalDamage += Damage;

      var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, u.X, u.Y);
      var x = MathEx.GetPolarOffsetX(caster.X, 250, angle);
      var y = MathEx.GetPolarOffsetY(caster.Y, 250, angle);

      var dummy = DummyCasterManager.GetGlobalDummyCaster();
      dummy.SetFacing(angle);

      dummy.CastPointFromCaster(
        caster,
        ABILITY_TP26_FLAMETHROWER_FLAME_TANK_DUMMY,
        ORDER_BREATH_OF_FIRE,
        1,
        x,
        y
      );
    }
    var fx = effect.Create(@"Abilities\Spells\Orc\LiquidFire\Liquidfire.mdl", targetPoint.X, targetPoint.Y);
    fx.Scale = 0.7f;
    EffectSystem.Add(fx, 1.0f);
  }
}
