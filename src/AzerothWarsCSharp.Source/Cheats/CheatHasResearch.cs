using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Cheats
{
  public static class CheatHasResearch
  {
    private const string COMMAND = "-hasresearch ";

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

      return i switch
      {
        < 10 => i + 48,
        < 36 => i + 65 - 10,
        _ => i + 97 - 36
      };
    }

    private static int S2Raw(string s)
    {
      return ((Char2Id(SubString(s, 0, 1)) * 256 + Char2Id(SubString(s, 1, 2))) * 256 + Char2Id(SubString(s, 2, 3))) *
        256 + Char2Id(SubString(s, 3, 4));
    }

    private static void CheckResearch(player p, string parameter)
    {
      var obj = S2Raw(parameter);
      DisplayTextToPlayer(p, 0, 0,
        "|cffD27575CHEAT:|r Level of research " + GetObjectName(obj) + ": " + I2S(GetPlayerTechCount(p, obj, true)));
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      CheckResearch(GetTriggerPlayer(), parameter);
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}