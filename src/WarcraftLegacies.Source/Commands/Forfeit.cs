using System;
using System.Collections.Generic;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// A <see cref="Command"/> that allows a player to vote to forfeit a game.
/// </summary>
/// 
public sealed class Forfeit : Command
{
  private static readonly Dictionary<Team, HashSet<player>> _ffVotesByTeam = new();

  private const int VotesRequired = 6;

  public override string CommandText => "ff";
  public override ExpectedParameterCount ExpectedParameterCount => new(0);
  public override CommandType Type => CommandType.Normal;
  public override string Description => "Vote to forfeit the game.";
  public override void OnRegister()
  {
    try
    {
      trigger trigger = trigger.Create();
      foreach (var player in Util.EnumeratePlayers())
      {
        trigger.RegisterPlayerEvent(player, playerevent.Leave);
      }
      trigger.AddAction(() =>
      {
        RegisterLeaveVote(@event.Player);
      });

      // Check a faction change aka -obs
      foreach (var faction in FactionManager.GetAllFactions())
      {
        faction.ScoreStatusChanged += _ => OnFactionScoreStatusChanged(faction);
     };
    }
    catch (Exception ex)
    {
      Console.WriteLine("wow an error.");
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
        RegisterLeaveVote(player);
      }
    }
  }

  /// <summary>
  /// Gets called when a player leaves the game.
  /// </summary>
  public static void RegisterLeaveVote(player leavingPlayer)
  {
    var team = leavingPlayer.GetPlayerData().Team;
    if (team == null)
    {
      return;
    }
    if (!_ffVotesByTeam.TryGetValue(team, out var votes))
    {
      votes = new HashSet<player>();
      _ffVotesByTeam[team] = votes;
    }
    if (!votes.Add(leavingPlayer))
    {
      return;
    }

    var currentVotes = votes.Count;
    var playerFaction = leavingPlayer.GetPlayerData().Faction;
    var prefixCol = playerFaction?.PrefixCol ?? "";
    team.DisplayText(
        $"{prefixCol}{leavingPlayer.Name}|r has left the game and counts as a forfeit vote. ({currentVotes}/{VotesRequired})."
    );

    if (currentVotes >= VotesRequired)
    {
      team.DisplayText("Forfeit vote passed.");
      foreach (var p in Util.EnumeratePlayers())
      {
        p.DisplayTextTo($"{team.Name} has forfeited the game.|cFFFF0000The game will end in 10 seconds.");
      }
      WCSharp.Events.PeriodicEvents.AddPeriodicEvent(() =>
      {
        EndGame(true);
        return false;
      }, 10f);
    }
  }

  /// <summary>
  /// Gets called when a player types the -ff command ingame.
  /// </summary>
  public override string Execute(player commandUser, params string[] parameters)
  {
    var team = commandUser.GetPlayerData().Team;
    if (team == null)
    {
      return "You are not on a team.";
    }
    if (!_ffVotesByTeam.TryGetValue(team, out var votes))
    {
      votes = new HashSet<player>();
      _ffVotesByTeam[team] = votes;
    }
    if (!votes.Add(commandUser))
    {
      return "You have already voted to forfeit.";
    }

    var currentVotes = votes.Count;
    var playerFaction = commandUser.GetPlayerData().Faction;
    var prefixCol = playerFaction?.PrefixCol ?? "";
    team.DisplayText(
        $"{prefixCol}{commandUser.Name}|r voted to forfeit ({currentVotes}/{VotesRequired})."
    );

    if (currentVotes >= VotesRequired)
    {
      team.DisplayText("Forfeit vote passed.");
      foreach (var player in Util.EnumeratePlayers())
      {
        player.DisplayTextTo($"|cFFFF0000{team.Name}|r has forfeited the game. The game will end in 10 seconds.");
      }
      WCSharp.Events.PeriodicEvents.AddPeriodicEvent(() =>
      {
        EndGame(true);
        return false;
      }, 10f);

    }
    return "Forfeit vote registered.";
  }
}
