namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class ObserverSlots{

    static void MakeObserver(player p ){
      ForceAddPlayer(Observers, p);
      CreateFogModifierRectBJ( true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() );
      SetPlayerState(p, PLAYER_STATE_OBSERVER, 1);
    }

  }
}
