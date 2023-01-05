using MacroTools;
using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Neutral
{
  /// <summary>
  /// Responsible for tying the ownership of the Gilneas Gate towers to the gate itself.
  /// </summary>
  public static class GilneasGateTowers
  {
    /// <summary>
    /// Sets up <see cref="GilneasGateTowers"/>.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplaced)
    {
      var greymaneGateTowerA = preplaced.GetUnit(Constants.UNIT_O05Q_GREYMANETOWER_GILNEAS_REAL_TOWER, new Point(6580, 2677));
      var greymaneGateTowerB = preplaced.GetUnit(Constants.UNIT_O05Q_GREYMANETOWER_GILNEAS_REAL_TOWER, new Point(7206, 2697));

      greymaneGateTowerA.SetInvulnerable(true);
      greymaneGateTowerB.SetInvulnerable(true);
      
      foreach (var gilneasGateUnitTypeId in new[]
               {
                 Constants.UNIT_H02L_GREYMANE_S_GATE_DEAD,
                 Constants.UNIT_H02M_GREYMANE_S_GATE_OPEN,
                 Constants.UNIT_H02K_GREYMANE_S_GATE_CLOSED
               })
      {
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, () =>
        {
          greymaneGateTowerA.SetOwner(Player(PLAYER_NEUTRAL_PASSIVE));
          greymaneGateTowerB.SetOwner(Player(PLAYER_NEUTRAL_PASSIVE));
        }, gilneasGateUnitTypeId);
      }
      
      PlayerUnitEvents.Register(UnitTypeEvent.FinishesUpgrade, () =>
      {
        greymaneGateTowerA.SetOwner(GetTriggerUnit().OwningPlayer());
        greymaneGateTowerB.SetOwner(GetTriggerUnit().OwningPlayer());
      }, Constants.UNIT_H02K_GREYMANE_S_GATE_CLOSED);
    }
  }
}