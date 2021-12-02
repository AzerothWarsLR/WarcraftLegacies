using AzerothWarsCSharp.Source.Libraries.Commands;
using WCSharp.Shared.Extensions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Cheats
{
  /// <summary>
  /// A cheat to increase or decrease the user's gold.
  /// </summary>
  public static class CheatHp
  {
    public static void Setup()
    {
      CommandSystem.Register(new CheatCommand("hp", (player triggerPlayer, string[] arguments) =>
      {
        if (int.TryParse(arguments[0], out var hp))
        {
          var tempGroup = CreateGroup();
          GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
          foreach (var u in tempGroup.Enumerate())
          {
            SetUnitState(u, UNIT_STATE_LIFE, hp);
          }

          DestroyGroup(tempGroup);
          CommandSystem.Display(triggerPlayer, "Setting health of selected units to " + arguments[0] + ".");
        }
      }));
    }
  }
}