using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.UserInterface
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public abstract class ChoiceDialogPresenter<T>
  {
    protected readonly dialog? PickDialog = DialogCreate();
    protected readonly List<Choice<T>> Choices;
    protected bool HasChoiceBeenPicked = false;
    
    private readonly Dictionary<button, Choice<T>> _choicePicksByButton = new();
    private readonly List<trigger> _triggers = new();
    private readonly string _dialogText;
    
    /// <summary>Initializes a new instance of the <see cref="ChoiceDialogPresenter{T}"/> class.</summary>
    protected ChoiceDialogPresenter(Choice<T>[] choices, string dialogText)
    {
      foreach (var choice in choices)
      {
        var factionButton = DialogAddButton(PickDialog, choice.Name, 0);
        _choicePicksByButton[factionButton] = choice;
      }

      Choices = choices.ToList();
      _dialogText = dialogText;
    }

    /// <summary>Fired when a choice has been made.</summary>
    protected abstract void OnChoicePicked(player whichPlayer, Choice<T> choice);

    /// <summary>Invoked when a player fails to make a choice in time.</summary>
    protected abstract void OnChoiceExpired(player whichPlayer, Choice<T> defaultChoice);

    /// <summary>Displays the faction choice to a player.</summary>
    public void Run(player whichPlayer)
    {
      DialogSetMessage(PickDialog, _dialogText);

      var timer = CreateTimer();
      TimerStart(timer, 4, false, () =>
      {
        StartChoicePick(whichPlayer);
        DestroyTimer(GetExpiredTimer());
      });

      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 24, false, () =>
      {
        OnChoiceExpired(whichPlayer, Choices.First());
        DestroyTimer(GetExpiredTimer());
      });
    }

    private void StartChoicePick(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        DialogDisplay(GetLocalPlayer(), PickDialog, true);

      foreach (var (button, choice) in _choicePicksByButton)
      {
        var pickTrigger = CreateTrigger();
        TriggerRegisterDialogButtonEvent(pickTrigger, button);
        TriggerAddAction(pickTrigger, () =>
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

    protected void Dispose()
    {
      DialogClear(PickDialog);
      DialogDestroy(PickDialog);
      
      foreach (var trigger in _triggers)
        trigger.Destroy();
    }
  }
}