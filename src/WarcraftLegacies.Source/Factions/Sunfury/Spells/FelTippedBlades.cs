using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>The unit's attacks apply a stacking poison that deals damage over time and slows attacks.</summary>
public sealed class FelTippedBlades : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> DamagePerStack { get; init; }
  public required int MaxStacks { get; init; }
  public required float Duration { get; init; }
  public required int SlowAbilityId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0 || !target.Alive || target.IsUnitType(unittype.Structure) ||
        !target.IsEnemyTo(attacker.Owner))
    {
      return;
    }

    BuffSystem.Add(new FelPoisonBuff(attacker, target, BuffApplicatorId, BuffId, SlowAbilityId, MaxStacks)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerStack = DamagePerStack.GetValue(level)
    }, StackBehaviour.Stack);
  }
}

/// <summary>The stacking poison from <see cref="FelTippedBlades"/>.</summary>
public sealed class FelPoisonBuff : BoundBuff
{
  private readonly int _slowAbilityId;
  private readonly int _maxStacks;
  private int _stacks = 1;
  private bool _applied;

  public required float DamagePerStack { get; set; }

  public FelPoisonBuff(unit caster, unit target, int buffApplicatorId, int buffId, int slowAbilityId, int maxStacks) :
    base(caster, target)
  {
    _slowAbilityId = slowAbilityId;
    _maxStacks = maxStacks;
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply()
  {
    _applied = true;
    Target.AddAbility(_slowAbilityId);
    Target.SetAbilityLevel(_slowAbilityId, _stacks);
  }

  public override void OnTick() =>
    Caster.DealDamage(Target, DamagePerStack * _stacks, false, false, attacktype.Normal, damagetype.Magic,
      weapontype.WhoKnows);

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    DamagePerStack = ((FelPoisonBuff)newStack).DamagePerStack;
    if (_stacks < _maxStacks)
    {
      _stacks++;
      Target.SetAbilityLevel(_slowAbilityId, _stacks);
    }

    return StackResult.Stack;
  }

  public override void OnDispose()
  {
    if (_applied)
    {
      Target.RemoveAbility(_slowAbilityId);
    }

    base.OnDispose();
  }
}
