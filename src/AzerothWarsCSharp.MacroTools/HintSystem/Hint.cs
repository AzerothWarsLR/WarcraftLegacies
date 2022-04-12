using System.Collections.Generic;
using System.Linq;
using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.HintSystem
{
  public sealed class Hint
  {
    private const float HINT_INTERVAL = 180;

    private static readonly HashSet<Hint> All = new();
    private static readonly HashSet<Hint> Unread = new();
    private readonly string _msg;

    public Hint(string msg)
    {
      _msg = msg;
    }

    public static void Register(Hint hint)
    {
      All.Add(hint);
      Unread.Add(hint);
    }

    private void Display()
    {
      Libraries.Display.DisplayHint(GetLocalPlayer(), _msg);
      Unread.Remove(this);
    }

    private static void DisplayRandom()
    {
      if (Unread.Count > 0)
      {
        Unread.ElementAt(GetRandomInt(0, Unread.Count - 1)).Display();
      }
    }

    private static void DisplayRandomHints()
    {
      foreach (var player in GetAllPlayers())
      {
        if (GetLocalPlayer() == player)
        {
          DisplayRandom();
        }
      }
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEventPeriodic(trig, HINT_INTERVAL);
      TriggerAddAction(trig, DisplayRandomHints);
    }
  }
}