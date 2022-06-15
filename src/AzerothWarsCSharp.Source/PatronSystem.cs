using System;
using AzerothWarsCSharp.MacroTools;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source
{
   public static class PatronSystem
   {
      private static int TierToUnitType(PatronTier tier)
      {
         switch (tier)
         {
            case PatronTier.One:
               return Constants.UNIT_NHMC_PATRONS_FOOTMAN;
            case PatronTier.Two:
               return Constants.UNIT_NFRO_PATRONS_KNIGHT;
            case PatronTier.Three:
            default:
               throw new ArgumentOutOfRangeException(nameof(tier), tier, null);
         }
      }
      
      private static void SetupPatron(string name, PatronTier tier, Point position)
      {
         var unit = PreplacedUnitSystem.GetUnit(TierToUnitType(tier), position);
         BlzSetUnitName(unit, $"{name} - Tier {(int)tier} Patron");
      }

      private static void SetupPatron(string name, int unitTypeId)
      {
         var unit = PreplacedUnitSystem.GetUnit(unitTypeId);
         BlzSetUnitName(unit, $"{name} - Tier 3 Patron");
      }

      public static void Setup()
      {
         SetupPatron("owen wallace", PatronTier.One, new Point(0, 0));
         SetupPatron("Bogsnow", PatronTier.One, new Point(0, 0));
         SetupPatron("bredbrodak", PatronTier.Two, new Point(0, 0));
         SetupPatron("Kelzat", PatronTier.Two, new Point(0, 0));
         SetupPatron("Dromoka", PatronTier.Two, new Point(0, 0));
         SetupPatron("Menos", PatronTier.Two, new Point(0, 0));
         SetupPatron("Bocelot", PatronTier.Two, new Point(0, 0));
         SetupPatron("Eagleman", PatronTier.Two, new Point(0, 0));
         SetupPatron("Acroties", PatronTier.Two, new Point(0, 0));
         SetupPatron("Yubari", PatronTier.Two, new Point(0, 0));
         SetupPatron("Mr. Cash", FourCC("n0CS"));
         SetupPatron("Greenelf", Constants.UNIT_NPIG_PATRONS_TIER_3_1);
      }
   }
}