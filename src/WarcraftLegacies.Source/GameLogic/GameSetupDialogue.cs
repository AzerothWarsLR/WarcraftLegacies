using MacroTools.Cheats;
using MacroTools.Timer;
using System;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// A Dialog that players see until <see cref="ZandalarGoblinChoiceDialogue"/> has been resolved
  /// </summary>
  public class GameSetupDialogue : ITimer
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
    public GameSetupDialogue(float duration)
    {
      waitDialogue = DialogCreate();
      _duration = duration;
      DialogSetMessage(waitDialogue, "|nGame is setting up");
      // Required to be able to test the map in single player because timers are halted
      // when dialogue is being displayed so the ZandalarGoblinChoiceDialogue never resolves
      if (TestMode.AreCheatsActive)
      {
        DialogSetMessage(waitDialogue, "|nGame is in test mode");
        var closeButton  = DialogAddButton(waitDialogue, "Ok", 0);
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
