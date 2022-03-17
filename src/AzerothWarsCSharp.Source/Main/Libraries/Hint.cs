using System.Collections.Generic;
using System.Linq;

namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Hint
  {
    private const float HINT_INTERVAL = 180;

    private static readonly HashSet<Hint> All = new();
    private static readonly HashSet<Hint> Unread = new();
    private readonly string _msg;

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

    private Hint(string msg)
    {
      _msg = msg;
      All.Add(this);
      Unread.Add(this);
    }

    private static void DisplayRandomHints()
    {
      var i = 0;
      while (true)
      {
        if (i == Environment.MAX_PLAYERS)
        {
          break;
        }

        if (GetLocalPlayer() == Player(i))
        {
          DisplayRandom();
        }

        i += 1;
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