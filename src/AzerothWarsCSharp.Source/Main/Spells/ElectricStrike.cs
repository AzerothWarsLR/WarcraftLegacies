namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class ElectricStrike{

  
    private const int ABIL_ID        = FourCC(A0RC);
    private const int STUN_ID        = FourCC(A0RD)        ;//The ability that gets cast on each unit in the radius
    private const int PURGE_ID       = FourCC(Aprg)        ;//The ability that gets cast on each unit in the radius
    private const string  PURGE_ORDER    = "purge";
    private const string  STUN_ORDER     = "firebolt";
    private const float    RADIUS         = 50000;
    private const string  EFFECT         = "Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl";

    private group TempGroup = CreateGroup();
  

    private static void Cast( ){
      unit u;
      unit caster;
      caster = GetTriggerUnit();
      P = GetOwningPlayer(caster);
      GroupEnumUnitsInRange(TempGroup, GetSpellTargetX(), GetSpellTargetY(), RADIUS, null);
      while(true){
        u = FirstOfGroup(TempGroup);
        if ( u == null){ break; }
        if (IsUnitType(u, UNIT_TYPE_STRUCTURE) == false && UnitAlive(u) == true){
          DummyCastUnit(GetOwningPlayer(caster), STUN_ID, STUN_ORDER, 1, u);
          DummyCastUnit(GetOwningPlayer(caster), PURGE_ID, PURGE_ORDER, 1, u);
        }
        GroupRemoveUnit(TempGroup,u);
      }
    }

    private static void OnInit( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
