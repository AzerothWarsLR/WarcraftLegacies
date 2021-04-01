using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat to increase or decrease the user's food.
  /// </summary>
  public static class CheatFood
  {
    public static void Initialize()
    {
      CheatCommand.Register("food", (player triggerPlayer, string[] arguments) =>
      {
        if (int.TryParse(arguments[0], out int food))
        {
          AdjustPlayerStateBJ(food, triggerPlayer, PLAYER_STATE_RESOURCE_FOOD_CAP);
          CheatCommand.Display(triggerPlayer, "Granted " + arguments[0] + " food.");
        }
      }
      );
    }
  }
}