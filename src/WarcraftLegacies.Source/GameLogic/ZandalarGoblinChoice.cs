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
  public static class ZandalarGoblinChoiceDialogue
  {
    private static readonly dialog? PickDialogue = DialogCreate();
    private static readonly button? NoButton = DialogAddButton(PickDialogue, "Zandalari", 0);
    private static readonly button? YesButton = DialogAddButton(PickDialogue, "Goblins", 0);
    private static readonly trigger? YesTrigger = CreateTrigger();
    private static readonly trigger? NoTrigger = CreateTrigger();
    private static bool _factionPicked;

    /// <summary>
    /// Sets up <see cref="ZandalarGoblinChoiceDialogue"/>.
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
      if (GetLocalPlayer() == Player(8))
        DialogDisplay(GetLocalPlayer(), PickDialogue, false);
      DialogClear(PickDialogue);
      DialogDestroy(PickDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);
      DestroyTimer(GetExpiredTimer());

      if (_factionPicked)
      {
        PickZandalar();
      }
      else
      {
        PickGoblin();
      }
    }

    private static void StartFactionPick()
    {
      if (GetLocalPlayer() == Player(8))
        DialogDisplay(GetLocalPlayer(), PickDialogue, true);

      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      TriggerAddAction(noTrigger, () => { _factionPicked = true; });
      TriggerAddAction(yesTrigger, () => { _factionPicked = false; });
      DestroyTimer(GetExpiredTimer());
    }

    private static void PickZandalar()
    {
      var gobUnits = Regions.GoblinStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var zandaUnits = Regions.TrollStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(ZandalarSetup.Zandalar, zandaUnits);
      RemoveFaction(GoblinSetup.Goblin, gobUnits);
      if (GetLocalPlayer() == Player(8))
        SetCameraPosition(Regions.TrollStartPos.Center.X, Regions.TrollStartPos.Center.Y);
    }

    private static void PickGoblin()
    {
      var gobUnits = Regions.GoblinStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var zandaUnits = Regions.TrollStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AssignFaction(GoblinSetup.Goblin, gobUnits);
      RemoveFaction(ZandalarSetup.Zandalar, zandaUnits);
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
      Player(8).SetFaction(faction);
      Player(8).SetTeam(TeamSetup.Horde);
      Player(8).RescueGroup(units, true);
    }
  }
}
