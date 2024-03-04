

namespace WarcraftLegacies.Source.GameLogic
{
   /// <summary>
   /// Responsible for managing basic game settings.
   /// </summary>
   public static class MapFlagSetup
   {
      /// <summary>
      /// Forces observers to be enabled.
      /// </summary>
      public static void Setup()
      {
         SetMapFlag(MAP_OBSERVERS, true);
         SetMapFlag(MAP_OBSERVERS_ON_DEATH, true);
         SetMapFlag(MAP_LOCK_RESOURCE_TRADING, true);
         SetMapFlag(MAP_LOCK_ALLIANCE_CHANGES, true);
      }
   }
}