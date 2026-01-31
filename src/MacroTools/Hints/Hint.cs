using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;

namespace MacroTools.Hints;

public sealed class Hint
{
  private const float HintInterval = 180;

  private static readonly List<Hint> _unread = new();
  private readonly string _msg;
  private static bool _initialized;

  public Hint(string msg)
  {
    _msg = msg;
  }

  public static void Register(Hint hint)
  {
    if (!_initialized)
    {
      Initialize();
    }
    _unread.Add(hint);
  }

  /// <summary>
  /// Registers a new <see cref="Hint"/> with the specified message.
  /// </summary>
  public static void Register(string message)
  {
    if (!_initialized)
    {
      Initialize();
    }
    _unread.Add(new Hint(message));
  }

  private void Display()
  {
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      player.DisplayHint(_msg);
    }

    _unread.Remove(this);
  }

  private static void DisplayRandom()
  {
    if (_unread.Count > 0)
    {
      _unread.ElementAt(GetRandomInt(0, _unread.Count - 1)).Display();
    }
  }

  private static void DisplayRandomHints()
  {
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      if (player.LocalPlayer == player)
      {
        DisplayRandom();
      }
    }
  }

  private static void Initialize()
  {
    _initialized = true;
    var trig = trigger.Create();
    trig.RegisterTimerEvent(HintInterval, true);
    trig.AddAction(DisplayRandomHints);
  }
}
