using System;
using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

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
  public required LeveledAbilityField<float> MaxHealthMultiplier { get; init; }


  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      foreach (var unit in GlobalGroup.EnumUnitsInRange(targetPoint, Radius))
      {
        if (IsValidTarget(caster, unit))
        {
          EmpowerUnit(GetAbilityLevel(caster), unit);
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to cast {nameof(InspireMadness)}: {ex}");
    }
  }

  private static bool IsValidTarget(unit caster, unit target)
  {
    return !target.IsUnitType(unittype.Structure) && !target.IsUnitType(unittype.Ancient) &&
           !target.IsUnitType(unittype.Mechanical) && !target.IsUnitType(unittype.Resistant) &&
           !target.IsUnitType(unittype.Hero) && target.Owner == caster.Owner && target.Alive
           && !target.IsInvulnerable &&
           !target.IsUnitType(unittype.Summoned) && !target.IsIllusion;
  }

  private void EmpowerUnit(int level, unit target)
  {
    target.MultiplyBaseDamage(AttackDamageMultiplier.Base + AttackDamageMultiplier.PerLevel * level, 0);
    target.MultiplyAttackCooldown(1 / (AttackSpeedMultiplier.Base + AttackSpeedMultiplier.PerLevel * level), 0);
    target.MultiplyMaxHitpoints(MaxHealthMultiplier.Base + MaxHealthMultiplier.PerLevel * level);
    target.SetVertexColor(100, 255, 150);
    target.SetTimedLife(Duration);
    target.SetExploded(true);
    target.SetScale(1.1f, 1.1f, 1.1f);
    target.RemoveType(UNIT_TYPE_SUMMONED);

    if (target.UnitType == UNIT_U013_SUPER_MAJOR_CTHUN)
    {
      target.SetScale(0.6f, 0.6f, 0.6f);
    }

    effect.Create(EffectTarget, target.X, target.Y).Scale = EffectScaleTarget;
    EffectSystem.Add(effect.Create(EffectTarget, target.X, target.Y));
    effect.Create(EffectTarget, target.X, target.Y).SetColor(0, 255, 0);
  }

}
