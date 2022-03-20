//Revokes an invitation sent to a player from the sending player)s Team.

using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Commands
{
	public class UninviteCommand{

	
		private const string COMMAND = "-uninvite ";
  

		private static void Actions( ){
			string enteredString = GetEventPlayerChatString();
			string content = null;
			Faction targetFaction = 0;
			Person senderPerson = Person.ByHandle(GetTriggerPlayer());

			if (SubString( enteredString, 0, StringLength(COMMAND) ) == COMMAND){
				content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
				content = StringCase(content, false);
				targetFaction = Faction.factionsByName[content];
				if (targetFaction != 0){
					if (targetFaction.Person != 0){
						senderPerson.Faction.Team.Uninvite(targetFaction);
					}else {
						DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no player with the Faction " + targetFaction.prefixCol + targetFaction.Name + "|r.");
					}
				}else {
					DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no Faction with the name " + content + ".");
				}
			}
		}

		public static void Setup( ){
			trigger trig = CreateTrigger(  );
			var i = 0;

			while(true){
				if ( i > MAX_PLAYERS){ break; }
				TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false );
				i = i + 1;
			}

			TriggerAddAction(trig,  Actions);
		}

	}
}
