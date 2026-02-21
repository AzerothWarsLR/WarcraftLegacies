using System;

namespace MacroTools.GameTime;

public static class GameTimeDialog
{
  private static timerdialog? _timerDialog;

  /// <summary>
  /// Creates the game time dialog and registers it with the turn manager.
  /// </summary>
  /// <exception cref="InvalidOperationException">
  /// Thrown if the dialog has already been initialized.
  /// </exception>
  /// <remarks>
  /// The dialog display is delayed to avoid conflicts with the multiboard initialization.
  /// </remarks>
  public static void Setup()
  {
    if (_timerDialog != null)
    {
      throw new InvalidOperationException("The game time dialog has already been initialized.");
    }

    _timerDialog = GameTimeManager.CreateDialog();

    // This must be after the Multiboard is shown or the Multiboard will break.
    var delayedDisplayTimer = timer.Create();
    delayedDisplayTimer.Start(2, false, () =>
    {
      _timerDialog.IsDisplayed = true;
      _timerDialog.SetTitle("Game starts in:");
      delayedDisplayTimer.Dispose();
    });

    GameTimeManager.TurnEnded += (_, _) => _timerDialog.SetTitle($"Turn {GameTimeManager.GetTurn()}");
  }
}
