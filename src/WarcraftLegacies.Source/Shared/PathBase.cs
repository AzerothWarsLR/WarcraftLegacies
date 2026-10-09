using System;
using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Utils;
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
  public static void CreateStructure(player whichPlayer, int unitTypeId, float x, float y)
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

  private static unit? GetBlockingKeyUnit(float x, float y)
  {
    var area = new Rectangle(x - StructureSize, y - StructureSize, x + StructureSize, y + StructureSize);
    return GlobalGroup.EnumUnitsInRect(area).FirstOrDefault(IsKeyUnit);
  }

  private static bool IsKeyUnit(unit whichUnit) =>
    whichUnit.IsUnitType(unittype.Structure) &&
    (!whichUnit.IsRemovable() || whichUnit.UnitType == UNIT_N06Z_FLIGHT_PATH_ORCISH_HORDE);
}
