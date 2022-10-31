// using MacroTools.FactionSystem;
//
// using static War3Api.Common;  using static MacroTools.GeneralHelpers;
// {
//   public class TierReflectivePlating{
//
//     private static void Research( ){
//       StormwindSetup.Stormwind.ModObjectLimit(FourCC("h04C"),UNLIMITED)        ;//Bladesman
//       StormwindSetup.Stormwind.ModObjectLimit(FourCC("h02O"),-Faction.UNLIMITED)       ;//Militiaman
//       StormwindSetup.Stormwind.ModObjectLimit(FourCC("R030"), Faction.UNLIMITED)       ;//Code of Chivalry
//       StormwindSetup.Stormwind.ModObjectLimit(FourCC("R031"), Faction.UNLIMITED)       ;//Elven Refugees
//     }
//
//     public static void Setup( ){
//       RegisterResearchFinishedAction(FourCC("R02Z"),  Research);
//     }
//
//   }
// }
