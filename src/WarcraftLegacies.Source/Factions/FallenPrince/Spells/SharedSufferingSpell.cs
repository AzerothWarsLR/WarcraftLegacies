using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Damages a target over time; if the curse ends early, the damage left bursts onto nearby enemies.</summary>
public sealed class SharedSufferingSpell : Spell
{
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required float BurstRadius { get; init; }
  public required int DebuffAbilityId { get; init; }
  public required int BuffId { get; init; }
  public required string TickEffectPath { get; init; }
  public required string BurstEffectPath { get; init; }

  public SharedSufferingSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, DebuffAbilityId, ORDER_CRIPPLE, 1, target,
      DummyCastOriginType.Target);
    BuffSystem.Add(new SharedSufferingBuff(caster, target, BuffId)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerTick = DamagePerSecond.GetValue(GetAbilityLevel(caster)),
      BurstRadius = BurstRadius,
      TickEffectPath = TickEffectPath,
      BurstEffectPath = BurstEffectPath
    }, StackBehaviour.Stack);
  }
}

/// <summary>The Shared Suffering curse, bound to its in-game buff so that a dispel can be detected.</summary>
public sealed class SharedSufferingBuff : BoundBuff
{
  private const float BindGracePeriod = 0.5f;
  private float _initialDuration;
  private bool _applied;
  private bool _expired;

  public required float DamagePerTick { get; init; }
  public required float BurstRadius { get; init; }
  public required string TickEffectPath { get; init; }
  public required string BurstEffectPath { get; init; }

  public SharedSufferingBuff(unit caster, unit target, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BuffId = buffId;
  }

  public override void OnApply()
  {
    _applied = true;
    _initialDuration = Duration;
  }

  public override void OnTick()
  {
    effect.Create(TickEffectPath, Target, "chest").Dispose();
    Caster.DealDamage(Target, DamagePerTick, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    _initialDuration = Duration + BindGracePeriod;
    return StackResult.Stack;
  }

  public override void OnExpire()
  {
    _expired = true;
    Target.RemoveAbility(BuffId);
  }

  public override void OnDispose()
  {
    if (_applied && !_expired && (_initialDuration - Duration >= BindGracePeriod || !Target.Alive))
    {
      Burst();
    }

    base.OnDispose();
  }

  private void Burst()
  {
    var damage = DamagePerTick * Duration / Interval;
    if (damage <= 0)
    {
      return;
    }

    effect.Create(BurstEffectPath, Target.X, Target.Y).Dispose();
    foreach (var unit in GlobalGroup.EnumUnitsInRange(Target.X, Target.Y, BurstRadius))
    {
      if (unit == Target || !CastFilters.IsTargetEnemyAndAliveUnits(Caster, unit) ||
          unit.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      Caster.DealDamage(unit, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }
}
