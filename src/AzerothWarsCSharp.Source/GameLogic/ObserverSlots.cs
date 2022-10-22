using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.GameLogic
{
  public static class ObserverSlots
  {
    private static readonly force Observers = CreateForce();

    public static void MakeObserver(player p)
    {
      ForceAddPlayer(Observers, p);
      var newFogModifier =
        CreateFogModifierRect(p, FOG_OF_WAR_VISIBLE, GeneralHelpers.GetPlayableMapArea().Rect, true, false);
      FogModifierStart(newFogModifier);
      SetPlayerState(p, PLAYER_STATE_OBSERVER, 1);
    }
  }
}