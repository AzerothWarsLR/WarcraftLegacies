using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
///   If a unit with a tech limit of 0 is trained or revived, delete and refund it instantly.
/// </summary>
public static class RefundZeroLimitUnits
{
  private static void VerifyUnitIntegrity(unit whichUnit)
  {
    var unitType = whichUnit.UnitType;
    var player = whichUnit.Owner;
    if (player.GetPlayerData().GetObjectLimit(unitType) != 0)
    {
      return;
    }

    player.Gold += whichUnit.IsUnitType(unittype.Hero) ? PlayerDistributor.HeroCost : unit.GoldCostOf(unitType);

    whichUnit.Dispose();
  }

  /// <summary>
  /// Registers triggers that cause the following:
  /// <para>Whenever a unit with a tech limit of 0 is trained or revived, delete and refund it instantly.</para>
  /// </summary>
  public static void Setup()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining,
      () => { VerifyUnitIntegrity(@event.TrainedUnit); });
    PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive,
      () => { VerifyUnitIntegrity(@event.RevivingUnit); });
  }
}
