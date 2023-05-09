using System.Collections.Generic;
using System.Linq;
using DesyncSafeAnalyzer.Attributes;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.HintSystem
{
  public sealed class Hint
  {
    private const float HintInterval = 180;
    
    private static readonly List<Hint> Unread = new();
    private readonly string _msg;
    private static bool _initialized;

    /// <summary>
    /// Initializes a new instance of the <see cref="Hint"/> class.
    /// </summary>
    /// <param name="msg">The message to display to all players when the hint is triggered.</param>
    public Hint(string msg)
    {
      _msg = msg;
    }

    public static void Register(Hint hint)
    {
      if (!_initialized) 
        Initialize();
      Unread.Add(hint);
    }
    
    private void Display(player whichPlayer) => whichPlayer.DisplayHint(_msg);

    private static void DisplayRandomHints()
    {
      if (Unread.Count == 0)
        return;
      
      var hint = Unread.ElementAt(GetRandomInt(0, Unread.Count - 1));
      Unread.Remove(hint);
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        hint.Display(player);
    }

    private static void Initialize()
    {
      _initialized = true;
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, HintInterval, true);
      TriggerAddAction(trig, DisplayRandomHints);
    }
  }
}