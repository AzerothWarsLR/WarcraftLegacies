using System;

namespace MacroTools.FactionSystem;

public sealed class FactionNameChangeEventArgs : EventArgs
{
  public FactionNameChangeEventArgs(Faction faction, string previousName)
  {
    PreviousName = previousName;
    Faction = faction;
  }

  public Faction Faction { get; }
  public string PreviousName { get; }
}
