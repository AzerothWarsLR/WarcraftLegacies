using System.Collections.Generic;
using WCSharp.Buffs;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>When the unit drops low, it takes much less damage for a while; this can only happen once in a while.</summary>
public sealed class LastDefender
{
  private readonly HashSet<unit> _onCooldown = new();

  public required int AbilityTypeId { get; init; }
  public required float HealthThreshold { get; init; }
  public required float DamageReduction { get; init; }
  public required float Duration { get; init; }
  public required float Cooldown { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }

  /// <summary>Starts listening for damage.</summary>
  public void Register()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, LastDefenderBuff.OnAnyUnitDamaged);
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, OnAnyUnitDamaged);
  }

  private void OnAnyUnitDamaged()
  {
    var defender = @event.Unit;
    if (defender.GetAbilityLevel(AbilityTypeId) == 0 || _onCooldown.Contains(defender) ||
        (defender.Life - @event.Damage) / defender.MaxLife >= HealthThreshold)
    {
      return;
    }

    _onCooldown.Add(defender);
    @event.Damage *= 1 - DamageReduction;
    BuffSystem.Add(new LastDefenderBuff(defender, defender, BuffApplicatorId, BuffId)
    {
      Duration = Duration,
      DamageReduction = DamageReduction
    }, StackBehaviour.Stack);
    var cooldown = timer.Create();
    cooldown.Start(Cooldown, false, () =>
    {
      _onCooldown.Remove(defender);
      cooldown.Dispose();
    });
  }
}

/// <summary>The damage reduction from <see cref="LastDefender"/>.</summary>
public sealed class LastDefenderBuff : BoundBuff
{
  private static readonly Dictionary<unit, LastDefenderBuff> _defending = new();
  private bool _applied;

  public required float DamageReduction { get; init; }

  public LastDefenderBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Reduces the damage a defending unit takes.</summary>
  public static void OnAnyUnitDamaged()
  {
    if (_defending.Count == 0)
    {
      return;
    }

    if (_defending.TryGetValue(@event.Unit, out var defending))
    {
      @event.Damage *= 1 - defending.DamageReduction;
    }
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    _defending[Target] = this;
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
    if (_applied && _defending.TryGetValue(Target, out var defending))
    {
      if (defending == this)
      {
        _defending.Remove(Target);
      }
    }

    base.OnDispose();
  }
}
