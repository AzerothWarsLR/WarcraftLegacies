using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using System.Collections.Generic;
using System.Linq;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// A Dialogue where a player can choose between Forsaken and Legion
  /// </summary>
  public static class LegionForsakenChoiceDialogue
  {
    private static readonly dialog? PickDialogue = DialogCreate();
    //private static readonly button? NoButton = DialogAddButton(PickDialogue, "Cult", 0);
    private static readonly button? YesButton = DialogAddButton(PickDialogue, "Legion", 0);
    private static readonly trigger? YesTrigger = CreateTrigger();
    private static readonly trigger? NoTrigger = CreateTrigger();
    private static bool _factionPicked;

    /// <summary>
    /// Sets up <see cref="LegionForsakenChoiceDialogue"/>.
    /// </summary>
    public static void Setup()
    {
      DialogSetMessage(PickDialogue, "Pick your Faction");
      var timer = CreateTimer();
      TimerStart(timer, 4, false, StartFactionPick);
      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 24, false, ConcludeFactionPick);
    }

    private static void ConcludeFactionPick()
    {
      if (GetLocalPlayer() == Player(23))
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);
      DialogClear(PickDialogue);
      DialogDestroy(PickDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);
      DestroyTimer(GetExpiredTimer());

      if (_factionPicked)
      {
        PickForsaken();
      }
      else
      {
        PickLegion();
      }
    }

    private static void StartFactionPick()
    {
      if (GetLocalPlayer() == Player(23))
        DialogDisplay(GetLocalPlayer(), PickDialogue, true);

      var yesTrigger = CreateTrigger();
      //var noTrigger = CreateTrigger();
      //TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      //TriggerAddAction(noTrigger, () => { _factionPicked = true; });
      TriggerAddAction(yesTrigger, () => { _factionPicked = false; });
      DestroyTimer(GetExpiredTimer());
    }

    private static void PickForsaken()
    {
      var legionUnits = Regions.LegionStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var forsakenUnits = Regions.ForsakenStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(ForsakenSetup.Forsaken, forsakenUnits);
      RemoveFaction(LegionSetup.Legion, legionUnits);
      if (GetLocalPlayer() == Player(23))
        SetCameraPosition(Regions.ForsakenStartPos.Center.X, Regions.ForsakenStartPos.Center.Y);
    }

    private static void PickLegion()
    {
      var legionUnits = Regions.LegionStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var forsakenUnits = Regions.ForsakenStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(LegionSetup.Legion, legionUnits);
      RemoveFaction(ForsakenSetup.Forsaken, forsakenUnits);
    }

    private static void RemoveFaction(Faction faction, List<unit> units)
    {
      faction.RemoveGoldMines();
      foreach (var unit in units)
      {
        if (ControlPointManager.Instance.UnitIsControlPoint(unit))
        {
          unit.SetInvulnerable(false);
          unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
        }
        else
        {
          unit.Remove();
        }

        faction.Defeat();
      }
    }

    private static void AssignFaction(Faction faction, List<unit> units)
    {
      Player(23).SetFaction(faction);
      Player(23).SetTeam(TeamSetup.Legion);
      Player(23).RescueGroup(units, true);
    }
  }
}
