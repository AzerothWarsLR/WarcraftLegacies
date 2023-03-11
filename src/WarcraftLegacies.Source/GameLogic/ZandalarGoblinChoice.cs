using MacroTools.Cheats;
using MacroTools.Extensions;
using MacroTools.Frames;
using System;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// 
  /// </summary>
  public class ZandalarGoblinChoice : ILinkedTimer
  {
    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }

    private readonly dialog? PickDialogue;
    private readonly button? NoButton;
    private readonly button? YesButton;
    private readonly trigger? YesTrigger;
    private readonly trigger? NoTrigger;
    private readonly float _duration;
    private readonly GameSetupScreen _gameSetupScreen;
    private bool _factionPicked;
    private timer? _timer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="gameSetupScreen"></param>
    public ZandalarGoblinChoice(float duration, GameSetupScreen gameSetupScreen)
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

  public class GameSetupScreen : ILinkedTimer
  {
    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }

    private timer? _timer;
    private readonly dialog waitDialogue;
    private readonly float _duration;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="duration"></param>
    public GameSetupScreen(float duration)
    {
      waitDialogue = DialogCreate();
      _duration = duration;
      DialogSetMessage(waitDialogue, "Game is setting up");
      // Required to be able to test the map in single player because timers are halted
      // when dialogue is being displayed
      if (TestMode.AreCheatsActive)
      {
        DialogSetMessage(waitDialogue, "Game is in test mode");
        var closeButton  = DialogAddButton(waitDialogue, "Close", 0);
        var trigger = CreateTrigger();
        TriggerRegisterDialogButtonEvent(trigger, closeButton);
        TriggerAddAction(trigger, CloseDialogue);
      }
    }

    /// <inheritdoc/>
    public void StartTimer()
    {
      OpenDialogue();
      _timer = CreateTimer();
      TimerStart(_timer, _duration, false, CloseDialogue);
    }

    private void OpenDialogue()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        if (GetLocalPlayer() == player && player != Player(8))
          DialogDisplay(player, waitDialogue, true);
    }

    private void CloseDialogue()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        if (GetLocalPlayer() == player && player != Player(8))
          DialogDisplay(player, waitDialogue, false);

      DialogClear(waitDialogue);
      DialogDestroy(waitDialogue);
      DestroyTimer(_timer);
      OnTimerEnds?.Invoke(this, new EventArgs());
    }
  }

}
