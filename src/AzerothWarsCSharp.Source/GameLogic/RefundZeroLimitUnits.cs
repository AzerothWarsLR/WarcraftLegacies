//using static War3Api.Common;
//using static War3Api.Blizzard;
//using AzerothWarsCSharp.Source.Libraries;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  public static class RefundZeroLimitUnits
//  {
//    private static void OnAnyUnitTrained()
//    {
//      var trainedUnit = GetTrainedUnit();
//      var owningPlayer = GetOwningPlayer(trainedUnit);
//      var tempFaction = Faction.ByPlayerHandle(owningPlayer);
//      if (tempFaction.GetObjectLimit(GetUnitTypeId(trainedUnit)) == 0)
//      {
//        var unitTypeId = GetUnitTypeId(trainedUnit);
//        AdjustPlayerStateSimpleBJ(owningPlayer, PLAYER_STATE_RESOURCE_GOLD, GetUnitGoldCost(unitTypeId));
//        AdjustPlayerStateSimpleBJ(owningPlayer, PLAYER_STATE_RESOURCE_LUMBER, GetUnitWoodCost(unitTypeId));
//      }
//      RemoveUnit(trainedUnit);
//    }

//    public static void Initialize()
//    {
//      var trig = CreateTrigger();
//      TriggerRegisterAnyUnitEventBJ(trig, EVENT_PLAYER_UNIT_TRAIN_FINISH);
//      TriggerAddAction(trig, OnAnyUnitTrained);
//    }
//  }
//}