using System;
using System.Collections.Generic;
using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Heals a friendly unit. Healing past full health becomes a shield that absorbs damage.</summary>
public sealed class QueensMendingSpell : Spell
{
  public required LeveledAbilityField<float> Heal { get; init; }
  public required float ShieldDuration { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required string HealEffectPath { get; init; }
  public required string ShieldEffectPath { get; init; }

  public QueensMendingSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, QueensMendingShield.OnAnyUnitDamaged);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var heal = Heal.GetValue(caster.GetAbilityLevel(Id));
    var overheal = heal - (target.MaxLife - target.Life);
    target.Life += heal;
    AddSpecialEffectTarget(HealEffectPath, target, "origin").Dispose();
    if (overheal <= 0)
    {
      return;
    }

    BuffSystem.Add(new QueensMendingShield(caster, target, BuffApplicatorId, BuffId)
    {
      Duration = ShieldDuration,
      Absorb = overheal,
      ShieldEffectPath = ShieldEffectPath
    }, StackBehaviour.Stack);
  }
}

/// <summary>The shield from <see cref="QueensMendingSpell"/>.</summary>
public sealed class QueensMendingShield : BoundBuff
{
  private static readonly Dictionary<unit, QueensMendingShield> _shields = new();

  private effect? _shieldEffect;

  public required float Absorb { get; set; }
  public required string ShieldEffectPath { get; init; }

  public QueensMendingShield(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Lets any active shield soak up the damage its unit is about to take.</summary>
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

    var absorbed = Math.Min(@event.Damage, shield.Absorb);
    shield.Absorb -= absorbed;
    @event.Damage -= absorbed;
    if (shield.Absorb <= 0)
    {
      shield.Active = false;
    }
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _shields[Target] = this;
    _shieldEffect = AddSpecialEffectTarget(ShieldEffectPath, Target, "origin");
  }

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    var refresh = (QueensMendingShield)newStack;
    Duration = refresh.Duration;
    Absorb = Math.Max(Absorb, refresh.Absorb);
    return StackResult.Stack;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (_shieldEffect != null)
    {
      _shieldEffect.Dispose();
      _shieldEffect = null;
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
}
