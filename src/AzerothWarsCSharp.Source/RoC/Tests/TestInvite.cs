public class TestInvite{


    void Run( ){
      TEAM_HORDE.Invite(FACTION_SCOURGE);
      this.Assert(TEAM_HORDE.IsFactionInvited(FACTION_SCOURGE), "Expected Scourge to be an invitee of team Horde");
    }

    private static void onInit( ){
      thistype.create("invite");
    }


}
