using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class CheatCommand
  {
    public delegate void OnCheatDelegate(player triggerPlayer, string[] arguments);

    public static bool Active { get; set; }

    public static void Register(string activator, OnCheatDelegate onCommand)
    {
      var trig = CreateTrigger();
      for (var i = 0; i < 12; i++)
      {
        TriggerRegisterPlayerChatEvent(trig, Player(i), "- " + activator, false);
      }
      TriggerAddAction(trig, OnAnyCheat);
      _cheatsByActivator[activator] = onCommand;
    }

    public static void Display(player whichPlayer, string msg)
    {
      DisplayTextToPlayer(whichPlayer, 0, 0, msg);
    }

    public static bool CanPlayerUseCheats(player whichPlayer)
    {
      if (GetPlayerName(whichPlayer) == "YakaryBovine#6863" || GetPlayerName(whichPlayer) == "Lordsebas#11619" || Active)
      {
        return true;
      }
      return false;
    }

    private static void OnAnyCheat()
    {
      if (CanPlayerUseCheats(GetTriggerPlayer())){
        string chatString = GetEventPlayerChatString();
        string activator = chatString.Split(' ')[0];
        string[] arguments = chatString.Split(' ').Skip(1).ToArray();
        _cheatsByActivator[activator]?.Invoke(GetTriggerPlayer(), arguments);
      }
    }

    private static readonly Dictionary<string, OnCheatDelegate> _cheatsByActivator = new();
  }
}
