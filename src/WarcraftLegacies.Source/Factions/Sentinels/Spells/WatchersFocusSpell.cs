using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class WatchersFocusSpell : Spell
{
  public required float Radius { get; init; }
  public required LeveledAbilityField<float> Duration { get; init; }
  public required int CritAbilityId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }

  public WatchersFocusSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var duration = Duration.GetValue(level);

    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!IsValidTarget(caster, unit))
      {
        continue;
      }

      BuffSystem.Add(new WatchersFocusBuff(caster, unit, BuffApplicatorId, BuffId, CritAbilityId, level)
      {
        Duration = duration
      }, StackBehaviour.Stack);
    }
  }

  private static bool IsValidTarget(unit caster, unit target)
  {
    return target.Alive
           && target.IsAllyTo(caster.Owner)
           && !target.IsUnitType(unittype.Structure)
           && target.UnitType != DummyCasterManager.UnitTypeId;
  }
}

public sealed class WatchersFocusBuff : BoundBuff
{
  private readonly int _critAbilityId;
  private readonly int _abilityLevel;
  private bool _applied;

  public WatchersFocusBuff(unit caster, unit target, int buffApplicatorId, int buffId, int critAbilityId,
    int abilityLevel) : base(caster, target)
  {
    _critAbilityId = critAbilityId;
    _abilityLevel = abilityLevel;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply()
  {
    _applied = true;
    Target.AddAbility(_critAbilityId);
    Target.SetAbilityLevel(_critAbilityId, _abilityLevel);
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
      Target.RemoveAbility(_critAbilityId);
    }

    base.OnDispose();
  }
}
