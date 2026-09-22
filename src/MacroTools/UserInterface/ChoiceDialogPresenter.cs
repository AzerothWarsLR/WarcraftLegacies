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

  protected abstract void OnChoicePicked(player whichPlayer, TChoice choice);
  protected abstract TChoice GetDefaultChoice(player whichPlayer);
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

    timer timer = timer.Create();
    timer.Start(4, false, () =>
    {
      StartChoicePick(whichPlayer);
      @event.ExpiredTimer.Dispose();
    });

    var concludeTimer = timer.Create();
    concludeTimer.Start(24, false, () =>
    {
      ChoiceExpired(whichPlayer);
      @event.ExpiredTimer.Dispose();
    });
  }

  private void StartChoicePick(player whichPlayer)
  {
    // The buttons are titled through the translation table, and the table the local player picks is not known until
    // their settings have been read: with no loaded settings Loc.GetLanguage falls back to the client locale, which
    // is a different language from the one the player chose and, on a client whose locale the game does not report,
    // English. A button titled before that point therefore stays English for the whole dialog. The message already
    // waits for the settings, so the buttons are built in the same place and inherit the same guarantees.
    if (player.LocalPlayer == whichPlayer)
    {
      SaveManager.RunWhenLocalPlayerSettingsReady(() =>
      {
        var choicePicksByButton = new Dictionary<button, TChoice>();
        foreach (var choice in Choices.Where(x => IsChoiceActive(whichPlayer, x)))
        {
          var factionButton = _pickDialog.AddButton(Loc.Get(choice.Name), 0);
          choicePicksByButton[factionButton] = choice;
        }

        RegisterPickTriggers(whichPlayer, choicePicksByButton);
        _pickDialog?.SetMessage(Loc.Get(_dialogText));
        _pickDialog?.SetVisibility(player.LocalPlayer, true);
      });

      return;
    }

    var choicePicksByButton = new Dictionary<button, TChoice>();
    foreach (var choice in Choices.Where(x => IsChoiceActive(whichPlayer, x)))
    {
      var factionButton = _pickDialog.AddButton(Loc.Get(choice.Name), 0);
      choicePicksByButton[factionButton] = choice;
    }

    RegisterPickTriggers(whichPlayer, choicePicksByButton);
  }

  private void RegisterPickTriggers(player whichPlayer, Dictionary<button, TChoice> choicePicksByButton)
  {
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
