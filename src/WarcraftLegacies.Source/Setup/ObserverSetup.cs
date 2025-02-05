using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup
{
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
        FogModifierStart(CreateFogModifierRect(observer, FOG_OF_WAR_VISIBLE,
          Rectangle.WorldBounds.Rect, false, false));
        RemovePlayer(observer, PLAYER_GAME_RESULT_DEFEAT);
        SetPlayerState(observer, PLAYER_STATE_OBSERVER, 1);
      }
    }
  }
}