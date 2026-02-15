using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Commands;

public sealed class Stats : Command
{
  public override string CommandText => "stats";
  public override ExpectedParameterCount ExpectedParameterCount => new(0);
  public override CommandType Type => CommandType.Normal;
  public override string Description => "Shows your match statistics.";

  public override string Execute(player commandUser, params string[] parameters)
  {
    var stats = commandUser.GetMatchStats();
    var games = stats.GamesPlayed;
    var wins = stats.Wins;
    var losses = stats.Losses;
    var winRate = games > 0 ? (int)((float)wins / games * 100) : 0;
    var slot = stats.LastSlotPlayed;
    var faction = stats.LastFactionPlayed ?? "Unknown";
    var team = stats.LastTeamName ?? "Unknown";

    return
      "Match stats:\n" +
      $"Wins: {wins}\n" +
      $"Losses: {losses}\n" +
      $"Games played: {games}\n" +
      $"Win rate: {winRate}%\n" +
      $"Last slot: {slot}\n" +
      $"Last faction: {faction}\n" +
      $"Last team: {team}";
  }
}
