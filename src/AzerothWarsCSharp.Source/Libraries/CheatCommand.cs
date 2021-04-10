using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class CheatCommand
  {
    public delegate void OnCheatDelegate(player triggerPlayer, string[] arguments);

    public static bool Active { get; set; } = true;

    public static void Register(string activator, OnCheatDelegate onCommand)
    {
      try
      {
        var trig = CreateTrigger();
        for (var i = 0; i < 12; i++)
        {
          TriggerRegisterPlayerChatEvent(trig, Player(i), "-" + activator, false);
        }
        TriggerAddAction(trig, OnAnyCheat);
        _cheatsByActivator[activator] = onCommand;
      }
      catch (Exception ex)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.ToString());
      }
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

    public static string[] GetChatStringCommandParameters(string chatString)
    {
      return chatString.Split(' ').Skip(1).ToArray();
    }

    public static string GetChatStringCommandActivator(string chatString)
    {
      var activatorPortion = chatString.Split(' ')[0];
      return activatorPortion.Substring(1, activatorPortion.Length-1);
    }

    private static void OnAnyCheat()
    {
      try
      {
        if (CanPlayerUseCheats(GetTriggerPlayer()))
        {
          string chatString = GetEventPlayerChatString();
          string activator = GetChatStringCommandActivator(chatString);
          string[] arguments = GetChatStringCommandParameters(chatString);
          _cheatsByActivator[activator]?.Invoke(GetTriggerPlayer(), arguments);
        }
      }
      catch (Exception ex)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.ToString());
      }
    }

    private static readonly Dictionary<string, OnCheatDelegate> _cheatsByActivator = new();
  }
}
