using System.Collections.Generic;
using System.Linq;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class BestialWrathSpell : Spell
{
  public required float Radius { get; init; }
  public required LeveledAbilityField<float> Duration { get; init; }
  public required int AttackSpeedAbilityId { get; init; }
  public required int DamageBonusAbilityId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required IReadOnlyList<int> BeastUnitTypeIds { get; init; }

  public BestialWrathSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var duration = Duration.GetValue(level);

    Apply(caster, caster, level, duration);

    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (unit == caster || !unit.Alive || unit.Owner != caster.Owner || !BeastUnitTypeIds.Contains(unit.UnitType))
      {
        continue;
      }

      Apply(caster, unit, level, duration);
    }
  }

  private void Apply(unit caster, unit target, int level, float duration)
  {
    BuffSystem.Add(new BestialWrathBuff(caster, target, BuffApplicatorId, BuffId, AttackSpeedAbilityId,
      DamageBonusAbilityId, level)
    {
      Duration = duration
    }, StackBehaviour.Stack);
  }
}

public sealed class BestialWrathBuff : BoundBuff
{
  private readonly int _attackSpeedAbilityId;
  private readonly int _damageBonusAbilityId;
  private readonly int _abilityLevel;
  private bool _applied;

  public BestialWrathBuff(unit caster, unit target, int buffApplicatorId, int buffId, int attackSpeedAbilityId,
    int damageBonusAbilityId, int abilityLevel) : base(caster, target)
  {
    _attackSpeedAbilityId = attackSpeedAbilityId;
    _damageBonusAbilityId = damageBonusAbilityId;
    _abilityLevel = abilityLevel;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply()
  {
    _applied = true;
    Target.AddAbility(_attackSpeedAbilityId);
    Target.SetAbilityLevel(_attackSpeedAbilityId, _abilityLevel);
    Target.AddAbility(_damageBonusAbilityId);
    Target.SetAbilityLevel(_damageBonusAbilityId, _abilityLevel);
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override void OnDispose()
  {
    if (_applied)
    {
      Target.RemoveAbility(_attackSpeedAbilityId);
      Target.RemoveAbility(_damageBonusAbilityId);
    }

    base.OnDispose();
  }
}
