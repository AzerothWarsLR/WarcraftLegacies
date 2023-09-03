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
  /// A Dialogue where a player can choose between Gilneas and Quel
  /// </summary>
  public static class DalaGilneasChoiceDialogue
  {
    private static readonly dialog? PickDialogue = DialogCreate();
    private static readonly button? NoButton = DialogAddButton(PickDialogue, "Gilneas", 0);
    private static readonly button? YesButton = DialogAddButton(PickDialogue, "Dalaran", 0);
    private static readonly trigger? YesTrigger = CreateTrigger();
    private static readonly trigger? NoTrigger = CreateTrigger();
    private static bool _factionPicked;

    /// <summary>
    /// Sets up <see cref="DalaGilneasChoiceDialogue"/>.
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
      if (GetLocalPlayer() == Player(7))
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);
      DialogClear(PickDialogue);
      DialogDestroy(PickDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);
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

    private static void StartFactionPick()
    {
      if (GetLocalPlayer() == Player(7))
        DialogDisplay(GetLocalPlayer(), PickDialogue, true);

      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      TriggerAddAction(noTrigger, () => { _factionPicked = true; });
      TriggerAddAction(yesTrigger, () => { _factionPicked = false; });
      DestroyTimer(GetExpiredTimer());
    }

    private static void PickGilneas()
    {
      var dalaUnits = Regions.DalaStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var gilneasUnits = Regions.GilneasStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(GilneasSetup.Gilneas, gilneasUnits);
      RemoveFaction(DalaranSetup.Dalaran, dalaUnits);
      if (GetLocalPlayer() == Player(7))
        SetCameraPosition(Regions.GilneasStartPos.Center.X, Regions.GilneasStartPos.Center.Y);
    }

    private static void PickDala()
    {
      var dalaUnits = Regions.DalaStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var gilneasUnits = Regions.GilneasStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(DalaranSetup.Dalaran, dalaUnits);
      RemoveFaction(GilneasSetup.Gilneas, gilneasUnits);
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
      Player(7).SetFaction(faction);
      Player(7).SetTeam(TeamSetup.NorthAlliance);
      Player(7).RescueGroup(units, true);
    }
  }
}
