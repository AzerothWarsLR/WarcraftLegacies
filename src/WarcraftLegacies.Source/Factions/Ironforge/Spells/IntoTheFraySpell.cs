using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Shields nearby allies so that damage which would leave them nearly dead is mostly blocked.</summary>
public sealed class IntoTheFraySpell : Spell
{
  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required float HealthThreshold { get; init; }
  public required float DamageReduction { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required string CastEffectPath { get; init; }

  public IntoTheFraySpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, IntoTheFrayBuff.OnAnyUnitDamaged);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    effect.Create(CastEffectPath, caster.X, caster.Y).Dispose();
    foreach (var ally in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!ally.Alive || !ally.IsAllyTo(caster.Owner) || ally.IsUnitType(unittype.Structure) ||
          ally.IsUnitType(unittype.Hero) || ally.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      BuffSystem.Add(new IntoTheFrayBuff(caster, ally, BuffApplicatorId, BuffId)
      {
        Duration = Duration,
        HealthThreshold = HealthThreshold,
        DamageReduction = DamageReduction
      }, StackBehaviour.Stack);
    }
  }
}

/// <summary>The shield from <see cref="IntoTheFraySpell"/>.</summary>
public sealed class IntoTheFrayBuff : BoundBuff
{
  private static readonly Dictionary<unit, IntoTheFrayBuff> _shielded = new();
  private bool _applied;

  public required float HealthThreshold { get; init; }
  public required float DamageReduction { get; init; }

  public IntoTheFrayBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <summary>Blocks most of any damage that would leave a shielded unit below the threshold.</summary>
  public static void OnAnyUnitDamaged()
  {
    if (_shielded.Count == 0)
    {
      return;
    }

    if (!_shielded.TryGetValue(@event.Unit, out var shield))
    {
      return;
    }

    var target = @event.Unit;
    if ((target.Life - @event.Damage) / target.MaxLife < shield.HealthThreshold)
    {
      @event.Damage *= 1 - shield.DamageReduction;
    }
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    _shielded[Target] = this;
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
    if (_applied && _shielded.TryGetValue(Target, out var shield))
    {
      if (shield == this)
      {
        _shielded.Remove(Target);
      }
    }

    base.OnDispose();
  }
}
