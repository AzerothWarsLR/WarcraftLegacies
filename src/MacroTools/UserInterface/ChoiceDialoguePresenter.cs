using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public class ChoiceDialoguePresenter
  {
    //Ensures choice dialogs are kept in memory until they're done.
    private readonly List<ChoiceDialoguePresenter> _activeChoices = new ();
    
    protected readonly dialog? PickDialogue = DialogCreate();
    private readonly Dictionary<button, string> _choicePicksByButton = new();
    protected readonly List<string> Choices;
    private readonly List<trigger> _triggers = new();
    private readonly string _dialogueTxt;
    protected bool HasChoiceBeenPicked = false;

    /// <summary>Initializes a new instance of the <see cref="ChoiceDialoguePresenter"/> class.</summary>
    protected ChoiceDialoguePresenter(string[] choices, string dialogueTxt)
    {
      foreach (var choice in choices)
      {
        var factionButton = DialogAddButton(PickDialogue, choice, 0);
        _choicePicksByButton[factionButton] = choice;
      }
      Choices = choices.ToList();
      _dialogueTxt = dialogueTxt;
    }
    
    public event EventHandler<ChoiceDialoguePresenterEventArgs>? ChoicePicked;
    
    public event EventHandler<ChoiceDialoguePresenterEventArgs>? ChoiceExpired;

    /// <summary>Displays the faction choice to a player.</summary>
    public void Run(player whichPlayer)
    {
      _activeChoices.Add(this);
      DialogSetMessage(PickDialogue, _dialogueTxt);
      
      var timer = CreateTimer();
      TimerStart(timer, 4, false, () =>
      {
        StartChoicePick(whichPlayer);
        DestroyTimer(GetExpiredTimer());
      });
      
      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 24, false, () =>
      {
        ChoiceExpired?.Invoke(this, new ChoiceDialoguePresenterEventArgs(whichPlayer,Choices.First()));
        DestroyTimer(GetExpiredTimer());
      });
    }
    
    private void StartChoicePick(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        DialogDisplay(GetLocalPlayer(), PickDialogue, true);
      
      foreach (var (button, choice) in _choicePicksByButton)
      {
        var pickTrigger = CreateTrigger();
        TriggerRegisterDialogButtonEvent(pickTrigger, button);
        TriggerAddAction(pickTrigger, () =>
        {
          try
          {
            ChoicePicked?.Invoke(this,new ChoiceDialoguePresenterEventArgs(whichPlayer,choice));
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
      if (!_activeChoices.Contains(this))
        return;

      DialogClear(PickDialogue);
      DialogDestroy(PickDialogue);

      _activeChoices.Remove(this);
      foreach (var trigger in _triggers)
        trigger.Destroy();
    }
  }
}