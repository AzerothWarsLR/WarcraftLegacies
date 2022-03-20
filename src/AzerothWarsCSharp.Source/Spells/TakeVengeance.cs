//When Maiev dies, she becomes an illusory assassin with additional damage.
//If she hits at least x times before it expires, she revives. Lasts y seconds.

namespace AzerothWarsCSharp.Source.Spells
{
  public class TakeVengeance{

  
    private const int HERO_ID = FourCC(Ewrd) ;//The hero that can use Take Vengeance

    private const int ABIL_ID = FourCC(A017);
    private const int ALTERNATE_FORM_ID = FourCC(espv);
    private const int HITS_REVIVE_THRESHOLD = 5   ;//Maiev needs to hit this many times to revive
    private const float HEAL_BASE = 900                ;//Maiev goes into Vengeance form with this much free health
    private const float HEAL_LEVEL = 300;
    private const int DAMAGE_BASE = 20;
    private const int DAMAGE_LEVEL = 20;
    private const float DURATION = 20;

    private const string REVIVE_EFFECT = "Heal Blue.mdx";
  


    private static trigger damageTrigger;
    readonly static Table vengeanceByUnit;

    private unit caster;
    private int tick;
    private int originalFormId;
    private int damageBonus;
    private int hitsDone;
    private float duration;
    private float maxDuration;

    private void operator DamageBonus=(int i ){
      BlzSetUnitBaseDamage(caster, BlzGetUnitBaseDamage(caster, 0) + i - DamageBonus, 0);
      damageBonus = i;
    }

    private integer operator DamageBonus( ){
      return damageBonus;
    }

    private void destroy( ){
      vengeanceByUnit[GetHandleId(caster)] = 0;
      DamageBonus = 0;
      BlzSetUnitSkin(caster, originalFormId);
      stopPeriodic();
      caster = null;
      deallocate();
    }

    private void revive( ){
      DestroyEffect(AddSpecialEffect(REVIVE_EFFECT, GetUnitX(caster), GetUnitY(caster)));
      destroy();
    }

    void onAttack( ){
      hitsDone = hitsDone + 1;
      if (hitsDone >= HITS_REVIVE_THRESHOLD){
        revive();
      }
    }

    private void periodic( ){
      tick = tick + 1;
      duration = duration - T32_PERIOD;
      if (duration <= 0){
        KillUnit(caster);
        destroy();
      }
    }



    private static void onInit( ){
      vengeanceByUnit = Table.create();
    }

    thistype (unit caster, int damageBonus, float heal, float duration ){

      SetUnitState(caster, UNIT_STATE_LIFE, heal);
      vengeanceByUnit[GetHandleId(caster)] = this;
      tick = 0;
      this.caster = caster;
      this.duration = duration;
      maxDuration = duration;
      originalFormId = BlzGetUnitSkin(caster);
      DamageBonus = damageBonus;
      hitsDone = 0;
      BlzSetUnitSkin(caster, ALTERNATE_FORM_ID);
      startPeriodic();
      DestroyEffect(AddSpecialEffect(REVIVE_EFFECT, GetUnitX(caster), GetUnitY(caster)));
      ;;
    }


    //When Maiev deals damage, check if she has Vengeance and act
    private static void OnInflictsDamage( ){
      Vengeance tempVengeance = Vengeance.vengeanceByUnit[GetHandleId(GetEventDamageSource())];
      if (tempVengeance != 0 && BlzGetEventIsAttack()){
        tempVengeance.onAttack();
      }
    }

    //Unit is damaged; check if it has this ability and it would take the damage. If so, trigger this ability
    private static void OnTakesDamage( ){
      unit triggerUnit = GetTriggerUnit();
      var abilityLevel = 0;
      if (GetUnitAbilityLevel(triggerUnit, ABIL_ID) > 0){
        abilityLevel = GetUnitAbilityLevel(triggerUnit, ABIL_ID);
        if (BlzGetUnitSkin(triggerUnit) != ALTERNATE_FORM_ID && GetEventDamage() >= GetUnitState(triggerUnit, UNIT_STATE_LIFE) && GetUnitState(triggerUnit, UNIT_STATE_MANA) >= BlzGetUnitAbilityManaCost(triggerUnit, ABIL_ID, abilityLevel)){
          BlzSetEventDamage(0);
          Vengeance.create(triggerUnit, DAMAGE_BASE + DAMAGE_LEVEL*abilityLevel, HEAL_BASE + HEAL_LEVEL*abilityLevel, DURATION);
        }
      }
      triggerUnit = null;
    }

    public static void Setup( ){
      RegisterUnitTypeTakesDamageAction(HERO_ID,  OnTakesDamage);
      RegisterUnitTypeInflictsDamageAction(HERO_ID,  OnInflictsDamage);
    }

  }
}
