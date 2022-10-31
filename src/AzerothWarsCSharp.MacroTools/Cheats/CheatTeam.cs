using System;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatTeam
  {
    private const string COMMAND = "-team ";
    private static string? _parameter;
    
    private static void Actions()
    {
      try
      {
        if (!TestSafety.CheatCondition()) return;

        var enteredString = GetEventPlayerChatString();
        var p = GetTriggerPlayer();
        _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

        if (!FactionManager.TeamWithNameExists(_parameter))
        {
          throw new Exception($"There is no registered {nameof(Team)} with the name {_parameter}.");
        }
      
        var t = FactionManager.GetTeamByName(_parameter);
        var faction = PlayerData.ByHandle(p).Faction;
        faction?.Player?.SetTeam(t);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to team to " + t.Name + ".");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}