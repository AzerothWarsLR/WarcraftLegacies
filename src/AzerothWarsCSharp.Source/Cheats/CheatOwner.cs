using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;
using WCSharp.Utils.Extensions;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat that changes the owner of selected units.
  /// </summary>
  public static class CheatOwner
  {
    public static void Initialize()
    {
      CheatCommand.Register("owner", (player triggerPlayer, string[] arguments) =>
      {
        if (int.TryParse(arguments[0], out int playerId))
        {
          var tempGroup = CreateGroup();
          GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
          foreach (unit u in tempGroup.Enumerate())
          {
            SetUnitOwner(u, Player(playerId), true);
          }
          DestroyGroup(tempGroup);
          CheatCommand.Display(triggerPlayer, "Setting owner of selected units to player in slot " + arguments[0] + ".");
        }
      }
      );
    }
  }
}