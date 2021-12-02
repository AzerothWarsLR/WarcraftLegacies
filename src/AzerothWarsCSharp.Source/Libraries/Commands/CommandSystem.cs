using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries.Commands
{
  public static class CommandSystem
  {
    private static readonly Dictionary<string, Command> CommandsByActivator = new();

    public static void Register(Command command)
    {
      var trig = CreateTrigger();
      var activator = command.Activator;
      for (var i = 0; i < 12; i++) TriggerRegisterPlayerChatEvent(trig, Player(i), "-" + activator, false);
      TriggerAddAction(trig, OnAnyCheat);
      CommandsByActivator[activator] = command;
    }
    
    public static void Display(player whichPlayer, string msg)
    {
      DisplayTextToPlayer(whichPlayer, 0, 0, msg);
    }

    private static string[] GetChatStringCommandParameters(string chatString)
    {
      return chatString.Split(' ').Skip(1).ToArray();
    }

    private static string GetChatStringCommandActivator(string chatString)
    {
      var activatorPortion = chatString.Split(' ')[0];
      return activatorPortion.Substring(1, activatorPortion.Length - 1);
    }

    private static void OnAnyCheat()
    {
      var chatString = GetEventPlayerChatString();
      var activator = GetChatStringCommandActivator(chatString);
      var arguments = GetChatStringCommandParameters(chatString);
      CommandsByActivator[activator].OnCommand?.Invoke(GetTriggerPlayer(), arguments);
    }
  }
}