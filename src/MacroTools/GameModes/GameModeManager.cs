using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Utils;

namespace MacroTools.GameModes;

/// <summary>
/// Manages voting and selection of <see cref="IGameMode"/>s.
/// </summary>
public sealed class GameModeManager
{
  private readonly List<GameModeVote> _gameModeVotes;

  /// <summary>How long to wait before displaying the votes to players.</summary>
  public float TimeToDisplay { get; init; }

  /// <summary>How long players can vote for before the game mode is chosen.</summary>
  public float VoteLength { get; init; }

  public GameModeManager(IEnumerable<IGameMode> gameModes)
  {
    _gameModeVotes = gameModes.Select(x => new GameModeVote(x)).ToList();
  }

  public void Setup()
  {
    timer.Create().Start(TimeToDisplay, false, PresentVotesToPlayers);
  }

  private void PresentVotesToPlayers()
  {
    try
    {
      dialog dialog = dialog.Create();
      dialog.SetMessage("Vote Game Mode");
      var buttonClickTriggers = new List<trigger>();
      foreach (var gameModeVote in _gameModeVotes)
      {
        var dialogButton = dialog.AddButton(gameModeVote.GameMode.Name, 0);
        var buttonClickTrigger = trigger.Create();
        buttonClickTrigger.RegisterButtonEvent(dialogButton);
        buttonClickTrigger.AddAction(() => { gameModeVote.VoteCount += 1; });
        buttonClickTriggers.Add(buttonClickTrigger);
      }

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        dialog.SetVisibility(player, true);
      }

      @event.ExpiredTimer.Dispose();
      timer.Create().Start(VoteLength, false, () =>
      {
        ConcludeVote(dialog, buttonClickTriggers);
        @event.ExpiredTimer.Dispose();
      });
    }

    catch (Exception ex)
    {
      Logger.LogError(ex.Message);
    }
  }

  private void ConcludeVote(dialog dialog, List<trigger> buttonClickTriggers)
  {
    var highestVotedGameMode = _gameModeVotes.OrderByDescending(x => x.VoteCount).First();
    highestVotedGameMode.GameMode.OnChoose();

    @event.ExpiredTimer.Dispose();
    dialog.Clear();

    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      player.DisplayTextTo($"The {highestVotedGameMode.GameMode.Name} game mode has been chosen.");
      dialog.SetVisibility(player, false);
    }

    foreach (var trigger in buttonClickTriggers)
    {
      trigger.Dispose();
    }
  }

  private sealed class GameModeVote
  {
    public IGameMode GameMode { get; }

    public int VoteCount { get; set; }

    public GameModeVote(IGameMode gameMode)
    {
      GameMode = gameMode;
    }
  }
}
