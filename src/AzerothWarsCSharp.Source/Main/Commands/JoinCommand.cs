//Joins the specified Team. Only works if an Invite has first been extended.

using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Commands
{
  public class JoinCommand{

	
    private const string COMMAND = "-join ";
  

    private static void Actions( ){
      string enteredString = GetEventPlayerChatString();
      string content = null;
      Team targetTeam = 0;
      Person triggerPerson = Person.ByHandle(GetTriggerPlayer());

      if (triggerPerson.Faction.CanBeInvited == false){
        DisplayTextToPlayer(triggerPerson.Player, 0, 0, "You canFourCC(t voluntarily change teams.");
      }

      if (SubString( enteredString, 0, StringLength(COMMAND) ) == COMMAND){
        content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
        content = StringCase(content, false);
        targetTeam = Team.teamsByName[content];
        if (targetTeam != 0){
          if (targetTeam.IsFactionInvited(triggerPerson.Faction)){
            triggerPerson.Faction.Team = targetTeam;
            DisplayTextToPlayer(triggerPerson.Player, 0, 0, "You have joined " + targetTeam.Name + ".");
            targetTeam.DisplayText(triggerPerson.Faction.prefixCol + triggerPerson.Faction.Name + "|r has joined the " + targetTeam.Name + ".");
          }else {
            DisplayTextToPlayer(triggerPerson.Player, 0, 0, "You have !been invited to join " + targetTeam.Name + ".");
          }
        }else {
          DisplayTextToPlayer(triggerPerson.Player, 0, 0, "There is no Team with the name " + targetTeam.Name + ".");
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

      TriggerAddAction(trig,  Actions);
    }

  }
}
