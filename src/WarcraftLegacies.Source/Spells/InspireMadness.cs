using System;
using System.Linq;
using MacroTools.Spells;
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
    return !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient) &&
           !target.IsUnitType(unittype.Mechanical) &&
           !target.IsUnitType(unittype.Resistant) &&
           !target.IsUnitType(unittype.Hero) &&
           target.Alive &&
           !target.IsAllyTo(caster.Owner) &&
           !target.IsUnitType(unittype.Summoned);
  }

  private void ConvertUnit(unit caster, unit target)
  {
    target.SetOwner(caster.Owner);
    target.ApplyTimedLife(FourCC("Bpos"), Duration);
    target.SetExploded(true);
    target.RemoveType(UNIT_TYPE_SUMMONED);

    var tempEffect = effect.Create(EffectTarget, target.X, target.Y);
    tempEffect.Scale = EffectScaleTarget;
    EffectSystem.Add(tempEffect);
  }
}
