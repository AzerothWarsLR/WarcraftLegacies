using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Localization;
using WCSharp.Shared;

namespace MacroTools.Factions;

/// <summary>
/// Moves players between <see cref="Team"/>s mid-game, with a ceasefire between the old allies, a cap on how big a
/// team can get, and a cooldown before the same player can change teams again.
/// </summary>
public static class TeamChanges
{
  private static readonly Dictionary<player, float> LastChangeTimes = new();
  private static timer? _clock;
  private static bool _watching;
  private static readonly List<Action> AnyTeamChangedHandlers = new();
  private static float _cooldown = 600;
  private static Func<Team, int> _capacity = _ => int.MaxValue;

  /// <summary>How many seconds a player and their former allies can't attack each other after a team change.</summary>
  public static float CeasefireDuration { get; set; } = 60;

  /// <summary>How many seconds a player has to wait after changing teams before they can change again.</summary>
  public static float Cooldown
  {
    get => _cooldown;
    set
    {
      _cooldown = value;
      NotifyTeamChanged();
    }
  }

  /// <summary>How many players a <see cref="Team"/> can hold before nobody else can join it.</summary>
  public static Func<Team, int> Capacity
  {
    get => _capacity;
    set
    {
      _capacity = value;
      NotifyTeamChanged();
    }
  }

  /// <summary>
  /// Runs <paramref name="handler"/> whenever any player joins or leaves a <see cref="Team"/>, or the team size cap or
  /// cooldown changes.
  /// </summary>
  public static void OnAnyTeamChanged(Action handler)
  {
    WatchTeams();
    AnyTeamChangedHandlers.Add(handler);
  }

  private static float Now
  {
    get
    {
      if (_clock == null)
      {
        _clock = timer.Create();
        _clock.Start(1000000, false, () => { });
      }

      return TimerGetElapsed(_clock);
    }
  }

  /// <summary>How many players count towards <paramref name="team"/>'s cap, including the rest of its <see cref="Bloc"/>.</summary>
  public static int GetSize(Team team) => team.Bloc?.Size ?? team.Size;

  /// <summary>Whether <paramref name="team"/> has no room left for another player.</summary>
  public static bool IsFull(Team team) => GetSize(team) >= Capacity(team);

  /// <summary>
  /// Whether <paramref name="whichPlayer"/> can move to <paramref name="team"/> without going over its cap. Moving
  /// within the same <see cref="Bloc"/> never changes its size, so it always has room.
  /// </summary>
  public static bool HasRoomFor(Team team, player whichPlayer)
  {
    var currentTeam = whichPlayer.GetPlayerData().Team;
    if (currentTeam == team || (team.Bloc != null && currentTeam?.Bloc == team.Bloc))
    {
      return true;
    }

    return !IsFull(team);
  }

  /// <summary>Whether two players are on the same <see cref="Team"/> or in the same <see cref="Bloc"/>.</summary>
  public static bool AreTeammates(player playerA, player playerB)
  {
    var teamA = playerA.GetPlayerData().Team;
    var teamB = playerB.GetPlayerData().Team;
    return teamA != null && (teamA == teamB || (teamA.Bloc != null && teamA.Bloc == teamB?.Bloc));
  }

  /// <summary>Seconds left before <paramref name="whichPlayer"/> can change teams again.</summary>
  public static float GetCooldownRemaining(player whichPlayer) =>
    LastChangeTimes.TryGetValue(whichPlayer, out var lastChange) ? Math.Max(0, lastChange + Cooldown - Now) : 0;

