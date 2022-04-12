using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatSpawn
  {
    private const string COMMAND = "-spawn ";
    private static string? _parameter;
    private static string? _parameter2;


    private static int Char2Id(string c)
    {
      var i = 0;
      const string abc = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

      while (true)
      {
        string t = SubString(abc, i, i + 1);
        if (t == null || t == c) break;
        i += 1;
      }

      if (i < 10)
        return i + 48;
      else if (i < 36)
        return i + 65 - 10;
      else
        return i + 97 - 36;
    }

    private static int S2Raw(string? s)
    {
      return ((Char2Id(SubString(s, 0, 1)) * 256 + Char2Id(SubString(s, 1, 2))) * 256 + Char2Id(SubString(s, 2, 3))) *
        256 + Char2Id(SubString(s, 3, 4));
    }

    private static void Spawn()
    {
      var i = 0;
      while (true)
      {
        if (i == S2I(_parameter2)) break;
        CreateUnit(GetTriggerPlayer(), S2Raw(_parameter), GetUnitX(GetEnumUnit()), GetUnitY(GetEnumUnit()), 0);
        CreateItem(S2Raw(_parameter), GetUnitX(GetEnumUnit()), GetUnitY(GetEnumUnit()));
        i += 1;
      }
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(COMMAND) + 4);
      _parameter2 = SubString(enteredString, StringLength(COMMAND) + StringLength(_parameter) + 1,
        StringLength(enteredString));

      if (S2I(_parameter2) < 1) _parameter2 = "1";

      if (S2Raw(_parameter) >= 0)
      {
        ForGroupBJ(GetUnitsSelectedAll(p), Spawn);
        DisplayTextToPlayer(p, 0, 0,
          "|cffD27575CHEAT:|r Attempted to spawn " + _parameter2 + " of object " + GetObjectName(S2Raw(_parameter)) +
          ".");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}