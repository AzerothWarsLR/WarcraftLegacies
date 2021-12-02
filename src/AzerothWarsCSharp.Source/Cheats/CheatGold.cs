using AzerothWarsCSharp.Source.Libraries.Commands;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Cheats
{
  /// <summary>
  /// A cheat to increase or decrease the user's gold.
  /// </summary>
  public static class CheatGold
  {
    public static void Setup()
    {
      var cheatGold = new CheatCommand("gold", (triggerPlayer, arguments) =>
      {
        if (int.TryParse(arguments[0], out var gold))
        {
          AdjustPlayerStateBJ(gold, triggerPlayer, PLAYER_STATE_RESOURCE_GOLD);
          CommandSystem.Display(triggerPlayer, "Granted " + arguments[0] + " gold.");
        }
      }
      );
      CommandSystem.Register(cheatGold);
    }
  }
}