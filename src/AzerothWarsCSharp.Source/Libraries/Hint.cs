using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  class Hint
  {
    private const float HINT_INTERVAL = 180;

    public Hint(string text)
    {
      _text = text;
    }

    public void Display()
    {
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "\n|cff00ff00HINT|r - " + _text);
      StartSound(_sound);
    }

    public static void Register(Hint hint)
    {
      _registered.Add(hint);
    }

    public static void Initialize()
    {
      PeriodicEvents.AddPeriodicEvent(DisplayRandomHint, HINT_INTERVAL);
      _sound = CreateSound(@"Sound/Interface/Hint.wav", false, false, false, 0, 0, "DefaultEAXON");
    }

    private static bool DisplayRandomHint() {
      if (_registered.Count > 0)
      {
        var randomHint = _registered[GetRandomInt(0, _registered.Count)];
        randomHint.Display();
        _registered.Remove(randomHint);
      }
      return true;
    }

    private static readonly List<Hint> _registered = new();
    private static sound _sound;

    private readonly string _text;
  }
}