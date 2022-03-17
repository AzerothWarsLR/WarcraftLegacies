public class TestSafety{

  
    boolean AreCheatsActive
  

  static boolean CheatCondition( ){
    string triggerPlayerName = GetPlayerName(GetTriggerPlayer());
    if (triggerPlayerName == "YakaryBovine#6863" || triggerPlayerName == "Lordsebas#11619"){
      return true;
    }
    return AreCheatsActive;
  }

  private static void Warning( ){
    DisplayTextToForce(GetPlayersAll(), "This map is in test mode && contains |cffD27575CHEATS|r.");
    DisplayTextToForce(GetPlayersAll(), "To use these |cffD27575CHEATS|r, refer to the Quest menu.");
  }

  private static void Quests( ){
    CreateQuestBJ( bj_QUESTTYPE_REQ_DISCOVERED, "Test Commands", " - gold x|n - lumber x|n - food x|n - tele on/off (use patrol to teleport anywhere on the map instantly)|n - build on/off (press cancel on a building to finish its progress instantly)|n - nocd on/off (instant refresh cds)|n - mana on/off (instant refund all mana)|n - unlock (unlocks all Path requirements)|n - god on/off (deal 100x damage, take no damage)|n - vision on/off (reveal entire map)|n - time xx (time of day)|n - control xx (take shared control of player xx)|n - uncontrol xx (revoke control of player xx)|n - level xx (level of selected units)|n - hp xx (health of selected units)|n - mp xx|n - remove (remove selected units)|n - faction <text> (change faction to entered string)|n - team <text> (change team to entered string)|n - owner xx (transfer selected units to player xx)|n - spawn yyyy xx (spawns xx instances of unit || item yyyy, uses rawcodes)|n - kick xx (causes player xx to psuedo-leave, && lose faction && team)|n", "ReplaceableTextures\\CommandButtons\\BTNStaffOfTeleportation.blp" );
  }

  private static void OnInit( ){
    trigger trig = null;
    int i = 0;
    int userCount = 0;

    AreCheatsActive = true;
    i = 0;
    while(true){
    if ( i == MAX_PLAYERS || AreCheatsActive == false){ break; }
      if (GetPlayerSlotState(Player(i)) == PLAYER_SLOT_STATE_PLAYING && GetPlayerController(Player(i)) == MAP_CONTROL_USER){
        userCount = userCount + 1;
        if (userCount > 1){
          AreCheatsActive = false;
        }
      }
      i = i + 1;
    }

    if (AreCheatsActive == true){
      Quests();
      trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 200, true);
      TriggerAddCondition(trig, ( Warning));
    }
  }
}
