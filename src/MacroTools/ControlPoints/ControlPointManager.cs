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
    GameTimeManager.GameStarted += (_, _) =>
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
    };
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
  public int StartingMaxHitPoints { get; init; }

  /// <summary>
  /// All Neutral Hostile <see cref="ControlPoint"/>s start with this many hit points.
  /// </summary>
  public int HostileStartingCurrentHitPoints { get; init; }

  /// <summary>
  /// An ability that grants <see cref="ControlPoint"/>s additional hit point regeneration.
  /// </summary>
  public int RegenerationAbility { get; init; }

  /// <summary>
  /// An ability that grants <see cref="ControlPoint"/>s resistance against Piercing damage.
  /// </summary>
  public int PiercingResistanceAbility { get; init; }

  /// <summary>
  /// Determines the settings for the <see cref="ControlPoint.Defender"/> units that defend <see cref="ControlPoint"/>s.
  /// </summary>
  public ControlLevelSettings ControlLevelSettings { get; init; } = new();

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
  ///   Registers a <see cref="ControlPoint" /> to the Control Point system.
  /// </summary>
  public void Register(ControlPoint controlPoint)
  {
    _byUnit.Add(controlPoint.Unit, controlPoint);
    _byUnitType.TryAdd(controlPoint.UnitType, controlPoint);
    controlPoint.Unit.MaxLife = StartingMaxHitPoints;
    controlPoint.Unit.SetLifePercent(100);
    controlPoint.Unit.DefenseType = WCSharp.Api.Enums.DefenseType.Large;

    controlPoint.Unit.Name = $"{controlPoint.Unit.Name} ({controlPoint.Value} gold/min)";
    controlPoint.Unit.AddAbility(PiercingResistanceAbility);

    RegisterIncome(controlPoint);
    RegisterDamageTrigger(controlPoint);
    RegisterOwnershipChangeTrigger(controlPoint);

    if (controlPoint.UseControlLevels)
    {
      RegisterControlLevelChangeTrigger(controlPoint);
      RegisterControlLevelGrowthOverTime(controlPoint);
      ConfigureControlPointStats(controlPoint, true);
      controlPoint.Unit.AddAbility(IncreaseControlLevelAbilityTypeId);
    }

    controlPoint.OnRegister();
    if (controlPoint.Unit.Owner != player.NeutralAggressive)
    {
      controlPoint.Unit.AddAbility(RegenerationAbility);
    }
  }

  private static void RegisterIncome(ControlPoint controlPoint)
  {
    var playerData = controlPoint.Owner.GetPlayerData();
    playerData.AddControlPoint(controlPoint);
    playerData.BaseIncome += controlPoint.Value;
  }

  private static void RegisterDamageTrigger(ControlPoint controlPoint)
  {
    trigger trigger = trigger.Create();
    trigger.RegisterUnitEvent(controlPoint.Unit, unitevent.Damaged);
    trigger.AddAction(() =>
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
    });
  }

  private void RegisterOwnershipChangeTrigger(ControlPoint controlPoint)
  {
    trigger trigger = trigger.Create();
    trigger.RegisterUnitEvent(controlPoint.Unit, unitevent.ChangeOwner);
    trigger.AddAction(() =>
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

        if (controlPoint.Unit.GetAbilityLevel(PiercingResistanceAbility) == 0)
        {
          controlPoint.Unit.AddAbility(PiercingResistanceAbility);
        }

        controlPoint.Unit.SetLifePercent(100);
        controlPoint.ControlLevel = 0;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    });
  }

  private void RegisterControlLevelChangeTrigger(ControlPoint controlPoint)
  {
    controlPoint.ControlLevelChanged += (_, _) =>
    {
      if (controlPoint.ControlLevel > 0)
      {
        CreateOrUpdateDefender(controlPoint);
        ConfigureControlPointStats(controlPoint, false);
        controlPoint.Unit.SetScale(1.2f, 1.2f, 1.2f);
        if ((int)controlPoint.ControlLevel == ControlLevelSettings.ControlLevelMaximum)
        {
          controlPoint.Unit.RemoveAbility(IncreaseControlLevelAbilityTypeId);
        }
      }
      else
      {
        RemoveDefender(controlPoint);
        ConfigureControlPointStats(controlPoint, false);
      }
    };
  }

  private void RegisterControlLevelGrowthOverTime(ControlPoint controlPoint)
  {
    GameTimeManager.TurnEnded += (_, _) =>
    {
      if (controlPoint.Owner == player.NeutralAggressive ||
          controlPoint.Owner == player.NeutralPassive ||
          controlPoint.Owner == player.NeutralVictim ||
          controlPoint.ControlLevel >= ControlLevelSettings.ControlLevelMaximum)
      {
        return;
      }

      controlPoint.ControlLevel += 1 + controlPoint.Owner.GetControlLevelPerTurnBonus();
      effect effect = effect.Create(@"Abilities\Spells\Items\AIlm\AIlmTarget.mdl", controlPoint.Unit.X, controlPoint.Unit.Y);
      effect.Scale = 1.5f;
      EffectSystem.Add(effect);
    };
  }

  private void ConfigureControlPointStats(ControlPoint controlPoint, bool initialize)
  {
    var flooredLevel = (int)controlPoint.ControlLevel;
    var maxHitPoints = StartingMaxHitPoints + flooredLevel * ControlLevelSettings.HitPointsPerControlLevel;
    var lifePercent = Math.Max(controlPoint.Unit.GetLifePercent(), 1);

    controlPoint.Unit.MaxLife = maxHitPoints;
    controlPoint.Unit.Level = flooredLevel;
    controlPoint.Unit.Armor = ControlLevelSettings.ArmorPerControlLevel * flooredLevel;
    controlPoint.Unit
      .ShowAttackUi(false);

    if (initialize && controlPoint.Unit.Owner == player.NeutralAggressive)
    {
      controlPoint.Unit.Life = HostileStartingCurrentHitPoints;
    }
    else
    {
      controlPoint.Unit.SetLifePercent(lifePercent);
    }

    ConfigureControlPointOrDefenderAttack(controlPoint.Unit, flooredLevel);
  }

  private void CreateOrUpdateDefender(ControlPoint controlPoint)
  {
    var flooredLevel = (int)controlPoint.ControlLevel;

    var owner = controlPoint.Owner;
    var playerData = owner.GetPlayerData();

    var defenderUnitTypeId = playerData.Faction?.ControlPointDefenderUnitTypeId ?? ControlLevelSettings.DefaultDefenderUnitTypeId;
    controlPoint.Defender ??= unit.Create(owner, defenderUnitTypeId, controlPoint.Unit.X, controlPoint.Unit.Y);
    controlPoint.Defender.AddAbility(FourCC("Aloc"));
    controlPoint.Defender.IsInvulnerable = true;
    ConfigureControlPointOrDefenderAttack(controlPoint.Defender, flooredLevel);
    ConfigureControlPointOrDefenderAttack(controlPoint.Unit, flooredLevel);
  }

  private void RemoveDefender(ControlPoint controlPoint)
  {
    if (controlPoint.Defender != null)
    {
      controlPoint.Defender.Kill();
    }

    controlPoint.Defender = null;
    controlPoint.Unit.IsInvulnerable = false;
    controlPoint.Unit.AddAbility(IncreaseControlLevelAbilityTypeId);
  }

  private void ConfigureControlPointOrDefenderAttack(unit whichUnit, int controlLevel)
  {
    whichUnit.AttackBaseDamage1 = controlLevel == 0
      ? -1
      : ControlLevelSettings.DamageBase - 1 + controlLevel * ControlLevelSettings.DamagePerControlLevel;
    whichUnit.AttackDiceNumber1 = 1;
    whichUnit.AttackDiceSides1 = 1;
    whichUnit.AttackAttackType1 = WCSharp.Api.Enums.AttackType.Chaos;
  }
}
