using System;
using System.Collections.Generic;
using System.Linq;

namespace AzerothWarsCSharp.MacroTools.Factions
{
  /// <summary>
  /// Responsible for the management of all <see cref="Faction"/>s and <see cref="Team"/>s in the game.
  /// </summary>
  public static class FactionManager
  {
    private static readonly Dictionary<string, Team> TeamsByName = new();
    private static readonly List<Team> AllTeams = new();
    
    public static IEnumerable<Team> GetAllTeams()
    {
      return AllTeams.ToList();
    }
    
    public static bool TeamWithNameExists(string teamName)
    {
      return TeamsByName.ContainsKey(teamName);
    }

    public static Team GetTeamByName(string teamName)
    {
      return TeamsByName[teamName];
    }
    
    /// <summary>
    /// Registers a <see cref="Faction"/> to the <see cref="FactionManager"/>,
    /// allowing it to be retrieved globally and fire global events.
    /// </summary>
    public static void Register(Faction faction)
    {
      
    }

    /// <summary>
    /// Registers a <see cref="Team"/> to the <see cref="FactionManager"/>,
    /// allowing it to be retrieved globally and fire global events.
    /// </summary>
    public static void Register(Team team)
    {
      if (!TeamsByName.ContainsKey(team.Name.ToLower()))
      {
        TeamsByName[team.Name.ToLower()] = team;
        AllTeams.Add(team);
      }
      else
        throw new Exception($"Attempted to register a {nameof(Team)} named {team.Name}, but there is already a registered {nameof(Team)} with that name.");
    }
  }
}