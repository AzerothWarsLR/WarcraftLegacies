 library AllyinfoCommand initializer OnInit requires Income

  
    private const string COMMAND = "-ally";
    private const string INFO_COLOR = "|c00add8e6";
  

  private static void Actions( ){
    Person whichPerson = Person.ByHandle(GetTriggerPlayer());

    DisplayTextToPlayer(whichPerson.Player, 0, 0, "The ally command have changed, they are now:;
-invite (faction name)
-join (team name)
-uninvite (faction name)
-unally")

  }

  private static void OnInit( ){
    trigger trig = CreateTrigger(  );
    int i = 0;

    while(true){
    if ( i > MAX_PLAYERS){ break; }
      TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false );
      i = i + 1;
    }

    TriggerAddCondition( trig, ( Actions) );
  }

}
