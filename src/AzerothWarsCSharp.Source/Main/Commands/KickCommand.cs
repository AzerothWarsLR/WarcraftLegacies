using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Commands
{
  public class BootCommand{

  
    private const string COMMAND     = "-boot ";
    private string parameter = null;
  

    private static void Actions( ){
      string enteredString = GetEventPlayerChatString();
      string content = null;
      Faction targetFaction = 0;
      Person senderPerson = Person.ByHandle(GetTriggerPlayer());

      if (SubString( enteredString, 0, StringLength(COMMAND) ) == COMMAND){
        content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
        content = StringCase(content, false);
        targetFaction = Faction.factionsByName[content];

        if (senderPerson.Faction != FACTION_NAGA){
          DisplayTextToPlayer(senderPerson.Player, 0, 0, "This command can only be used by liege factions.");
          return;
        }

        if (AreAllianceActive == true){
          DisplayTextToPlayer(senderPerson.Player, 0, 0, "Alliances are open");
          return;
        }

        if (targetFaction == 0){
          DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no Faction with the name " + content + ".");
          return;
        }

        if (senderPerson.Faction == targetFaction){
          DisplayTextToPlayer(senderPerson.Player, 0, 0, "You can!boot yourself from the game.");
          return;
        }

        if (targetFaction.Person == 0){
          DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no player with the Faction " + targetFaction.ColoredName + ".");
          return;
        }

        if (FACTION_FEL_HORDE.Team != TEAM_NAGA){
          DisplayTextToPlayer(senderPerson.Player, 0, 0, " " + targetFaction.ColoredName + " is !your vassal.");
          return;
        }

        if (targetFaction.Person != 0){
          targetFaction.obliterate();
          targetFaction.Person.Faction = 0;
        }

      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      int i = 0;
      while(true){
        if ( i > MAX_PLAYERS){ break; }
        TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false );
        i = i + 1;
      }
      TriggerAddAction( trig,  Actions );
    }

  }
}
