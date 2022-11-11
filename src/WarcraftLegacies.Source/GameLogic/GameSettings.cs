using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
   /// <summary>
   /// Responsible for managing basic game settings.
   /// </summary>
   public static class GameSettings
   {
      /// <summary>
      /// Forces observers to be enabled.
      /// </summary>
      public static void Setup()
      {
         SetMapFlag(MAP_OBSERVERS, true);
         SetMapFlag(MAP_OBSERVERS_ON_DEATH, true);
      }
   }
}