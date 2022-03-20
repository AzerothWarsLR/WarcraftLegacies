namespace AzerothWarsCSharp.Source.Spells
{
  public class StormEarthAndFire{

  
    private const int  ABIL_ID = FourCC(A0HM);

    private const int  UNIT_TYPE_1 = FourCC(npn4);
    private const int  UNIT_TYPE_2 = FourCC(npn5);
    private const int  UNIT_TYPE_3 = FourCC(npn6);
    private const float     DURATION = 60    ;//Summoned unit duration

    private const string   EFFECT = "war3mapImported\\Soul Discharge Blue.mdx";
    private const float     EFFECT_SCALE = 11;
    private const string   EFFECT_TARGET = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl";
    private const float     EFFECT_SCALE_TARGET = 10;

    private const float    HEALTH_BONUS_BASE = -015     ;//These refer to the % extra amount of that stat a Simulacrum gets
    private const float    HEALTH_BONUS_LEVEL = 015     ;//The level ones are for each additional hero level, including level 1
    private const float    DAMAGE_BONUS_BASE = -015;
    private const float    DAMAGE_BONUS_LEVEL = 015;
  

    private static unit SummonPanda(player whichPlayer, int unitType, float x, float y, float facing, float damageBonus, float hitpointBonus, float duration ){
      unit newUnit = CreateUnit(whichPlayer, unitType, x, y, facing);
      effect tempEffect;
      UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
      UnitApplyTimedLife(newUnit, 0, DURATION);
      ScaleUnitBaseDamage(newUnit, 1 + damageBonus, 0);
      ScaleUnitMaxHP(newUnit, 1 + hitpointBonus);
      tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(newUnit), GetUnitY(newUnit));
      BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET);
      DestroyEffect(tempEffect);
      return newUnit;
    }

    private static void Cast( ){
      unit caster = null;
      int level;
      group tempGroup;
      unit u = null;
      player triggerPlayer = null;
      effect tempEffect = null;
      unit newUnit = null;
      float x;
      float y;
      caster = GetTriggerUnit();
      triggerPlayer = GetOwningPlayer(caster);
      level = GetUnitAbilityLevel(caster, ABIL_ID);
      x = GetPolarOffsetX(GetUnitX(caster), 150, GetUnitFacing(caster));
      y = GetPolarOffsetY(GetUnitY(caster), 150, GetUnitFacing(caster));
      //Create the replicant
      SummonPanda(triggerPlayer, UNIT_TYPE_1, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION);
      SummonPanda(triggerPlayer, UNIT_TYPE_2, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION);
      SummonPanda(triggerPlayer, UNIT_TYPE_3, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION);
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
