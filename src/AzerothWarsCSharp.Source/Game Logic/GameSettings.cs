using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Game_Logic
{
   public static class GameSettings
   {
      public static void Setup()
      {
         SetMapFlag(MAP_OBSERVERS, true);
         SetMapFlag(MAP_OBSERVERS_ON_DEATH, true);
      }
   }
}