using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;
using WCSharp.Utils.Extensions;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat to increase or decrease the user's gold.
  /// </summary>
  public static class CheatMP
  {
    public static void Initialize()
    {
      CheatCommand.Register("mp", (player triggerPlayer, string[] arguments) =>
      {
        if (int.TryParse(arguments[0], out int hp))
        {
          var tempGroup = CreateGroup();
          GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
          foreach (unit u in tempGroup.Enumerate())
          {
            SetUnitState(u, UNIT_STATE_MANA, hp);
          }
          DestroyGroup(tempGroup);
          CheatCommand.Display(triggerPlayer, "Setting mana of selected units to " + arguments[0] + ".");
        }
      }
      );
    }
  }
}