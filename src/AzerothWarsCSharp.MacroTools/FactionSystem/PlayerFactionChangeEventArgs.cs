using System;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public class PlayerFactionChangeEventArgs : EventArgs
  {
    public player Player { get; }
    public Faction PreviousFaction { get; }
    
    public PlayerFactionChangeEventArgs(player player, Faction previousFaction)
    {
      Player = player;
      PreviousFaction = previousFaction;
    }
  }
}