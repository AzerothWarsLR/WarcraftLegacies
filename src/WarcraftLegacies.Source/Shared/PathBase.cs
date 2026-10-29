using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Utils;
using WarcraftLegacies.Source.GameLogic;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Shared;

/// <summary>
/// Builds the fresh base a faction starts with after taking a path that restarts it somewhere new.
/// </summary>
public static class PathBase
{
  private const float StructureSize = 256;
  private const float Facing = 270;
  private const int MaxNudges = 4;
  private const float ArmySpacing = 120;

  private static readonly HashSet<int> _ships = new()
  {
    UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE,
    UNIT_H0AR_SCOUT_SHIP_ALLIANCE,
    UNIT_H0AX_FRIGATE_ALLIANCE,
    UNIT_H0B3_FIRESHIP_ALLIANCE,
    UNIT_H0B0_GALLEY_ALLIANCE,
    UNIT_H0B6_BOARDING_VESSEL_ALLIANCE,
    UNIT_H0AN_JUGGERNAUT_ALLIANCE,
    UNIT_H0B7_BOMBARD_ALLIANCE
  };

  /// <summary>Removes everything <paramref name="whichPlayer"/> owns outside <paramref name="keep"/>.</summary>
  public static void RemoveAllUnitsOutside(player whichPlayer, Rectangle keep)
  {
    var kept = GlobalGroup.EnumUnitsInRect(keep);
    foreach (var unit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (kept.Contains(unit))
      {
        continue;
      }

      if (unit.IsRemovable())
      {
        unit.SafelyRemove();
      }
      else
      {
        unit.SetOwner(player.NeutralAggressive);
      }
    }
  }

