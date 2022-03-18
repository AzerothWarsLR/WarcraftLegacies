namespace AzerothWarsCSharp.Source.Main.Spells.Fel_Horde
{
  public class ThunderFists{

  
    private const int UNITTYPE_ID = FourCC(O01P);
    private const int ABIL_ID = FourCC(A0LN);
    private const int DUMMY_ABIL_ID = FourCC(A024);
    private const string DUMMY_ORDER_ID = "forkedlightning";

    private const float CHANCE = 015;
  

    private static void Damaging( ){
      var level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID);
      if (level > 0 && BlzGetEventIsAttack() && GetRandomReal(0,1) <= CHANCE){
        DummyCastUnitFromPoint(GetOwningPlayer(GetEventDamageSource()), DUMMY_ABIL_ID, DUMMY_ORDER_ID, level, GetTriggerUnit(), GetUnitX(GetEventDamageSource()), GetUnitY(GetEventDamageSource()));
      }
    }

    public static void Setup( ){
      RegisterUnitTypeInflictsDamageAction(UNITTYPE_ID,  Damaging);
    }

  }
}
