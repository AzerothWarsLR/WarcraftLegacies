using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatSpawn
  {
    private const string Command = "-spawn ";
    private static string? _parameter;
    private static string? _parameter2;

    private static void Spawn(unit whichUnit)
    {
      var i = 0;
      while (true)
      {
        if (i == S2I(_parameter2)) break;
        CreateUnit(GetTriggerPlayer(), FourCC(_parameter), GetUnitX(whichUnit), GetUnitY(whichUnit), 0);
        CreateItem(FourCC(_parameter), GetUnitX(whichUnit), GetUnitY(whichUnit));
        i += 1;
      }
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      var enteredString = GetEventPlayerChatString();
      var p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(Command), StringLength(Command) + 4);
      _parameter2 = SubString(enteredString, StringLength(Command) + StringLength(_parameter) + 1,
        StringLength(enteredString));

      if (S2I(_parameter2) < 1) _parameter2 = "1";

      if (FourCC(_parameter) < 0) return;
      foreach (var unit in new GroupWrapper().EnumSelectedUnits(p).EmptyToList())
      {
        Spawn(unit);
      }

      DisplayTextToPlayer(p, 0, 0,
        $"|cffD27575CHEAT:|r Attempted to spawn {_parameter2} of object {GetObjectName(FourCC(_parameter))}.");
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}