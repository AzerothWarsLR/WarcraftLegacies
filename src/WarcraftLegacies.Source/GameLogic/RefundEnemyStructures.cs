using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

public static class RefundEnemyStructures
{
  private static readonly Dictionary<player, float> GlobalTotals = new();

  public static Dictionary<player, float> InRegion(Rectangle rect, player owner)
  {
    var refundTotals = new Dictionary<player, float>();

    foreach (var building in GlobalGroup.EnumUnitsInRect(rect)
               .Where(u => u.IsUnitType(unittype.Structure) &&
                           u.Owner != owner &&
                           u.Owner != player.NeutralPassive &&
                           u.Owner != player.NeutralAggressive))
    {
      var enemy = building.Owner;
      var refund = building.GoldCost;

      if (refund > 0)
      {
        enemy.Gold += refund;

        if (!refundTotals.ContainsKey(enemy))
        {
          refundTotals[enemy] = 0;
        }

        refundTotals[enemy] += refund;

        if (!GlobalTotals.ContainsKey(enemy))
        {
          GlobalTotals[enemy] = 0;
        }

        GlobalTotals[enemy] += refund;
      }

      building.DropAllItems();
      building.Kill();
      building.Dispose();
    }

    return refundTotals;
  }
  public static Dictionary<player, float> InRadius(float x, float y, float radius, player owner)
  {
    var refundTotals = new Dictionary<player, float>();

    foreach (var building in GlobalGroup.EnumUnitsInRange(x, y, radius)
               .Where(u => u.IsUnitType(unittype.Structure) &&
                           u.Owner != owner &&
                           u.Owner != player.NeutralPassive &&
                           u.Owner != player.NeutralAggressive))
    {
      var enemy = building.Owner;
      var refund = building.GoldCost;

      if (refund > 0)
      {
        enemy.Gold += refund;

        if (!refundTotals.ContainsKey(enemy))
        {
          refundTotals[enemy] = 0;
        }

        refundTotals[enemy] += refund;

        if (!GlobalTotals.ContainsKey(enemy))
        {
          GlobalTotals[enemy] = 0;
        }

        GlobalTotals[enemy] += refund;
      }

      building.DropAllItems();
      building.Kill();
      building.Dispose();
    }

    return refundTotals;
  }
  public static void FlushMessages()
  {
    foreach (var kvp in GlobalTotals)
    {
      DisplayTextToPlayer(kvp.Key, 0, 0,
        $"|cff00ff00You received {kvp.Value} gold refunded from removed buildings.|r");
    }

    GlobalTotals.Clear();
  }
}
