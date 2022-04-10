using System.Linq;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Buffs;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public class MassSimulacrum : Spell
  {
    public float Radius { get; init; } = 150;
    public int CountBase { get; init; }
    public int CountLevel { get; init; }
    public float Duration { get; init; }
    public string Effect { get; init; }
    public float EffectScale { get; init; }
    public string EffectTarget { get; init; }
    public float EffectScaleTarget { get; init; }
    public float HealthBonusBase { get; init; }
    public float HealthBonusLevel { get; init; }
    public float DamageBonusBase { get; init; }
    public float DamageBonusLevel { get; init; }
    
    public MassSimulacrum(int id) : base(id)
    {
      
    }

    private static bool IsValidTarget(unit caster, unit target)
    {
      return !IsUnitIllusion(target) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
             !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
             !IsUnitType(target, UNIT_TYPE_RESISTANT) && !IsUnitType(target, UNIT_TYPE_HERO) &&
             IsUnitAlly(target, GetOwningPlayer(caster)) && UnitAlive(target);
    }

    private void ReplicateUnit(unit caster, unit target)
    {
      var newUnit = CreateUnit(GetOwningPlayer(caster), GetUnitTypeId(target), GetUnitX(target), GetUnitY(target),
        GetUnitFacing(target));
      var level = GetAbilityLevel(caster);
      var buff = new SimulacrumBuff(caster, newUnit, 1 + DamageBonusBase + DamageBonusLevel * level,
        1 + HealthBonusBase + HealthBonusLevel * level, Duration, EffectTarget, EffectScaleTarget);
      BuffSystem.Add(buff);
    }

    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      var group = new GroupWrapper();
      group.EnumUnitsInRange(targetX, targetY, Radius);
      var maxTargets = CountBase * CountLevel * GetAbilityLevel(caster);
      foreach (var unit in group.EmptyToList().Take(maxTargets))
      {
        if (IsValidTarget(caster, unit))
        {
          ReplicateUnit(caster, unit);
        }
      }
      var effect = AddSpecialEffect(Effect, targetX, targetY);
      BlzSetSpecialEffectScale(effect, EffectScale);
      DestroyEffect(effect);
    }
  }
}