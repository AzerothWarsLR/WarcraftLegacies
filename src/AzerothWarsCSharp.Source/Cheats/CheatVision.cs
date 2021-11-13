//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using static War3Api.Blizzard;
//using System.Collections.Generic;
//using AzerothWarsCSharp.Common.Constants;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat that guves the player vision over the entire map.
//  /// </summary>
//  public static class CheatVision
//  {
//    public static void Initialize()
//    {
//      //Create cheat
//      CheatCommand.Register("vision", (player triggerPlayer, string[] arguments) =>
//      {
//        var toggleArg = arguments[1];
//        if (toggleArg == "on")
//        {
//          _fogModifiersByPlayer[triggerPlayer] = CreateFogModifierRectBJ(true, triggerPlayer, FOG_OF_WAR_VISIBLE, GetPlayableMapRect());
//          CheatCommand.Display(triggerPlayer, "Vision over whole map granted.");
//        }
//        else if (toggleArg == "off")
//        {
//          DestroyFogModifier(_fogModifiersByPlayer[triggerPlayer]);
//          _fogModifiersByPlayer[triggerPlayer] = null;
//          CheatCommand.Display(triggerPlayer, "Vision over whole map revoked.");
//        }
//      }
//      );
//    }

//    private static readonly Dictionary<player, fogmodifier> _fogModifiersByPlayer = new();
//  }
//}