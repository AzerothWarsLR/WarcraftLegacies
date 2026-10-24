using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Localization;
using WCSharp.Shared.Data;

namespace MacroTools.Utils;

public static class RefundSystem
{
  private static readonly Dictionary<player, float> _globalTotals = new();

  private static void RefundHostileStructures(player whichPlayer, IEnumerable<unit> units) =>
    RefundStructures(units.Where(u => u.IsEnemyTo(whichPlayer)));

  private static void RefundStructures(IEnumerable<unit> units)
  {
    foreach (var u in units.Where(u =>
               u.IsUnitType(unittype.Structure) &&
               u.IsRemovable()))
    {
      var enemy = u.Owner;
      var refund = u.GoldCost;

      if (refund > 0)
      {
        enemy.Gold += refund;

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
  }

  public static void RefundEnemyStructuresInRect(player whichPlayer, params Rectangle[] regions)
  {
    foreach (var region in regions)
    {
      var units = GlobalGroup.EnumUnitsInRect(region);
      RefundHostileStructures(whichPlayer, units);
    }

    FlushMessages();
  }

  public static void RefundEnemyStructuresInRange(player whichPlayer, float x, float y, float radius)
  {
    var units = GlobalGroup.EnumUnitsInRange(x, y, radius);
    RefundHostileStructures(whichPlayer, units);
    FlushMessages();
  }

  /// <summary>Removes every other player's structures in range, refunding their owners, but leaves neutral buildings alone.</summary>
  public static void RefundOtherStructuresInRange(player whichPlayer, float x, float y, float radius)
  {
    var units = GlobalGroup.EnumUnitsInRange(x, y, radius);
    RefundStructures(units.Where(u => u.Owner != whichPlayer && u.Owner != player.NeutralPassive &&
                                      u.Owner != player.NeutralAggressive));
    FlushMessages();
  }

  private static void FlushMessages()
  {
    foreach (var kvp in _globalTotals)
    {
      DisplayTextToPlayer(kvp.Key, 0, 0, Loc.Format(
        "|cff00ff00You received {gold} gold refunded from removed buildings.|r",
        ("{gold}", kvp.Value.ToString())));
    }

    _globalTotals.Clear();
  }
}
