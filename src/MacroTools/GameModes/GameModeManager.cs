using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.GameModes
{
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
      CreateTimer().Start(TimeToDisplay, false, PresentVotesToPlayers);
    }

    private void PresentVotesToPlayers()
    {
      try
      {
        var dialog = DialogCreate();
        DialogSetMessage(dialog, "Vote Game Mode");
        var buttonClickTriggers = new List<trigger>();
        foreach (var gameModeVote in _gameModeVotes)
        {
          var dialogButton = DialogAddButton(dialog, gameModeVote.GameMode.Name, 0);
          var buttonClickTrigger = CreateTrigger();
          TriggerRegisterDialogButtonEvent(buttonClickTrigger, dialogButton);
          TriggerAddAction(buttonClickTrigger, () => { gameModeVote.VoteCount += 1; });
          buttonClickTriggers.Add(buttonClickTrigger);
        }

        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
          DialogDisplay(player, dialog, true);

        GetExpiredTimer().Destroy();
        CreateTimer().Start(VoteLength, false, () => { ConcludeVote(dialog, buttonClickTriggers); });
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

      GetExpiredTimer().Destroy();
      DialogClear(dialog);

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        DisplayTextToPlayer(player, 0, 0, $"The {highestVotedGameMode.GameMode.Name} game mode has been chosen.");
        DialogDisplay(player, dialog, false);
      }
      
      foreach (var trigger in buttonClickTriggers)
        DestroyTrigger(trigger);
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
}