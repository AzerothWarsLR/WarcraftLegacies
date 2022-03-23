//Like vanilla Life Drain & Siphon Mana, but it applies to a group of units.
//Only drains if the caster needs the health and mana OR the target is an enemy.

namespace AzerothWarsCSharp.Source.Spells.Quel_thalas
{
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

    private unit _caster;
    private unit _target;
    private lightning _lightning;
    private float _tick;
    private float _lifedrain;
    private float _manadrain;
    private effect _effect;

    void Destroy( ){
      DestroyLightning(_lightning);
      _lightning = null;
      this.caster = null;
      _target = null;
      DestroyEffect(this.effect);
      stopPeriodic();
    }

    private void Drain( ){
      if (GetUnitState(caster, UNIT_STATE_LIFE) < GetUnitState(caster, UNIT_STATE_MAX_LIFE) || !IsUnitAlly(_target, GetOwningPlayer(caster))){
        UnitDamageTarget(caster, _target, _lifedrain * PERIOD, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
        UnitHeal(caster, caster, RMinBJ(_lifedrain * PERIOD, GetUnitState(_target, UNIT_STATE_LIFE)));
      }
      if (GetUnitState(caster, UNIT_STATE_MANA) < GetUnitState(caster, UNIT_STATE_MAX_MANA) || !IsUnitAlly(_target, GetOwningPlayer(caster))){
        UnitRestoreMana(caster, caster, RMinBJ(_manadrain * PERIOD, GetUnitState(_target, UNIT_STATE_MANA)));
        UnitReduceMana(caster, _target, _manadrain * PERIOD);
      }
    }

    private void Periodic( ){
      tick = tick + 1;
      if (tick >= PERIOD * T32_FPS){
        Drain();
        MoveLightning(_lightning, true, GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(_target), GetUnitY(_target));
        if (GetDistanceBetweenPoints(GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(_target), GetUnitY(_target)) > RANGE + RADIUS / 2 || !UnitAlive(_target) || IsUnitType(_target, UNIT_TYPE_MAGIC_IMMUNE)){
          this.destroy();
        }
        tick = tick - PERIOD * T32_FPS;
      }
    }



    thistype (unit caster, unit target, float lifedrain, float manadrain ){

      this.caster = caster;
      this._target = target;
      this._lifedrain = lifedrain;
      this._manadrain = manadrain;
      _lightning = AddLightning("DRAB", true, GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this._target), GetUnitY(this._target));
      this.effect = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Drain\\DrainTarget.mdl", this._target, "chest");
      startPeriodic();
      ;;
    }


    //A group of SiphoningBeams.

    public static thistype[] ByUnit;
    private Set _siphoningBeams = 0;
    private unit _caster;
    private float _tick;
    private effect _effect;

    void Destroy( ){
      var i = 0;
      caster = null;
      while(true){
        if ( i == _siphoningBeams.size){ break; }
        SiphoningBeam(_siphoningBeams[i]).destroy();
        i = i + 1;
      }
      DestroyEffect(this.effect);
      _siphoningBeams.destroy();
      stopPeriodic();
      deallocate();
    }

    private void Periodic( ){
      tick = tick + 1;
      if (tick >= PERIOD * T32_FPS){
        tick = tick - PERIOD * T32_FPS;
      }
    }



    thistype (unit caster, float x, float y, float radius, float lifedrain, float manadrain ){

      group tempGroup = CreateGroup();
      var i = 0;
      unit u = null;
      this.caster = caster;
      this.tick = 0;
      _siphoningBeams = Set.create("siphoning Beams");
      this.effect = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Drain\\DrainCaster.mdl", this.caster, "chest");

      GroupEnumUnitsInRange(tempGroup, x, y, radius, null);
      while(true){
        if ( BlzGroupGetSize(tempGroup) == 0 || i == COUNT_BASE){ break; }
        u = BlzGroupUnitAt(tempGroup, GetRandomInt( 0, BlzGroupGetSize(tempGroup) - 1) );
        if (caster != u && !IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT) && !IsUnitType(u, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(u)){
          _siphoningBeams.add(SiphoningBeam.create(this.caster, u, lifedrain, manadrain));
          i = i + 1;
        }
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
      tempGroup = null;
      startPeriodic();
      ;;
    }


    private static void StopChannel( ){
      ByUnit[GetUnitId(GetTriggerUnit())].destroy();
    }

    private static void StartChannel( ){
      unit u = GetTriggerUnit();
      ByUnit[GetUnitId(u)] = SiphoningRitual.create(u, GetSpellTargetX(), GetSpellTargetY(), RADIUS, LIFEDRAIN_BASE+GetUnitAbilityLevel(u, ABIL_ID)*LIFEDRAIN_LEVEL, MANADRAIN_BASE+GetUnitAbilityLevel(u, ABIL_ID)*MANADRAIN_LEVEL);
    }

    public static void Setup( ){
      RegisterSpellChannelAction(ABIL_ID,  StartChannel);
      RegisterSpellEndcastAction(ABIL_ID,  StopChannel);
    }

  }
}
