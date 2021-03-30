using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class Command
  {
    public delegate void OnCommandDelegate(player triggerPlayer, string[] arguments);

    public static void Register(string activator, OnCommandDelegate onCommand)
    {
      var trig = CreateTrigger();
      for (var i = 0; i < 12; i++)
      {
        TriggerRegisterPlayerChatEvent(trig, Player(i), "- " + activator, false);
      }
      TriggerAddAction(trig, OnAnyCommand);
      _commandsByActivator[activator] = onCommand;
    }

    private static void OnAnyCommand()
    {
      string chatString = GetEventPlayerChatString();
      string activator = chatString.Split(' ')[0];
      string[] arguments = chatString.Split(' ').Skip(1).ToArray();
      _commandsByActivator[activator]?.Invoke(GetTriggerPlayer(), arguments);
    }

    private static Dictionary<string, OnCommandDelegate> _commandsByActivator = new();
  }
}
