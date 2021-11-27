library TestNightElfVictory requires Test, FactionSetup

  struct TestNightElfVictory extends Test
    method Run takes nothing returns nothing
      set FACTION_SCOURGE.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_LEGION.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_LORDAERON.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_DALARAN.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_QUELTHALAS.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_FROSTWOLF.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_WARSONG.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_STORMWIND.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_IRONFORGE.ScoreStatus = SCORESTATUS_DEFEATED
      set FACTION_FEL_HORDE.ScoreStatus = SCORESTATUS_DEFEATED
    endmethod

    private static method onInit takes nothing returns nothing 
      call thistype.create("nightelfvictory")
    endmethod
  endstruct

endlibrary