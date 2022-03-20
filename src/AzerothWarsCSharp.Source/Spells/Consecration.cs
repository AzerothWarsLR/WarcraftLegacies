namespace AzerothWarsCSharp.Source.Spells
{
  public class Consecration{

  
    private const int ABIL_ID        = FourCC(A0WE);
    private const int DUMMY_ID       = FourCC(S00H)        ;//The ability that gets cast on each unit in the radius
    private const string  DUMMY_ORDER    = "cripple";
    private const float    DAMAGE_BASE    = 0;
    private const float    DAMAGE_LEVEL   = 60;
    private const float    RADIUS         = 22500;
    private const string  EFFECT         = "Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl";
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
        DummyCastUnit(GetOwningPlayer(caster), DUMMY_ID, DUMMY_ORDER, 1, u);
        GroupRemoveUnit(TempGroup,u);
      }
      DestroyEffect(AddSpecialEffect(EFFECT,GetUnitX(caster),GetUnitY(caster)));
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
