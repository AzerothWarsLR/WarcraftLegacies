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

    private keyword Consecration;
    private Consecration[] ConsecrationsByUnit      ;//For attaching to channeler unit
    private group UnitsWithConsecration = CreateGroup();
    private unit TempUnit;
    private group TempGroup = CreateGroup();
  


    unit       cas;
    float       tick;
    float       duration;
    float       fullDuration;

    effect     sfxSparkle;
    effect     sfxRing;
    effect     sfxProgress;

    float       sfxRingAlpha;
    float       sfxSparkleAlpha = 255;

    float       x;
    float       y;
    float       z;
    float       radius;
    float       damage;
    float       fullDamage;

    private bool    ended = false;

    private void destroy( ){
      BlzSetSpecialEffectTimeScale(sfxRing,1);
      BlzSetSpecialEffectPosition(sfxSparkle, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      BlzSetSpecialEffectPosition(sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(sfxSparkle);
      DestroyEffect(sfxRing);
      DestroyEffect(sfxProgress);

      GroupRemoveUnit(UnitsWithConsecration, cas);
      SetUnitInvulnerable(cas, false);

      cas = null;
      sfxSparkle = null;
      sfxRing = null;
      sfxProgress = null;

      this.stopPeriodic();
      this.deallocate();
    }

    void end( ){
      ended = true;
    }

    void protect(unit u ){
      if (GetDistanceBetweenPoints(x, y, GetUnitX(u), GetUnitY(u)) <= radius && IsUnitAlly(u, GetOwningPlayer(cas))){
        BlzSetEventDamage(0);
      }
    }

    private void explode( ){
      effect explodeEffect = AddSpecialEffect(EXPLODE_EFFECT, x, y);
      unit u = null;
      BlzSetSpecialEffectScale(explodeEffect, EXPLODE_SCALE);
      DestroyEffect(explodeEffect);

      P = GetOwningPlayer(cas);
      GroupEnumUnitsInRange(TempGroup,x,y,radius,( EnemyAliveFilter));
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        UnitDamageTarget(cas, u, damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_NORMAL, WEAPON_TYPE_WHOKNOWS);
        GroupRemoveUnit(TempGroup,u);
      }
    }

    private void periodic( ){
      tick = tick+1;
      duration = duration - 1/T32_FPS;

      if (ended == true && duration > 0){
        duration = 0;
      }

      if (duration >= 0){
        //Scale up the damage
        if (damage < fullDamage){
          damage = damage + fullDamage/(fullDuration*T32_FPS);
        }
        //Fade in the ring
        if (sfxRingAlpha < CONSECRATION_ALPHA_RING){
          sfxRingAlpha = sfxRingAlpha + (CONSECRATION_ALPHA_RING / (CONSECRATION_ALPHA_FADE*T32_FPS));
          BlzSetSpecialEffectAlpha(sfxRing, R2I(sfxRingAlpha));
        }
      }

      if (duration == 0){
        explode();
        destroy();
      }
    }



    thistype (unit cast, float x, float y, float damage, float radius, float duration ){

      var i = 0;
      bool b = false;

      cas = cast;

      this.x  = x;
      this.y  = y;
      z  = 2000 + GetPositionZ(x,y);
      fullDamage = damage;
      this.radius = radius;
      fullDuration = duration;
      this.duration = duration;

      sfxSparkle = AddSpecialEffect(CONSECRATION_EFFECT_SPARKLE,x,y);
      BlzSetSpecialEffectScale(sfxSparkle,CONSECRATION_SCALE);
      BlzSetSpecialEffectColor(sfxSparkle, 255, 255, 0);

      sfxRing = AddSpecialEffect(CONSECRATION_EFFECT_RING,x,y);
      BlzSetSpecialEffectTimeScale(sfxRing, 0);
      BlzSetSpecialEffectColor(sfxRing, 235, 235, 50);
      BlzSetSpecialEffectAlpha(sfxRing, 0);
      BlzSetSpecialEffectScale(sfxRing,CONSECRATION_SCALE_RING);

      sfxProgress = AddSpecialEffect(PROGRESS_EFFECT,x,y);
      BlzSetSpecialEffectTimeScale(sfxProgress, 1/DURATION);
      BlzSetSpecialEffectColorByPlayer(sfxProgress, Player(4));
      BlzSetSpecialEffectScale(sfxProgress,PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT);

      GroupAddUnit(UnitsWithConsecration, cast);
      SetUnitInvulnerable(cas, true);

      this.startPeriodic();

      ;;
    }


    private static void OnDamageB( ){
      ConsecrationsByUnit[GetUnitId(GetEnumUnit())].protect(TempUnit);
    }

    private static void OnDamage( ){
      TempUnit = GetTriggerUnit()     ;//This gets used in the .protect() method of Consecration
      if (BlzGroupGetSize(UnitsWithConsecration) > 0){
        ForGroup(UnitsWithConsecration,  OnDamageB);
      }
      TempUnit = null;
    }

    private static void StopChannel( ){
      ConsecrationsByUnit[GetUnitId(GetTriggerUnit())].end();
    }

    private static void StartChannel( ){
      unit u = GetTriggerUnit();
      var i = 0;
      bool b = false;

      ConsecrationsByUnit[GetUnitId(u)] = Consecration.create(u, GetUnitX(u), GetUnitY(u), CONSECRATION_DAMAGE_BASE+GetUnitAbilityLevel(u, ABIL_ID)*CONSECRATION_DAMAGE_LEVEL, CONSECRATION_RADIUS, DURATION);
    }

    public static void Setup( ){
      RegisterSpellChannelAction(ABIL_ID,  StartChannel);
      RegisterSpellEndcastAction(ABIL_ID,  StopChannel);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  OnDamage);
    }

  }
}
