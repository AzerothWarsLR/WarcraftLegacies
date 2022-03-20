namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class MassEnrage{

  
    private const int ABIL_ID = FourCC(A0QK);
    private const int DUMMY_ABIL_ID = FourCC(ACuf);
    private const string DUMMY_ORDER_STRING = "unholyfrenzy";
    private const float RADIUS = 50;
  

    private static bool EnrageFilter(unit caster, unit target ){
      if (IsUnitAlly(target, GetOwningPlayer(caster)) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(target)){
        return true;
      }
      return false;
    }

    private static void Cast( ){
      unit caster = null;
      int level;
      caster = GetTriggerUnit();
      level = GetUnitAbilityLevel(caster, ABIL_ID);
      DummyCastOnUnitsInCircle(GetTriggerUnit(), DUMMY_ABIL_ID, DUMMY_ORDER_STRING, GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), GetSpellTargetX(), GetSpellTargetY(), (RADIUS*level)+100, CastFilter.EnrageFilter);
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
