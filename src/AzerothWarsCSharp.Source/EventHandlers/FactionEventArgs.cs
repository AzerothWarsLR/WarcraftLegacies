using AzerothWarsCSharp.Source.Libraries;
using System;

namespace AzerothWarsCSharp.Source
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
