using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>The caster leaps backwards, then fires a fan of arrows back at the spot it left.</summary>
public sealed class ShadowStepSpell : Spell
{
  private const float StepInterval = 0.03f;

  public required LeveledAbilityField<float> Damage { get; init; }
  public required float LeapDistance { get; init; }
  public required float LeapDuration { get; init; }
  public required int ArrowCount { get; init; }
  public required float FanAngle { get; init; }
  public required float ArrowRange { get; init; }
  public required float ArrowWidth { get; init; }
  public required string ArrowPath { get; init; }
  public required string LeapEffectPath { get; init; }

  public ShadowStepSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var facing = caster.Facing;
    var leapAngle = facing + 180;
    var steps = (int)(LeapDuration / StepInterval);
    var stepDistance = LeapDistance / steps;
    var damage = Damage.GetValue(GetAbilityLevel(caster));
    effect.Create(LeapEffectPath, caster.X, caster.Y).Dispose();
    var stepsTaken = 0;
    var leap = timer.Create();
    leap.Start(StepInterval, true, () =>
    {
      var nextX = MathEx.GetPolarOffsetX(caster.X, stepDistance, leapAngle);
      var nextY = MathEx.GetPolarOffsetY(caster.Y, stepDistance, leapAngle);
      stepsTaken++;
      var blocked = IsTerrainPathable(nextX, nextY, PATHING_TYPE_WALKABILITY);
      if (!blocked && caster.Alive)
      {
        caster.SetPosition(nextX, nextY);
        caster.Facing = facing;
      }

      if (stepsTaken < steps && !blocked && caster.Alive)
      {
        return;
      }

      leap.Dispose();
      if (caster.Alive)
      {
        FireArrows(caster, facing, damage);
      }
    });
  }

  private void FireArrows(unit caster, float facing, float damage)
  {
    var firstAngle = facing - FanAngle / 2;
    var spacing = ArrowCount > 1 ? FanAngle / (ArrowCount - 1) : 0;
    var struck = new HashSet<unit>();
    for (var i = 0; i < ArrowCount; i++)
    {
      var angle = firstAngle + spacing * i;
      var endX = MathEx.GetPolarOffsetX(caster.X, ArrowRange, angle);
      var endY = MathEx.GetPolarOffsetY(caster.Y, ArrowRange, angle);
      MissileSystem.Add(new ShadowStepArrow(caster.Owner, caster.X, caster.Y, endX, endY)
      {
        Caster = caster,
        EffectString = ArrowPath,
        Speed = 1400,
        CollisionRadius = ArrowWidth,
        CasterLaunchZ = 60,
        TargetImpactZ = 60,
        Damage = damage,
        Struck = struck,
        Active = true
      });
    }
  }
}

/// <summary>One arrow fired by <see cref="ShadowStepSpell"/>.</summary>
public sealed class ShadowStepArrow : BasicMissile
{
  public required float Damage { get; init; }
  public required HashSet<unit> Struck { get; init; }

  public ShadowStepArrow(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  public override void OnCollision(unit unit)
  {
    if (!CastFilters.IsTargetEnemyAndAliveUnits(Caster, unit) || unit.UnitType == DummyCasterManager.UnitTypeId ||
        Struck.Contains(unit))
    {
      return;
    }

    Struck.Add(unit);
    unit.Damage(Caster, Damage, attacktype.Hero);
  }
}
