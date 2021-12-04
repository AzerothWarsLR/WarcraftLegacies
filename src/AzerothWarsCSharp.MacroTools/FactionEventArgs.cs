using System;

namespace AzerothWarsCSharp.MacroTools
{
  public class FactionEventArgs : EventArgs
  {
    public FactionEventArgs(Faction faction)
    {
      Faction = faction;
    }

    public Faction Faction { get; }
  }
}