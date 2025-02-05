using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.UserInterface
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public abstract class ChoiceDialogPresenter<TChoice> where TChoice : IChoice
  {
    private readonly dialog? _pickDialog = DialogCreate();
    protected readonly List<TChoice> Choices;
    protected bool HasChoiceBeenPicked = false;
    
    private readonly Dictionary<button, TChoice> _choicePicksByButton = new();
    private readonly List<trigger> _triggers = new();
    private readonly string _dialogText;
    
    /// <summary>Initializes a new instance of the <see cref="ChoiceDialogPresenter{T}"/> class.</summary>
    protected ChoiceDialogPresenter(TChoice[] choices, string dialogText)
    {
      foreach (var choice in choices)
      {
        var factionButton = DialogAddButton(_pickDialog, choice.Name, 0);
        _choicePicksByButton[factionButton] = choice;
      }

      Choices = choices.ToList();
      _dialogText = dialogText;
    }

    /// <summary>Fired when a choice has been made.</summary>
    protected abstract void OnChoicePicked(player whichPlayer, TChoice choice);

    /// <summary>The default choice for this presenter, if the player picks nothing by the time it expires.</summary>
    protected abstract TChoice GetDefaultChoice(player whichPlayer);

    /// <summary>Displays the faction choice to a player.</summary>
    public void Run(player whichPlayer)
    {
      DialogSetMessage(_pickDialog, _dialogText);

      var timer = CreateTimer();
      TimerStart(timer, 4, false, () =>
      {
        StartChoicePick(whichPlayer);
        DestroyTimer(GetExpiredTimer());
      });

      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 24, false, () =>
      {
        ChoiceExpired(whichPlayer);
        DestroyTimer(GetExpiredTimer());
      });
    }

    private void StartChoicePick(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        DialogDisplay(GetLocalPlayer(), _pickDialog, true);

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
    
    private void ChoiceExpired(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        DialogDisplay(GetLocalPlayer(), _pickDialog, false);

      if (!HasChoiceBeenPicked)
        OnChoicePicked(whichPlayer, GetDefaultChoice(whichPlayer));
      
      DialogClear(_pickDialog);
      DialogDestroy(_pickDialog);
      
      foreach (var trigger in _triggers)
        trigger.Destroy();
    }
  }
}