using System.Collections.Generic;
using System.Linq;

namespace AzerothWarsCSharp.MacroTools
{
  public class Team
  {
    private readonly List<Faction> _factions = new();

    public Team(string name, string victoryMusicPath)
    {
      Name = name;
      VictoryMusicPath = victoryMusicPath;
    }

    public string Name { get; }
    public string VictoryMusicPath { get; }

    public List<Faction> GetFactions()
    {
      return _factions.ToList();
    }

    public void AddFaction(Faction faction)
    {
      _factions.Add(faction);
    }
  }
}