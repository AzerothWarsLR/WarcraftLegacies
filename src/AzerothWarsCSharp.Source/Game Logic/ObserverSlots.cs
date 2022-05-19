using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Game_Logic
{
  public static class ObserverSlots
  {
    private static readonly force Observers = CreateForce();
    
    public static void MakeObserver(player p)
    {
      ForceAddPlayer(Observers, p);
      CreateFogModifierRectBJ(true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect());
      SetPlayerState(p, PLAYER_STATE_OBSERVER, 1);
    }
  }
}