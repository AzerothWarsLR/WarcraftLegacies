using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameModes;
using MacroTools.GameTime;
using MacroTools.UserInterface;
using MacroTools.Utils;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.UserInterface;

public static class GameStartVoteSequence
{
  private static List<unit> _pausedUnits = new();

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
            CustomOptionsSelection.Setup(customOptionsVoteLength, ShowFactionChoicesThenFinish);
          }
          else
          {
            ShowFactionChoicesThenFinish();
          }
        });
      });
    });
  }

  private static void ShowFactionChoicesThenFinish()
  {
    FactionChoiceDialogSetup.Setup(() =>
    {
      if (HardModeSetting.EarlyGameSkipped)
      {
        HardModeSetting.ApplyToWildcardFactions();
      }

      FinishGameStart();
    });
  }

  private static void FinishGameStart()
  {
    FactionStartingResources.GrantPending();
    GameTimeManager.Start();
    GameTimeDialog.Setup();
    GameTimeManager.RegisterOnTurn(1, UnpauseAllUnits);
    DisplayIntroText.SetupWelcomeMessage(24);
    DisplayIntroText.SetupFactionIntroText(3);
  }

  public static void PauseUnit(unit whichUnit)
  {
    whichUnit.SetPausedEx(true);
    _pausedUnits.Add(whichUnit);
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
