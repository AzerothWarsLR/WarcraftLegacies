using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
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

      var unitsToTransfer = CreateGroup().EnumUnitsInRect(Regions.TrollStartPos).EmptyToList();
      foreach (var unit in unitsToTransfer)
      {
        unit.SetOwner(Player(PLAYER_NEUTRAL_PASSIVE));
      }

      Player(8).SetFaction(GoblinSetup.Goblin);
      Player(8).SetTeam(TeamSetup.Horde);
      RemoveFaction(GoblinSetup.Goblin, Regions.GoblinStartPos);

      Player(8).SetFaction(ZandalarSetup.Zandalar);
      Player(8).SetTeam(TeamSetup.Horde);
      foreach (var unit in CreateGroup().EnumUnitsInRect(Regions.TrollStartPos).EmptyToList())
      {
        unit.SetOwner(Player(8));
      }
      _factionPicked = true;
      ConcludeFactionPick();
    }

    private void PickGoblin()
    {
      var unitsToTransfer = CreateGroup().EnumUnitsInRect(Regions.GoblinStartPos).EmptyToList();
      foreach (var unit in unitsToTransfer)
      {
        unit.SetOwner(Player(PLAYER_NEUTRAL_PASSIVE));
        Console.WriteLine($"unit {unit.GetProperName()} transferred to {unit.OwningPlayer()}");
      }

      Player(8).SetFaction(ZandalarSetup.Zandalar);
      Player(8).SetTeam(TeamSetup.Horde);
      RemoveFaction(ZandalarSetup.Zandalar, Regions.TrollStartPos);

      Player(8).SetFaction(GoblinSetup.Goblin);
      Player(8).SetTeam(TeamSetup.Horde);
      foreach (var unit in unitsToTransfer)
      {
        unit.SetOwner(Player(8));
        Console.WriteLine($"unit{unit.GetProperName()} transferred to {unit.OwningPlayer()}");
      }
      _factionPicked = true;
      ConcludeFactionPick();
    }

    private void RemoveFaction(Faction faction, Rectangle rect)
    {
      foreach (var unit in CreateGroup().EnumUnitsInRect(rect).EmptyToList())
      {
        if (ControlPointManager.Instance.UnitIsControlPoint(unit))
        {
          SetUnitOwner(unit, Player(GetBJPlayerNeutralVictim()), true);
          Console.WriteLine($"unit{unit.GetProperName()} transferred to {unit.OwningPlayer()}");
        }
        else
        {
          RemoveUnit(unit);
          Console.WriteLine($"removed unit {unit.GetProperName()}");
        }
      }

      faction.Leave();
    }
  }
}
