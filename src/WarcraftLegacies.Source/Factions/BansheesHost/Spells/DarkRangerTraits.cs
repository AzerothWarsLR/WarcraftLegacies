using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Keeps the unit's innate Black Arrow switched on.</summary>
public sealed class BlackArrowAlwaysOn : UnitTrait, IEffectOnCreated
{
  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    var delay = timer.Create();
    delay.Start(0, false, () =>
    {
      createdUnit.IssueOrder(ORDER_BLACK_ARROW_ON);
      delay.Dispose();
    });
  }
}

/// <summary>Every few attacks also pierce through the target, striking enemies in a line behind it.</summary>
public sealed class RangerGeneralsFocus : UnitTrait, IAppliesEffectOnDamage
{
  private readonly Dictionary<unit, int> _attackCounts = new();

  public required int AbilityTypeId { get; init; }
  public required int BlackArrowAbilityTypeId { get; init; }
  public required int AttacksPerPierce { get; init; }
  public required float Length { get; init; }
  public required float Width { get; init; }
  public required LeveledAbilityField<float> DamageFraction { get; init; }
  public required int MinionTypeId { get; init; }
  public required int MinionCount { get; init; }
  public required float MinionDuration { get; init; }
  public required string ArrowPath { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0)
    {
      return;
    }

    _attackCounts.TryGetValue(attacker, out var count);
    count++;
    if (count < AttacksPerPierce)
    {
      _attackCounts[attacker] = count;
      return;
    }

    _attackCounts[attacker] = 0;
    var damage = @event.Damage * DamageFraction.GetValue(level);
    var angle = MathEx.GetAngleBetweenPoints(attacker.X, attacker.Y, target.X, target.Y);
    var endX = MathEx.GetPolarOffsetX(target.X, Length, angle);
    var endY = MathEx.GetPolarOffsetY(target.Y, Length, angle);
    MissileSystem.Add(new PiercingArrowMissile(attacker.Owner, target.X, target.Y, endX, endY)
    {
      Caster = attacker,
      EffectString = ArrowPath,
      Speed = 1500,
      CasterLaunchZ = 60,
      TargetImpactZ = 60,
      Active = true
    });

    var raisesMinions = attacker.GetAbilityLevel(BlackArrowAbilityTypeId) > 0;
    foreach (var victim in GetUnitsInLine(attacker, target, angle))
    {
      victim.Damage(attacker, damage, attacktype.Hero);
      if (raisesMinions && !victim.Alive && !victim.IsUnitType(unittype.Structure) && !victim.IsUnitType(unittype.Mechanical))
      {
        RaiseMinions(attacker, victim);
      }
    }
  }

  private List<unit> GetUnitsInLine(unit attacker, unit target, float angle)
  {
    var victims = new List<unit>();
    for (var distance = Width; distance <= Length; distance += Width)
    {
      var x = MathEx.GetPolarOffsetX(target.X, distance, angle);
      var y = MathEx.GetPolarOffsetY(target.Y, distance, angle);
      foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, Width))
      {
        if (nearby != target && !victims.Contains(nearby) && nearby.UnitType != DummyCasterManager.UnitTypeId &&
            CastFilters.IsTargetEnemyAndAliveUnits(attacker, nearby))
        {
          victims.Add(nearby);
        }
      }
    }

    return victims;
  }

  private void RaiseMinions(unit attacker, unit victim)
  {
    for (var i = 0; i < MinionCount; i++)
    {
      unit.Create(attacker.Owner, MinionTypeId, victim.X, victim.Y, victim.Facing).ApplyTimedLife(0, MinionDuration);
    }
  }
}

/// <summary>The visual arrow that flies on through the target of <see cref="RangerGeneralsFocus"/>.</summary>
public sealed class PiercingArrowMissile : BasicMissile
{
  public PiercingArrowMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }
}
