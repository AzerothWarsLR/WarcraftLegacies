using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.Timer;
using System;
using System.Collections.Generic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static System.Collections.Specialized.BitVector32;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// A Dialogue where a player can choose between Zandalar and Goblin
  /// </summary>
  public class ZandalarGoblinChoiceDialogue : ITimer
  {
    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }

    private readonly dialog? PickDialogue;
    private readonly button? NoButton;
    private readonly button? YesButton;
    private readonly trigger? YesTrigger;
    private readonly trigger? NoTrigger;
    private readonly float _duration;

    private bool _factionPicked;
    private timer? _timer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="duration"></param>
    public ZandalarGoblinChoiceDialogue(float duration)
    {

      PickDialogue = DialogCreate();
      NoButton = DialogAddButton(PickDialogue, "Zandalari", 0);
      YesButton = DialogAddButton(PickDialogue, "Goblins", 0);
      YesTrigger = CreateTrigger();
      NoTrigger = CreateTrigger();
      _duration = duration;
      DialogSetMessage(PickDialogue, "Pick your Faction");

    }

    /// <inheritdoc/>
    public void StartTimer()
    {
      StartFactionPick();
      _timer = CreateTimer();
      TimerStart(_timer, _duration, false, ConcludeFactionPick);
    }

    private void StartFactionPick()
    {
      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      TriggerAddAction(noTrigger, PickZandalar);
      TriggerAddAction(yesTrigger, PickGoblin);

      DialogDisplay(Player(8), PickDialogue, true);
    }

    private void ConcludeFactionPick()
    {
      if (!_factionPicked)
      {
        PickZandalar();
        return;
      }

      DialogDisplay(Player(8), PickDialogue, false);

      DialogClear(PickDialogue);
      DialogDestroy(PickDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);
      DestroyTimer(_timer);
      OnTimerEnds?.Invoke(this, new EventArgs());
    }

    private void PickZandalar()
    {
      var gobUnits = Regions.GoblinStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var zandaUnits = Regions.TrollStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      RemoveFaction(GoblinSetup.Goblin, gobUnits);
      AssignFaction(ZandalarSetup.Zandalar, zandaUnits);
      SetCameraPosition(Regions.TrollStartPos.Center.X, Regions.TrollStartPos.Center.Y);
      _factionPicked = true;
      ConcludeFactionPick();
    }

    private void PickGoblin()
    {
      var gobUnits = Regions.GoblinStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      var zandaUnits = Regions.TrollStartPos.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      RemoveFaction(ZandalarSetup.Zandalar, zandaUnits);
      AssignFaction(GoblinSetup.Goblin, zandaUnits);
      _factionPicked = true;
      ConcludeFactionPick();
    }

    private static void RemoveFaction(Faction faction, List<unit> gobUnits)
    {
      faction.ScoreStatus = ScoreStatus.Defeated;
      faction.RemoveGoldMines();
      foreach (var unit in gobUnits)
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
