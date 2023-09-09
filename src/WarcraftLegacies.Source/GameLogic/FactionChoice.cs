using System.Collections.Generic;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoice
  {
    private readonly dialog? _pickDialogue = DialogCreate();
    private readonly trigger? _yesTrigger = CreateTrigger();
    private readonly trigger? _noTrigger = CreateTrigger();
    private Dictionary<button, Faction> _factionPicksByButton = new();
    private bool _factionPicked;
    
    /// <summary>Initializes a new instance of the <see cref="FactionChoice"/> class.</summary>
    public FactionChoice(params Faction[] factionChoices)
    {
      foreach (var faction in factionChoices)
      {
        var factionButton = DialogAddButton(_pickDialogue, faction.Name, 0);
        _factionPicksByButton[factionButton] = faction;
      }
    }

    /// <summary>Displays the faction choice to a player.</summary>
    public void Run(player whichPlayer)
    {
      DialogSetMessage(_pickDialogue, "Pick your Faction");
      var timer = CreateTimer();
      TimerStart(timer, 4, false, StartFactionPick);
      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 24, false, ConcludeFactionPick);
    }
    
    private static void StartFactionPick()
    {
      if (GetLocalPlayer() == Player(7))
        DialogDisplay(GetLocalPlayer(), _pickDialogue, true);

      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(noTrigger, _noButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, _yesButton);
      TriggerAddAction(noTrigger, () => { _factionPicked = true; });
      TriggerAddAction(yesTrigger, () => { _factionPicked = false; });
      DestroyTimer(GetExpiredTimer());
    }
    
    private static void ConcludeFactionPick()
    {
      if (GetLocalPlayer() == Player(7))
        DialogDisplay(GetLocalPlayer(), _pickDialogue, false);
      DialogClear(_pickDialogue);
      DialogDestroy(_pickDialogue);
      DestroyTrigger(_yesTrigger);
      DestroyTrigger(_noTrigger);
      DestroyTimer(GetExpiredTimer());

      if (_factionPicked)
      {
        PickGilneas();
      }
      else
      {
        PickDala();
      }
    }
    
    private void PickFaction(Faction whichFaction, List<unit> startingUnits)
    {
      
    }

    private void RemoveFaction(Faction whichFaction, List<unit> startingUnits)
    {
      
    }
  }
}