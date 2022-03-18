namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class WarStompCairne{

  
    private const int ABIL_ID        = FourCC(A0WM);
    private const int STUN_ID        = FourCC(A0WN)        ;//The Storm Bolt dummy spell that applies the stun itself
    private const string  STUN_ORDER     = "thunderbolt";
    private const float    DAMAGE_BASE    = 20;
    private const float    DAMAGE_LEVEL   = 30;
    private const float    RADIUS         = 30000;
    private const int DURATION_BASE  = 0;
    private const int DURATION_LEVEL = 1;
    private const string  EFFECT         = "Abilities\\Spells\\Orc\\Warstomp\\WarStompCaster.mdl";
    private group     TempGroup = CreateGroup();
  

    private static void Cast( ){
      unit u;
      unit caster;
      int level;
      caster = GetTriggerUnit();
      level = GetUnitAbilityLevel(caster, ABIL_ID);
      P = GetOwningPlayer(caster);
      GroupEnumUnitsInRange(TempGroup,GetUnitX(caster),GetUnitY(caster),RADIUS,( EnemyAliveFilter));
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        UnitDamageTarget(caster, u, DAMAGE_BASE+DAMAGE_LEVEL*level, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
        DummyCastUnit(GetOwningPlayer(caster), STUN_ID, STUN_ORDER, DURATION_BASE + DURATION_LEVEL*level, u);
        GroupRemoveUnit(TempGroup,u);
      }
      DestroyEffect(AddSpecialEffect(EFFECT,GetUnitX(caster),GetUnitY(caster)));
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
