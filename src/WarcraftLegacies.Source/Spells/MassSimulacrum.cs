using System.Linq;
using MacroTools.Buffs;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

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
    return !target.IsIllusion && !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient) && !target.IsUnitType(unittype.Mechanical) &&
           !target.IsUnitType(unittype.Resistant) && !target.IsUnitType(unittype.Hero) &&
           target.IsAllyTo(caster.Owner) && target.Alive;
  }

  private void ReplicateUnit(unit caster, unit target)
  {
    var newUnit = unit.Create(caster.Owner, target.UnitType, target.X, target.Y, target.Facing);
    newUnit.AddType(unittype.Summoned);
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
    foreach (var unit in GlobalGroup.EnumUnitsInRange(targetPoint, Radius).Take(maxTargets))
    {
      if (IsValidTarget(caster, unit))
      {
        ReplicateUnit(caster, unit);
      }
    }
    effect effect = effect.Create(Effect, targetPoint.X, targetPoint.Y);
    effect.Scale = EffectScale;
    effect.Dispose();
  }
}
