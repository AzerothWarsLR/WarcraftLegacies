using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class StormEarthandFire : Spell
  {
    public int UnitType1 { get; init; }
    public int UnitType2 { get; init; }
    public int UnitType3 { get; init; }

    /// <summary>
    /// How long the summoned units last.
    /// </summary>
    public float Duration { get; init; }

    public string EffectTarget { get; init; } = "";
    public float EffectScaleTarget { get; init; }

    public float HealthBonusBase { get; init; }
    public float HealthBonusLevel { get; init; } //The level ones are for each additional hero level, including level 1
    public float DamageBonusBase { get; init; }
    public float DamageBonusLevel { get; init; }

    public StormEarthandFire(int id) : base(id)
    {
    }

    public void SummonPanda(player player, int unitType, float x, float y, float facing, float damageBonus,
      float hitpointBonus, float durationunit)
    {
      var newUnit = CreateUnit(player, unitType, x, y, facing);
      UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
      UnitApplyTimedLife(newUnit, 0, Duration);
      newUnit.MultiplyBaseDamage(1 + damageBonus, 0);
      newUnit.MultiplyMaxHitpoints(1 + hitpointBonus);
      var tempEffect = AddSpecialEffect(EffectTarget, GetUnitX(newUnit), GetUnitY(newUnit));
      BlzSetSpecialEffectScale(tempEffect, EffectScaleTarget);
      DestroyEffect(tempEffect);
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var triggerPlayer = GetOwningPlayer(caster);
      var level = GetUnitAbilityLevel(caster, Id);
      var x = MathEx.GetPolarOffsetX(GetUnitX(caster), 150, GetUnitFacing(caster));
      var y = MathEx.GetPolarOffsetY(GetUnitY(caster), 150, GetUnitFacing(caster));
      var damageBonus = DamageBonusBase + DamageBonusLevel * level;
      var hitpointBonus = HealthBonusBase + HealthBonusLevel * level;
      SummonPanda(triggerPlayer, UnitType1, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, Duration);
      SummonPanda(triggerPlayer, UnitType2, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, Duration);
      SummonPanda(triggerPlayer, UnitType3, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, Duration);
    }
  }
}