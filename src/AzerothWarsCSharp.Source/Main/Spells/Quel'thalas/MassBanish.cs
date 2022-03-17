namespace AzerothWarsCSharp.Source.Main.Spells.Quel_thalas
{
  public class MassBanish{

  
    private const int ABIL_ID = FourCC(A0FD);
    private const int DUMMY_ABIL_ID = FourCC(A0FE);
    private const string DUMMY_ORDER_STRING = "banish";
    private const float RADIUS = 250;
  

    private static boolean BanishFilter(unit caster, unit target ){
      if (!IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(target)){
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
