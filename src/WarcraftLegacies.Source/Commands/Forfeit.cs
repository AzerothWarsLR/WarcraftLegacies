using System.Collections.Generic;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// A <see cref="Command"/> that sets the player's camera to a specific height.
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

    ///this should be impossible i guess but u never know!
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
    int currentVotes = votes.Count;

    team.DisplayText(
        $"{commandUser.Name} voted to forfeit ({currentVotes}/{VotesRequired})."
    );

    if (currentVotes >= VotesRequired)
    {
      team.DisplayText("Forfeit vote passed.");
      EndGame(true);
    }

    return "Forfeit vote registered.";
  }
}
