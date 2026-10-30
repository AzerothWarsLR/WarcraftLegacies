using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Heals nearby friendly gryphons and makes them attack faster for a while.</summary>
public sealed class MastersWhistleSpell : Spell
{
  public required float Radius { get; init; }
  public required LeveledAbilityField<float> Heal { get; init; }
  public required float Duration { get; init; }
  public required HashSet<int> GryphonTypeIds { get; init; }
  public required int AttackSpeedAbilityId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required string HealEffectPath { get; init; }

  public MastersWhistleSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var heal = Heal.GetValue(GetAbilityLevel(caster));
    foreach (var gryphon in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!gryphon.Alive || !gryphon.IsAllyTo(caster.Owner) || !GryphonTypeIds.Contains(gryphon.UnitType))
      {
        continue;
      }

      gryphon.Life += heal;
      effect.Create(HealEffectPath, gryphon, "origin").Dispose();
      BuffSystem.Add(new MastersWhistleBuff(caster, gryphon, BuffApplicatorId, BuffId)
      {
        Duration = Duration,
        AttackSpeedAbilityId = AttackSpeedAbilityId
      }, StackBehaviour.Stack);
    }
  }
}

/// <summary>The attack speed bonus from <see cref="MastersWhistleSpell"/>.</summary>
public sealed class MastersWhistleBuff : BoundBuff
{
  private bool _applied;

  public required int AttackSpeedAbilityId { get; init; }

  public MastersWhistleBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = true;
    BindAura(buffApplicatorId, buffId);
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    _applied = true;
    Target.AddAbility(AttackSpeedAbilityId);
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
    }

    base.OnDispose();
  }
}
