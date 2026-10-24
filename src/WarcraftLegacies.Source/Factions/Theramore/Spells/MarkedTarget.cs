using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>The unit's attacks can mark their target: marks from its ranged form boost allied ranged damage against it, marks from its melee form boost allied melee damage.</summary>
public sealed class MarkedTarget : UnitTrait, IAppliesEffectOnDamage
{
  private const float DeathCheckInterval = 0.25f;

  private readonly Dictionary<unit, Mark> _marks = new();

  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> ChancePercent { get; init; }
  public required float Duration { get; init; }
  public required LeveledAbilityField<float> DamageBonus { get; init; }
  public required int MarkAuraId { get; init; }
  public required int MeleeFormTypeId { get; init; }
  public required string MarkEffectPath { get; init; }

  /// <summary>Starts boosting allied damage against marked units.</summary>
  public void Register() => PlayerUnitEvents.Register(UnitTypeEvent.Damaging, OnAnyUnitDamaging);

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0 || !target.Alive || target.IsUnitType(unittype.Structure) ||
        GetRandomInt(1, 100) > ChancePercent.GetValue(level))
    {
      return;
    }

    var buffsMelee = attacker.UnitType == MeleeFormTypeId;
    if (_marks.TryGetValue(target, out var existing))
    {
      existing.Refresh(attacker.Owner, DamageBonus.GetValue(level), Duration, buffsMelee);
      return;
    }

    var mark = new Mark(attacker.Owner, DamageBonus.GetValue(level), Duration, buffsMelee,
      effect.Create(MarkEffectPath, target, "overhead"));
    _marks[target] = mark;
    target.AddAbility(MarkAuraId);
    var watch = timer.Create();
    watch.Start(DeathCheckInterval, true, () =>
    {
      mark.Remaining -= DeathCheckInterval;
      if (target.Alive && mark.Remaining > 0)
      {
        return;
      }

      watch.Dispose();
      _marks.Remove(target);
      mark.Visual.Dispose();
      target.RemoveAbility(MarkAuraId);
    });
  }

  private void OnAnyUnitDamaging()
  {
    var target = @event.Unit;
    if (!_marks.TryGetValue(target, out var mark) || !@event.IsAttack)
    {
      return;
    }

    var source = @event.DamageSource;
    var matchesMark = mark.BuffsMelee ? source.IsUnitType(unittype.MeleeAttacker) : source.IsUnitType(unittype.RangedAttacker);
    if (matchesMark && (source.Owner == mark.Marker || source.IsAllyTo(mark.Marker)))
    {
      @event.Damage *= 1 + mark.DamageBonus;
    }
  }

  private sealed class Mark
  {
    public Mark(player marker, float damageBonus, float duration, bool buffsMelee, effect visual)
    {
      Marker = marker;
      DamageBonus = damageBonus;
      Remaining = duration;
      BuffsMelee = buffsMelee;
      Visual = visual;
    }

    public player Marker { get; private set; }

    public float DamageBonus { get; private set; }

    public float Remaining { get; set; }

    public bool BuffsMelee { get; private set; }

    public effect Visual { get; }

    public void Refresh(player marker, float damageBonus, float duration, bool buffsMelee)
    {
      Marker = marker;
      DamageBonus = damageBonus;
      Remaining = duration;
      BuffsMelee = buffsMelee;
    }
  }
}
