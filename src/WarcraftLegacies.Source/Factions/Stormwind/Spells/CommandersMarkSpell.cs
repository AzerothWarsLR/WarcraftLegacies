using System.Collections.Generic;
using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Marks a target enemy so that it takes more damage from all sources for a while.</summary>
public sealed class CommandersMarkSpell : Spell
{
  public required LeveledAbilityField<float> DamageBonus { get; init; }
  public required float Duration { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }

  public CommandersMarkSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, CommandersMarkBuff.OnAnyUnitDamaged);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    BuffSystem.Add(new CommandersMarkBuff(caster, target, BuffApplicatorId, BuffId)
    {
      Duration = Duration,
      DamageBonus = DamageBonus.GetValue(GetAbilityLevel(caster))
    }, StackBehaviour.Stack);
  }
}

/// <summary>The mark from <see cref="CommandersMarkSpell"/>.</summary>
public sealed class CommandersMarkBuff : BoundBuff
{
  private static readonly Dictionary<unit, CommandersMarkBuff> _marked = new();
  private bool _applied;

  public required float DamageBonus { get; init; }

  public CommandersMarkBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Increases the damage a marked unit takes.</summary>
  public static void OnAnyUnitDamaged()
  {
    if (_marked.Count == 0)
    {
      return;
    }

    if (_marked.TryGetValue(@event.Unit, out var mark))
    {
      @event.Damage *= 1 + mark.DamageBonus;
    }
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    _marked[Target] = this;
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
    if (_applied && _marked.TryGetValue(Target, out var mark))
    {
      if (mark == this)
      {
        _marked.Remove(Target);
      }
    }

    base.OnDispose();
  }
}
