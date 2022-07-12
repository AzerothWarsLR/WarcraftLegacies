using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Game_Logic
{
   /// <summary>
   /// Display intro text to all players after some period of time has elapsed.
   /// </summary>
   public static class DisplayIntroText
   {
      private static void Display()
      {
         foreach (var player in GeneralHelpers.GetAllPlayers())
         {
            DisplayTextToPlayer(player, 0, 0, player.GetFaction()?.IntroText);
         }
         DestroyTimer(GetExpiredTimer());
      }
      
      public static void Setup(float timeout)
      {
         var timer = CreateTimer();
         TimerStart(timer, timeout, false, Display);
      }
   }
}