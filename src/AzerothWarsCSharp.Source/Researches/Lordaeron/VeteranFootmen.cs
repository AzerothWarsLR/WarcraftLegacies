// using AzerothWarsCSharp.MacroTools.FactionSystem;
// using AzerothWarsCSharp.Source.Setup.FactionSetup;
//
// using static War3Api.Common;  using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
// {
//   public class VeteranFootmen{
//
//   
//     private const int RESEARCH_ID = FourCC("R00B");
//   
//
//     private static void Research( ){
//       LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("hfoo"), -Faction.UNLIMITED)  ;//Footman
//       LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("h029"), Faction.UNLIMITED)   ;//Veteran Footman
//     }
//
//     public static void Setup( ){
//       RegisterResearchFinishedAction(RESEARCH_ID,  Research);
//     }
//
//   }
// }
