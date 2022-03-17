namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class MassIceArmor{

  
    private const int ABIL_ID = FourCC(A0H3);
    private const int DUMMY_ABIL_ID = FourCC(A0H6);
    private const string DUMMY_ORDER_STRING = "frostarmor";
    private const float RADIUS = 400;
  

    private static boolean BanishFilter(unit caster, unit target ){
      if (IsUnitAlly(target, GetOwningPlayer(caster)) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(target)){
        return true;
      }
      return false;
    }

    private static void Cast( ){
      DummyCastOnUnitsInCircle(GetTriggerUnit(), DUMMY_ABIL_ID, DUMMY_ORDER_STRING, GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), GetSpellTargetX(), GetSpellTargetY(), RADIUS, CastFilter.BanishFilter);
    }

    private static void OnInit( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
