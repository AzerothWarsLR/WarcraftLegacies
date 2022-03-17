//If a unit with a tech limit of 0 is trained or revived, delete and refund it instantly.
public class RefundZeroLimitUnits{

  private static void VerifyUnitIntegrity(unit u ){
    player p = GetOwningPlayer(u);
    Person tempPerson = Person.ByHandle(p);
    UnitType tempUnitType = 0;
    if (tempPerson.GetObjectLimit(GetUnitTypeId(u)) == 0){
      tempUnitType = UnitType.ByHandle(u);
      if (tempUnitType != 0){
        AdjustPlayerStateSimpleBJ(p, PLAYER_STATE_RESOURCE_GOLD, tempUnitType.GoldCost);
        AdjustPlayerStateSimpleBJ(p, PLAYER_STATE_RESOURCE_LUMBER, tempUnitType.LumberCost);
      }
      RemoveUnit(u);
    }
    u = null;
    p = null;
  }

  private static void OnAnyUnitTrained( ){
    VerifyUnitIntegrity(GetTrainedUnit());
  }

  private static void OnAnyUnitRevived( ){
    VerifyUnitIntegrity(GetRevivingUnit());
  }

  private static void OnInit( ){
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH,  OnAnyUnitTrained);
    PlayerUnitEventAddAction(EVENT_PLAYER_HERO_REVIVE_FINISH,  OnAnyUnitRevived);
  }

}
