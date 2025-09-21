using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Makes a number of player slots into observers.
/// </summary>
public static class ObserverSetup
{
  /// <summary>
  /// Sets up <see cref="ObserverSetup"/>.
  /// </summary>
  public static void Setup(IEnumerable<player> observers)
  {
    foreach (var observer in observers)
    {
      Rectangle.WorldBounds.Rect.AddFogModifier(observer, fogstate.Visible, false, false).Start();
      observer.Remove(playergameresult.Defeat);
      observer.SetState(playerstate.Observer, 1);
    }
  }
}
