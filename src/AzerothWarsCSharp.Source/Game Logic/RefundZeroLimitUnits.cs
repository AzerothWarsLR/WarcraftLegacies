using AzerothWarsCSharp.Source.Libraries.MacroTools;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  /// <summary>
  /// If a unit with a tech limit of 0 is trained or revived, delete and refund it instantly.
  /// </summary>
  public static class RefundZeroLimitUnits
  {
    private static void VerifyUnitIntegrity(unit whichUnit)
    {
      var player = GetOwningPlayer(whichUnit);
      var tempPerson = Person.ByHandle(player);
      if (tempPerson != null && tempPerson.GetObjectLimit(GetUnitTypeId(whichUnit)) == 0)
      {
        AdjustPlayerStateSimpleBJ(player, PLAYER_STATE_RESOURCE_GOLD, GetUnitGoldCost(GetUnitTypeId(whichUnit)));
        AdjustPlayerStateSimpleBJ(player, PLAYER_STATE_RESOURCE_LUMBER, GetUnitWoodCost(GetUnitTypeId(whichUnit)));
        RemoveUnit(whichUnit);
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining,
        () => { VerifyUnitIntegrity(GetTrainedUnit()); });
      PlayerUnitEvents.Register(PlayerUnitEvent.HeroTypeFinishesRevive,
        () => { VerifyUnitIntegrity(GetRevivingUnit()); });
    }
  }
}