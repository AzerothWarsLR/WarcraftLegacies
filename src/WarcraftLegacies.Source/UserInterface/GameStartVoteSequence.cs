using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameModes;
using MacroTools.GameTime;
using MacroTools.UserInterface;
using MacroTools.Utils;
using WarcraftLegacies.Source.GameLogic;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.UserInterface;

/// <summary>
/// Orchestrates the game-start vote sequence: the game mode vote, then the Custom Options vote, pausing every
/// unit in the world for the duration of both so nobody can start playing before they're settled. The turn
/// timer doesn't start counting, and starting resources aren't handed out, until all of this has concluded -
/// see <see cref="FinishGameStart"/> - so difficulty settings decided here (e.g. Hard mode) can still affect
/// them instead of racing against an already-ticking clock.
/// </summary>
public static class GameStartVoteSequence
{
  private static List<unit> _pausedUnits = new();

  /// <summary>
  /// Shows the game-mode vote after <paramref name="timeToDisplay"/> seconds, then the Difficulty/Diplomacy
  /// vote once a mode has been chosen, then the Custom Options vote too if "Custom" won that, unpausing the
  /// game once everything has concluded.
  /// </summary>
  public static void Setup(IEnumerable<IGameMode> gameModes, float timeToDisplay, float modeVoteLength,
    float difficultyVoteLength, float customOptionsVoteLength)
  {
    timer.Create().Start(timeToDisplay, false, () =>
    {
      PauseAllUnits();

      GameModeSelection.Setup(gameModes, modeVoteLength, winningMode =>
      {
        DifficultySelection.Setup(difficultyVoteLength, winningMode.ForcesOpenDiplomacy, difficulty =>
        {
          if (difficulty == Difficulty.Hard)
          {
            HardModeSetting.Apply();
          }

          if (difficulty == Difficulty.Custom)
          {
            CustomOptionsSelection.Setup(customOptionsVoteLength, FinishGameStart);
          }
          else
          {
            FinishGameStart();
          }
        });
      });
    });
  }

  /// <summary>
  /// Everything that used to happen unconditionally at map init, now deferred until the vote sequence is
  /// actually done: hands out every faction's (possibly difficulty-adjusted) starting resources, starts the
  /// turn timer, and unpauses the world.
  /// </summary>
  private static void FinishGameStart()
  {
    FactionStartingResources.GrantPending();
    GameTimeManager.Start();
    GameTimeDialog.Setup();
    UnpauseAllUnits();
  }

  private static void PauseAllUnits()
  {
    _pausedUnits = GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds);
    foreach (var unit in _pausedUnits)
    {
      unit.SetPausedEx(true);
    }
  }

  private static void UnpauseAllUnits()
  {
    foreach (var unit in _pausedUnits)
    {
      unit.SetPausedEx(false);
    }

    _pausedUnits.Clear();
  }
}
