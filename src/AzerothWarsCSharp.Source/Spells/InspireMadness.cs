using System.Linq;
using AzerothWarsCSharp.Source.Libraries.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public class InspireMadness : Spell
  {
    public InspireMadness(int id) : base(id)
    {
    }

    public float Radius { get; init; }
    public int CountBase { get; init; }
    public int CountLevel { get; init; }
    public float Duration { get; init; }
    public string Effect { get; init; }
    public float EffectScale { get; init; }
    public string EffectTarget { get; init; }
    public float EffectScaleTarget { get; init; }

    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      var group = new GroupEx();
      group.EnumUnitsInRange(targetX, targetY, Radius);
      var maxTargets = CountBase * CountLevel * GetAbilityLevel(caster);
      foreach (var unit in group.ToList().Take(maxTargets))
        if (IsValidTarget(caster, unit))
          ConvertUnit(caster, unit);
      var tempEffect = AddSpecialEffect(Effect, GetSpellTargetX(), GetSpellTargetY());
      BlzSetSpecialEffectScale(tempEffect, EffectScale);
      DestroyEffect(tempEffect);
    }

    private static bool IsValidTarget(unit caster, unit target)
    {
      return !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
             !IsUnitType(target, UNIT_TYPE_MECHANICAL) && !IsUnitType(target, UNIT_TYPE_RESISTANT) &&
             !IsUnitType(target, UNIT_TYPE_HERO) && IsUnitAlly(target, GetOwningPlayer(caster)) && UnitAlive(target);
    }

    private void ConvertUnit(unit caster, unit target)
    {
      SetUnitOwner(target, GetOwningPlayer(caster), true);
      UnitApplyTimedLife(target, FourCC("Bpos"), Duration);
      SetUnitExploded(target, true);
      var tempEffect = AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target));
      BlzSetSpecialEffectScale(tempEffect, EffectScaleTarget);
      DestroyEffect(tempEffect);
    }
  }
}