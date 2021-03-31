using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;
using WCSharp.Utils.Extensions;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat to remove selected units outright.
  /// </summary>
  public static class CheatRemove
  {
    public static void Initialize()
    {
      CheatCommand.Register("remove", (player triggerPlayer, string[] arguments) =>
      {
        CheatCommand.Display(triggerPlayer, "Removing selected units.");
        var tempGroup = CreateGroup();
        GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
        foreach (unit u in tempGroup.Enumerate())
        {
          RemoveUnit(u);
        }
        DestroyGroup(tempGroup);
      }
      );
    }
  }
}