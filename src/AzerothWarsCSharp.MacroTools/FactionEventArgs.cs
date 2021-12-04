using System;

namespace AzerothWarsCSharp.MacroTools
{
  public class FactionEventArgs : EventArgs
  {
    public Faction Faction { get; }
    
    public FactionEventArgs(Faction faction)
    {
      Faction = faction;
    }
  }
}