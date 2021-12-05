using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class NorthAllianceSetup
  {
    public static Team Setup(IEnumerable<Faction> factionsInTeam)
    {
      var northAlliance = new Team("Alliance", "HeroicVictory");
      foreach (var faction in factionsInTeam)
      {
        FactionSystem.FactionSetTeam(faction, northAlliance);
      }
      FactionSystem.Add(northAlliance);
      return northAlliance;
    }
  }
}