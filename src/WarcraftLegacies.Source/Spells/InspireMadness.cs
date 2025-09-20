using System;
using System.Linq;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class InspireMadness : Spell
{
  public InspireMadness(int id) : base(id)
  {
  }

  public float Radius { get; init; }
  public int CountBase { get; init; }
  public int CountLevel { get; init; }
  public float Duration { get; init; }
  public string EffectTarget { get; init; } = "";
  public float EffectScaleTarget { get; init; }
  public float ChancePercentage { get; init; } = 100f;

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var maxTargets = CountBase + CountLevel * GetAbilityLevel(caster);
      var units = GlobalGroup
        .EnumUnitsInRange(targetPoint, Radius)
        .Where(unit => IsValidTarget(caster, unit))
        .Where(_ => GetRandomReal(0, 100) < ChancePercentage)
        .Take(maxTargets)
        .ToList();

      foreach (var unit in units)
      {
        ConvertUnit(caster, unit);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to cast {nameof(InspireMadness)}: {ex}");
    }
  }

  private static bool IsValidTarget(unit caster, unit target)
  {
    return !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
           !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
           !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
           !IsUnitType(target, UNIT_TYPE_RESISTANT) &&
           !IsUnitType(target, UNIT_TYPE_HERO) &&
           UnitAlive(target) &&
           !IsUnitAlly(target, GetOwningPlayer(caster)) &&
           !IsUnitType(target, UNIT_TYPE_SUMMONED);
  }

  private void ConvertUnit(unit caster, unit target)
  {
    SetUnitOwner(target, GetOwningPlayer(caster), true);
    UnitApplyTimedLife(target, FourCC("Bpos"), Duration);
    SetUnitExploded(target, true);

    var tempEffect = AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target));
    BlzSetSpecialEffectScale(tempEffect, EffectScaleTarget);
    EffectSystem.Add(tempEffect);
  }
}
