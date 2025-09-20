using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.ResearchSystems;
using MacroTools.Utils;
using WCSharp.Events;

namespace MacroTools.FactionSystem;

/// <summary>
///   Responsible for the management of all <see cref="Faction" />s and <see cref="Team" />s in the game.
/// </summary>
public static class FactionManager
{
  private static readonly Dictionary<string, Team> _teamsByName = new();
  private static readonly List<Team> _allTeams = new();
  private static readonly Dictionary<string, Faction> _factionsByName = new();
  private static readonly List<Faction> _allFactions = new();
  private static TeamSharedVisionMode _sharedVisionMode = TeamSharedVisionMode.All;

  /// <summary>
  ///   Fired when a <see cref="Faction" /> is registered to the <see cref="FactionManager" />.
  /// </summary>
  public static event EventHandler<Faction>? FactionRegistered;

  /// <summary>
  /// Fired when any <see cref="Faction"/> changes its name.
  /// </summary>
  public static event EventHandler<Faction>? AnyFactionNameChanged; //todo: remove this; shouldn't need static events of this nature

  /// <summary>
  /// How shared vision in <see cref="Team"/>s should behave.
  /// <para>Determines the <see cref="Team.SharedVisionMode"/> mode setting of all managed <see cref="Team"/>s.</para>
  /// </summary>
  public static TeamSharedVisionMode SharedVisionMode
  {
    get => _sharedVisionMode;
    set
    {
      foreach (var team in _allTeams)
      {
        team.SharedVisionMode = value;
      }

      _sharedVisionMode = value;
    }
  }

  /// <summary>
  /// Initialize WC3 game events related to <see cref="Faction"/>s.
  /// </summary>
  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
    {
      try
      {
        var faction = GetTriggerPlayer().GetFaction();
        if (faction == null)
        {
          return;
        }

        var researchId = GetResearched();
        var research = ResearchManager.GetFromTypeId(researchId);
        if (research == null || !research.IncompatibleWith.Any(x => faction.GetObjectLevel(x.ResearchTypeId) > 0))
        {
          faction.SetObjectLevel(researchId, GetPlayerTechCount(GetTriggerPlayer(), researchId, true));
          if (research == null)
          {
            return;
          }

          research.OnResearch(GetTriggerPlayer());
          foreach (var otherResearch in research.IncompatibleWith)
          {
            faction.SetObjectLimit(otherResearch.ResearchTypeId, -Faction.Unlimited);
          }
        }
        else
        {
          faction.SetObjectLimit(researchId, -Faction.Unlimited);
          research.Refund(GetTriggerPlayer());
        }
      }
      catch (Exception ex)
      {
        Logger.LogError(ex.ToString());
      }
    });
  }

  private static void OnFactionNameChange(object? sender, FactionNameChangeEventArgs args)
  {
    try
    {
      _factionsByName.Remove(args.PreviousName);
      _factionsByName.Add(args.Faction.Name, args.Faction);
      AnyFactionNameChanged?.Invoke(args.Faction, args.Faction);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  /// <summary>
  /// Returns all registered <see cref="Faction"/>s.
  /// </summary>
  /// <returns></returns>
  public static ReadOnlyCollection<Faction> GetAllFactions() => _allFactions.AsReadOnly();

  /// <summary>
  /// Returns all registered <see cref="Team"/>s.
  /// </summary>
  /// <returns></returns>
  public static ReadOnlyCollection<Team> GetAllTeams() => _allTeams.AsReadOnly();

  /// <summary>
  /// Gets the registered <see cref="Team"/> with the specified name.
  /// </summary>
  /// <param name="teamName">The name of the team.</param>
  /// <param name="team">The team with the specified name.</param>
  /// <returns>Returns true if a team with the specified name exists.</returns>
  public static bool TryGetTeamByName(string teamName, [NotNullWhen(true)] out Team? team) =>
    _teamsByName.TryGetValue(teamName.ToLower(), out team);

  /// <summary>
  /// Outputs the registered <see cref="Faction"/> with the specified name.
  /// </summary>
  /// <param name="factionName">The name of the faction.</param>
  /// <param name="faction">The faction with the specified name.</param>
  /// <returns>Returns true if a faction with the specified name exists.</returns>
  public static bool TryGetFactionByName(string factionName, [NotNullWhen(true)] out Faction? faction) =>
    _factionsByName.TryGetValue(factionName.ToLower(), out faction);

  /// <summary>
  /// Returns true if a <see cref="Faction"/> with the specified type exists.
  /// </summary>
  /// <param name="faction">Outputs the <see cref="Faction"/> with the specified type.</param>
  public static bool TryGetFactionByType<T>([NotNullWhen(true)] out T? faction) where T : Faction
  {
    faction = _factionsByName.Values.FirstOrDefault(x => x.GetType() == typeof(T)) as T;
    return faction != null;
  }

  /// <summary>
  ///   Registers a <see cref="Faction" /> to the <see cref="FactionManager" />,
  ///   allowing it to be retrieved globally and fire global events.
  /// </summary>
  public static void Register(Faction faction)
  {
    if (_factionsByName.ContainsKey(faction.Name.ToLower()))
    {
      throw new Exception($"Attempted to register faction that already exists with name {faction}.");
    }

    _factionsByName[faction.Name.ToLower()] = faction;
    foreach (var nickname in faction.Nicknames)
    {
      _factionsByName[nickname.ToLower()] = faction;
    }

    _allFactions.Add(faction);
    FactionRegistered?.Invoke(faction, faction);
    faction.OnRegistered();
    faction.NameChanged += OnFactionNameChange;

    ExecuteFactionDependentInitializers();
  }

  /// <summary>
  ///   Registers a <see cref="Team" /> to the <see cref="FactionManager" />,
  ///   allowing it to be retrieved globally and fire global events.
  /// </summary>
  public static void Register(Team team)
  {
    if (!_teamsByName.ContainsKey(team.Name.ToLower()))
    {
      team.SharedVisionMode = SharedVisionMode;
      _teamsByName[team.Name.ToLower()] = team;
      _allTeams.Add(team);
    }
    else
    {
      throw new Exception(
        $"Attempted to register a {nameof(Team)} named {team.Name}, but there is already a registered {nameof(Team)} with that name.");
    }
  }

  /// <summary>
  /// Executes all <see cref="FactionDependentInitializer"/>s related to the provided <see cref="Faction"/>, which have
  /// satisfied their dependencies and which have not already been executed.
  /// </summary>
  private static void ExecuteFactionDependentInitializers()
  {
    //Try execute initializers that depend on the provided Faction.
    var dependentInitializers = _allFactions
      .SelectMany(x => x.FactionDependentInitializers)
      .Where(x => !x.Executed && x.FactionDependencies.All(FactionOfTypeExists));
    foreach (var initializer in dependentInitializers)
    {
      initializer.Execute();
    }
  }

  /// <summary>
  /// Returns true if a <see cref="Faction"/> with the specified type exists.
  /// </summary>
  private static bool FactionOfTypeExists(Type factionType) => _allFactions.Any(x => x.GetType() == factionType);
}
