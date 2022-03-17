using AzerothWarsCSharp.Source.Main.Libraries;

namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class ReapingHour{

  
    private const int ABIL_ID = FourCC(A10N);

    private const float RANGE = 1500;
    private const float VELOCITY = 250;
    private const float RADIUS = 50 ;//Radius of each Horsemen)s damage
    private const int HORSEMEN_COUNT = 7 ;//Must be an odd number
    private const float HORSEMEN_WIDTH = 700 ;//The total width of the spell
    private const float DIST_FADE_START = 400  ;//When the spell has this many units left to travel, the special effect begins to fade out

    private const float DAMAGE_BASE = 50;
    private const float DAMAGE_LEVEL = 50;
    private const float EXECUTE_PERC = 1 ;//% of extra damage per % of lost life

    private const string EFFECT_PROJ = "units\\undead\\HeroDeathKnight\\HeroDeathKnight.mdl";
    private const float EFFECT_SCALE_PROJ = 07;
    private const string EFFECT_HIT = "Objects\\Spawnmodels\\Undead\\UndeadDissipate\\UndeadDissipate.mdl";
    private const float EFFECT_SCALE_HIT = 07;
    private const string EFFECT_SPAWN = "Abilities\\Spells\\Undead\\AnimateDead\\AnimateDeadTarget.mdl";
    private const float EFFECT_SCALE_SPAWN = 05;

    private group TempGroup = CreateGroup();
  


    private effect sfx = null;
    private float x = 0;
    private float y = 0;
    private float face = 0;

    void destroy( ){
      DestroyEffect(this.sfx);
      this.sfx = null;
      this.deallocate();
    }

    void operator X=(float r ){
      x = r;
      BlzSetSpecialEffectX(sfx, r);
      BlzSetSpecialEffectZ(sfx, GetPositionZ(x, y));
    }

    float operator X( ){
      return x;
    }

    void operator Y=(float r ){
      y = r;
      BlzSetSpecialEffectY(sfx, r);
      BlzSetSpecialEffectZ(sfx, GetPositionZ(x, y));
    }

    float operator Y( ){
      return y;
    }

    void operator Face=(float r ){
      face = r;
      BlzSetSpecialEffectYaw(sfx, r*bj_DEGTORAD);
    }

    float operator Face( ){
      return face;
    }

    void operator Alpha=(int i ){
      BlzSetSpecialEffectAlpha(sfx, i);
    }

    thistype (float x, float y, float face ){

      effect tempSfx = AddSpecialEffect(EFFECT_SPAWN, x, y);
      DestroyEffect(tempSfx);
      BlzSetSpecialEffectScale(tempSfx, EFFECT_SCALE_SPAWN);

      this.sfx = AddSpecialEffect(EFFECT_PROJ, x, y);
      X = x;
      Y = y;
      Face = face;
      BlzPlaySpecialEffect(this.sfx, ANIM_TYPE_WALK);
      BlzSetSpecialEffectScale(this.sfx, EFFECT_SCALE_PROJ);

      ;;
    }


    //Responsible for handling the movement, damage and expiry of its child ReapProjectiles

    private Set reapProjectiles;
    private unit caster = null;
    private float curDist = 0;
    private float maxDist = 0;
    private float damage = 0;
    private group hitGroup = null   ;//Units already hit by this ReapingHour

    void destroy( ){
      int i = 0;
      ReapProjectile reapProjectile;
      DestroyGroup(hitGroup);
      hitGroup = null;
      while(true){
        if ( i == reapProjectiles.size){ break; }
        reapProjectile = reapProjectiles[i];
        reapProjectile.destroy();
        i = i + 1;
      }
      reapProjectiles.destroy();
      this.stopPeriodic();
      this.deallocate();
    }

    void hit(ReapProjectile reapProjectile ){
      int i = 0;
      unit u = null;
      effect tempEffect = null;
      float damageMult = 0;
      GroupEnumUnitsInRange(TempGroup, reapProjectile.X, reapProjectile.Y, RADIUS, null);
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        if (!IsUnitInGroup(u, this.hitGroup) && !IsUnitAlly(u, GetOwningPlayer(this.caster)) && IsUnitAlive(u) && !BlzIsUnitInvulnerable(u) && !IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT)){
          damageMult = 1 + ((GetUnitState(u, UNIT_STATE_MAX_LIFE) - GetUnitState(u, UNIT_STATE_LIFE))/GetUnitState(u, UNIT_STATE_MAX_LIFE))*EXECUTE_PERC;
          UnitDamageTarget(this.caster, u, this.damage*damageMult, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
          tempEffect = AddSpecialEffect(EFFECT_HIT, GetUnitX(u), GetUnitY(u));
          BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_HIT);
          DestroyEffect(tempEffect);
          tempEffect = null;
          GroupAddUnit(this.hitGroup, u);
        }
        GroupRemoveUnit(TempGroup, u);
      }
      GroupClear(TempGroup);
    }

    void periodic( ){
      int i = 0;
      ReapProjectile reapProjectile;
      while(true){
        if ( i == reapProjectiles.size){ break; }
        reapProjectile = reapProjectiles[i];
        reapProjectile.X = GetPolarOffsetX(reapProjectile.X, VELOCITY/T32_FPS, reapProjectile.Face);
        reapProjectile.Y = GetPolarOffsetY(reapProjectile.Y, VELOCITY/T32_FPS, reapProjectile.Face);
        hit(reapProjectile);
        //Begin fadeout near the end of the path
        if (this.curDist > (this.maxDist - DIST_FADE_START)){
          reapProjectile.Alpha = R2I(255*( 1 - ( ( this.curDist / this.maxDist ) ) ) );
        }
        i = i + 1;
      }

      //Ended path
      if (this.curDist >= this.maxDist){
        this.destroy();
      }

      this.curDist = this.curDist + VELOCITY/T32_FPS;
    }



    thistype (unit caster, float x, float y, float face, float damage, float maxDist ){

      int i = 0;
      float offsetAngle;
      float offsetDist;
      int middle = (HORSEMEN_COUNT-1)/2;

      this.caster = caster;
      this.maxDist = maxDist;
      this.damage = damage;
      this.hitGroup = CreateGroup();
      this.reapProjectiles = Set.create("reaping hour");

      while(true){
        if ( i == HORSEMEN_COUNT){ break; }
        if (i < middle){
          offsetAngle = face-90 - 15*(middle-i);
          offsetDist = (middle - i)*(HORSEMEN_WIDTH / HORSEMEN_COUNT);
        }else if (i > middle){
          offsetAngle = face+90 + 15*(i - middle);
          offsetDist = (i - middle)*(HORSEMEN_WIDTH / HORSEMEN_COUNT);
        }else {
          offsetAngle = 0;
          offsetDist = 0;
        }
        reapProjectiles.add(ReapProjectile.create(GetPolarOffsetX(x, offsetDist, offsetAngle), GetPolarOffsetY(y, offsetDist, offsetAngle), face));
        i = i + 1;
      }

      this.startPeriodic();

      ;;
    }


    private static void Cast( ){
      ability triggerAbility = null;
      unit triggerUnit = null;
      float triggerX = 0;
      float triggerY = 0;
      float triggerFace = 0;
      int i = 0;
      float offsetAngle = 0;
      float offsetDist = 0;
      int middle = 0;
      int level = 0;
      triggerUnit = GetTriggerUnit();
      triggerX = GetUnitX(triggerUnit);
      triggerY = GetUnitY(triggerUnit);
      triggerFace = GetUnitFacing(triggerUnit);
      level = GetUnitAbilityLevel(triggerUnit, ABIL_ID);
      ReapingHour.create(triggerUnit, triggerX, triggerY, triggerFace, DAMAGE_BASE + DAMAGE_LEVEL*level, RANGE);
      triggerUnit = null;
    }

    private static void OnInit( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
