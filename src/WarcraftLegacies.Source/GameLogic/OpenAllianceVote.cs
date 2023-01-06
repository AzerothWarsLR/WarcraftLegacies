using MacroTools.HintSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// Players can vote as to whether or not all players can freely ally.
  /// </summary>
  public static class OpenAllianceVote
  {
    private static readonly dialog? VoteDialogue = DialogCreate();
    private static readonly button? NoButton = DialogAddButton(VoteDialogue, "No", 0);
    private static readonly button? YesButton = DialogAddButton(VoteDialogue, "Yes", 0);
    private static readonly trigger? YesTrigger = CreateTrigger();
    private static readonly trigger? NoTrigger = CreateTrigger();
    private static int _voteCount;

    /// <summary>
    /// Whether or not all players can freely ally.
    /// </summary>
    public static bool AreAlliancesOpen { get; private set; }

    /// <summary>
    /// Sets up <see cref="OpenAllianceVote"/>.
    /// </summary>
    public static void Setup()
    {
      DialogSetMessage(VoteDialogue, "Activate open alliances?");
      var timer = CreateTimer();
      TimerStart(timer, 63, false, StartVote);
      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 72, false, ConcludeVote);
    }
    
    private static void ConcludeVote()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) 
        DialogDisplay(player, VoteDialogue, false);
      DialogClear(VoteDialogue);
      DialogDestroy(VoteDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);

      if (_voteCount > 0)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "Alliances are open!");
        Hint.Register(
          new Hint("You can change alliances by using the commands -invite, -uninvite, -join, and -unally."));
        AreAlliancesOpen = true;
      }
      else
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
          "Open alliances are disabled; only Quests can change your alliance.");
        Hint.Register(new Hint("You can't change alliances except through a select few Quests."));
        AreAlliancesOpen = false;
      }

      DestroyTimer(GetExpiredTimer());
    }

    private static void StartVote()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        DialogDisplay(player, VoteDialogue, true);
      }

      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      TriggerAddAction(noTrigger, () => { _voteCount--; });
      TriggerAddAction(yesTrigger, () => { _voteCount++; });
      DestroyTimer(GetExpiredTimer());
    }
  }
}