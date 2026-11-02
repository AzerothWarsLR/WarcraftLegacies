using System.Collections.Generic;
using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>After taunting nearby enemies, the caster takes no damage for a while.</summary>
public sealed class StandOfHonorHoldSpell : Spell
{
  public required LeveledAbilityField<float> Duration { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }

  public StandOfHonorHoldSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, StandOfHonorHoldBuff.OnAnyUnitDamaged);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    BuffSystem.Add(new StandOfHonorHoldBuff(caster, caster, BuffApplicatorId, BuffId)
    {
      Duration = Duration.GetValue(GetAbilityLevel(caster))
    }, StackBehaviour.Stack);
  }
}

/// <summary>The damage immunity from <see cref="StandOfHonorHoldSpell"/>.</summary>
public sealed class StandOfHonorHoldBuff : BoundBuff
{
  private static readonly Dictionary<unit, StandOfHonorHoldBuff> _standing = new();
  private bool _applied;

  public StandOfHonorHoldBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Stops all damage to a unit holding its ground.</summary>
  public static void OnAnyUnitDamaged()
  {
    if (_standing.Count == 0)
    {
      return;
    }

    if (_standing.ContainsKey(@event.Unit))
    {
      @event.Damage = 0;
    }
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    _standing[Target] = this;
  }

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (_applied && _standing.TryGetValue(Target, out var stand))
    {
      if (stand == this)
      {
        _standing.Remove(Target);
      }
    }

    base.OnDispose();
  }
}
