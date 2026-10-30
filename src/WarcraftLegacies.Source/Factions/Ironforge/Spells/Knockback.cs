using System;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Slides units away from a point.</summary>
public static class Knockback
{
  private const float Interval = 0.03f;

  /// <summary>Pushes the unit away from the point over the given time, stopping early at unpathable ground or buildings, which calls <paramref name="onBlocked"/>.</summary>
  public static void Push(unit target, float fromX, float fromY, float distance, float duration, Action? onBlocked = null)
  {
    var angle = MathEx.GetAngleBetweenPoints(fromX, fromY, target.X, target.Y);
    var step = distance / duration * Interval;
    var stepX = MathEx.GetPolarOffsetX(0, step, angle);
    var stepY = MathEx.GetPolarOffsetY(0, step, angle);
    var elapsed = 0f;
    var knockback = timer.Create();
    knockback.Start(Interval, true, () =>
    {
      elapsed += Interval;
      var newX = target.X + stepX;
      var newY = target.Y + stepY;
      var blocked = pathingtype.Walkability.GetPathable(newX, newY);
      if (!blocked)
      {
        target.X = newX;
        target.Y = newY;
      }

      if (blocked || elapsed >= duration || !target.Alive)
      {
        knockback.Dispose();
        if (blocked && target.Alive && onBlocked != null)
        {
          onBlocked();
        }
      }
    });
  }
}
