//Scourge always has vision over Northrend.

public class NorthrendVision{

  
    private fogmodifier[] ScourgeFogModifiers;
  

  private static void Enable( ){
    player whichPlayer = FACTION_SCOURGE.Player;
    int i = 0;
    ScourgeFogModifiers[0] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Storm_Peaks, true, true);
    ScourgeFogModifiers[1] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Central_Northrend, true, true);
    ScourgeFogModifiers[2] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_The_Basin, true, true);
    ScourgeFogModifiers[3] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Ice_Crown, true, true);
    ScourgeFogModifiers[4] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Fjord, true, true);
    ScourgeFogModifiers[5] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Eastern_Northrend, true, true);
    ScourgeFogModifiers[6] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Far_Eastern_Northrend, true, true);
    ScourgeFogModifiers[7] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Coldarra, true, true);
    ScourgeFogModifiers[8] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Borean_Tundra, true, true);
    ScourgeFogModifiers[9] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_IcecrownShipyard, true, true);
    while(true){
    if ( ScourgeFogModifiers[i] == null){ break; }
      FogModifierStart(ScourgeFogModifiers[i]);
      i = i + 1;
    }
  }

  private static void Disable( ){
    int i = 0;
    while(true){
      if ( ScourgeFogModifiers[i] == null){ break; }
      DestroyFogModifier(ScourgeFogModifiers[i]);
      ScourgeFogModifiers[i] = null;
      i = i + 1;
    }
  }

  private static void PersonChangesFaction( ){
    player triggerPlayer;
    int i = 0;
    if (GetTriggerPerson().Faction == FACTION_SCOURGE){
      Enable();
    }else if (GetChangingPersonPrevFaction() == FACTION_SCOURGE){
      Disable();
    }
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    OnPersonFactionChange.register(trig);
    TriggerAddCondition(trig, ( PersonChangesFaction));

    if (FACTION_SCOURGE.Person != 0){
      Enable();
    }
  }

}
