using System;

namespace AzerothWarsCSharp.MacroTools.Factions
{
  public class PersonFactionChangeEventArgs : EventArgs
  {
    public Person Person { get; }
    public Faction PreviousFaction { get; }
    
    public PersonFactionChangeEventArgs(Person person, Faction previousFaction)
    {
      Person = person;
      PreviousFaction = previousFaction;
    }
  }
}