using AzerothWarsCSharp.MacroTools.FactionSystem;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// Joins the specified <see cref="Team"/>. Only works if an invite has first been extended.
  /// </summary>
  public static class JoinCommand
  {
    private const string COMMAND = "-join ";
    
    private static void Actions()
    {
      string enteredString = GetEventPlayerChatString();
      Person triggerPerson = Person.ByHandle(GetTriggerPlayer());

      if (SubString(enteredString, 0, StringLength(COMMAND)) == COMMAND)
      {
        string content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
        content = StringCase(content, false);
        
        if (Team.TeamWithNameExists(content))
        {
          Team targetTeam = Team.GetTeamByName(content);
          if (targetTeam.IsFactionInvited(triggerPerson.Faction))
          {
            triggerPerson.Faction.Team = targetTeam;
            DisplayTextToPlayer(triggerPerson.Player, 0, 0, $"You have joined {targetTeam.Name}.");
            targetTeam.DisplayText($"{triggerPerson.Faction.ColoredName} has joined the {targetTeam.Name}.");
          }
          else
          {
            DisplayTextToPlayer(triggerPerson.Player, 0, 0, "You have !been invited to join " + targetTeam.Name + ".");
          }
        }
        else
        {
          DisplayTextToPlayer(triggerPerson.Player, 0, 0, "There is no Team with the name " + content + ".");
        }
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent( trig, player, COMMAND, false);
      }
      TriggerAddAction(trig,  Actions);
    }
  }
}