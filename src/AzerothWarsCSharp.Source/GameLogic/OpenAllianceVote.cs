using AzerothWarsCSharp.MacroTools.HintSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.GameLogic
{
  public static class OpenAllianceVote
  {
    private static readonly dialog? VoteDialogue = DialogCreate();
    private static readonly button? YesButton = DialogAddButton(VoteDialogue, "Yes", 0);
    private static readonly button? NoButton = DialogAddButton(VoteDialogue, "No", 0);
    private static readonly trigger? YesTrigger = CreateTrigger();
    private static readonly trigger? NoTrigger = CreateTrigger();
    private static int _voteCount;

    public static bool AreAlliancesOpen { get; private set; }

    private static void ConcludeVote()
    {
      DialogClear(VoteDialogue);
      DestroyTrigger(YesTrigger);
      DestroyTrigger(NoTrigger);

      if (_voteCount > 0)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "Alliances are open!");
        Hint.Register(new Hint("You can change alliances by using the commands -invite, -uninvite, -join, and -unally."));
        AreAlliancesOpen = true;
      }
      else
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "Open alliances are disabled; only Quests can change your alliance.");
        Hint.Register(new Hint("You can't change alliances except through a select few Quests."));
        AreAlliancesOpen = false;
      }

      DestroyTimer(GetExpiredTimer());
    }
    
    private static void VoteYes()
    {
      _voteCount++;
    }

    private static void VoteNo()
    {
      _voteCount--;
    }
    
    private static void StartVote()
    {
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        DialogDisplay(player, VoteDialogue, true);
      }

      var yesTrigger = CreateTrigger();
      var noTrigger = CreateTrigger();
      TriggerRegisterDialogButtonEvent(yesTrigger, YesButton);
      TriggerRegisterDialogButtonEvent(noTrigger, NoButton);
      TriggerAddAction(yesTrigger, VoteYes);
      TriggerAddAction(noTrigger, VoteNo);
      DestroyTimer(GetExpiredTimer());
    }
    
    public static void Setup()
    {
      DialogSetMessage(VoteDialogue, "Activate open alliances?");
      var timer = CreateTimer();
      TimerStart(timer, 63, false, StartVote);
      var concludeTimer = CreateTimer();
      TimerStart(concludeTimer, 72, false, ConcludeVote);
    }
  }
}