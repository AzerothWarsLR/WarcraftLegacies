//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to spawn units with a specific ID.
//  /// </summary>
//  public static class CheatSpawn
//  {
//    private static int Char2Id(string c)
//    {
//      var i = 0;
//      var abc = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
//      string t;

//      while (true)
//      {
//        t = SubString(abc, i, i + 1);
//        i++;
//        if (t == null || t == c)
//        {
//          break;
//        }
//      }

//      if (i < 10)
//      {
//        return i + 48;
//      }
//      else if (i < 36)
//      {
//        return i + 65 - 10;
//      }
//      return i + 97 - 36;
//    }

//    private static int ToRaw(this string s)
//    {
//      return ((Char2Id(SubString(s, 0, 1)) * 256 + Char2Id(SubString(s, 1, 2))) * 256 + Char2Id(SubString(s, 2, 3))) * 256 + Char2Id(SubString(s, 3, 4));
//    }

//    public static void Initialize()
//    {
//      CheatCommand.Register("spawn", (player triggerPlayer, string[] arguments) =>
//      {
//        var unitTypeStr = arguments[0];
//        _ = int.TryParse(arguments[1], out int count);
//        if (count < 0)
//        {
//          count = 1;
//        }
//        var unitType = unitTypeStr.ToRaw();
//        var tempGroup = CreateGroup();
//        GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
//        var firstSelected = FirstOfGroup(tempGroup);
//        DestroyGroup(tempGroup);
//        for (var i = 0; i < count; i++)
//        {
//          CreateUnit(triggerPlayer, unitType, GetUnitX(firstSelected), GetUnitY(firstSelected), 0);
//        }
//        CheatCommand.Display(triggerPlayer, "Spawned " + count.ToString() + " units of type " + GetObjectName(unitType));
//      }
//      );
//    }
//  }
//}