namespace AzerothWarsCSharp.Source.Spells
{
  public class ElunesGaze{

  
    private const int ABIL_ID = FourCC(A0VX);
    private const int INVIS_ID = FourCC(A0VY);
    private const float RADIUS = 3500;
  

    private static bool ElunesGazeFilter(unit caster, unit target ){
      if (IsUnitAlly(target, GetOwningPlayer(caster)) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) && UnitAlive(target)){
        return true;
      }
      return false;
    }

    private static void Cast( ){
      DummyCastOnUnitsInCircle(GetTriggerUnit(), INVIS_ID, "invisibility", 1, GetSpellTargetX(), GetSpellTargetY(), RADIUS, CastFilter.ElunesGazeFilter);
    }

    public static void Setup( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
