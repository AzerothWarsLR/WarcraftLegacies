using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.GameModes;
using MacroTools.UserInterface;
using MacroTools.Utils;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.UserInterface;

/// <summary>
/// Orchestrates the game-start vote sequence: the game mode vote, then the Custom Options vote, pausing every
/// unit in the world for the duration of both so nobody can start playing before they're settled.
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
        DifficultySelection.Setup(difficultyVoteLength, winningMode.ForcesOpenDiplomacy, customChosen =>
        {
          if (customChosen)
          {
            CustomOptionsSelection.Setup(customOptionsVoteLength, UnpauseAllUnits);
          }
          else
          {
            UnpauseAllUnits();
          }
        });
      });
    });
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