  /// <summary>
  /// Moves <paramref name="whichPlayer"/> to <paramref name="destination"/>, starting a ceasefire with everyone they
  /// leave behind.
  /// </summary>
  public static void Move(player whichPlayer, Team destination)
  {
    var playerData = whichPlayer.GetPlayerData();
    var formerTeam = playerData.Team;
    if (formerTeam == destination)
    {
      return;
    }

    var formerAllies = GetAllies(formerTeam).Where(x => x != whichPlayer).ToList();
    playerData.SetTeam(destination);
    formerAllies.RemoveAll(x => AreTeammates(x, whichPlayer));
    LastChangeTimes[whichPlayer] = Now;

    var factionName = playerData.Faction?.ColoredName ?? whichPlayer.Name;
    destination.DisplayText(Loc.Format("{faction} has joined the {team}.", ("{faction}", factionName), ("{team}", destination.LocalizedName)));
    StartCeasefire(whichPlayer, formerAllies, factionName);
  }

  /// <summary>
  /// Moves <paramref name="whichPlayer"/> onto a <see cref="Team"/> of their own, starting a ceasefire with everyone
  /// they leave behind.
  /// </summary>
  public static void MoveSolo(player whichPlayer)
  {
    var faction = whichPlayer.GetPlayerData().Faction;
    var teamName = $"{faction?.Name ?? whichPlayer.Name} Pact";
    if (!FactionManager.TryGetTeamByName(teamName, out var soloTeam))
    {
      soloTeam = new Team(teamName);
      FactionManager.Register(soloTeam);
    }

    if (soloTeam.Size > 0 && !soloTeam.Contains(whichPlayer))
    {
      soloTeam = new Team($"{teamName} {soloTeam.Size + 1}");
      FactionManager.Register(soloTeam);
    }

    Move(whichPlayer, soloTeam);
  }

  private static void StartCeasefire(player whichPlayer, List<player> formerAllies, string factionName)
  {
    if (formerAllies.Count == 0)
    {
      return;
    }

    foreach (var formerAlly in formerAllies)
    {
      whichPlayer.SetAllianceState(formerAlly, AllianceState.Neutral);
      formerAlly.SetAllianceState(whichPlayer, AllianceState.Neutral);
      formerAlly.DisplayTextTo(Loc.Format("{faction} has left your team. There is a ceasefire for {seconds} seconds before you are enemies.",
        ("{faction}", factionName), ("{seconds}", ((int)CeasefireDuration).ToString())));
    }

    whichPlayer.DisplayTextTo(Loc.Format("You have left your team. There is a ceasefire for {seconds} seconds before your former allies become your enemies.",
      ("{seconds}", ((int)CeasefireDuration).ToString())));

    var ceasefireTimer = timer.Create();
    var dialog = timerdialog.Create(ceasefireTimer);
    dialog.SetTitle(Loc.Get("Ceasefire ends in:"));
    if (player.LocalPlayer == whichPlayer || formerAllies.Contains(player.LocalPlayer))
    {
      dialog.IsDisplayed = true;
    }

    ceasefireTimer.Start(CeasefireDuration, false, () =>
    {
      foreach (var formerAlly in formerAllies)
      {
        if (!AreTeammates(whichPlayer, formerAlly))
        {
          whichPlayer.SetAllianceState(formerAlly, AllianceState.Unallied);
          formerAlly.SetAllianceState(whichPlayer, AllianceState.Unallied);
        }
      }

      dialog.Dispose();
      ceasefireTimer.Dispose();
    });
  }

  internal static void NotifyTeamChanged()
  {
    foreach (var handler in AnyTeamChangedHandlers)
    {
      handler();
    }
  }

  private static IEnumerable<player> GetAllies(Team? team)
  {
    if (team == null)
    {
      return Array.Empty<player>();
    }

    return team.Bloc == null ? team.Members : team.Bloc.Teams.SelectMany(x => x.Members);
  }

  private static void WatchTeams()
  {
    if (_watching)
    {
      return;
    }

    _watching = true;
    foreach (var whichPlayer in Util.EnumeratePlayers())
    {
      var playerData = whichPlayer.GetPlayerData();
      playerData.PlayerJoinedTeam += _ => NotifyTeamChanged();
      playerData.PlayerLeftTeam += _ => NotifyTeamChanged();
    }
  }
}
