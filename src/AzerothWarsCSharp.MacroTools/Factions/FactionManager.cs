using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Factions
{
  /// <summary>
  ///   Responsible for the management of all <see cref="Faction" />s and <see cref="Team" />s in the game.
  /// </summary>
  public static class FactionManager
  {
    private static readonly Dictionary<string, Team> TeamsByName = new();
    private static readonly List<Team> AllTeams = new();
    private static readonly Dictionary<string, Faction> FactionsByName = new();
    private static readonly List<Power> AllPowers = new();

    public static event EventHandler<Faction>? FactionRegistered;
    public static event EventHandler<Power>? PowerAdded;
    
    private static void OnFactionNameChange(object? sender, FactionNameChangeEventArgs args)
    {
      FactionsByName.Remove(args.PreviousName);
      args.Faction.Name = args.Faction.Name;
      FactionsByName.Add(args.Faction.Name, args.Faction);
    }

    public static List<Power> GetAllPowers()
    {
      return AllPowers.ToList();
    }
    
    public static IEnumerable<Team> GetAllTeams()
    {
      return AllTeams.ToList();
    }

    public static bool TeamWithNameExists(string teamName)
    {
      return TeamsByName.ContainsKey(teamName.ToLower());
    }

    public static Team GetTeamByName(string teamName)
    {
      return TeamsByName[teamName.ToLower()];
    }

    public static Faction? GetFromPlayer(player whichPlayer)
    {
      return Person.ByHandle(whichPlayer)?.Faction;
    }

    public static bool FactionWithNameExists(string name)
    {
      return FactionsByName.ContainsKey(name.ToLower());
    }

    public static Faction GetFromName(string name)
    {
      return FactionsByName[name.ToLower()];
    }

    public static void FactionAddPower(Faction faction, Power power)
    {
      AllPowers.Add(power);
      PowerAdded?.Invoke(null, power);
    }
    
    /// <summary>
    ///   Registers a <see cref="Faction" /> to the <see cref="FactionManager" />,
    ///   allowing it to be retrieved globally and fire global events.
    /// </summary>
    public static void Register(Faction faction)
    {
      if (!FactionsByName.ContainsKey(faction.Name.ToLower()))
      {
        FactionsByName[faction.Name.ToLower()] = faction;
        faction.NameChanged += OnFactionNameChange;
        FactionRegistered?.Invoke(faction, faction);
      }
      else
      {
        throw new Exception($"Attempted to register faction that already exists with name {faction}.");
      }

      FactionRegistered?.Invoke(faction, faction);
    }

    /// <summary>
    ///   Registers a <see cref="Team" /> to the <see cref="FactionManager" />,
    ///   allowing it to be retrieved globally and fire global events.
    /// </summary>
    public static void Register(Team team)
    {
      if (!TeamsByName.ContainsKey(team.Name.ToLower()))
      {
        TeamsByName[team.Name.ToLower()] = team;
        AllTeams.Add(team);
      }
      else
      {
        throw new Exception(
          $"Attempted to register a {nameof(Team)} named {team.Name}, but there is already a registered {nameof(Team)} with that name.");
      }
    }
  }
}