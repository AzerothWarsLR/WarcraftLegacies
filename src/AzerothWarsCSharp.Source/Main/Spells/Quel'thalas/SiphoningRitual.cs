//Like vanilla Life Drain & Siphon Mana, but it applies to a group of units.
//Only drains if the caster needs the health and mana OR the target is an enemy.
public class SiphoningRitual{

  
    private const int ABIL_ID = FourCC(A0FA);
    private const int COUNT_BASE = 7    ;//Target limit
    private const float LIFEDRAIN_BASE = 10 ;//Per second
    private const float LIFEDRAIN_LEVEL = 10;
    private const float MANADRAIN_BASE = 5 ;//Per second
    private const float MANADRAIN_LEVEL = 5;
    private const float RANGE = 500;
    private const float RADIUS = 225;
    private const float PERIOD = 01;
  

  //A single beam connecting the caster to the victim, draining its life.

    private unit caster = null;
    private unit target = null;
    private lightning lightning = null;
    private float tick = 0;
    private float lifedrain = 0;
    private float manadrain = 0;
    private effect effect;

    void destroy( ){
      DestroyLightning(this.lightning);
      this.lightning = null;
      this.caster = null;
      this.target = null;
      DestroyEffect(this.effect);
      stopPeriodic();
    }

    private void drain( ){
      if (GetUnitState(caster, UNIT_STATE_LIFE) < GetUnitState(caster, UNIT_STATE_MAX_LIFE) || !IsUnitAlly(target, GetOwningPlayer(caster))){
        UnitDamageTarget(caster, target, lifedrain * PERIOD, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
        UnitHeal(caster, caster, RMinBJ(lifedrain * PERIOD, GetUnitState(target, UNIT_STATE_LIFE)));
      }
      if (GetUnitState(caster, UNIT_STATE_MANA) < GetUnitState(caster, UNIT_STATE_MAX_MANA) || !IsUnitAlly(target, GetOwningPlayer(caster))){
        UnitRestoreMana(caster, caster, RMinBJ(manadrain * PERIOD, GetUnitState(target, UNIT_STATE_MANA)));
        UnitReduceMana(caster, target, manadrain * PERIOD);
      }
    }

    private void periodic( ){
      tick = tick + 1;
      if (tick >= PERIOD * T32_FPS){
        this.drain();
        MoveLightning(this.lightning, true, GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this.target), GetUnitY(this.target));
        if (GetDistanceBetweenPoints(GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this.target), GetUnitY(this.target)) > RANGE + RADIUS / 2 || !UnitAlive(target) || IsUnitType(target, UNIT_TYPE_MAGIC_IMMUNE)){
          this.destroy();
        }
        tick = tick - PERIOD * T32_FPS;
      }
    }



     thistype (unit caster, unit target, float lifedrain, float manadrain ){

      this.caster = caster;
      this.target = target;
      this.lifedrain = lifedrain;
      this.manadrain = manadrain;
      this.lightning = AddLightning("DRAB", true, GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this.target), GetUnitY(this.target));
      this.effect = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Drain\\DrainTarget.mdl", this.target, "chest");
      startPeriodic();
      ;;
    }


  //A group of SiphoningBeams.

    public static thistype[] ByUnit;
    private Set siphoningBeams = 0;
    private unit caster = null;
    private float tick = 0;
    private effect effect = null;

    void destroy( ){
      int i = 0;
      caster = null;
      while(true){
        if ( i == siphoningBeams.size){ break; }
        SiphoningBeam(siphoningBeams[i]).destroy();
        i = i + 1;
      }
      DestroyEffect(this.effect);
      siphoningBeams.destroy();
      stopPeriodic();
      deallocate();
    }

    private void periodic( ){
      tick = tick + 1;
      if (tick >= PERIOD * T32_FPS){
        tick = tick - PERIOD * T32_FPS;
      }
    }



     thistype (unit caster, float x, float y, float radius, float lifedrain, float manadrain ){

      group tempGroup = CreateGroup();
      int i = 0;
      unit u = null;
      this.caster = caster;
      this.tick = 0;
      this.siphoningBeams = Set.create("siphoning Beams");
      this.effect = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Drain\\DrainCaster.mdl", this.caster, "chest");

      GroupEnumUnitsInRange(tempGroup, x, y, radius, null);
      while(true){
      if ( BlzGroupGetSize(tempGroup) == 0 || i == COUNT_BASE){ break; }
        u = BlzGroupUnitAt(tempGroup, GetRandomInt( 0, BlzGroupGetSize(tempGroup) - 1) );
        if (caster != u && !IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT) && !IsUnitType(u, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(u)){
          this.siphoningBeams.add(SiphoningBeam.create(this.caster, u, lifedrain, manadrain));
          i = i + 1;
        }else {
        }
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
      tempGroup = null;
      startPeriodic();
      ;;
    }


  private static void StopChannel( ){
    SiphoningRitual.ByUnit[GetUnitId(GetTriggerUnit())].destroy();
  }

  private static void StartChannel( ){
    unit u = GetTriggerUnit();
    SiphoningRitual.ByUnit[GetUnitId(u)] = SiphoningRitual.create(u, GetSpellTargetX(), GetSpellTargetY(), RADIUS, LIFEDRAIN_BASE+GetUnitAbilityLevel(u, ABIL_ID)*LIFEDRAIN_LEVEL, MANADRAIN_BASE+GetUnitAbilityLevel(u, ABIL_ID)*MANADRAIN_LEVEL);
  }

  private static void OnInit( ){
    RegisterSpellChannelAction(ABIL_ID,  StartChannel);
    RegisterSpellEndcastAction(ABIL_ID,  StopChannel);
  }

}
