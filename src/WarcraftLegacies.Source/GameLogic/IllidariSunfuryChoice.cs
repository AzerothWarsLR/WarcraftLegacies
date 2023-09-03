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
  /// A Dialogue where a player can choose between Zandalar and Goblin
  /// </summary>
  public static class IllidariSunfuryChoiceDialogue
  {
    private static readonly dialog? PickDialogue = DialogCreate();
    private static readonly button? NoButton = DialogAddButton(PickDialogue, "Sunfury", 0);
    private static readonly button? YesButton = DialogAddButton(PickDialogue, "Illidari", 0);
    private static readonly trigger? YesTrigger = CreateTrigger();
    private static readonly trigger? NoTrigger = CreateTrigger();
    private static bool _factionPicked;

    /// <summary>
    /// Sets up <see cref="IllidariSunfuryChoiceDialogue"/>.
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
      if (GetLocalPlayer() == Player(15))
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);
      DialogClear(PickDialogue);
      DialogDestroy(PickDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);
      DestroyTimer(GetExpiredTimer());

      if (_factionPicked)
      {
        PickSunfury();
      }
      else
      {
        PickIllidari();
      }
    }

    private static void StartFactionPick()
    {
      if (GetLocalPlayer() == Player(15))
        DialogDisplay(GetLocalPlayer(), PickDialogue, true);

      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      TriggerAddAction(noTrigger, () => { _factionPicked = true; });
      TriggerAddAction(yesTrigger, () => { _factionPicked = false; });
      DestroyTimer(GetExpiredTimer());
    }

    private static void PickSunfury()
    {
      var illidariUnits = Regions.IllidanStartingPosition.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var sunfuryUnits = Regions.SunfuryStartingPosition.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(SunfurySetup.Sunfury, sunfuryUnits);
      RemoveFaction(IllidariSetup.Illidari, illidariUnits);
      if (GetLocalPlayer() == Player(15))
        SetCameraPosition(Regions.SunfuryStartingPosition.Center.X, Regions.SunfuryStartingPosition.Center.Y);
    }

    private static void PickIllidari()
    {
      var illidariUnits = Regions.IllidanStartingPosition.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var sunfuryUnits = Regions.SunfuryStartingPosition.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(IllidariSetup.Illidari, illidariUnits);
      RemoveFaction(SunfurySetup.Sunfury, sunfuryUnits);
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
          unit.Remove();

        faction.Defeat();
      }
    }

    private static void AssignFaction(Faction faction, List<unit> units)
    {
      Player(15).SetFaction(faction);
      Player(15).SetTeam(TeamSetup.Outland);
      Player(15).RescueGroup(units, true);
    }
  }
}
