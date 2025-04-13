using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.JumpSystem
{
  /// <summary>
  /// Handles the mechanics of jumping spells, moving units along a parabolic arc.
  /// </summary>
  public static class JumpSystem
  {
    private static readonly List<JumpInstance> ActiveJumps = new();

    /// <summary>
    /// Triggers a new jump for the given unit to a target point with specified speed and max height.
    /// </summary>
    public static void TriggerJump(unit jumper, Point targetPoint, float jumpSpeed, float maxHeight)
    {
      var instance = new JumpInstance(jumper, targetPoint, jumpSpeed, maxHeight);
      ActiveJumps.Add(instance);
      
      // Disable pathing/movement for the unit during the jump
      SetUnitPathing(jumper, false);
    }

    /// <summary>
    /// Updates all active jumps. Call this method once per frame or on a fixed timer.
    /// </summary>
    public static void Update(float deltaTime)
    {
      for (var i = ActiveJumps.Count - 1; i >= 0; i--)
      {
        var jump = ActiveJumps[i];
        if (jump.Update(deltaTime))
        {
          ActiveJumps.RemoveAt(i);
        }
      }
    }

    /// <summary>
    /// Represents a single jump instance.
    /// </summary>
    private class JumpInstance
    {
      private readonly unit _unit;
      private readonly Point _startPosition;
      private readonly Point _targetPosition;
      private readonly float _totalDistance;
      private readonly float _speed;
      private readonly float _maxHeight;

      private float _traveledDistance;

      public JumpInstance(unit unit, Point targetPosition, float speed, float maxHeight)
      {
        _unit = unit;
        _startPosition = new Point(GetUnitX(unit), GetUnitY(unit));
        _targetPosition = targetPosition;

        // Calculate the total distance manually
        _totalDistance = CalculateDistance(_startPosition, _targetPosition);

        _speed = speed;
        _maxHeight = maxHeight;
        _traveledDistance = 0f;
      }

      /// <summary>
      /// Updates the unit's position along the jump arc.
      /// </summary>
      /// <param name="deltaTime">The time step for this update (e.g., 0.03 for 30ms).</param>
      /// <returns>True if the jump has finished, otherwise false.</returns>
      public bool Update(float deltaTime)
      {
        _traveledDistance += _speed * deltaTime;

        // Calculate progress along the arc
        var progress = _traveledDistance / _totalDistance;

        // Stop the jump if the progress is complete
        if (progress >= 1.0f)
        {
          SetFinalPosition();
          return true;
        }

        // Calculate new position and parabolic height
        var newX = Lerp(_startPosition.X, _targetPosition.X, progress);
        var newY = Lerp(_startPosition.Y, _targetPosition.Y, progress);
        var newHeight = CalculateHeight(_maxHeight, progress);

        // Move the unit to the new position
        SetUnitX(_unit, newX);
        SetUnitY(_unit, newY);
        SetUnitFlyHeight(_unit, newHeight, 0);

        return false;
      }

      // Moves the unit to the final position and re-enables pathing
      private void SetFinalPosition()
      {
        SetUnitX(_unit, _targetPosition.X);
        SetUnitY(_unit, _targetPosition.Y);
        SetUnitFlyHeight(_unit, 0, 0); 
        SetUnitPathing(_unit, true); 
      }

      /// <summary>
      /// Calculates the distance between two points.
      /// </summary>
      private static float CalculateDistance(Point start, Point target)
      {
        float dx = target.X - start.X;
        float dy = target.Y - start.Y;
        return MathF.Sqrt(dx * dx + dy * dy); // Pythagorean theorem
      }

      // Parabolic height function
      private static float CalculateHeight(float maxHeight, float progress)
      {
        return 4 * maxHeight * progress * (1 - progress); // Parabola formula
      }

      // Linear interpolation helper
      private static float Lerp(float start, float end, float t)
      {
        return start + t * (end - start);
      }
    }
  }
}