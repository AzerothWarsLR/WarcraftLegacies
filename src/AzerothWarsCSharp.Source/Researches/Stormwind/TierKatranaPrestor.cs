// using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
// {
//   public class TierKatranaPrestor{
//
//   
//     private const int DEMI_UNITTYPE_ID = FourCC("n06F");
//   
//
//     private static void Research( ){
//       CreateUnit(StormwindSetup.Stormwind.Player, DEMI_UNITTYPE_ID, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), 0);
//     }
//
//     public static void Setup( ){
//       RegisterResearchFinishedAction(FourCC("R03Y"),  Research);
//       StormwindSetup.Stormwind.ModObjectLimit(DEMI_UNITTYPE_ID, 1);
//     }
//
//   }
// }
