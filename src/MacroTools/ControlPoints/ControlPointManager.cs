using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Exceptions;
using MacroTools.Extensions;
using MacroTools.GameTime;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared;

namespace MacroTools.ControlPoints;

/// <summary>
/// Manages lifetimes and storage of all <see cref="ControlPoint"/>s.
/// </summary>
public sealed class ControlPointManager
{
  static ControlPointManager()
  {
    GameTimeManager.RegisterOnTurn(1, () =>
    {
      timer.Create().Start(Period, true, () =>
      {
        foreach (var player in Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
        {
          var playerData = player.GetPlayerData();
          if (playerData.Faction != null)
          {
            playerData.AddFractionalGold(playerData.TotalIncome * Period / 60);
          }
        }
      });
    });
  }

  /// <summary>
  /// The singleton instance of the <see cref="ControlPointManager"/> class.
  /// </summary>
  public static ControlPointManager Instance
  {
    get
    {
      if (_instance == null)
      {
        throw new SystemNotInitializedException($"{nameof(ControlPointManager)} has not been initialized.");
      }

      return _instance;
    }
    set
    {
      if (_instance != null)
      {
        throw new SystemAlreadyInitializedException($"{nameof(ControlPointManager)} has already been initialized.");
      }

      _instance = value;
    }
  }

  /// <summary>
  /// All <see cref="ControlPoint"/>s are given this many hitpoints.
  /// </summary>
  public required int StartingMaxHitPoints { get; init; }

  /// <summary>
  /// All Neutral Hostile <see cref="ControlPoint"/>s start with this many hit points.
  /// </summary>
  public required int HostileStartingCurrentHitPoints { get; init; }

  /// <summary>
  /// An ability that grants <see cref="ControlPoint"/>s additional hit point regeneration.
  /// </summary>
  public required int RegenerationAbility { get; init; }

  /// <summary>
  /// An ability that grants <see cref="ControlPoint"/>s resistance against Piercing damage.
  /// </summary>
  public required int PiercingResistanceAbility { get; init; }

  /// <summary>
  /// Determines the settings for the <see cref="ControlPoint.Defender"/> units that defend <see cref="ControlPoint"/>s.
  /// </summary>
  public required ControlPointSettings ControlPointSettings { get; init; }

  /// <summary>
  /// Fired when a <see cref="ControlPoint"/> is created.
  /// </summary>
  public event Action<ControlPoint>? ControlPointCreated;

  /// <summary>
  /// This ability can be used to increase a <see cref="ControlPoint"/>'s <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public int IncreaseControlLevelAbilityTypeId
  {
    get => _increaseControlLevelAbilityTypeId;
    init
    {
      _increaseControlLevelAbilityTypeId = value;
      PlayerUnitEvents.Register(SpellEvent.Effect, () =>
      {
        try
        {
          var controlPoint = _byUnit[@event.Unit];
          controlPoint.ControlLevel += 1;
          effect effect = effect.Create(@"Abilities\Spells\Items\AIlm\AIlmTarget.mdl", controlPoint.Unit.X, controlPoint.Unit.Y);
          effect.Scale = 1.5f;
          EffectSystem.Add(effect);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Failed to execute {GetObjectName(IncreaseControlLevelAbilityTypeId)}: {ex}.");
        }
      }, _increaseControlLevelAbilityTypeId);
    }
  }

  /// <summary>
  ///   How often players receive income.
  ///   Changing this will not affect the total amount of income they receive.
  /// </summary>
  private const float Period = 1;

  private static ControlPointManager? _instance;

  private readonly Dictionary<int, ControlPoint> _byUnitType = new();
  private readonly Dictionary<unit, ControlPoint> _byUnit = new();
  private readonly int _increaseControlLevelAbilityTypeId;

  /// <summary>
  /// Returns all registered <see cref="ControlPoint"/>s.
  /// </summary>
  public List<ControlPoint> GetAllControlPoints() => _byUnit.Values.ToList();

  /// <summary>
  ///   Whether the given unit is a <see cref="ControlPoint" />.
  /// </summary>
  public bool UnitIsControlPoint(unit unit) => _byUnit.ContainsKey(unit);

  /// <summary>
  ///   Returns the <see cref="ControlPoint" /> with the given unit type ID.
  /// </summary>
  public ControlPoint GetFromUnitType(int unitType)
  {
    if (_byUnitType.TryGetValue(unitType, out var controlPoint))
    {
      return controlPoint;
    }

    throw new KeyNotFoundException($"There is no {nameof(ControlPoint)} with unit type ID {Utils.FourCc.GetString(unitType)}");
  }

  /// <summary>
  /// Creates a new <see cref="ControlPoint"/>, causing it to grant income over time.
  /// </summary>
  /// <param name="representingUnit">The unit representing the Control Point on the map.</param>
  /// <param name="value">The income gained per turn from owning the Control Point.</param>
  /// <param name="useControlLevels">Whether the Control Point accumulates a level each turn.</param>
  public void Create(unit representingUnit, int value, bool useControlLevels)
  {
    var controlPoint = new ControlPoint(representingUnit, value, useControlLevels);
    _byUnit.Add(controlPoint.Unit, controlPoint);
    _byUnitType.TryAdd(controlPoint.UnitType, controlPoint);

    controlPoint.Unit.MaxLife = StartingMaxHitPoints;
    controlPoint.Unit.Life = representingUnit.Owner == player.NeutralAggressive ? HostileStartingCurrentHitPoints : controlPoint.Unit.MaxLife;
    controlPoint.Unit.DefenseType = WCSharp.Api.Enums.DefenseType.Large;
    controlPoint.Unit.ShowAttackUi(false);

    controlPoint.Unit.Name = $"{controlPoint.Unit.Name} ({controlPoint.Value} gold/min)";
    controlPoint.Unit.AddAbility(PiercingResistanceAbility);

    RegisterIncome(controlPoint);

    PlayerUnitEvents.Register(UnitEvent.IsDamaged, () => OnControlPointDamaged(controlPoint), controlPoint.Unit);
    PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () => OnControlPointChangesOwner(controlPoint), controlPoint.Unit);

    if (controlPoint.UseControlLevels)
    {
      RegisterControlLevelGrowthOverTime(controlPoint);
      controlPoint.ControlLevelChanged += OnControlPointLevelChanged;
      controlPoint.Unit.AddAbility(IncreaseControlLevelAbilityTypeId);
    }

    controlPoint.OnRegister();
    if (controlPoint.Unit.Owner != player.NeutralAggressive)
    {
      controlPoint.Unit.AddAbility(RegenerationAbility);
    }

    ControlPointCreated?.Invoke(controlPoint);
  }

