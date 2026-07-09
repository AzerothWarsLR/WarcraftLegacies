using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Localization;
using MacroTools.Save;

namespace MacroTools.UserInterface;

/// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
public abstract class ChoiceDialogPresenter<TChoice> where TChoice : IChoice
{
  private readonly dialog? _pickDialog = dialog.Create();
  protected readonly List<TChoice> Choices;
  protected bool HasChoiceBeenPicked = false;

  private readonly List<trigger> _triggers = new();
  private readonly string _dialogText;

  /// <summary>Initializes a new instance of the <see cref="ChoiceDialogPresenter{T}"/> class.</summary>
  protected ChoiceDialogPresenter(TChoice[] choices, string dialogText)
  {
    Choices = choices.ToList();
    _dialogText = dialogText;
  }

  /// <summary>Fired when a choice has been made.</summary>
  protected abstract void OnChoicePicked(player whichPlayer, TChoice choice);

  /// <summary>The default choice for this presenter, if the player picks nothing by the time it expires.</summary>
  protected abstract TChoice GetDefaultChoice(player whichPlayer);

  /// <summary>
  /// Determines whether a choice is active for the player it is being presented to. Inactive choices are not shown.
  /// </summary>
  protected abstract bool IsChoiceActive(player whichPlayer, TChoice choice);

  /// <summary>Displays the faction choice to a player.</summary>
  public void Run(player whichPlayer)
  {
    var activeChoices = Choices.Where(x => IsChoiceActive(whichPlayer, x));

    if (activeChoices.Count() == 1)
    {
      OnChoicePicked(whichPlayer, GetDefaultChoice(whichPlayer));
      return;
    }

    var choicePicksByButton = new Dictionary<button, TChoice>();
    foreach (var choice in Choices.Where(x => IsChoiceActive(whichPlayer, x)))
    {
      var factionButton = _pickDialog.AddButton(Loc.Get(choice.Name), 0);
      choicePicksByButton[factionButton] = choice;
    }

    timer timer = timer.Create();
    timer.Start(4, false, () =>
    {
      StartChoicePick(whichPlayer, choicePicksByButton);
      @event.ExpiredTimer.Dispose();
    });

    var concludeTimer = timer.Create();
    concludeTimer.Start(24, false, () =>
    {
      ChoiceExpired(whichPlayer);
      @event.ExpiredTimer.Dispose();
    });
  }

  private void StartChoicePick(player whichPlayer, Dictionary<button, TChoice> choicePicksByButton)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      // SetMessage and SetVisibility(true) must land in the same call, together, gated on the same
      // RunWhenLocalPlayerSettingsReady check - WC3 dialogs don't visually update SetMessage calls that land
      // after SetVisibility(true), so if the two were awaited separately (as before), a message set later than
      // the dialog's visibility could silently render blank forever once the dialog is already on screen. Waiting
      // here still matters: this dialog appears on a fixed 4-second timer, well before the local player's language
      // is guaranteed to have finished auto-detecting.
      SaveManager.RunWhenLocalPlayerSettingsReady(() =>
      {
        _pickDialog?.SetMessage(Loc.Get(_dialogText));
        _pickDialog?.SetVisibility(player.LocalPlayer, true);
      });
    }

    foreach (var (button, choice) in choicePicksByButton)
    {
      var pickTrigger = trigger.Create();
      pickTrigger.RegisterButtonEvent(button);
      pickTrigger.AddAction(() =>
      {
        try
        {
          OnChoicePicked(whichPlayer, choice);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex);
        }
      });

      _triggers.Add(pickTrigger);
    }
  }

  private void ChoiceExpired(player whichPlayer)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      _pickDialog.SetVisibility(player.LocalPlayer, false);
    }

    if (!HasChoiceBeenPicked)
    {
      OnChoicePicked(whichPlayer, GetDefaultChoice(whichPlayer));
    }

    _pickDialog.Clear();
    _pickDialog.Dispose();

    foreach (var trigger in _triggers)
    {
      trigger.Dispose();
    }
  }
}
