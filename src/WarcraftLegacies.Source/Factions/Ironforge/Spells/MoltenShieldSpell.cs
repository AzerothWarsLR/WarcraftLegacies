using System;
using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Wraps a friendly unit in molten armor that reduces damage taken, then releases the blocked damage at nearby enemies.</summary>
public sealed class MoltenShieldSpell : Spell
{
  public required LeveledAbilityField<float> DamageReduction { get; init; }
  public required LeveledAbilityField<float> MaximumBurst { get; init; }
  public required float Duration { get; init; }
  public required float BurstRadius { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required int MoveSpeedAbilityId { get; init; }
  public required string BurstEffectPath { get; init; }

  public MoltenShieldSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, MoltenShieldBuff.OnAnyUnitDamaged);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = caster.GetAbilityLevel(Id);
    BuffSystem.Add(new MoltenShieldBuff(caster, target, BuffApplicatorId, BuffId)
    {
      Duration = Duration,
      Reduction = DamageReduction.GetValue(level),
      MaximumBurst = MaximumBurst.GetValue(level),
      BurstRadius = BurstRadius,
      MoveSpeedAbilityId = MoveSpeedAbilityId,
      BurstEffectPath = BurstEffectPath
    }, StackBehaviour.Stack);
  }
}

/// <summary>The molten armor from <see cref="MoltenShieldSpell"/>.</summary>
public sealed class MoltenShieldBuff : BoundBuff
{
  private static readonly Dictionary<unit, MoltenShieldBuff> _shields = new();
  private bool _applied;

  public required float Reduction { get; set; }
  public required float MaximumBurst { get; set; }
  public required float BurstRadius { get; init; }
  public required int MoveSpeedAbilityId { get; init; }
  public required string BurstEffectPath { get; init; }

  /// <summary>The damage blocked so far, released when the armor fades.</summary>
  public float Stored { get; private set; }

  public MoltenShieldBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Reduces the damage a shielded unit is about to take and stores what was blocked.</summary>
  public static void OnAnyUnitDamaged()
  {
    if (_shields.Count == 0 || @event.Damage <= 0)
    {
      return;
    }

    if (!_shields.TryGetValue(@event.Unit, out var shield))
    {
      return;
    }

    var blocked = @event.Damage * shield.Reduction;
    @event.Damage -= blocked;
    shield.Stored = Math.Min(shield.MaximumBurst, shield.Stored + blocked);
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    _shields[Target] = this;
    Target.AddAbility(MoveSpeedAbilityId);
  }

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    var refresh = (MoltenShieldBuff)newStack;
    Duration = refresh.Duration;
    Reduction = Math.Max(Reduction, refresh.Reduction);
    MaximumBurst = Math.Max(MaximumBurst, refresh.MaximumBurst);
    return StackResult.Stack;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (_applied)
    {
      Target.RemoveAbility(MoveSpeedAbilityId);
      Burst();
    }

    if (_shields.TryGetValue(Target, out var shield))
    {
      if (shield == this)
      {
        _shields.Remove(Target);
      }
    }

    base.OnDispose();
  }

  private void Burst()
  {
    if (Stored <= 0)
    {
      return;
    }

    effect.Create(BurstEffectPath, Target.X, Target.Y).Dispose();
    foreach (var victim in GlobalGroup.EnumUnitsInRange(Target.X, Target.Y, BurstRadius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(Caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      Caster.DealDamage(victim, Stored, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }
}
