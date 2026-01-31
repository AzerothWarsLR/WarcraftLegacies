using System;

namespace MacroTools.Factions;

public sealed class FactionPowerEventArgs : EventArgs
{
  public FactionPowerEventArgs(Faction faction, Power power)
  {
    Faction = faction;
    Power = power;
  }

  public Faction Faction { get; }
  public Power Power { get; }
}
