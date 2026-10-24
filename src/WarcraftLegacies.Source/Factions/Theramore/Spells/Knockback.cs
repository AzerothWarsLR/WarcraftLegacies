using System;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Slides units across the ground, stopping when they hit a building or unwalkable ground.</summary>
public static class Knockback
{
  private const float StepInterval = 0.03f;
  private const float StructureRadius = 64;

  /// <summary>Pushes <paramref name="target"/> along <paramref name="angle"/>, calling <paramref name="onBlocked"/> if it slams into something.</summary>
  public static void Push(unit target, float angle, float distance, float duration, Action<unit>? onBlocked = null)
  {
    var steps = Math.Max(1, (int)(duration / StepInterval));
    var stepDistance = distance / steps;
    var stepsTaken = 0;
    var slide = timer.Create();
    slide.Start(StepInterval, true, () =>
    {
      stepsTaken++;
      var nextX = MathEx.GetPolarOffsetX(target.X, stepDistance, angle);
      var nextY = MathEx.GetPolarOffsetY(target.Y, stepDistance, angle);
      var blocked = IsTerrainPathable(nextX, nextY, PATHING_TYPE_WALKABILITY) || IsNearStructure(nextX, nextY);
      if (!blocked && target.Alive)
      {
        target.X = nextX;
        target.Y = nextY;
      }

      if (stepsTaken < steps && !blocked && target.Alive)
      {
        return;
      }

      slide.Dispose();
      if (blocked && target.Alive && onBlocked != null)
      {
        onBlocked(target);
      }
    });
  }

  private static bool IsNearStructure(float x, float y)
  {
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, StructureRadius))
    {
      if (nearby.Alive && nearby.IsUnitType(unittype.Structure))
      {
        return true;
      }
    }

    return false;
  }
}
