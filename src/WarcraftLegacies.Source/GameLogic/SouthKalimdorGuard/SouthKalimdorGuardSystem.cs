using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.GameTime;
using MacroTools.Shores;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic.SouthKalimdorGuard;

/// <summary>
/// Shoves intruding units back out of Southern Kalimdor until <see cref="UnlockTurn"/>.
/// </summary>
public static class SouthKalimdorGuardSystem
{
  /// <summary>
  /// The turn Southern Kalimdor opens up. Also used as the rock wall expiry in <see cref="Setup.RockSetup"/>.
  /// </summary>
  public const int UnlockTurn = 15;

  private const float PushBackDistance = 128f;
  private const float MessageCooldownSeconds = 20f;

  private static readonly Rectangle[] LockedRegions =
  {
    Regions.SouthKalimdor1,
    Regions.SouthKalimdor2,
    Regions.SouthKalimdor3
  };

  private static readonly HashSet<player> _recentlyWarned = new();

  public static void Setup()
  {
    var splitX = (LockedRegions.Min(region => region.Left) + LockedRegions.Max(region => region.Right)) / 2;

    foreach (var region in LockedRegions)
    {
      var enterTrigger = trigger.Create();
      enterTrigger.RegisterEnterRegion(region.Region);
      enterTrigger.AddAction(() => OnUnitEntered(region, splitX));
    }
  }

  private static void OnUnitEntered(Rectangle region, float splitX)
  {
    var triggerUnit = @event.Unit;

    if (GameTimeManager.Turn >= UnlockTurn)
    {
      return;
    }

    var owner = triggerUnit.Owner;
    if (owner == player.NeutralAggressive || owner == player.NeutralPassive)
    {
      return;
    }

    if (triggerUnit.IsUnitBoat())
    {
      return;
    }

    var entryPosition = triggerUnit.GetPosition();
    var safePosition = GetPushBackPosition(region, entryPosition);
    triggerUnit.SetPosition(safePosition.X, safePosition.Y);

    WarnPlayer(owner, entryPosition.X < splitX
      ? "|cff00ffffNaga raiders control these waters. Your forces are turned back until the mainland is secure.|r"
      : "|cffcc8800Centaur riders patrol this frontier. Your forces are turned back until the mainland is secure.|r");
  }

  private static Point GetPushBackPosition(Rectangle region, Point position)
  {
    var distanceToLeft = position.X - region.Left;
    var distanceToRight = region.Right - position.X;
    var distanceToBottom = position.Y - region.Bottom;
    var distanceToTop = region.Top - position.Y;
    var closest = System.Math.Min(System.Math.Min(distanceToLeft, distanceToRight), System.Math.Min(distanceToBottom, distanceToTop));

    var candidate = closest == distanceToLeft ? new Point(region.Left - PushBackDistance, position.Y)
      : closest == distanceToRight ? new Point(region.Right + PushBackDistance, position.Y)
      : closest == distanceToBottom ? new Point(position.X, region.Bottom - PushBackDistance)
      : new Point(position.X, region.Top + PushBackDistance);

    if (IsSafeLandingSpot(candidate))
    {
      return candidate;
    }

    return GetNearestSafeShore(candidate) ?? candidate;
  }

  /// <summary>
  /// True if the position is walkable ground and not inside any of the locked regions.
  /// </summary>
  private static bool IsSafeLandingSpot(Point position) =>
    !pathingtype.Walkability.GetPathable(position.X, position.Y) &&
    !LockedRegions.Any(region => region.Contains(position.X, position.Y));

  private static Point? GetNearestSafeShore(Point position)
  {
    Shore? nearest = null;
    var nearestDistanceSquared = float.MaxValue;
    foreach (var shore in ShoreManager.GetAllShores())
    {
      if (LockedRegions.Any(region => region.Contains(shore.Position.X, shore.Position.Y)))
      {
        continue;
      }

      var deltaX = shore.Position.X - position.X;
      var deltaY = shore.Position.Y - position.Y;
      var distanceSquared = deltaX * deltaX + deltaY * deltaY;
      if (distanceSquared < nearestDistanceSquared)
      {
        nearestDistanceSquared = distanceSquared;
        nearest = shore;
      }
    }

    return nearest?.Position;
  }

  private static void WarnPlayer(player whichPlayer, string message)
  {
    if (_recentlyWarned.Contains(whichPlayer))
    {
      return;
    }

    _recentlyWarned.Add(whichPlayer);
    DisplayTextToPlayer(whichPlayer, 0, 0, message);

    var cooldown = timer.Create();
    cooldown.Start(MessageCooldownSeconds, false, () =>
    {
      _recentlyWarned.Remove(whichPlayer);
      cooldown.Dispose();
    });
  }
}
