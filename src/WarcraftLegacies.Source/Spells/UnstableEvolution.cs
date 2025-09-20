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
    return !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
           !IsUnitType(target, UNIT_TYPE_MECHANICAL) && !IsUnitType(target, UNIT_TYPE_RESISTANT) &&
           !IsUnitType(target, UNIT_TYPE_HERO) && GetOwningPlayer(target) == GetOwningPlayer(caster) && UnitAlive(target)
           && !BlzIsUnitInvulnerable(target) &&
           !IsUnitType(target, UNIT_TYPE_SUMMONED) && !IsUnitIllusion(target);
  }

  private void EmpowerUnit(int level, unit target)
  {
    target.MultiplyBaseDamage(AttackDamageMultiplier.Base + AttackDamageMultiplier.PerLevel * level, 0);
    target.MultiplyAttackCooldown(1 / (AttackSpeedMultiplier.Base + AttackSpeedMultiplier.PerLevel * level), 0);
    target.MultiplyMaxHitpoints(MaxHealthMultiplier.Base + MaxHealthMultiplier.PerLevel * level);
    SetUnitVertexColor(target, 100, 255, 150, 255);
    target.SetTimedLife(Duration);
    SetUnitExploded(target, true);
    SetUnitScale(target, 1.1f, 1.1f, 1.1f);

    if (GetUnitTypeId(target) == UNIT_U013_SUPER_MAJOR_C_THUN)
    {
      SetUnitScale(target, 0.6f, 0.6f, 0.6f);
    }

    var effect = AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target));
    BlzSetSpecialEffectScale(effect, EffectScaleTarget);
    EffectSystem.Add(effect);
    BlzSetSpecialEffectColor(effect, 0, 255, 0);
  }

}
