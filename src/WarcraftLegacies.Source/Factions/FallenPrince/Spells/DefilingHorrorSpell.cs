using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Nearby enemies flee in fear that cannot be dispelled, and take more damage for a while.</summary>
public sealed class DefilingHorrorSpell : Spell
{
  public required float Radius { get; init; }
  public required LeveledAbilityField<float> FearDuration { get; init; }
  public required float HeroFearDuration { get; init; }
  public required LeveledAbilityField<float> DamageAmplification { get; init; }
  public required float AmplificationDuration { get; init; }
  public required int FearApplicatorId { get; init; }
  public required int DefiledAbilityId { get; init; }
  public required int DefiledBuffId { get; init; }
  public required string CastEffectPath { get; init; }

  public DefilingHorrorSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, DefiledBuff.OnAnyUnitDamaged);
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var fearDuration = FearDuration.GetValue(level);
    var amplification = DamageAmplification.GetValue(level);
    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    effect.Create(CastEffectPath, caster.X, caster.Y).Dispose();

    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, unit) || unit.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      BuffSystem.Add(new DefilingHorrorFear(caster, unit, FearApplicatorId, caster.X, caster.Y)
      {
        Duration = unit.IsUnitType(unittype.Hero) ? HeroFearDuration : fearDuration,
        Interval = 0.2f
      }, StackBehaviour.Stack);

      dummyCaster.CastUnit(caster, DefiledAbilityId, ORDER_CRIPPLE, 1, unit, DummyCastOriginType.Target);
      BuffSystem.Add(new DefiledBuff(caster, unit, DefiledBuffId, amplification)
      {
        Duration = AmplificationDuration
      }, StackBehaviour.Stack);
    }
  }
}

/// <summary>Keeps its target running away from where the horror was unleashed; not tied to any dispellable buff.</summary>
public sealed class DefilingHorrorFear : TickingBuff
{
  private const float FleeDistance = 400;
  private readonly int _applicatorId;
  private readonly float _originX;
  private readonly float _originY;

  public DefilingHorrorFear(unit caster, unit target, int applicatorId, float originX, float originY) :
    base(caster, target)
  {
    _applicatorId = applicatorId;
    _originX = originX;
    _originY = originY;
    IsBeneficial = false;
  }

  public override void OnApply()
  {
    Target.AddAbility(_applicatorId);
    Target.HideAbility(_applicatorId, true);
    Flee();
  }

  public override void OnTick() => Flee();

  public override StackResult OnStack(Buff newStack)
  {
    if (newStack.Duration > Duration)
    {
      Duration = newStack.Duration;
    }

    return StackResult.Stack;
  }

  public override void OnDispose()
  {
    Target.RemoveAbility(_applicatorId);
    if (Target.Alive)
    {
      Target.IssueOrder(ORDER_STOP);
    }

    base.OnDispose();
  }

  private void Flee()
  {
    var angle = MathEx.GetAngleBetweenPoints(_originX, _originY, Target.X, Target.Y);
    Target.IssueOrder(ORDER_MOVE, MathEx.GetPolarOffsetX(Target.X, FleeDistance, angle),
      MathEx.GetPolarOffsetY(Target.Y, FleeDistance, angle));
  }
}

/// <summary>Makes its target take more damage from all sources; bound to a dispellable debuff.</summary>
public sealed class DefiledBuff : BoundBuff
{
  private static readonly Dictionary<unit, float> _amplificationByUnit = new();
  private float _amplification;
  private bool _applied;

  public DefiledBuff(unit caster, unit target, int buffId, float amplification) : base(caster, target)
  {
    _amplification = amplification;
    IsBeneficial = false;
    BuffId = buffId;
  }

  public override void OnApply()
  {
    _applied = true;
    _amplificationByUnit[Target] = _amplification;
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    if (newStack is DefiledBuff defiled && defiled._amplification > _amplification)
    {
      _amplification = defiled._amplification;
      _amplificationByUnit[Target] = _amplification;
    }

    return StackResult.Stack;
  }

  public override void OnExpire() => Target.RemoveAbility(BuffId);

  public override void OnDispose()
  {
    if (_applied)
    {
      _amplificationByUnit.Remove(Target);
    }

    base.OnDispose();
  }

  public static void OnAnyUnitDamaged()
  {
    if (_amplificationByUnit.Count == 0)
    {
      return;
    }

    if (_amplificationByUnit.TryGetValue(@event.Unit, out var amplification))
    {
      @event.Damage *= 1 + amplification;
    }
  }
}
