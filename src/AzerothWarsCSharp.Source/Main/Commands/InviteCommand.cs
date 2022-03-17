//Invites the specified faction)s player to the sender)s Team.

using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Commands
{
  public class InviteCommand{

	
    private const string COMMAND = "-invite ";
  

    private static void Actions( ){
      string enteredString = GetEventPlayerChatString();
      string content = null;
      Faction targetFaction = 0;
      Person senderPerson = Person.ByHandle(GetTriggerPlayer());

      if (AreAllianceActive == true){
        if (SubString( enteredString, 0, StringLength(COMMAND) ) == COMMAND){
          content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
          content = StringCase(content, false);
          targetFaction = Faction.factionsByName[content];

          if (targetFaction == 0){
            DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no Faction with the name " + content + ".");
            return;
          }

          if (targetFaction.CanBeInvited == false){
            DisplayTextToPlayer(senderPerson.Player, 0, 0, targetFaction.prefixCol + targetFaction.Name + " canFourCC(t voluntarily change teams.");
          }

          if (senderPerson.Faction == targetFaction){
            DisplayTextToPlayer(senderPerson.Player, 0, 0, "You can!invite yourself to your own team.");
            return;
          }

          if (targetFaction.Person == 0){
            DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no player with the Faction " + targetFaction.prefixCol + targetFaction.Name + "|r.");
            return;
          }

          if (targetFaction.Person != 0){
            senderPerson.Faction.Team.Invite(targetFaction);
          }

        }
      }else {
        DisplayTextToPlayer(senderPerson.Player, 0, 0, "You can!ally yet");
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

      TriggerAddAction(trig,  Actions);
    }

  }
}
