using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>The caster charges to a point, damaging, stunning and knocking aside every enemy in the way.</summary>
public sealed class HighlandChargeSpell : Spell
{
  private const float Interval = 0.03f;
  private const int TrailEveryTicks = 4;

  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Speed { get; init; }
  public required float HitRadius { get; init; }
  public required float KnockbackDistance { get; init; }
  public required float KnockbackDuration { get; init; }
  public required int StunAbilityId { get; init; }
  public required string HitEffectPath { get; init; }
  public required string TrailEffectPath { get; init; }

  public HighlandChargeSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var damage = Damage.GetValue(level);
    var startX = caster.X;
    var startY = caster.Y;
    var distance = MathEx.GetDistanceBetweenPoints(new Point(startX, startY), targetPoint);
    if (distance < 1)
    {
      return;
    }

    var stepX = (targetPoint.X - startX) / distance * Speed * Interval;
    var stepY = (targetPoint.Y - startY) / distance * Speed * Interval;
    var travelled = 0f;
    var ticks = 0;
    var hit = new List<unit>();
    caster.SetPausedEx(true);
    SetUnitPathing(caster, false);
    caster.SetAnimation("walk");
    SetUnitTimeScale(caster, 2);
    var charge = timer.Create();
    charge.Start(Interval, true, () =>
    {
      var newX = caster.X + stepX;
      var newY = caster.Y + stepY;
      var blocked = pathingtype.Walkability.GetPathable(newX, newY);
      if (!blocked && caster.Alive)
      {
        caster.X = newX;
        caster.Y = newY;
        travelled += Speed * Interval;
        ticks++;
        if (ticks % TrailEveryTicks == 0)
        {
          effect.Create(TrailEffectPath, caster.X, caster.Y).Dispose();
        }

        HitEnemies(caster, level, damage, hit);
      }

      if (!blocked && travelled < distance && caster.Alive)
      {
        return;
      }

      charge.Dispose();
      SetUnitTimeScale(caster, 1);
      SetUnitPathing(caster, true);
      caster.SetPausedEx(false);
      caster.SetAnimation("stand");
    });
  }

  private void HitEnemies(unit caster, int level, float damage, List<unit> hit)
  {
    foreach (var victim in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, HitRadius))
    {
      if (hit.Contains(victim) || !CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) ||
          victim.UnitType == DummyCasterManager.UnitTypeId || victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      hit.Add(victim);
      effect.Create(HitEffectPath, victim, "chest").Dispose();
      caster.DealDamage(victim, damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.MetalHeavyBash);
      if (!victim.Alive)
      {
        continue;
      }

      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, level, victim, DummyCastOriginType.Target);
      if (!victim.IsUnitType(unittype.Flying))
      {
        Knockback.Push(victim, caster.X, caster.Y, KnockbackDistance, KnockbackDuration);
      }
    }
  }
}
