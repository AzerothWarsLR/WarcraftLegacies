using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class ObserverSlots
  {
    public static void MakeObserver(player p)
    {
      ForceAddPlayer(Person.Observers, p);
      CreateFogModifierRectBJ(true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect());
      SetPlayerState(p, PLAYER_STATE_OBSERVER, 1);
    }
  }
}