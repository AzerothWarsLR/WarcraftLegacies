using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoiceDialogPresenter
  {
    private readonly dialog? _pickDialogue = DialogCreate();
    private readonly Dictionary<button, Faction> _factionPicksByButton = new();
    private Faction? _pickedFaction;
    private readonly List<Faction> _factionChoices;

    /// <summary>Initializes a new instance of the <see cref="FactionChoiceDialogPresenter"/> class.</summary>
    public FactionChoiceDialogPresenter(params Faction[] factionChoices)
    {
      foreach (var faction in factionChoices)
      {
        var factionButton = DialogAddButton(_pickDialogue, faction.Name, 0);
        _factionPicksByButton[factionButton] = faction;
      }
      _factionChoices = factionChoices.ToList();
    }

    /// <summary>Displays the faction choice to a player.</summary>
    public void Run(player whichPlayer)
    {
      DialogSetMessage(_pickDialogue, "Pick your Faction");
      
      var timer = CreateTimer();
      TimerStart(timer, 4, false, () =>
      {
        StartFactionPick(whichPlayer);
      });
      
      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 24, false, () =>
      {
        ConcludeFactionPick(whichPlayer);
        DestroyTimer(GetExpiredTimer());
      });
    }
    
    private void StartFactionPick(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        DialogDisplay(GetLocalPlayer(), _pickDialogue, true);
      
      foreach (var (button, faction) in _factionPicksByButton)
      {
        var pickTrigger = CreateTrigger();
        TriggerRegisterDialogButtonEvent(pickTrigger, button);
        TriggerAddAction(pickTrigger, () =>
        {
          _pickedFaction = faction;
        });
        GetTriggeringTrigger().Destroy();
      }
      DestroyTimer(GetExpiredTimer());
    }
    
    private void ConcludeFactionPick(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        DialogDisplay(GetLocalPlayer(), _pickDialogue, false);
      
      DialogClear(_pickDialogue);
      DialogDestroy(_pickDialogue);
      
      if (_pickedFaction != null)
        PickFaction(_pickedFaction, new List<unit>());
      
      foreach (var unpickedFaction in _factionChoices)
        RemoveFaction(unpickedFaction, new List<unit>());
    }
    
    private void PickFaction(Faction whichFaction, List<unit> startingUnits)
    {
      
    }

    private void RemoveFaction(Faction whichFaction, List<unit> startingUnits)
    {
      
    }
  }
}