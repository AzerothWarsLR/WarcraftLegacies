using System.Collections.Generic;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions
{
  public class SharedStartLocationManager
  {
    private readonly Dictionary<string, Faction> _factions;

    public SharedStartLocationManager(Dictionary<string, Faction> factions)
    {
      _factions = factions;
    }

    public Point GetStartLocation(string factionName)
    {
      if (_factions.TryGetValue(factionName, out var faction))
      {
        return faction.GetStartLocation();
      }
      return Point.Zero;
    }
  }
}