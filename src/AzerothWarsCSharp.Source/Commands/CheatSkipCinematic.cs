using static War3Api.Common;
using static War3Api.Blizzard;
using AzerothWarsCSharp.Common.Constants;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat to skip all current cinematics by pressing Escape.
  /// </summary>
  public static class CheatSkipCinematic
  {
    private static void Actions() {
      if (CheatCommand.CanPlayerUseCheats(GetTriggerPlayer()))
      {
        CheatCommand.Display(GetTriggerPlayer(), "Skipping cinematics.");
        CinematicModeBJ(false, GetPlayersAll());
        DestroyTrigger(GetTriggeringTrigger());
      }
    }

    public static void Initialize() {
      var trig = CreateTrigger();
      for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
      {
        TriggerRegisterPlayerEventEndCinematic(trig, Player(i));
      }
      TriggerAddAction(trig, Actions);
    }

  }
}
