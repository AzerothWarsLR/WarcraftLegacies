using System;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatTeam
  {
    private const string Command = "-team ";
    private static string? _parameter;
    
    private static void Actions()
    {
      try
      {
        if (!TestSafety.CheatCondition()) return;

        var enteredString = GetEventPlayerChatString();
        var p = GetTriggerPlayer();
        _parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

        if (!FactionManager.TeamWithNameExists(_parameter))
        {
          throw new Exception($"There is no registered {nameof(Team)} with the name {_parameter}.");
        }
      
        var t = FactionManager.GetTeamByName(_parameter);
        p.SetTeam(t);
        DisplayTextToPlayer(p, 0, 0, $"|cffD27575CHEAT:|r Attempted to set team to {t.Name}.");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);

      TriggerAddAction(trig, Actions);
    }
  }
}