using System;

namespace MacroTools.FactionSystem
{
  public sealed class PlayerFactionChangeEventArgs : EventArgs
  {
    public player Player { get; }
    public Faction? PreviousFaction { get; }
    
    public PlayerFactionChangeEventArgs(player player, Faction? previousFaction)
    {
      Player = player;
      PreviousFaction = previousFaction;
    }
  }
}