  /// <summary>Clears hostile creeps from <paramref name="area"/> and gives <paramref name="newOwner"/> its neutral control points.</summary>
  public static void ClaimArea(Rectangle area, player newOwner)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(area))
    {
      if (unit.IsControlPoint())
      {
        if (unit.Owner == player.NeutralAggressive || unit.Owner == player.NeutralPassive)
        {
          unit.SetOwner(newOwner);
        }

        continue;
      }

      if (unit.Owner != player.NeutralAggressive)
      {
        continue;
      }

      if (unit.IsRemovable())
      {
        unit.SafelyRemove();
      }
      else
      {
        unit.Rescue(newOwner);
      }
    }
  }

  /// <summary>
  /// Creates a structure, refunding anything it replaces, but moving it aside rather than destroying a control point,
  /// capital or other key building.
  /// </summary>
  public static unit? CreateStructure(player whichPlayer, int unitTypeId, float x, float y)
  {
    for (var i = 0; i < MaxNudges; i++)
    {
      var blocker = GetBlockingKeyUnit(x, y);
      if (blocker == null)
      {
        break;
      }

      var dx = x - blocker.X;
      var dy = y - blocker.Y;
      var distance = Math.Max(1, (float)Math.Sqrt(dx * dx + dy * dy));
      x = blocker.X + dx / distance * StructureSize * 1.5f;
      y = blocker.Y + dy / distance * StructureSize * 1.5f;
    }

    var structure = GeneralHelpers.CreateStructureForced(whichPlayer, unitTypeId, x, y, Facing, StructureSize);
    if (structure == null || !structure.Alive)
    {
      Logger.LogWarning($"Could not create {GetObjectName(unitTypeId)} at {(int)x}, {(int)y}.");
    }
    else
    {
      TeleportScrollSetting.StockShop(structure);
    }

    return structure;
  }

  /// <summary>Gives <paramref name="hero"/> to <paramref name="owner"/>, replacing a dead hero with a living one.</summary>
  public static void SummonLegend(LegendaryHero hero, player owner, Point position)
  {
    var existing = hero.Unit;
    var experience = 0;
    if (existing != null && !existing.Alive)
    {
      experience = existing.Experience;
      hero.Unit = null;
    }

    hero.ForceCreate(owner, position, Facing);
    if (hero.Unit != null && experience > hero.Unit.Experience)
    {
      hero.Unit.SetExperience(experience, false);
    }
  }

  /// <summary>Creates <paramref name="count"/> units of the same type at one spot.</summary>
  public static void CreateUnits(player whichPlayer, int unitTypeId, int count, float x, float y)
  {
    for (var i = 0; i < count; i++)
    {
      unit.Create(whichPlayer, unitTypeId, x, y, Facing);
    }
  }

  /// <summary>Removes <paramref name="hero"/> from the game, dropping its items.</summary>
  public static void RemoveHero(LegendaryHero hero)
  {
    var heroUnit = hero.Unit;
    if (heroUnit == null)
    {
      return;
    }

    heroUnit.DropAllItems();
    hero.Unit = null;
    heroUnit.Dispose();
  }

  /// <summary>Replaces <paramref name="whichUnit"/> with a unit of another type, keeping its health percentage.</summary>
  public static void ReplaceUnit(unit whichUnit, player owner, int unitTypeId, float x, float y)
  {
    var facing = whichUnit.Facing;
    var lifePercent = whichUnit.Life / whichUnit.MaxLife;
    whichUnit.Dispose();
    var replacement = unit.Create(owner, unitTypeId, x, y, facing);
    if (replacement != null)
    {
      replacement.Life = replacement.MaxLife * lifePercent;
    }
  }

  /// <summary>
  /// Brings <paramref name="whichPlayer"/>'s army to <paramref name="x"/>, <paramref name="y"/>, swapping units for
  /// their <paramref name="equivalents"/>. Ships stay where they are, and swaps beyond the player's limits are removed.
  /// </summary>
  public static void RelocateArmy(player whichPlayer, IReadOnlyDictionary<int, int> equivalents, float x, float y) =>
    RelocateArmy(whichPlayer, equivalents, new[] { new Point(x, y) });

  /// <summary>
  /// Moves <paramref name="whichPlayer"/>'s army to the <paramref name="spots"/> in turn, so it lands in a few groups
  /// instead of one block, swapping units for their <paramref name="equivalents"/> where there are any.
  /// </summary>
  public static void RelocateArmy(player whichPlayer, IReadOnlyDictionary<int, int> equivalents, IReadOnlyList<Point> spots)
  {
    var faction = whichPlayer.GetPlayerData().Faction;
    var swappedCounts = new Dictionary<int, int>();
    var movers = new List<unit>();
    var newTypes = new List<int>();
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive || whichUnit.IsUnitType(unittype.Structure) || !whichUnit.IsRemovable() ||
          !whichUnit.IsSelectable() || _ships.Contains(whichUnit.UnitType))
      {
        continue;
      }

      var hasEquivalent = equivalents.TryGetValue(whichUnit.UnitType, out var newType);
      if (hasEquivalent && faction != null)
      {
        var swappedCount = swappedCounts.GetValueOrDefault(newType);
        if (swappedCount >= faction.GetObjectLimit(newType))
        {
          whichUnit.DropAllItems();
          whichUnit.Dispose();
          continue;
        }

        swappedCounts[newType] = swappedCount + 1;
      }

      movers.Add(whichUnit);
      newTypes.Add(hasEquivalent ? newType : 0);
    }

    var perSpot = (movers.Count + spots.Count - 1) / spots.Count;
    var columns = 1;
    while (columns * columns < perSpot)
    {
      columns++;
    }

    var rows = (perSpot + columns - 1) / columns;
    for (var index = 0; index < movers.Count; index++)
    {
      var spot = spots[index % spots.Count];
      var slot = index / spots.Count;
      var unitX = spot.X + (slot % columns - (columns - 1) / 2f) * ArmySpacing;
      var unitY = spot.Y + (slot / columns - (rows - 1) / 2f) * ArmySpacing;
      if (newTypes[index] != 0)
      {
        ReplaceUnit(movers[index], whichPlayer, newTypes[index], unitX, unitY);
      }
      else
      {
        movers[index].SetPosition(unitX, unitY);
      }
    }
  }

  /// <summary>
  /// Gives <paramref name="heir"/> every structure <paramref name="whichPlayer"/> owns outside the <paramref name="keep"/> areas,
  /// swapping them for their <paramref name="equivalents"/> where there are any. Capitals and control points only change hands.
  /// </summary>
  public static void HandOverStructures(player whichPlayer, player heir, IReadOnlyDictionary<int, int>? equivalents,
    params Rectangle[] keep)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive || !whichUnit.IsUnitType(unittype.Structure))
      {
        continue;
      }

      if (IsInAny(keep, whichUnit.X, whichUnit.Y))
      {
        continue;
      }

      var heirType = 0;
      if (equivalents != null && whichUnit.IsRemovable())
      {
        if (equivalents.TryGetValue(whichUnit.UnitType, out var equivalent))
        {
          heirType = equivalent;
        }
      }

      if (heirType != 0)
      {
        ReplaceUnit(whichUnit, heir, heirType, whichUnit.X, whichUnit.Y);
      }
      else
      {
        whichUnit.SetOwner(heir);
      }
    }
  }

  /// <summary>Swaps the structures <paramref name="whichPlayer"/> owns inside <paramref name="area"/> for their <paramref name="equivalents"/>.</summary>
  public static void ConvertStructures(player whichPlayer, IReadOnlyDictionary<int, int> equivalents, Rectangle area) =>
    ConvertStructures(whichPlayer, equivalents, (x, y) => area.Contains(x, y));

  /// <summary>Swaps every structure <paramref name="whichPlayer"/> owns for its <paramref name="equivalents"/>.</summary>
  public static void ConvertStructures(player whichPlayer, IReadOnlyDictionary<int, int> equivalents) =>
    ConvertStructures(whichPlayer, equivalents, (_, _) => true);

  private static void ConvertStructures(player whichPlayer, IReadOnlyDictionary<int, int> equivalents,
    Func<float, float, bool> isInArea)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive || !whichUnit.IsUnitType(unittype.Structure) || !whichUnit.IsRemovable() ||
          !isInArea(whichUnit.X, whichUnit.Y))
      {
        continue;
      }

      if (equivalents.TryGetValue(whichUnit.UnitType, out var newType))
      {
        ReplaceUnit(whichUnit, whichPlayer, newType, whichUnit.X, whichUnit.Y);
      }
    }
  }

  private static bool IsInAny(Rectangle[] areas, float x, float y)
  {
    foreach (var area in areas)
    {
      if (area.Contains(x, y))
      {
        return true;
      }
    }

    return false;
  }

  private static unit? GetBlockingKeyUnit(float x, float y)
  {
    var area = new Rectangle(x - StructureSize, y - StructureSize, x + StructureSize, y + StructureSize);
    return GlobalGroup.EnumUnitsInRect(area).FirstOrDefault(IsKeyUnit);
  }

  private static bool IsKeyUnit(unit whichUnit) =>
    whichUnit.IsUnitType(unittype.Structure) &&
    (!whichUnit.IsRemovable() || whichUnit.UnitType == UNIT_N06Z_FLIGHT_PATH_ORCISH_HORDE);
}
