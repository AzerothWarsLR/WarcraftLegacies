namespace AzerothWarsCSharp.Source.Spells
{
  public class DivineJustice{

  
    private const int    ABIL_ID                        = FourCC(A097);
    private const float       DURATION                       = 8;

    private const string     CONSECRATION_EFFECT_SPARKLE    = "war3mapImported\\Consecrate.mdx";
    private const string     CONSECRATION_EFFECT_RING       = "war3mapImported\\Point Target.mdx";
    private const float       CONSECRATION_DAMAGE_BASE       = 200;
    private const float       CONSECRATION_DAMAGE_LEVEL      = 250;
    private const float       CONSECRATION_RADIUS            = 400;
    private const float       CONSECRATION_SCALE             = 23;
    private const float       CONSECRATION_SCALE_RING        = 55;
    private const float       CONSECRATION_ALPHA_FADE        = 05;
    private const float       CONSECRATION_ALPHA_RING        = 255;

    private const string     EXPLODE_EFFECT                 = "war3mapImported\\Divine Edict.mdx";
    private const float       EXPLODE_SCALE                  = 2;

    private const string     PROGRESS_EFFECT                = "war3mapImported\\Progressbar.mdx";
    private const float       PROGRESS_SCALE                 = 15;
    private const float       PROGRESS_HEIGHT                = 225;

    private keyword _consecration;
    private Consecration[] _consecrationsByUnit      ;//For attaching to channeler unit
    private group _unitsWithConsecration = CreateGroup();
    private unit _tempUnit;
    private group _tempGroup = CreateGroup();
  


    unit       _cas;
    float       _tick;
    float       _duration;
    float       _fullDuration;

    effect     _sfxSparkle;
    effect     _sfxRing;
    effect     _sfxProgress;

    float       _sfxRingAlpha;
    float       _sfxSparkleAlpha = 255;

    float       _x;
    float       _y;
    float       _z;
    float       _radius;
    float       _damage;
    float       _fullDamage;

    private bool    _ended = false;

    private void Destroy( ){
      BlzSetSpecialEffectTimeScale(_sfxRing,1);
      BlzSetSpecialEffectPosition(_sfxSparkle, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      BlzSetSpecialEffectPosition(_sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(_sfxSparkle);
      DestroyEffect(_sfxRing);
      DestroyEffect(_sfxProgress);

      GroupRemoveUnit(_unitsWithConsecration, _cas);
      SetUnitInvulnerable(_cas, false);

      _cas = null;
      _sfxSparkle = null;
      _sfxRing = null;
      _sfxProgress = null;

      this.stopPeriodic();
      this.deallocate();
    }

    void End( ){
      _ended = true;
    }

    void Protect(unit u ){
      if (GetDistanceBetweenPoints(_x, _y, GetUnitX(u), GetUnitY(u)) <= _radius && IsUnitAlly(u, GetOwningPlayer(_cas))){
        BlzSetEventDamage(0);
      }
    }

    private void Explode( ){
      effect explodeEffect = AddSpecialEffect(EXPLODE_EFFECT, _x, _y);
      unit u = null;
      BlzSetSpecialEffectScale(explodeEffect, EXPLODE_SCALE);
      DestroyEffect(explodeEffect);

      P = GetOwningPlayer(_cas);
      GroupEnumUnitsInRange(_tempGroup,_x,_y,_radius,( EnemyAliveFilter));
      while(true){
        u = FirstOfGroup(_tempGroup);
        if ( u == null){ break; }
        UnitDamageTarget(_cas, u, _damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_NORMAL, WEAPON_TYPE_WHOKNOWS);
        GroupRemoveUnit(_tempGroup,u);
      }
    }

    private void Periodic( ){
      _tick = _tick+1;
      _duration = _duration - 1/T32_FPS;

      if (_ended == true && _duration > 0){
        _duration = 0;
      }

      if (_duration >= 0){
        //Scale up the damage
        if (_damage < _fullDamage){
          _damage = _damage + _fullDamage/(_fullDuration*T32_FPS);
        }
        //Fade in the ring
        if (_sfxRingAlpha < CONSECRATION_ALPHA_RING){
          _sfxRingAlpha = _sfxRingAlpha + (CONSECRATION_ALPHA_RING / (CONSECRATION_ALPHA_FADE*T32_FPS));
          BlzSetSpecialEffectAlpha(_sfxRing, R2I(_sfxRingAlpha));
        }
      }

      if (_duration == 0){
        Explode();
        Destroy();
      }
    }



    thistype (unit cast, float x, float y, float damage, float radius, float duration ){

      var i = 0;
      bool b = false;

      _cas = cast;

      this._x  = x;
      this._y  = y;
      _z  = 2000 + GetPositionZ(x,y);
      _fullDamage = damage;
      this._radius = radius;
      _fullDuration = duration;
      this._duration = duration;

      _sfxSparkle = AddSpecialEffect(CONSECRATION_EFFECT_SPARKLE,x,y);
      BlzSetSpecialEffectScale(_sfxSparkle,CONSECRATION_SCALE);
      BlzSetSpecialEffectColor(_sfxSparkle, 255, 255, 0);

      _sfxRing = AddSpecialEffect(CONSECRATION_EFFECT_RING,x,y);
      BlzSetSpecialEffectTimeScale(_sfxRing, 0);
      BlzSetSpecialEffectColor(_sfxRing, 235, 235, 50);
      BlzSetSpecialEffectAlpha(_sfxRing, 0);
      BlzSetSpecialEffectScale(_sfxRing,CONSECRATION_SCALE_RING);

      _sfxProgress = AddSpecialEffect(PROGRESS_EFFECT,x,y);
      BlzSetSpecialEffectTimeScale(_sfxProgress, 1/DURATION);
      BlzSetSpecialEffectColorByPlayer(_sfxProgress, Player(4));
      BlzSetSpecialEffectScale(_sfxProgress,PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(_sfxProgress, PROGRESS_HEIGHT);

      GroupAddUnit(_unitsWithConsecration, cast);
      SetUnitInvulnerable(_cas, true);

      this.startPeriodic();

      
    }


    private static void OnDamageB( ){
      _consecrationsByUnit[GetUnitId(GetEnumUnit())].protect(_tempUnit);
    }

    private static void OnDamage( ){
      _tempUnit = GetTriggerUnit()     ;//This gets used in the .protect() method of Consecration
      if (BlzGroupGetSize(_unitsWithConsecration) > 0){
        ForGroup(_unitsWithConsecration,  OnDamageB);
      }
      _tempUnit = null;
    }

    private static void StopChannel( ){
      _consecrationsByUnit[GetUnitId(GetTriggerUnit())].end();
    }

    private static void StartChannel( ){
      unit u = GetTriggerUnit();
      var i = 0;
      bool b = false;

      _consecrationsByUnit[GetUnitId(u)] = _consecration.create(u, GetUnitX(u), GetUnitY(u), CONSECRATION_DAMAGE_BASE+GetUnitAbilityLevel(u, ABIL_ID)*CONSECRATION_DAMAGE_LEVEL, CONSECRATION_RADIUS, DURATION);
    }

    public static void Setup( ){
      RegisterSpellChannelAction(ABIL_ID,  StartChannel);
      RegisterSpellEndcastAction(ABIL_ID,  StopChannel);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  OnDamage);
    }

  }
}
