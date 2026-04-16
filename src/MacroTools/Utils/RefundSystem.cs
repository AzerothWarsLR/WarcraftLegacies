using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;

namespace MacroTools.Utils;

public static class RefundSystem
{
  private static readonly Dictionary<player, float> _globalTotals = new();

  public static Dictionary<player, float> RefundUnits(IEnumerable<unit> units, player owner)
  {
    var refundTotals = new Dictionary<player, float>();

    foreach (var u in units.Where(u => u.IsUnitType(unittype.Structure) &&
                                       u.Owner != owner &&
                                       u.Owner != player.NeutralPassive &&
                                       u.Owner != player.NeutralAggressive))
    {
      var enemy = u.Owner;
      var refund = u.GoldCost;

      if (refund > 0)
      {
        enemy.Gold += refund;

        if (!refundTotals.ContainsKey(enemy))
        {
          refundTotals[enemy] = 0;
        }

        refundTotals[enemy] += refund;

        if (!_globalTotals.ContainsKey(enemy))
        {
          _globalTotals[enemy] = 0;
        }

        _globalTotals[enemy] += refund;
      }

      u.DropAllItems();
      u.Kill();
      u.Dispose();
    }

    return refundTotals;
  }

  public static void FlushMessages()
  {
    foreach (var kvp in _globalTotals)
    {
      DisplayTextToPlayer(kvp.Key, 0, 0,
        $"|cff00ff00You received {kvp.Value} gold refunded from removed buildings.|r");
    }

    _globalTotals.Clear();
  }
}
