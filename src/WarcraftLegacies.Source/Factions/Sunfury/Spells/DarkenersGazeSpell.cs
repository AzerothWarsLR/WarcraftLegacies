using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>Fixes the caster's gaze on an enemy hero, revealing it and speeding the caster up while it lasts.</summary>
public sealed class DarkenersGazeSpell : Spell
{
  public required float Duration { get; init; }
  public required int SpeedAbilityId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }

  public DarkenersGazeSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    BuffSystem.Add(new DarkenersGazeBuff(caster, target, BuffApplicatorId, BuffId, SpeedAbilityId,
      GetAbilityLevel(caster))
    {
      Duration = Duration
    }, StackBehaviour.Stack);
  }
}

/// <summary>Marks the hero under <see cref="DarkenersGazeSpell"/>.</summary>
public sealed class DarkenersGazeBuff : BoundBuff
{
  private readonly int _speedAbilityId;
  private readonly int _abilityLevel;
  private bool _applied;

  public DarkenersGazeBuff(unit caster, unit target, int buffApplicatorId, int buffId, int speedAbilityId,
    int abilityLevel) : base(caster, target)
  {
    _speedAbilityId = speedAbilityId;
    _abilityLevel = abilityLevel;
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply()
  {
    _applied = true;
    Caster.AddAbility(_speedAbilityId);
    Caster.SetAbilityLevel(_speedAbilityId, _abilityLevel);
    UnitShareVision(Target, Caster.Owner, true);
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
      Caster.RemoveAbility(_speedAbilityId);
      UnitShareVision(Target, Caster.Owner, false);
    }

    base.OnDispose();
  }
}

/// <summary>Makes the gazing hero's attacks deal bonus damage to the hero under <see cref="DarkenersGazeBuff"/>.</summary>
public sealed class DarkenersGazeTrait : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required int BuffId { get; init; }
  public required LeveledAbilityField<float> BonusDamage { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0 || @event.Unit.GetAbilityLevel(BuffId) == 0)
    {
      return;
    }

    @event.Damage += BonusDamage.GetValue(level);
  }
}