  private static void RegisterIncome(ControlPoint controlPoint)
  {
    var playerData = controlPoint.Owner.GetPlayerData();
    playerData.AddControlPoint(controlPoint);
    playerData.BaseIncome += controlPoint.Value;
  }

  private static void OnControlPointDamaged(ControlPoint controlPoint)
  {
    try
    {
      var attacker = @event.DamageSource;
      var hitPoints = controlPoint.Unit.Life - @event.Damage;
      if (hitPoints > 1)
      {
        return;
      }

      @event.Damage = 0;
      controlPoint.Unit.SetOwner(attacker.Owner);
      controlPoint.Unit.SetLifePercent(100);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  private void OnControlPointChangesOwner(ControlPoint controlPoint)
  {
    try
    {
      var previousOwner = PlayerData.ByHandle(@event.ChangingUnitPrevOwner);
      previousOwner.RemoveControlPoint(controlPoint);
      previousOwner.BaseIncome -= controlPoint.Value;

      var newOwner = PlayerData.ByHandle(@event.Unit.Owner);
      newOwner.AddControlPoint(controlPoint);
      newOwner.BaseIncome += controlPoint.Value;

      if (controlPoint.Unit.GetAbilityLevel(RegenerationAbility) == 0)
      {
        controlPoint.Unit.AddAbility(RegenerationAbility);
      }

      controlPoint.Unit.SetLifePercent(100);
      controlPoint.ControlLevel = 0;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  private void RegisterControlLevelGrowthOverTime(ControlPoint controlPoint)
  {
    GameTimeManager.RegisterOnTurnRepeating(1, () =>
    {
      if (controlPoint.Owner == player.NeutralAggressive ||
          controlPoint.Owner == player.NeutralPassive ||
          controlPoint.Owner == player.NeutralVictim ||
          controlPoint.ControlLevel >= ControlPointSettings.ControlLevelMaximum)
      {
        return;
      }

      controlPoint.ControlLevel += 1 + controlPoint.Owner.GetControlLevelPerTurnBonus();
      effect effect = effect.Create(@"Abilities\Spells\Items\AIlm\AIlmTarget.mdl", controlPoint.Unit.X, controlPoint.Unit.Y);
      effect.Scale = 1.5f;
      EffectSystem.Add(effect);
    });
  }

  private void OnControlPointLevelChanged(ControlPoint controlPoint)
  {
    var unit = controlPoint.Unit;

    var flooredLevel = (int)controlPoint.ControlLevel;
    var maxHitPoints = StartingMaxHitPoints + flooredLevel * ControlPointSettings.HitPointsPerControlLevel;
    var lifePercent = Math.Max(controlPoint.Unit.GetLifePercent(), 1);

    controlPoint.Unit.MaxLife = maxHitPoints;
    controlPoint.Unit.Level = flooredLevel;
    controlPoint.Unit.Armor = ControlPointSettings.ArmorPerControlLevel * flooredLevel;
    controlPoint.Unit.SetLifePercent(lifePercent);

    if (unit.GetAbilityLevel(IncreaseControlLevelAbilityTypeId) > 0 && controlPoint.ControlLevel >= ControlPointSettings.ControlLevelMaximum)
    {
      unit.RemoveAbility(IncreaseControlLevelAbilityTypeId);
      return;
    }

    if (unit.GetAbilityLevel(IncreaseControlLevelAbilityTypeId) == 0 && controlPoint.ControlLevel < ControlPointSettings.ControlLevelMaximum)
    {
      unit.AddAbility(IncreaseControlLevelAbilityTypeId);
    }
  }
}
