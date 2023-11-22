// using static War3Api.Common;  using static MacroTools.GeneralHelpers;
// {
//   public class StormwindDies{
//
//     private static void Dies( ){
//       KillUnit( gg_unit_h055_0035 );
//       KillUnit( gg_unit_h053_1121 );
//       KillUnit( udg_HeadquartersORHall );
//       KillUnit( udg_SanctumORCathedral );
//       DestroyTrigger(GetTriggeringTrigger());
//     }
//
//     public static void Setup( ){
//       trigger trig = CreateTrigger();
//       TriggerRegisterUnitEvent(trig, gg_unit_h00X_0007, EVENT_UNIT_DEATH);
//       TriggerAddCondition(trig, ( Dies));
//     }
//
//   }
// }
