using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Utils;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.FallenPrince;

/// <summary>Raises the culled dead around Stratholme as zombies that serve no one, but spare the Fallen Prince's side.</summary>
public static class CulledOutbreak
{
  private const int CulledPlayerId = 21;
  private const int GroupCount = 20;
  private const int SpawnAttempts = 10;
  private const float CenterX = 14557;
  private const float CenterY = 12392;
  private const float MinRadius = 300;
  private const float MaxRadius = 1500;
  private const float MarchDistance = 4000;
  private const float HuntInterval = 8;
  private const float HuntRadius = 3000;
  private const float ControlPointSearchRadius = 8000;
  private const int CauldronCount = 4;
  private const float CauldronSpawnInterval = 60;
  private const int ZombieLimit = 70;
  private const float CauldronClearance = 450;
  private const float CauldronSize = 192;
  private const string RiseEffect = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl";

  /// <summary>Raises the zombies, allied to everyone on <paramref name="fallenPrince"/>'s team.</summary>
  public static void Unleash(player fallenPrince)
  {
    var culled = player.Create(CulledPlayerId);
    culled.Name = Loc.Get("The Culled");
    culled.SetState(playerstate.GivesBounty, 0);
    ControlPointManager.Instance.CaptureRedirects[culled] = fallenPrince;
    PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, () => PrepareZombie(@event.Unit),
      UNIT_U106_CULLED_ZOMBIE_FALLENPRINCE_CULLED);
    foreach (var other in WCSharp.Shared.Util.EnumeratePlayers())
    {
      if (other == culled)
      {
        continue;
      }

      var allianceState = other == fallenPrince || TeamChanges.AreTeammates(other, fallenPrince)
        ? AllianceState.Allied
        : AllianceState.Unallied;
      culled.SetAllianceState(other, allianceState);
      other.SetAllianceState(culled, allianceState);
    }

    for (var i = 0; i < GroupCount; i++)
    {
      var angle = 0f;
      var x = CenterX;
      var y = CenterY;
      for (var attempt = 0; attempt < SpawnAttempts; attempt++)
      {
        angle = GetRandomReal(0, 2 * MathEx.Pi);
        var radius = GetRandomReal(MinRadius, MaxRadius);
        x = CenterX + radius * Cos(angle);
        y = CenterY + radius * Sin(angle);
        if (!pathingtype.Walkability.GetPathable(x, y))
        {
          break;
        }
      }

      effect.Create(RiseEffect, x, y).Dispose();
      var groupSize = GetRandomInt(2, 3);
      for (var j = 0; j < groupSize; j++)
      {
        var zombie = unit.Create(culled, UNIT_U106_CULLED_ZOMBIE_FALLENPRINCE_CULLED, x, y, angle * MathEx.RadToDeg);
        PrepareZombie(zombie);
        zombie.IssueOrder(ORDER_ATTACK, x + MarchDistance * Cos(angle), y + MarchDistance * Sin(angle));
      }
    }

