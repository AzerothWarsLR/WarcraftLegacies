using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>The caster and the player's nearby melee soldiers charge a point, knocking back the first enemy each one reaches.</summary>
public sealed class ChargeOfTheramoreSpell : Spell
{
  private const float CheckInterval = 0.1f;

  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required float ChargeSpeed { get; init; }
  public required float HitRadius { get; init; }
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float KnockbackDistance { get; init; }
  public required int StunAbilityId { get; init; }
  public required string ChargeEffectPath { get; init; }
  public required string HitEffectPath { get; init; }

  public ChargeOfTheramoreSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var damage = Damage.GetValue(GetAbilityLevel(caster));
    var chargers = new Dictionary<unit, float>();
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (nearby == caster || (nearby.Owner == caster.Owner && nearby.Alive && nearby.IsUnitType(unittype.MeleeAttacker) &&
                               !nearby.IsUnitType(unittype.Hero) && !nearby.IsUnitType(unittype.Structure)))
      {
        chargers[nearby] = GetUnitMoveSpeed(nearby);
        SetUnitMoveSpeed(nearby, ChargeSpeed);
        effect.Create(ChargeEffectPath, nearby, "origin").Dispose();
        nearby.IssueOrder(ORDER_MOVE, targetPoint.X, targetPoint.Y);
      }
    }

    var elapsed = 0f;
    var check = timer.Create();
    check.Start(CheckInterval, true, () =>
    {
      elapsed += CheckInterval;
      foreach (var charger in new List<unit>(chargers.Keys))
      {
        var victim = FindVictim(caster, charger);
        if (!charger.Alive || victim == null)
        {
          continue;
        }

        Hit(caster, charger, victim, damage);
        EndCharge(charger, chargers);
      }

      if (elapsed < Duration && chargers.Count > 0)
      {
        return;
      }

      check.Dispose();
      foreach (var charger in new List<unit>(chargers.Keys))
      {
        EndCharge(charger, chargers);
      }
    });
  }

  private unit? FindVictim(unit caster, unit charger)
  {
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(charger.X, charger.Y, HitRadius))
    {
      if (nearby.UnitType != DummyCasterManager.UnitTypeId && CastFilters.IsTargetEnemyAliveAndGroundUnits(caster, nearby))
      {
        return nearby;
      }
    }

    return null;
  }

  private void Hit(unit caster, unit charger, unit victim, float damage)
  {
    effect.Create(HitEffectPath, victim, "origin").Dispose();
    charger.DealDamage(victim, damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.WhoKnows);
    if (!victim.Alive)
    {
      return;
    }

    var angle = MathEx.GetAngleBetweenPoints(charger.X, charger.Y, victim.X, victim.Y);
    Knockback.Push(victim, angle, KnockbackDistance, 0.25f);
    DummyCasterManager.GetGlobalDummyCaster()
      .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, victim, DummyCastOriginType.Target);
  }

  private static void EndCharge(unit charger, Dictionary<unit, float> chargers)
  {
    if (!chargers.TryGetValue(charger, out var originalSpeed))
    {
      return;
    }

    chargers.Remove(charger);
    SetUnitMoveSpeed(charger, originalSpeed);
  }
}
