using System;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class UnstableEvolution : Spell
  {
    public UnstableEvolution(int id) : base(id)
    {
    }

    public required float Radius { get; init; }
    public required float Duration { get; init; }
    public required string EffectTarget { get; init; }
    public required float EffectScaleTarget { get; init; }
    public required LeveledAbilityField<float> AttackDamageMultiplier { get; init; }
    public required LeveledAbilityField<float> AttackSpeedMultiplier { get; init; }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        foreach (var unit in CreateGroup()
                   .EnumUnitsInRange(targetPoint, Radius)
                   .EmptyToList()
                 )
          if (IsValidTarget(caster, unit))
            EmpowerUnit(GetAbilityLevel(caster), unit);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to cast {nameof(InspireMadness)}: {ex}");
      }
    }

    private static bool IsValidTarget(unit caster, unit target)
    {
      return !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
             !IsUnitType(target, UNIT_TYPE_MECHANICAL) && !IsUnitType(target, UNIT_TYPE_RESISTANT) &&
             !IsUnitType(target, UNIT_TYPE_HERO) && target.OwningPlayer() == caster.OwningPlayer() && UnitAlive(target);
    }

    private void EmpowerUnit(int level, unit target)
    {
      target
        .MultiplyBaseDamage(AttackDamageMultiplier.Base + AttackDamageMultiplier.PerLevel * level, 0)
        .MultiplyAttackCooldown(1 / (AttackSpeedMultiplier.Base + AttackSpeedMultiplier.PerLevel * level), 0)
        .SetColor(100, 255, 150, 255)
        .SetTimedLife(Duration)
        .SetExplodeOnDeath(true)
        .SetScale(1.2f);
      
      AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target))
        .SetScale(EffectScaleTarget)
        .SetLifespan()
        .SetColor(0, 255, 0);
    }
  }
}