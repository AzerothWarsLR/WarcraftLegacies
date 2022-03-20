namespace AzerothWarsCSharp.Source.Spells
{
  public class MassSimulacrum{

  
    private const int  ABIL_ID = FourCC(A0DG);

    private const float     RADIUS = 150;
    private const int  COUNT_BASE = 2    ;//How many units to copy
    private const int  COUNT_LEVEL = 4;
    private const float     DURATION = 60    ;//Summoned unit duration

    private const string   EFFECT = "war3mapImported\\Soul Discharge Blue.mdx";
    private const float     EFFECT_SCALE = 11;
    private const string   EFFECT_TARGET = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl";
    private const float     EFFECT_SCALE_TARGET = 10;

    private const float    HEALTH_BONUS_BASE = -05     ;//These refer to the % extra amount of that stat a Simulacrum gets
    private const float    HEALTH_BONUS_LEVEL = 02     ;//The level ones are for each additional hero level, including level 1
    private const float    DAMAGE_BONUS_BASE = -05;
    private const float    DAMAGE_BONUS_LEVEL = 02;

    private group Simulacrums;
  

    private static void Cast( ){
      unit caster = null;
      int level;
      group tempGroup;
      unit u = null;
      player triggerPlayer = null;
      effect tempEffect = null;
      unit newUnit = null;
      caster = GetTriggerUnit();
      triggerPlayer = GetOwningPlayer(caster);
      level = GetUnitAbilityLevel(caster, ABIL_ID);
      tempGroup = CreateGroup();
      GroupEnumUnitsInRange(tempGroup, GetSpellTargetX(), GetSpellTargetY(), RADIUS, null);
      while(true){
        if ( BlzGroupGetSize(tempGroup) == 0){ break; }
        u = BlzGroupUnitAt(tempGroup, GetRandomInt( 0, BlzGroupGetSize(tempGroup) - 1) );
        if (!IsUnitIllusion(u) && !IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT) && !IsUnitType(u, UNIT_TYPE_MECHANICAL) && !IsUnitType(u, UNIT_TYPE_RESISTANT) && !IsUnitType(u, UNIT_TYPE_HERO) && IsUnitAlly(u, triggerPlayer) && IsUnitAliveBJ(u)){
          //Create the replicant
          newUnit = CreateUnit(triggerPlayer, GetUnitTypeId(u), GetUnitX(u), GetUnitY(u), GetUnitFacing(u));
          UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
          UnitApplyTimedLife(newUnit, 0, DURATION);
          SetUnitVertexColor(newUnit, 100, 100, 230, 150);
          ScaleUnitBaseDamage(newUnit, 1 + DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, 0);
          ScaleUnitMaxHP(newUnit, 1 + HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level);
          tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(newUnit), GetUnitY(newUnit));
          BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET);
          DestroyEffect(tempEffect);
          GroupAddUnit(Simulacrums, newUnit);
          newUnit = null;
        }
        GroupRemoveUnit(tempGroup, u);
      }
      tempEffect = AddSpecialEffect(EFFECT, GetSpellTargetX(), GetSpellTargetY());
      BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE);
      DestroyEffect(tempEffect);
      caster = null;
      tempEffect = null;
      triggerPlayer = null;
      tempGroup = null;
      DestroyGroup(tempGroup);
      u = null;
    }

    private static void Death( ){
      unit u = GetTriggerUnit();
      if (IsUnitInGroup(u, Simulacrums)){
        DestroyEffect(AddSpecialEffect(EFFECT_TARGET, GetUnitX(u), GetUnitY(u)));
        GroupRemoveUnit(Simulacrums,u);
        RemoveUnit(u);
      }
      u = null;
    }

    public static void Setup( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DEATH,  Death);
      RegisterSpellEffectAction(ABIL_ID,  Cast);

      Simulacrums = CreateGroup();
    }

  }
}