    timer.Create().Start(HuntInterval, true, () => SendIdleZombiesHunting(culled));
    var cauldrons = RaiseCauldrons(culled);
    timer.Create().Start(CauldronSpawnInterval, true, () => SpawnFromCauldrons(culled, cauldrons));
  }

  /// <summary>Places the plague cauldrons on open ground around Stratholme, clear of any buildings.</summary>
  private static List<unit> RaiseCauldrons(player culled)
  {
    var cauldrons = new List<unit>();
    foreach (var radius in new[] { 700f, 1000f, 1300f })
    {
      for (var i = 0; i < 8 && cauldrons.Count < CauldronCount; i++)
      {
        var angle = MathEx.Pi / 8 + i * MathEx.Pi / 4;
        var x = CenterX + radius * Cos(angle);
        var y = CenterY + radius * Sin(angle);
        if (pathingtype.Walkability.GetPathable(x, y) || IsNearStructureOrCauldron(x, y, cauldrons))
        {
          continue;
        }

        cauldrons.Add(GeneralHelpers.CreateStructureForced(culled, UNIT_U109_PLAGUE_CAULDRON_FALLENPRINCE_CULLED, x, y,
          270, CauldronSize));
      }
    }

    return cauldrons;
  }

  private static bool IsNearStructureOrCauldron(float x, float y, List<unit> cauldrons) =>
    GlobalGroup.EnumUnitsInRange(x, y, CauldronClearance).Any(other => other.Alive && other.IsUnitType(unittype.Structure)) ||
    cauldrons.Any(cauldron => MathEx.GetDistanceBetweenPoints(cauldron.GetPosition(), new WCSharp.Shared.Data.Point(x, y)) < CauldronClearance * 2);

  /// <summary>Each standing cauldron raises a zombie, unless the culled are already at their limit.</summary>
  private static void SpawnFromCauldrons(player culled, List<unit> cauldrons)
  {
    var zombies = GlobalGroup.EnumUnitsOfPlayer(culled)
      .Count(x => x.Alive && x.UnitType == UNIT_U106_CULLED_ZOMBIE_FALLENPRINCE_CULLED);
    foreach (var cauldron in cauldrons)
    {
      if (zombies >= ZombieLimit)
      {
        return;
      }

      if (!cauldron.Alive)
      {
        continue;
      }

      effect.Create(RiseEffect, cauldron.X, cauldron.Y - 200).Dispose();
      var zombie = unit.Create(culled, UNIT_U106_CULLED_ZOMBIE_FALLENPRINCE_CULLED, cauldron.X, cauldron.Y - 200, 270);
      PrepareZombie(zombie);
      zombies++;
    }
  }

  /// <summary>Zombies that have nothing to do shamble towards the nearest enemy, or failing that the nearest enemy-held control point.</summary>
  private static void SendIdleZombiesHunting(player culled)
  {
    foreach (var zombie in GlobalGroup.EnumUnitsOfPlayer(culled))
    {
      if (!zombie.Alive || zombie.CurrentOrder != 0)
      {
        continue;
      }

      var target = FindNearestEnemy(zombie, culled);
      if (target == null)
      {
        target = FindNearestEnemyControlPoint(zombie, culled);
      }

      if (target != null)
      {
        zombie.IssueOrder(ORDER_ATTACK, target.X, target.Y);
      }
    }
  }

  private static unit? FindNearestEnemy(unit zombie, player culled)
  {
    unit? nearest = null;
    var nearestDistance = HuntRadius * HuntRadius;
    foreach (var other in GlobalGroup.EnumUnitsInRange(zombie.X, zombie.Y, HuntRadius))
    {
      if (!other.Alive || !IsUnitEnemy(other, culled))
      {
        continue;
      }

      var distance = GetDistanceSquared(zombie, other);
      if (distance < nearestDistance)
      {
        nearest = other;
        nearestDistance = distance;
      }
    }

    return nearest;
  }

  private static unit? FindNearestEnemyControlPoint(unit zombie, player culled)
  {
    unit? nearest = null;
    var nearestDistance = ControlPointSearchRadius * ControlPointSearchRadius;
    foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
    {
      var controlPointUnit = controlPoint.Unit;
      if (!IsUnitEnemy(controlPointUnit, culled))
      {
        continue;
      }

      var distance = GetDistanceSquared(zombie, controlPointUnit);
      if (distance < nearestDistance)
      {
        nearest = controlPointUnit;
        nearestDistance = distance;
      }
    }

    return nearest;
  }

  private static float GetDistanceSquared(unit first, unit second)
  {
    var dx = first.X - second.X;
    var dy = first.Y - second.Y;
    return dx * dx + dy * dy;
  }

  private static void PrepareZombie(unit zombie)
  {
    zombie.Level = 0;
    zombie.IssueOrder(ORDER_PARASITE_ON);
  }
}
