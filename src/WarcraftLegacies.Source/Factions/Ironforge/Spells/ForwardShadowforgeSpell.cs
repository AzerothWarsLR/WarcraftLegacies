using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Rallies nearby friendly units, speeding them up and making their first attack stun.</summary>
public sealed class ForwardShadowforgeSpell : Spell
{
  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required int AttackSpeedAbilityId { get; init; }
  public required int MoveSpeedAbilityId { get; init; }
  public required int StunAbilityId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required string CastEffectPath { get; init; }

  public ForwardShadowforgeSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.Damaging, ShadowforgeRallyBuff.OnAnyUnitDamaging);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = caster.GetAbilityLevel(Id);
    AddSpecialEffect(CastEffectPath, caster.X, caster.Y).Dispose();
    foreach (var ally in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!ally.Alive || !ally.IsAllyTo(caster.Owner) || ally.IsUnitType(unittype.Structure) ||
          ally.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      BuffSystem.Add(new ShadowforgeRallyBuff(caster, ally, BuffApplicatorId, BuffId)
      {
        Duration = Duration,
        Level = level,
        AttackSpeedAbilityId = AttackSpeedAbilityId,
        MoveSpeedAbilityId = MoveSpeedAbilityId,
        StunAbilityId = StunAbilityId
      }, StackBehaviour.Stack);
    }
  }
}

/// <summary>The rally from <see cref="ForwardShadowforgeSpell"/>.</summary>
public sealed class ShadowforgeRallyBuff : BoundBuff
{
  private static readonly Dictionary<unit, ShadowforgeRallyBuff> _rallied = new();
  private bool _applied;
  private bool _firstAttackReady = true;

  public required int Level { get; init; }
  public required int AttackSpeedAbilityId { get; init; }
  public required int MoveSpeedAbilityId { get; init; }
  public required int StunAbilityId { get; init; }

  public ShadowforgeRallyBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Stuns the target of a rallied unit's first attack.</summary>
  public static void OnAnyUnitDamaging()
  {
    if (_rallied.Count == 0 || !@event.IsAttack)
    {
      return;
    }

    var attacker = @event.DamageSource;
    if (!_rallied.TryGetValue(attacker, out var rally))
    {
      return;
    }

    var target = @event.Unit;
    if (!rally._firstAttackReady || !target.IsEnemyTo(attacker.Owner) || target.IsUnitType(unittype.Structure))
    {
      return;
    }

    rally._firstAttackReady = false;
    DummyCasterManager.GetGlobalDummyCaster()
      .CastUnit(attacker, rally.StunAbilityId, ORDER_THUNDERBOLT, 1, target, DummyCastOriginType.Target);
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    _rallied[Target] = this;
    Target.AddAbility(AttackSpeedAbilityId);
    Target.SetAbilityLevel(AttackSpeedAbilityId, Level);
    Target.AddAbility(MoveSpeedAbilityId);
    Target.SetAbilityLevel(MoveSpeedAbilityId, Level);
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
    if (_applied)
    {
      Target.RemoveAbility(AttackSpeedAbilityId);
      Target.RemoveAbility(MoveSpeedAbilityId);
    }

    if (_rallied.TryGetValue(Target, out var rally))
    {
      if (rally == this)
      {
        _rallied.Remove(Target);
      }
    }

    base.OnDispose();
  }
}
