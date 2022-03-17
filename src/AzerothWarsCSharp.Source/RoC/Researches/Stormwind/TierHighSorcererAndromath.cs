public class TierHighSorcererAndromath{

  
    private const int DEMI_UNITTYPE_ID = FourCC(h05X);
  

  private static void Research( ){
    CreateUnit(FACTION_STORMWIND.Player, DEMI_UNITTYPE_ID, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), 0);
  }

  public static void OnInit( ){
    RegisterResearchFinishedAction(FourCC(R03X),  Research);
    FACTION_STORMWIND.ModObjectLimit(DEMI_UNITTYPE_ID, 1);
  }

}
