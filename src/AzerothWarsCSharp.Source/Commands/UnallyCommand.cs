//A command that causes a player to leave their Team and be given a solo Team with their Faction as the name.

using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Commands
{
	public class Unally{

	
		private const string COMMAND = "-unally";
  

		private static void Actions( ){
			Person triggerPerson = Person.ByHandle(GetTriggerPlayer());
			triggerPerson.Faction.Unally();

			// if AreAllianceActive == true then
			//   call triggerPerson.Faction.Unally()
			// else
			//   call DisplayTextToPlayer(triggerPerson.Player, 0, 0, "You cannot unally yet")
			// endif
		}

		public static void Setup( ){
			trigger trig = CreateTrigger(  );
			var i = 0;

			while(true){
				if ( i > MAX_PLAYERS){ break; }
				TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, true );
				i = i + 1;
			}

			TriggerAddAction(trig,  Actions);
		}

	}
}
