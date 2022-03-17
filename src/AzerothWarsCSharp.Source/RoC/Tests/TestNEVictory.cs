public class TestNightElfVictory{


    void Run( ){
      FACTION_SCOURGE.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_LEGION.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_LORDAERON.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_DALARAN.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_QUELTHALAS.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_FROSTWOLF.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_WARSONG.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_STORMWIND.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_IRONFORGE.ScoreStatus = SCORESTATUS_DEFEATED;
      FACTION_FEL_HORDE.ScoreStatus = SCORESTATUS_DEFEATED;
    }

    private static void onInit( ){
      thistype.create("nightelfvictory");
    }


}
