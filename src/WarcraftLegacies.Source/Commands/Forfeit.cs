using System;
using System.Collections.Generic;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using WCSharp.Shared;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// A <see cref="Command"/> that allows a player to vote to forfeit a game.
/// </summary>
public sealed class Forfeit : Command
{
  private static readonly Dictionary<Team, HashSet<player>> _ffVotesByTeam = new();

  private const int VotesRequired = 6;
  private const int ForfeitAllowedTurn = 10;

  public override string CommandText => "ff";
  public override ExpectedParameterCount ExpectedParameterCount => new(0);
  public override CommandType Type => CommandType.Normal;
  public override string Description => "Vote to forfeit the game.";

  public override void OnRegister()
  {
    foreach (var faction in FactionManager.GetAllFactions())
    {
      faction.ScoreStatusChanged += _ => OnFactionScoreStatusChanged(faction);
    }
  }

  /// <summary>
  /// Gets Called when a factions score status changes aka -obs
  /// </summary>
  private static void OnFactionScoreStatusChanged(Faction faction)
  {
    foreach (var player in Util.EnumeratePlayers())
    {
      var playerData = player.GetPlayerData();
      if (playerData.Faction == faction)
      {
        TryForfeitPlayer(player, hasLeft: true);
      }
    }
  }

  /// <summary>
  /// Gets called when a player leaves the game.
  /// </summary>
  private static ForfeitResult TryForfeitPlayer(player leavingPlayer, bool hasLeft = false)
  {
    var team = leavingPlayer.GetPlayerData().Team;
    if (team == null)
    {
      return ForfeitResult.NoTeam;
    }
    if (!_ffVotesByTeam.TryGetValue(team, out var votes))
    {
      votes = new HashSet<player>();
      _ffVotesByTeam[team] = votes;
    }
    if (!votes.Add(leavingPlayer))
    {
      return ForfeitResult.AlreadyForfeited;
    }

    var currentVotes = votes.Count;
    var playerFaction = leavingPlayer.GetPlayerData().Faction;
    var prefixCol = playerFaction?.PrefixCol ?? "";
    var coloredPlayerName = $"{prefixCol}{leavingPlayer.Name}|r";
    var message = hasLeft
      ? Loc.Format(
          "{player} has left the game and counts as a forfeit vote. ({votes}/{required}).",
          ("{player}", coloredPlayerName),
          ("{votes}", currentVotes.ToString()),
          ("{required}", VotesRequired.ToString()))
      : Loc.Format(
          "{player} voted to forfeit. ({votes}/{required}).",
          ("{player}", coloredPlayerName),
          ("{votes}", currentVotes.ToString()),
          ("{required}", VotesRequired.ToString()));

    team.DisplayText(message);
    TryEndGame(currentVotes, team);
    return ForfeitResult.Succeeded;
  }

  /// <summary>
  /// Gets called when a player types the -ff command ingame.
  /// </summary>
  public override string Execute(player commandUser, params string[] parameters)
  {
    if (GameTimeManager.Turn < ForfeitAllowedTurn)
    {
      return Loc.Format("You can't forfeit before turn {turn}.", ("{turn}", ForfeitAllowedTurn.ToString()));
    }

    var result = TryForfeitPlayer(commandUser);
    return result switch
    {
      ForfeitResult.Succeeded => Loc.Get("Forfeit vote registered."),
      ForfeitResult.NoTeam => Loc.Get("You are not in a team."),
      ForfeitResult.AlreadyForfeited => Loc.Get("You have already forfeited."),
      _ => throw new ArgumentOutOfRangeException(nameof(result))
    };
  }

  private static void TryEndGame(int currentVotes, Team team)
  {
    if (currentVotes >= VotesRequired)
    {
      team.DisplayText(Loc.Get("Forfeit vote passed."));
      foreach (var player in Util.EnumeratePlayers())
      {
        player.DisplayTextTo(Loc.Format(
          "{team} has forfeited the game.|cFFFF0000The game will end in 10 seconds.|r",
          ("{team}", team.Name)));
      }
      WCSharp.Events.PeriodicEvents.AddPeriodicEvent(() =>
      {
        EndGame(true);
        return false;
      }, 10f);
    }
  }
  private enum ForfeitResult
  {
    Succeeded,
    NoTeam,
    AlreadyForfeited
  }
}
