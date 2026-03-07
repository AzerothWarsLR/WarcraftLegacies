using System;
using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Exceptions;
using MacroTools.Extensions;
using MacroTools.GameTime;
using WCSharp.Events;

namespace MacroTools.GoldMines;

/// <summary>
/// Creates and manages gold mines that can appear atop <see cref="ControlPoint"/>s.
/// <remarks>Gold mines provide additional income on top of a Control Point's normal. Unlike Control Points, they
/// have a limited supply and will be permanently removed when it is exhausted.
/// <para>When a Control Point changes owner, any Gold Mine it has will be destroyed.</para>
/// <para>All Control Points unit types must have Gold Mine Ability for the user interface to correctly reflect
/// current gold remaining.</para>
/// </remarks>
/// </summary>
public static class GoldMineManager
{
  private static ControlPointManager _controlPointManager = null!;
  private static GoldMineSettings _settings = null!;
  private static bool _initialized;
  private static readonly List<GoldMine> _goldMines = new();

  /// <summary>
  /// Initializes the <see cref="GoldMineManager"/>, allowing Gold Mines to be created.
  /// <param name="controlPointManager">The <see cref="ControlPointManager"/> instance to listen to for changes in
  /// <see cref="ControlPoint"/>s.</param>
  /// <param name="settings">Settings controlling the core behaviour of Gold Mines.</param>
  /// </summary>
  public static void Initialize(ControlPointManager controlPointManager, GoldMineSettings settings)
  {
    if (_initialized)
    {
      throw new SystemAlreadyInitializedException($"The {nameof(GoldMineManager)} has already been initialized.");
    }

    _controlPointManager = controlPointManager;
    _settings = settings;
    _initialized = true;

    GameTimeManager.RegisterOnTurn(1, OnTurn);
  }

  /// <summary>
  /// Preregisters a unit type ID to be given a Gold Mine when a <see cref="ControlPoint"/> is created with that ID.
  /// <remarks>
  /// <para>If the ControlPoint already exists, will instead be registered immediately.</para>
  /// <para>Only fires once for each unit type ID registered.</para>
  /// </remarks>
  /// </summary>
  /// <param name="unitTypeId">The unit type to wait for.</param>
  /// <param name="income">The gold per turn that the Gold Mine provides.</param>
  /// <param name="capacity">How much gold the Gold Mine will provide before it's removed.</param>
  public static void Preregister(int unitTypeId, int income, int capacity)
  {
    if (!_initialized)
    {
      throw new SystemNotInitializedException($"The {nameof(GoldMineManager)} has not been initialized.");
    }

    if (_controlPointManager.TryGetFromUnitType(unitTypeId, out var preExistingPoint))
    {
      Create(preExistingPoint, income, capacity);
      return;
    }

    EventHandler<ControlPoint>? onControlPointCreated = null;
    onControlPointCreated = (_, point) =>
    {
      if (point.Unit.UnitType == unitTypeId)
      {
        Create(point, income, capacity);
        _controlPointManager.ControlPointCreated -= onControlPointCreated;
      }
    };
    _controlPointManager.ControlPointCreated += onControlPointCreated;
  }

  /// <summary>
  /// Creates a Gold Mine.
  /// </summary>
  /// <param name="controlPoint">Which Control Point to create the mine atop of.</param>
  /// <param name="income">The gold per turn that the Gold Mine provides.</param>
  /// <param name="capacity">How much gold the Gold Mine will provide before it's removed.</param>
  public static void Create(ControlPoint controlPoint, int income, int capacity)
  {
    if (!_initialized)
    {
      throw new SystemNotInitializedException($"The {nameof(GoldMineManager)} has not been initialized.");
    }

    var unit = controlPoint.Unit;
    unit.AddAbility(FourCC("Agld"));
    var effect = AddSpecialEffect(_settings.GoldMineModelDefault, unit.X, unit.Y);
    effect.PlayAnimation(animtype.Stand);
    effect.Scale = 1.2f;
    controlPoint.Owner.GetPlayerData().BonusIncome += income;
    var createdGoldMine = new GoldMine(effect, income, capacity, controlPoint);
    _goldMines.Add(createdGoldMine);
    controlPoint.AttackEnabled--;

    Action? onControlPointOwnerChanged = null;
    onControlPointOwnerChanged = () =>
    {
      @event.ChangingUnitPrevOwner.GetPlayerData().BonusIncome -= income;
      controlPoint.Owner.GetPlayerData().BonusIncome += income;
      Destroy(createdGoldMine);
      PlayerUnitEvents.Unregister(UnitEvent.ChangesOwner, onControlPointOwnerChanged, controlPoint.Unit);
    };
    PlayerUnitEvents.Register(UnitEvent.ChangesOwner, onControlPointOwnerChanged, controlPoint.Unit);
  }

  private static void OnTurn() =>
    PeriodicEvents.AddPeriodicEvent(() =>
    {
      foreach (var goldMine in _goldMines)
      {
        goldMine.Remaining -= (float)goldMine.Income / 60;
        if (goldMine.Remaining <= 0)
        {
          Destroy(goldMine);
        }
      }
      return true;
    }, 1);

  /// <summary>
  /// Destroys an existing Gold Mine, removing it from the map forever.
  /// </summary>
  private static void Destroy(GoldMine goldMine)
  {
    goldMine.Effect.Dispose();
    _goldMines.Remove(goldMine);
    goldMine.ControlPoint.Unit.RemoveAbility(FourCC("Agld"));
    goldMine.ControlPoint.AttackEnabled++;
    goldMine.ControlPoint.Owner.GetPlayerData().BonusIncome -= goldMine.Income;
  }
}
