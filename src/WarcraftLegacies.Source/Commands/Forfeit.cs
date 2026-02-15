using System.Collections.Generic;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Stats;
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
    team.DisplayText(
        $"{commandUser.Name} voted to forfeit ({currentVotes}/{VotesRequired})."
    );

    if (currentVotes >= VotesRequired)
    {
      team.DisplayText("Forfeit vote passed.");
      foreach (var player in Util.EnumeratePlayers())
      {
        player.DisplayTextTo($"{team.Name} has forfeited the game. The game will end in 10 seconds.");
      }
      MatchResultRecorder.RecordForfeitResult(team);

      WCSharp.Events.PeriodicEvents.AddPeriodicEvent(() =>
      {
        EndGame(true);
        return false;
      }, 10f);

    }
    return "Forfeit vote registered.";
  }
}
