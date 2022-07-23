using System.Data;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
   public static class NzothSetup
   {
      public static Faction? Nzoth { get; private set; }

      public static void Setup()
      {
         Nzoth = new Faction("N'zoth", null, null, null)
         {
            FoodMaximum = 40
         };
      }
   }
}