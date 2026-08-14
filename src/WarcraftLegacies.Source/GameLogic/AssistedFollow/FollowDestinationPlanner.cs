using System;

namespace WarcraftLegacies.Source.GameLogic.AssistedFollow;

/// <summary>
/// Produces stable follower destinations while retaining the army's current formation.
/// </summary>
public static class FollowDestinationPlanner
{
  private const float MaximumFormationRadius = 768;
  private const float MaximumRadiusSquared = MaximumFormationRadius * MaximumFormationRadius;
  private const float MinimumFormationSeparation = 48;
  private const float BaseFallbackRadius = 96;
  private const float FallbackRadiusPerSlot = 32;
  private const float GoldenAngleRadians = 2.399963229728653f;
  private const float PathingSampleSpacing = 32;

  /// <summary>
  /// Projects a follower's current offset from its leader onto the leader's new destination.
  /// </summary>
  public static void GetDestination(float leaderX, float leaderY, float followerX, float followerY,
    float leaderDestinationX, float leaderDestinationY, int formationSlot, out float destinationX,
    out float destinationY)
  {
    var offsetX = followerX - leaderX;
    var offsetY = followerY - leaderY;
    var offsetDistanceSquared = offsetX * offsetX + offsetY * offsetY;

    if (offsetDistanceSquared > MaximumRadiusSquared)
    {
      var scale = MaximumFormationRadius / MathF.Sqrt(offsetDistanceSquared);
      offsetX *= scale;
      offsetY *= scale;
    }
    else if (offsetDistanceSquared < MinimumFormationSeparation * MinimumFormationSeparation)
    {
      // Units can overlap after teleports or scripted spawns. Give them deterministic
      // fallback slots so trigger-issued individual orders do not converge on one point.
      var radius = Math.Min(MaximumFormationRadius,
        BaseFallbackRadius + FallbackRadiusPerSlot * MathF.Sqrt(formationSlot));
      var angle = formationSlot * GoldenAngleRadians;
      offsetX = radius * MathF.Cos(angle);
      offsetY = radius * MathF.Sin(angle);
    }

    destinationX = leaderDestinationX + offsetX;
    destinationY = leaderDestinationY + offsetY;
  }

  /// <summary>
  /// Walks outward from the leader's destination and retains the furthest formation point
  /// reachable without crossing blocked terrain.
  /// </summary>
  public static void GetPathingSafeDestination(float leaderDestinationX, float leaderDestinationY,
    float desiredDestinationX, float desiredDestinationY, Func<float, float, bool> isUnwalkable,
    out float destinationX, out float destinationY)
  {
    destinationX = leaderDestinationX;
    destinationY = leaderDestinationY;

    // A player can issue an order on blocked terrain and Warcraft will resolve it to a nearby
    // reachable point. Preserve that native behaviour instead of inventing an offset from it.
    if (isUnwalkable(leaderDestinationX, leaderDestinationY))
    {
      return;
    }

    var offsetX = desiredDestinationX - leaderDestinationX;
    var offsetY = desiredDestinationY - leaderDestinationY;
    var distance = MathF.Sqrt(offsetX * offsetX + offsetY * offsetY);
    if (distance == 0)
    {
      return;
    }

    for (var sampleDistance = PathingSampleSpacing; sampleDistance < distance;
         sampleDistance += PathingSampleSpacing)
    {
      var ratio = sampleDistance / distance;
      var sampleX = leaderDestinationX + offsetX * ratio;
      var sampleY = leaderDestinationY + offsetY * ratio;
      if (isUnwalkable(sampleX, sampleY))
      {
        return;
      }

      destinationX = sampleX;
      destinationY = sampleY;
    }

    if (!isUnwalkable(desiredDestinationX, desiredDestinationY))
    {
      destinationX = desiredDestinationX;
      destinationY = desiredDestinationY;
    }
  }
}
