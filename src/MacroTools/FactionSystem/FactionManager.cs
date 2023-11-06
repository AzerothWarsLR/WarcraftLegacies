using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.FactionSystem
{
  /// <summary>
  ///   Responsible for the management of all <see cref="Faction" />s and <see cref="Team" />s in the game.
  /// </summary>
  public static class FactionManager
  {
    private static readonly Dictionary<string, Team> TeamsByName = new();
    private static readonly List<Team> AllTeams = new();
    private static readonly Dictionary<string, Faction> FactionsByName = new();

    /// <summary>
    ///   Fired when a <see cref="Faction" /> is registered to the <see cref="FactionManager" />.
    /// </summary>
    public static event EventHandler<Faction>? FactionRegistered;

    /// <summary>
    /// Fired when any <see cref="Faction"/> changes its name.
    /// </summary>
    public static event EventHandler<Faction>? AnyFactionNameChanged; //todo: remove this; shouldn't need static events of this nature

    private static void OnFactionNameChange(object? sender, FactionNameChangeEventArgs args)
    {
      try
      {
        FactionsByName.Remove(args.PreviousName);
        FactionsByName.Add(args.Faction.Name, args.Faction);
        AnyFactionNameChanged?.Invoke(args.Faction, args.Faction);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    public static List<Faction> GetAllFactions()
    {
      return FactionsByName.Values.ToList();
    }
    
    public static List<Team> GetAllTeams()
    {
      return AllTeams.ToList();
    }

    public static bool TeamWithNameExists(string teamName)
    {
      return TeamsByName.ContainsKey(teamName.ToLower());
    }

    /// <summary>
    /// Returns the <see cref="Team"/> with the specified name if one exists.
    /// Returns null otherwise.
    /// </summary>
    public static Team? GetTeamByName(string teamName) =>
      TeamsByName.TryGetValue(teamName.ToLower(), out var team) ? team : null;

    public static Faction? GetFromPlayer(player whichPlayer)
    {
      return PlayerData.ByHandle(whichPlayer)?.Faction;
    }

    public static bool FactionWithNameExists(string name)
    {
      return FactionsByName.ContainsKey(name.ToLower());
    }

    /// <summary>
    /// Returns the <see cref="Faction"/> with the specified name if one exists.
    /// Returns null otherwise.
    /// </summary>
    public static Faction? GetFactionByName(string name) => 
      FactionsByName.TryGetValue(name.ToLower(), out var faction) ? faction : null;
    
    /// <summary>
    /// Returns true if a <see cref="Faction"/> with the specified type exists.
    /// </summary>
    /// <param name="faction">Outputs the <see cref="Faction"/> with the specified type.</param>
    public static bool TryGetFactionByType<T>([NotNullWhen(true)] out Faction? faction) where T : Faction
    {
      faction = FactionsByName.Values.FirstOrDefault(x => x.GetType() == typeof(T)) as T;
      return faction != null;
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
        faction.OnRegister();
        faction.NameChanged += OnFactionNameChange;
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