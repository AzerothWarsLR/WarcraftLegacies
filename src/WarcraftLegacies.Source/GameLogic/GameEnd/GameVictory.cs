using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic.GameEnd;

/// <summary>Announces the winners of the game.</summary>
public static class GameVictory
{
  public const string VictoryColor = "|cff911499";

  /// <summary>Whether someone has already won the game.</summary>
  public static bool IsWon { get; private set; }

  /// <summary>Announces that the side with the given name has won, and records its undefeated factions as winners.</summary>
  public static void Declare(string winnerName, string victoryMusic, IEnumerable<Faction> winners)
  {
    if (IsWon)
    {
      return;
    }

    IsWon = true;
    ClearTextMessages();
    foreach (var player in Util.EnumeratePlayers())
    {
      var victoryMessage = Loc.Format(
        "The {team} has won the game! You may choose to continue playing.",
        ("{team}", winnerName));

      player.DisplayTextTo($"{VictoryColor}\n{Loc.Get("TEAM VICTORY!")}|r\n{victoryMessage}");
    }

    PlayThematicMusic(victoryMusic);

    foreach (var faction in winners)
    {
      if (faction.Player != null && faction.ScoreStatus != ScoreStatus.Defeated)
      {
        Mmd.MmdManager.SetResult(faction.Player, "win");
      }
    }

    Mmd.MmdManager.WriteToMmd();
  }
}
