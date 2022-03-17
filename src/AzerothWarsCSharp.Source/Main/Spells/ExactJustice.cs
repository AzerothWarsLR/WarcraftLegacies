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
    private unit TempUnit = null;
    private group TempGroup = CreateGroup();
  


    unit       cas = null;
    float       tick = 0;
    float       duration = 0;
    float       fullDuration = 0;

    effect     sfxSparkle = null;
    effect     sfxRing = null;
    effect     sfxProgress = null;

    float       sfxRingAlpha    = 0;
    float       sfxSparkleAlpha = 255;

    float       x  = 0;
    float       y  = 0;
    float       z  = 0;
    float       radius = 0;
    float       damage = 0;
    float       fullDamage = 0;

    private boolean    ended = false;

    private void destroy( ){
      BlzSetSpecialEffectTimeScale(this.sfxRing,1);
      BlzSetSpecialEffectPosition(this.sfxSparkle, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      BlzSetSpecialEffectPosition(this.sfxProgress, -100000, -100000, 0)    ;//Has no death animation so needs to be moved off the map
      DestroyEffect(this.sfxSparkle);
      DestroyEffect(this.sfxRing);
      DestroyEffect(this.sfxProgress);

      GroupRemoveUnit(UnitsWithConsecration, this.cas);
      SetUnitInvulnerable(this.cas, false);

      this.cas = null;
      this.sfxSparkle = null;
      this.sfxRing = null;
      this.sfxProgress = null;

      this.stopPeriodic();
      this.deallocate();
    }

    void end( ){
      this.ended = true;
    }

    void protect(unit u ){
      if (GetDistanceBetweenPoints(this.x, this.y, GetUnitX(u), GetUnitY(u)) <= this.radius && IsUnitAlly(u, GetOwningPlayer(this.cas))){
        BlzSetEventDamage(0);
      }
    }

    private void explode( ){
      effect explodeEffect = AddSpecialEffect(EXPLODE_EFFECT, this.x, this.y);
      unit u = null;
      BlzSetSpecialEffectScale(explodeEffect, EXPLODE_SCALE);
      DestroyEffect(explodeEffect);

      P = GetOwningPlayer(this.cas);
      GroupEnumUnitsInRange(TempGroup,this.x,this.y,this.radius,( EnemyAliveFilter));
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        UnitDamageTarget(this.cas, u, this.damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_NORMAL, WEAPON_TYPE_WHOKNOWS);
        GroupRemoveUnit(TempGroup,u);
      }
    }

    private void periodic( ){
      this.tick = this.tick+1;
      this.duration = this.duration - 1/T32_FPS;

      if (this.ended == true && this.duration > 0){
        this.duration = 0;
      }

      if (this.duration >= 0){
        //Scale up the damage
        if (this.damage < this.fullDamage){
          this.damage = this.damage + this.fullDamage/(this.fullDuration*T32_FPS);
        }
        //Fade in the ring
        if (this.sfxRingAlpha < CONSECRATION_ALPHA_RING){
          this.sfxRingAlpha = this.sfxRingAlpha + (CONSECRATION_ALPHA_RING / (CONSECRATION_ALPHA_FADE*T32_FPS));
          BlzSetSpecialEffectAlpha(this.sfxRing, R2I(this.sfxRingAlpha));
        }
      }

      if (this.duration == 0){
        this.explode();
        this.destroy();
      }
    }



     thistype (unit cast, float x, float y, float damage, float radius, float duration ){

      int i = 0;
      boolean b = false;

      this.cas = cast;

      this.x  = x;
      this.y  = y;
      this.z  = 2000 + GetPositionZ(x,y);
      this.fullDamage = damage;
      this.radius = radius;
      this.fullDuration = duration;
      this.duration = duration;

      this.sfxSparkle = AddSpecialEffect(CONSECRATION_EFFECT_SPARKLE,x,y);
      BlzSetSpecialEffectScale(this.sfxSparkle,CONSECRATION_SCALE);
      BlzSetSpecialEffectColor(this.sfxSparkle, 255, 255, 0);

      this.sfxRing = AddSpecialEffect(CONSECRATION_EFFECT_RING,x,y);
      BlzSetSpecialEffectTimeScale(this.sfxRing, 0);
      BlzSetSpecialEffectColor(this.sfxRing, 235, 235, 50);
      BlzSetSpecialEffectAlpha(this.sfxRing, 0);
      BlzSetSpecialEffectScale(this.sfxRing,CONSECRATION_SCALE_RING);

      this.sfxProgress = AddSpecialEffect(PROGRESS_EFFECT,x,y);
      BlzSetSpecialEffectTimeScale(this.sfxProgress, 1/DURATION);
      BlzSetSpecialEffectColorByPlayer(this.sfxProgress, Player(4));
      BlzSetSpecialEffectScale(sfxProgress,PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT);

      GroupAddUnit(UnitsWithConsecration, cast);
      SetUnitInvulnerable(this.cas, true);

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
    int i = 0;
    boolean b = false;

    ConsecrationsByUnit[GetUnitId(u)] = Consecration.create(u, GetUnitX(u), GetUnitY(u), CONSECRATION_DAMAGE_BASE+GetUnitAbilityLevel(u, ABIL_ID)*CONSECRATION_DAMAGE_LEVEL, CONSECRATION_RADIUS, DURATION);
  }

  private static void OnInit( ){
    RegisterSpellChannelAction(ABIL_ID,  StartChannel);
    RegisterSpellEndcastAction(ABIL_ID,  StopChannel);
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  OnDamage);
  }

}
