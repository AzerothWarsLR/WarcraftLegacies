using System;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Blasts a cone of wind that damages enemies and pushes them away from the caster.</summary>
public sealed class GaleForceSpell : Spell
{
  public required float Range { get; init; }
  public required float ConeAngle { get; init; }
  public required float Damage { get; init; }
  public required float PushDistance { get; init; }
  public required float PushDuration { get; init; }
  public required string WindEffectPath { get; init; }

  public GaleForceSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var facing = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    for (var distance = Range / 3; distance <= Range; distance += Range / 3)
    {
      effect.Create(WindEffectPath, MathEx.GetPolarOffsetX(caster.X, distance, facing),
        MathEx.GetPolarOffsetY(caster.Y, distance, facing)).Dispose();
    }

    foreach (var nearby in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Range))
    {
      if (nearby.UnitType == DummyCasterManager.UnitTypeId || !CastFilters.IsTargetEnemyAliveAndGroundUnits(caster, nearby))
      {
        continue;
      }

      var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, nearby.X, nearby.Y);
      if (Math.Abs(NormalizeAngle(angle - facing)) > ConeAngle / 2)
      {
        continue;
      }

      caster.DealDamage(nearby, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      if (nearby.Alive)
      {
        Knockback.Push(nearby, angle, PushDistance, PushDuration);
      }
    }
  }

  private static float NormalizeAngle(float angle)
  {
    while (angle > 180)
    {
      angle -= 360;
    }

    while (angle < -180)
    {
      angle += 360;
    }

    return angle;
  }
}
