using System.Collections.Generic;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>Keeps harvestable world resources effectively inexhaustible.</summary>
public static class InfiniteResourceSetup
{
  private const int GoldAmount = 1_000_000;
  private const float TreeLife = 1_000_000;
  private const float RefreshInterval = 60;
  private static readonly List<unit> _goldMines = new();
  private static readonly List<destructable> _trees = new();

  /// <summary>Starts real-time resource maintenance independently of historical turns.</summary>
  public static void Setup()
  {
    FindGoldMines();
    FindTrees();
    ReplenishResources();

    var resourceTimer = timer.Create();
    resourceTimer.Start(RefreshInterval, true, ReplenishResources);
  }

  private static void ReplenishResources()
  {
    foreach (var goldMine in _goldMines)
    {
      if (goldMine.ResourceAmount > 0 && goldMine.ResourceAmount < GoldAmount)
      {
        goldMine.ResourceAmount = GoldAmount;
      }
    }

    foreach (var tree in _trees)
    {
      DestructableRestoreLife(tree, TreeLife, false);
    }
  }

  private static void FindGoldMines()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds))
    {
      if (unit.ResourceAmount > 0)
      {
        _goldMines.Add(unit);
      }
    }
  }

  private static void FindTrees()
  {
    // Warcraft has no native tree-type query. A hidden worker's harvest order
    // succeeds only for lumber-bearing destructables, allowing discovery without
    // hardcoding the map's many custom tree rawcodes.
    var treeDetector = unit.Create(player.NeutralPassive, FourCC("hpea"), 0, 0, 0);
    ShowUnit(treeDetector, false);
    UnitAddAbility(treeDetector, FourCC("Ahrl"));
    Rectangle.WorldBounds.Rect.EnumerateDestructables(null, () =>
    {
      var destructable = GetEnumDestructable();
      if (IssueTargetOrder(treeDetector, "harvest", destructable))
      {
        _trees.Add(destructable);
      }
    });
    RemoveUnit(treeDetector);
  }
}
