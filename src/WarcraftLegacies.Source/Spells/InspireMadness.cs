using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Effects;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class InspireMadness : Spell
  {
    public InspireMadness(int id) : base(id)
    {
    }

    public float Radius { get; init; }
    public int CountBase { get; init; }
    public int CountLevel { get; init; }
    public float Duration { get; init; }
    public string Effect { get; init; } = "";
    public float EffectScale { get; init; }
    public string EffectTarget { get; init; } = "";
    public float EffectScaleTarget { get; init; }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        var maxTargets = CountBase * CountLevel * GetAbilityLevel(caster);
        foreach (var unit in CreateGroup()
                   .EnumUnitsInRange(targetPoint, Radius)
                   .EmptyToList()
                   .Take(maxTargets)
                 )
          if (IsValidTarget(caster, unit))
            ConvertUnit(caster, unit);
        var tempEffect = AddSpecialEffect(Effect, GetSpellTargetX(), GetSpellTargetY());
        BlzSetSpecialEffectScale(tempEffect, EffectScale);
        EffectSystem.Add(tempEffect);
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
             !IsUnitType(target, UNIT_TYPE_HERO) && !IsUnitAlly(target, GetOwningPlayer(caster)) && UnitAlive(target);
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
}