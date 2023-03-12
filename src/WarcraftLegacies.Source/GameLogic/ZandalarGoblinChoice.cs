using MacroTools.Extensions;
using System;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
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
    private readonly GameSetupDialogue _gameSetupScreen;
    private bool _factionPicked;
    private timer? _timer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="gameSetupScreen">This starts playing at the same time as <see cref="ZandalarGoblinChoiceDialogue"/></param>
    public ZandalarGoblinChoiceDialogue(float duration, GameSetupDialogue gameSetupScreen)
    {
      _gameSetupScreen = gameSetupScreen;
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
      _gameSetupScreen.StartTimer();
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
        PickGoblin();
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
      Player(8).SetFaction(ZandalarSetup.Zandalar);
      Player(8).SetTeam(TeamSetup.Horde);
      _factionPicked = true;
      ConcludeFactionPick();
    }

    private void PickGoblin()
    {
      Player(8).SetFaction(GoblinSetup.Goblin);
      Player(8).SetTeam(TeamSetup.Horde);
      _factionPicked = true;
      ConcludeFactionPick();
    }
  }
}
