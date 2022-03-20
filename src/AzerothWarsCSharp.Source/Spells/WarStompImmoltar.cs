namespace AzerothWarsCSharp.Source.Spells
{
  public class WarStompImmoltar{

  
    private const int ABIL_ID        = FourCC(A0LU);
    private const int STUN_ID        = FourCC(A0WN)        ;//The Storm Bolt dummy spell that applies the stun itself
    private const string  STUN_ORDER     = "thunderbolt";
    private const float    DAMAGE         = 9000;
    private const float    RADIUS         = 20000;
    private const int DURATION       = 3;
    private const string  EFFECT         = "Abilities\\Spells\\Orc\\Warstomp\\WarStompCaster.mdl";
    private group     TempGroup = CreateGroup();
  

    private static void Cast( ){
      unit u;
      unit caster;
      caster = GetTriggerUnit();
      P = GetOwningPlayer(caster);
      GroupEnumUnitsInRange(TempGroup,GetUnitX(caster),GetUnitY(caster),RADIUS,( EnemyAliveFilter));
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        UnitDamageTarget(caster, u, DAMAGE, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
        DummyCastUnit(GetOwningPlayer(caster), STUN_ID, STUN_ORDER, DURATION, u);
        GroupRemoveUnit(TempGroup,u);
      }
      DestroyEffect(AddSpecialEffect(EFFECT,GetUnitX(caster),GetUnitY(caster)));
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
