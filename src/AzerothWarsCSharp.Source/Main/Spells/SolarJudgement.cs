public class SolarJudgement{

  
    private const int ABIL_ID = FourCC(A01F);

    private const float DAMAGE_BASE = 20;
    private const float DAMAGE_LEVEL = 20;
    private const float DURATION = 14;
    private const float PERIOD = 025;

    private const float HEAL_MULT = 15;
    private const float EVIL_MULT = 11;

    private const float RADIUS = 250;
    private const float BOLT_RADIUS = 125;

    private const string EFFECT = "Shining Flare.mdx";
    private const string EFFECT_HEAL = "Abilities\\Spells\\Human\\Heal\\HealTarget.mdl";

    private group TempGroup = CreateGroup();
  


    private unit caster;
    private float x;
    private float y;
    private float damage;
    private float tick = 0;
    private float duration;

    private void destroy( ){
      stopPeriodic();
      caster = null;
      deallocate();
    }

    private void bolt(float x, float y ){
      float damageMult = 1;
      unit u;

      DestroyEffect(AddSpecialEffect(EFFECT, x, y));

      P = GetOwningPlayer(caster);
      //Damage enemies
      GroupEnumUnitsInRange(TempGroup,x,y,BOLT_RADIUS,( EnemyAliveFilter));
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        if (IsUnitType(u, UNIT_TYPE_UNDEAD) == true){
          damageMult = EVIL_MULT;
        }else {
          damageMult = 1;
        }
        UnitDamageTarget(caster, u, damage*damageMult, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
        GroupRemoveUnit(TempGroup,u);
      }

      //Heal allies
      GroupEnumUnitsInRange(TempGroup,x,y,BOLT_RADIUS,( AllyAliveFilter));
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        if (IsUnitType(u, UNIT_TYPE_UNDEAD) == false){
          damageMult = HEAL_MULT;
          SetUnitState(u, UNIT_STATE_LIFE, GetUnitState(u, UNIT_STATE_LIFE) + damage * damageMult);
          DestroyEffect(AddSpecialEffectTarget(EFFECT_HEAL, u, "origin"));
        }
        GroupRemoveUnit(TempGroup,u);
      }

      GroupClear(TempGroup);
      P = null;
      u = null;
    }

    private void randomBolt( ){
      float randomAngle = GetRandomReal(0, 2*bj_PI);
      float randomRadius = GetRandomReal(0, RADIUS);
      bolt(x + randomRadius * Cos(randomAngle), y + randomRadius * Sin(randomAngle));
    }

    private void periodic( ){
      tick = tick + 1;
      duration = duration - 1/T32_FPS;
      if (tick >= PERIOD * T32_FPS){
        randomBolt();
        tick = tick - PERIOD * T32_FPS;
      }
      if (duration <= 0){
        destroy();
      }
    }



     thistype (unit caster, float x, float y, float damage, float duration ){

      this.duration = duration;
      this.caster = caster;
      this.duration = duration;
      this.damage = damage;
      this.x = x;
      this.y = y;
      this.tick = 0;
      startPeriodic();
      ;;
    }


  private static void Cast( ){
    SolarJudgement.create(GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(), DAMAGE_BASE + DAMAGE_LEVEL*GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), DURATION);
  }

  private static void OnInit( ){
    RegisterSpellEffectAction(ABIL_ID,  Cast);
  }

}
