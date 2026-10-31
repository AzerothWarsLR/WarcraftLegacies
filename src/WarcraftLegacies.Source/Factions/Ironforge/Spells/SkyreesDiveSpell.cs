using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>The caster leaps into the air and dives onto the target area, damaging enemies and knocking them back.</summary>
public sealed class SkyreesDiveSpell : Spell
{
  private const float Interval = 0.03f;

  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Radius { get; init; }
  public required float KnockbackDistance { get; init; }
  public required float KnockbackDuration { get; init; }
  public required float LeapHeight { get; init; }
  public required float LeapSpeed { get; init; }
  public required string ImpactPath { get; init; }

  public SkyreesDiveSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var startX = caster.X;
    var startY = caster.Y;
    var distance = MathEx.GetDistanceBetweenPoints(new Point(startX, startY), targetPoint);
    var duration = distance / LeapSpeed;
    if (duration < 0.3f)
    {
      duration = 0.3f;
    }

    var baseHeight = GetUnitDefaultFlyHeight(caster);
    caster.AddAbility(ABILITY_ARAV_STORM_CROW_FORM_BROWN_DRUID_OF_THE_TALON);
    caster.RemoveAbility(ABILITY_ARAV_STORM_CROW_FORM_BROWN_DRUID_OF_THE_TALON);
    caster.SetPausedEx(true);
    SetUnitPathing(caster, false);
    var elapsed = 0f;
    var leap = timer.Create();
    leap.Start(Interval, true, () =>
    {
      elapsed += Interval;
      var progress = elapsed / duration;
      if (progress > 1)
      {
        progress = 1;
      }

      caster.X = startX + (targetPoint.X - startX) * progress;
      caster.Y = startY + (targetPoint.Y - startY) * progress;
      SetUnitFlyHeight(caster, baseHeight + 4 * LeapHeight * progress * (1 - progress), 0);
      if (progress < 1 && caster.Alive)
      {
        return;
      }

      leap.Dispose();
      SetUnitFlyHeight(caster, baseHeight, 0);
      SetUnitPathing(caster, true);
      caster.SetPausedEx(false);
      if (caster.Alive)
      {
        Land(caster, level, caster.X, caster.Y);
      }
    });
  }

  private void Land(unit caster, int level, float x, float y)
  {
    effect.Create(ImpactPath, x, y).Dispose();
    var damage = Damage.GetValue(level);
    foreach (var victim in GlobalGroup.EnumUnitsInRange(x, y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      caster.DealDamage(victim, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      if (victim.Alive && !victim.IsUnitType(unittype.Flying))
      {
        Knockback.Push(victim, x, y, KnockbackDistance, KnockbackDuration);
      }
    }
  }
}
