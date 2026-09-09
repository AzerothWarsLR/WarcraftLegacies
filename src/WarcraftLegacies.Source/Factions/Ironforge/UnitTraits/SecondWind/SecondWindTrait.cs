using System.Linq;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.UnitTraits.SecondWind;

public sealed class SecondWindTrait : UnitTrait, IEffectOnCreated, IEffectOnDamaged, IEffectOnAbilityLearned
{
  private readonly int _abilityTypeId;

  public required LeveledAbilityField<float> HealPercentPerSecond { private get; init; }

  public string HealingEffect { private get; init; }
  public float HealingEffectScale { private get; init; } = 1f;
  public float OutOfCombatThreshold { private get; init; } = 7f;

  public SecondWindTrait(int abilityTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }

  public void OnCreated(unit createdUnit)
  {
    var level = createdUnit.GetAbilityLevel(_abilityTypeId);
    if (level == 0)
    {
      return;
    }

    StartCooldown(createdUnit, level);
  }

  public void OnDamaged()
  {
    var damaged = @event.Unit;
    var level = damaged.GetAbilityLevel(_abilityTypeId);
    if (level == 0 || @event.Damage <= 0 || !@event.DamageSource.IsEnemyTo(damaged.Owner))
    {
      return;
    }

    var activeRegen = BuffSystem.GetBuffsOnUnit(damaged).OfType<SecondWindBuff>().FirstOrDefault();
    if (activeRegen != null)
    {
      activeRegen.Active = false;
    }

    StartCooldown(damaged, level);
  }

  public void OnAbilityLearned(unit learner)
  {
    if (@event.LearnedSkill != _abilityTypeId)
    {
      return;
    }

    var level = learner.GetAbilityLevel(_abilityTypeId);
    if (level != 1)
    {
      return;
    }

    StartCooldown(learner, level);
  }

  private void StartCooldown(unit target, int level)
  {
    var existingCooldown = BuffSystem.GetBuffsOnUnit(target).OfType<SecondWindCooldownBuff>().FirstOrDefault();
    if (existingCooldown != null)
    {
      existingCooldown.Duration = OutOfCombatThreshold;
      return;
    }

    var healPercentPerSecond = HealPercentPerSecond.GetValue(level);
    BuffSystem.Add(new SecondWindCooldownBuff(target)
    {
      Active = true,
      Duration = OutOfCombatThreshold,
      IsBeneficial = true,
      HealPercentPerSecond = healPercentPerSecond,
      HealingEffect = HealingEffect,
      HealingEffectScale = HealingEffectScale
    });
  }
}
