namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class WarglaivesOfAzzinoth{

  
    private const int ABIL_ID = FourCC(A0YW);

    private const float RADIUS = 150;
    private const float DAMAGE_BASE = 4;
    private const float DAMAGE_LEVEL = 14;
    private const float DAMAGE_MULT_DEMON = 12   ;//How much extra damage % to do versus demons

    private const string EFFECT = "war3mapImported\\Culling Cleave.mdx";
    private const float EFFECT_SCALE = 09;
    private const damagetype DAMAGE_TYPE = DAMAGE_TYPE_MAGIC;
  

    private static void DoGlaive( ){
      group tempGroup = CreateGroup();
      unit u = null;
      unit caster = GetEventDamageSource();
      var level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID);
      effect tempSfx = AddSpecialEffect(EFFECT, GetUnitX(caster), GetUnitY(caster));
      float damage = 0;
      BlzSetSpecialEffectScale(tempSfx, EFFECT_SCALE);
      BlzSetSpecialEffectYaw(tempSfx, GetUnitFacing(caster)*bj_DEGTORAD);
      GroupEnumUnitsInRange(tempGroup, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), RADIUS, null);
      while(true){
        if ( BlzGroupGetSize(tempGroup) == 0){ break; }
        u = FirstOfGroup(tempGroup);
        if (!IsUnitAlly(u, GetOwningPlayer(caster)) && IsUnitAlive(u) && !BlzIsUnitInvulnerable(u) && !IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT)){
          damage = DAMAGE_BASE + DAMAGE_LEVEL*level;
          if (GetUnitRace(u) == RACE_DEMON){
            damage = damage*DAMAGE_MULT_DEMON;
          }
          UnitDamageTarget(caster, u, damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE, WEAPON_TYPE_WHOKNOWS);
        }
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
      caster = null;
    }

    private static void Damaging( ){
      var level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID);
      if (level > 0 && BlzGetEventIsAttack()){
        DoGlaive();
      }
    }

    public static void Setup( ){
      RegisterUnitTypeInflictsDamageAction(FourCC(Eill),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(Eidm),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(Eevm),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(Eilm),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(Eevi),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(E00F),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(E00G),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(E00E),  Damaging);
      RegisterUnitTypeInflictsDamageAction(FourCC(E00D),  Damaging);
    }

  }
}
