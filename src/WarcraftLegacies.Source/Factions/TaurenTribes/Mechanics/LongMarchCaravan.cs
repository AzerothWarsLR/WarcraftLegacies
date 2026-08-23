using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;
using WarcraftLegacies.Source.Objectives;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;

/// <summary>
/// Drives the pack kodos spawned by <see cref="Researches.StartTheLongMarch"/> from the starting camp to
/// Stonemaul Keep and then Thunder Bluff, handing off each base once the caravan actually reaches it and
/// fending off ambushes along the way.
/// </summary>
public sealed class LongMarchCaravan
{
  private static readonly int[] AmbushUnitTypes =
  {
    UNIT_OTCO_CENTAUR_OUTRUNNER_TAUREN_TRIBES_AMBUSH,
    UNIT_OTCD_CENTAUR_DRUDGE_TAUREN_TRIBES_AMBUSH,
    UNIT_OTCA_CENTAUR_ARCHER_TAUREN_TRIBES_AMBUSH,
    UNIT_OTCI_CENTAUR_IMPALER_TAUREN_TRIBES_AMBUSH
  };

  private const int AmbushWaveSize = 4;
  private const float OrderPulseInterval = 3.00f;
  private const float AmbushInterval = 10.00f;
  private const float ArrivalRadius = 500f;
  private const float ArrivalPauseSeconds = 4.00f;
  private const float FormationSpacing = 90f;

  private readonly Faction _taurenTribes;
  private readonly QuestTheLongMarch _quest;
  private readonly List<unit> _kodos;
  private readonly List<unit> _stonemaulRescueUnits;
  private readonly List<unit> _thunderBluffRescueUnits;
  private readonly Point _thunderBluffTarget;
  private readonly Rectangle _stonemaulKeep;
  private readonly Rectangle _thunderBluff;

  private Point _currentTarget;
  private timer? _orderTimer;
  private timer? _ambushTimer;
  private bool _stonemaulReached;
  private bool _awaitingArrival;
  private bool _concluded;

  /// <summary>
  /// Initializes a new instance of the <see cref="LongMarchCaravan"/> class, and immediately starts marching.
  /// </summary>
  public LongMarchCaravan(Faction taurenTribes, QuestTheLongMarch quest, List<unit> kodos, Rectangle stonemaulKeep,
    Rectangle thunderBluff)
  {
    _taurenTribes = taurenTribes;
    _quest = quest;
    _kodos = kodos;
    _stonemaulKeep = stonemaulKeep;
    _thunderBluff = thunderBluff;
    _thunderBluffTarget = Regions.ThunderbluffFlight.Center;
    var stonemaulControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N022_STONEMAUL);
    _currentTarget = new Point(stonemaulControlPoint.X, stonemaulControlPoint.Y);

    _stonemaulRescueUnits = stonemaulKeep.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _thunderBluffRescueUnits = thunderBluff.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

    foreach (var kodo in kodos)
    {
      PlayerUnitEventsHelper.RegisterDiesOrChangesOwnerOnce(OnKodoLost, kodo);
    }

