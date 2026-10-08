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

  /// <summary>
  /// Removes or rescues the hostile creeps in <paramref name="area"/>, and gives <paramref name="newOwner"/> any neutral
  /// control points there.
  /// </summary>
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
  /// Creates a structure, clearing other structures out of its way. It is moved aside rather than placed on top of a
  /// control point, so control points are never destroyed.
  /// </summary>
  public static void CreateStructure(player whichPlayer, int unitTypeId, float x, float y)
  {
    for (var i = 0; i < MaxNudges; i++)
    {
      var blocker = GetBlockingControlPoint(x, y);
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

    GeneralHelpers.CreateStructureForced(whichPlayer, unitTypeId, x, y, Facing, StructureSize);
  }

  /// <summary>
  /// Gives <paramref name="hero"/> to <paramref name="owner"/> at <paramref name="position"/>. A dead hero's body is
  /// removed and a living one that keeps its experience is created, since the old body may already belong to someone
  /// else and cannot be revived by the new owner.
  /// </summary>
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

  private static unit? GetBlockingControlPoint(float x, float y)
  {
    var area = new Rectangle(x - StructureSize, y - StructureSize, x + StructureSize, y + StructureSize);
    return GlobalGroup.EnumUnitsInRect(area).FirstOrDefault(unit => unit.IsControlPoint());
  }
}
