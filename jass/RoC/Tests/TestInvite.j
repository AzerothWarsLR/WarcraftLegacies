library TestInvite requires Test, Persons, TeamSetup, ScourgeSetup

  struct TestInvite extends Test
    method Run takes nothing returns nothing
      call TEAM_HORDE.Invite(FACTION_SCOURGE)
      call this.Assert(TEAM_HORDE.IsFactionInvited(FACTION_SCOURGE), "Expected Scourge to be an invitee of team Horde")
    endmethod

    private static method onInit takes nothing returns nothing 
      call thistype.create("invite")
    endmethod
  endstruct

endlibrary