    Tick();
    _orderTimer = timer.Create();
    _orderTimer.Start(OrderPulseInterval, true, Tick);
    _ambushTimer = timer.Create();
    _ambushTimer.Start(AmbushInterval, true, SpawnAmbush);
  }

  private void Tick()
  {
    if (_concluded || _awaitingArrival)
    {
      return;
    }

    var living = _kodos.Where(kodo => kodo.Alive).ToList();
    if (living.Count == 0)
    {
      return;
    }

    var closest = living.OrderBy(kodo => MathEx.GetDistanceBetweenPoints(kodo.GetPosition(), _currentTarget)).First();
    var closestDistance = MathEx.GetDistanceBetweenPoints(closest.GetPosition(), _currentTarget);
    Console.WriteLine($"[LongMarch] Closest kodo is {closestDistance:F0} units from target ({_currentTarget.X:F0}, {_currentTarget.Y:F0}), arrival radius {ArrivalRadius:F0}");

    if (closestDistance < ArrivalRadius)
    {
      BeginArrivalPause();
      return;
    }

    IssueMoveOrders(living);
  }

  private void IssueMoveOrders(List<unit> living)
  {
    var averageX = living.Average(kodo => kodo.X);
    var averageY = living.Average(kodo => kodo.Y);
    var directionX = _currentTarget.X - averageX;
    var directionY = _currentTarget.Y - averageY;
    var directionLength = Math.Sqrt(directionX * directionX + directionY * directionY);
    if (directionLength < 1)
    {
      directionLength = 1;
    }

    var perpendicularX = -directionY / directionLength;
    var perpendicularY = directionX / directionLength;
    var lineStart = -(living.Count - 1) / 2.0 * FormationSpacing;

    for (var i = 0; i < living.Count; i++)
    {
      var offset = lineStart + i * FormationSpacing;
      var offsetX = (float)(perpendicularX * offset);
      var offsetY = (float)(perpendicularY * offset);
      living[i].IssueOrder(ORDER_MOVE, _currentTarget.X + offsetX, _currentTarget.Y + offsetY);
    }
  }

  private void BeginArrivalPause()
  {
    _awaitingArrival = true;
    var arrivingAtThunderBluff = _stonemaulReached;
    Console.WriteLine($"[LongMarch] Caravan arrived at {(arrivingAtThunderBluff ? "Thunder Bluff" : "Stonemaul Keep")}, pausing before hand-off");
    var pauseTimer = timer.Create();
    pauseTimer.Start(ArrivalPauseSeconds, false, () =>
    {
      _awaitingArrival = false;
      if (arrivingAtThunderBluff)
      {
        OnReachThunderBluff();
      }
      else
      {
        OnReachStonemaulKeep();
      }

      pauseTimer.Dispose();
    });
  }

  private void OnReachStonemaulKeep()
  {
    if (_stonemaulReached || _concluded)
    {
      return;
    }

    _stonemaulReached = true;
    _taurenTribes.Player?.RescueGroup(_stonemaulRescueUnits);
    _quest.MarkStonemaulReached();
    _currentTarget = _thunderBluffTarget;
  }

  private void OnReachThunderBluff()
  {
    if (_concluded)
    {
      return;
    }

    OnReachStonemaulKeep();
    _taurenTribes.Player?.RescueGroup(_thunderBluffRescueUnits);
    _quest.MarkThunderBluffReached();
    Conclude();
  }

  private void OnKodoLost()
  {
    if (_concluded || _kodos.Any(kodo => kodo.Alive))
    {
      return;
    }

    if (!_stonemaulReached)
    {
      _stonemaulReached = true;
      InjureRescuedUnits(_stonemaulRescueUnits);
      _taurenTribes.Player?.RescueGroup(_stonemaulRescueUnits);
      _quest.MarkStonemaulReached();
    }

    InjureRescuedUnits(_thunderBluffRescueUnits);
    _taurenTribes.Player?.RescueGroup(_thunderBluffRescueUnits);
    _quest.MarkThunderBluffReached();
    Conclude();
  }

  private static void InjureRescuedUnits(IEnumerable<unit> units)
  {
    foreach (var rescuedUnit in units)
    {
      rescuedUnit.SetLifePercent(60);
    }
  }

  private void Conclude()
  {
    _concluded = true;
    _orderTimer?.Dispose();
    _orderTimer = null;
    _ambushTimer?.Dispose();
    _ambushTimer = null;
  }

  private void SpawnAmbush()
  {
    if (_concluded)
    {
      return;
    }

    var living = _kodos.Where(kodo => kodo.Alive).ToList();
    if (living.Count == 0)
    {
      return;
    }

    var origin = living[GetRandomInt(0, living.Count - 1)];
    var angle = GetRandomReal(0, 360) * Math.PI / 180.0;
    var spawnX = origin.X + (float)Math.Cos(angle) * 800;
    var spawnY = origin.Y + (float)Math.Sin(angle) * 800;

    if (IsInsideRect(spawnX, spawnY, _stonemaulKeep) || IsInsideRect(spawnX, spawnY, _thunderBluff))
    {
      Console.WriteLine($"[LongMarch] Skipped ambush wave - spawn point ({spawnX:F0}, {spawnY:F0}) is inside a safe zone");
      return;
    }

    var spawnedNames = new List<string>();
    for (var i = 0; i < AmbushWaveSize; i++)
    {
      var unitType = AmbushUnitTypes[GetRandomInt(0, AmbushUnitTypes.Length - 1)];
      var attacker = unit.Create(player.NeutralAggressive, unitType, spawnX, spawnY, GetRandomReal(0, 360));
      var attackPlayerUnits = GetRandomInt(0, 1) == 0;
      var target = (attackPlayerUnits ? GetNearestPlayerUnit(spawnX, spawnY) : null) ?? origin;
      attacker.IssueOrder(ORDER_ATTACK, target);
      spawnedNames.Add($"{GetObjectName(unitType)} -> {(target == origin ? "kodo" : "player unit")}");
    }

    Console.WriteLine($"[LongMarch] Ambush wave spawned at ({spawnX:F0}, {spawnY:F0}): {string.Join(", ", spawnedNames)}");
  }

  private static bool IsInsideRect(float x, float y, Rectangle rect) =>
    x >= rect.Rect.MinX && x <= rect.Rect.MaxX && y >= rect.Rect.MinY && y <= rect.Rect.MaxY;

  private unit? GetNearestPlayerUnit(float x, float y)
  {
    var player = _taurenTribes.Player;
    if (player == null)
    {
      return null;
    }

    var origin = new Point(x, y);
    return GlobalGroup.EnumUnitsOfPlayer(player)
      .Where(playerUnit => playerUnit.Alive && !playerUnit.IsUnitType(unittype.Structure))
      .OrderBy(playerUnit => MathEx.GetDistanceBetweenPoints(playerUnit.GetPosition(), origin))
      .FirstOrDefault();
  }
}
