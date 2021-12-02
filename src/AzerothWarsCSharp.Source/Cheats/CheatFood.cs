using AzerothWarsCSharp.Source.Libraries.Commands;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Cheats
{
  /// <summary>
  /// A cheat to increase or decrease the user's food.
  /// </summary>
  public static class CheatFood
  {
    public static void Setup()
    {
      CommandSystem.Register(new CheatCommand("food", (player triggerPlayer, string[] arguments) =>
      {
        if (int.TryParse(arguments[0], out var food))
        {
          AdjustPlayerStateBJ(food, triggerPlayer, PLAYER_STATE_RESOURCE_FOOD_CAP);
          CommandSystem.Display(triggerPlayer, "Granted " + arguments[0] + " food.");
        }
      }));
    }
  }
}