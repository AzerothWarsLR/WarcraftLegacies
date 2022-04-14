using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  /// <summary>
  ///   If a unit with a tech limit of 0 is trained or revived, delete and refund it instantly.
  /// </summary>
  public static class RefundZeroLimitUnits
  {
    private static void VerifyUnitIntegrity(unit whichUnit)
    {
      var player = GetOwningPlayer(whichUnit);
      if (player.GetObjectLimit(GetUnitTypeId(whichUnit)) == 0)
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