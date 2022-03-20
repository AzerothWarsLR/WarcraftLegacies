namespace AzerothWarsCSharp.Source.Spells
{
  public class SeismicShard{

  
    private const int ABIL_ID = FourCC(A0OD);
    private const int DUMMY_ABIL_ID = FourCC(A0OE);
    private const string DUMMY_ORDER_STRING = "thunderbolt";
    private const float RADIUS = 250;
  

    private static bool SeismicFilter(unit caster, unit target ){
      if (!IsUnitAlly(target, GetOwningPlayer(caster)) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(target)){
        return true;
      }
      return false;
    }

    private static void Cast( ){
      DummyCastFromPointOnUnitsInCircle(GetTriggerUnit(), DUMMY_ABIL_ID, DUMMY_ORDER_STRING, GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), GetSpellTargetX(), GetSpellTargetY(), RADIUS, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), CastFilter.SeismicFilter);
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
