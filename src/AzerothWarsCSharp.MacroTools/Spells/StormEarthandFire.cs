using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class StormEarthandFire : Spell
  {
    private int ABIL_ID { get; init; } = FourCC("A0HM");

    private int UNIT_TYPE_1 { get; init; } = FourCC("npn4");
    private int UNIT_TYPE_2 { get; init; } = FourCC("npn5");
    private int UNIT_TYPE_3 { get; init; } = FourCC("npn6");
    private float DURATION { get; init; } = 60.0F;    //Summoned unit duration

    private string EFFECT { get; init; } = "war3mapImported\\Soul Discharge Blue.mdx";
    private float EFFECT_SCALE { get; init; } = 1.1F;
    private string EFFECT_TARGET { get; init; } = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl";
    private float EFFECT_SCALE_TARGET { get; init; } = 1.0F;

    private float HEALTH_BONUS_BASE { get; init; } = -0.15F;   //These refer to the % extra amount of that stat a Simulacrum gets
    private float HEALTH_BONUS_LEVEL { get; init; } = 0.15F;     //The level ones are for each additional hero level, including level 1
    private float DAMAGE_BONUS_BASE { get; init; } = -0.15F;
    private float DAMAGE_BONUS_LEVEL { get; init; } = 0.15F;
    public StormEarthandFire(int id) : base(id)
    {
    }

    public SummonPanda(War3Api.Common.player player, int UnitType, float x, float y, float facing, float damageBonus, float hitpointBonus, float durationunit)
    {

    }
    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
        CreateUnit(GetOwningPlayer(caster), FourCC("hfoo"),100,100,90);
    }
  }
}


/*    private function SummonPanda takes player whichPlayer, int unitType, float x, float y, float facing, float damageBonus, float hitpointBonus, float duration returns unit
        local unit newUnit = CreateUnit(whichPlayer, unitType, x, y, facing)
        local effect tempEffect
        call UnitAddType(newUnit, UNIT_TYPE_SUMMONED)
        call UnitApplyTimedLife(newUnit, 0, DURATION)
        call ScaleUnitBaseDamage(newUnit, 1 + damageBonus, 0)
        call ScaleUnitMaxHP(newUnit, 1 + hitpointBonus)
        set tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(newUnit), GetUnitY(newUnit))
        call BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET)
        call DestroyEffect(tempEffect)
        return newUnit
    endfunction

    private function Cast takes nothing returns nothing
        local unit caster = null
        local int level
        local group tempGroup
        local unit u = null
        local player triggerPlayer = null
        local effect tempEffect = null
        local unit newUnit = null
        local float x
        local float y
        set caster = GetTriggerUnit()
        set triggerPlayer = GetOwningPlayer(caster)
        set level = GetUnitAbilityLevel(caster, ABIL_ID) 
        set x = GetPolarOffsetX(GetUnitX(caster), 150, GetUnitFacing(caster))
        set y = GetPolarOffsetY(GetUnitY(caster), 150, GetUnitFacing(caster))
        //Create the replicant
        call SummonPanda(triggerPlayer, UNIT_TYPE_1, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION)
        call SummonPanda(triggerPlayer, UNIT_TYPE_2, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION)
        call SummonPanda(triggerPlayer, UNIT_TYPE_3, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION)
    endfunction

    private function OnInit takes nothing returns nothing
        call RegisterSpellEffectAction(ABIL_ID, function Cast)
    endfunction
*/
