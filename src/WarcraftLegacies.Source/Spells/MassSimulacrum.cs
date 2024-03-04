using System.Linq;
using MacroTools.Buffs;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Spells
{
  public sealed class MassSimulacrum : Spell
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
      UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
      var level = GetAbilityLevel(caster);
      var buff = new SimulacrumBuff(caster, newUnit, 1 + DamageBonusBase + DamageBonusLevel * level,
        1 + HealthBonusBase + HealthBonusLevel * level, EffectTarget, EffectScaleTarget)
      {
        Duration = Duration
      };
      BuffSystem.Add(buff);
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var maxTargets = CountBase * CountLevel * GetAbilityLevel(caster);
      foreach (var unit in CreateGroup().EnumUnitsInRange(targetPoint, Radius).EmptyToList().Take(maxTargets))
      {
        if (IsValidTarget(caster, unit))
        {
          ReplicateUnit(caster, unit);
        }
      }
      var effect = AddSpecialEffect(Effect, targetPoint.X, targetPoint.Y);
      BlzSetSpecialEffectScale(effect, EffectScale);
      DestroyEffect(effect);
    }
  }
}