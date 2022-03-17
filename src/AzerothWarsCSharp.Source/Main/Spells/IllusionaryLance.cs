namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class IllusionaryLance{

  
    private const int UNITTYPE_ID = FourCC(U02A);
    private const int ABIL_ID = FourCC(A0SF);
    private const int DUMMY_ABIL_ID = FourCC(A0SI);
    private const int DUMMY_ORDER_ID = 852274;

    private const float ILLUSIONCHANCE_HERO = 01;
    private const float ILLUSIONCHANCE_ILLUSION = 001;
  

    private static void Damaging( ){
      int level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID);
      float chance;
      if (level > 0 && BlzGetEventIsAttack()){
        if (IsUnitIllusion(GetEventDamageSource())){
          chance = level * ILLUSIONCHANCE_ILLUSION;
        }else {
          chance = level * ILLUSIONCHANCE_HERO;
        }
        if (GetRandomReal(0,1) <= chance){
          DummyCastUnitId(GetOwningPlayer(GetEventDamageSource()), DUMMY_ABIL_ID, DUMMY_ORDER_ID, 1, GetEventDamageSource());
        }
      }
    }

    private static void OnInit( ){
      RegisterUnitTypeInflictsDamageAction(UNITTYPE_ID,  Damaging);
    }

  }
}
