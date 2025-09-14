using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Exceptions;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.Systems;
using WCSharp.Events;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace MacroTools.ControlPointSystem
{
  /// <summary>
  /// Manages lifetimes and storage of all <see cref="ControlPoint"/>s.
  /// </summary>
  public sealed class ControlPointManager
  {
    static ControlPointManager()
    {
      GameTime.GameStarted += (_, _) =>
      {
        CreateTimer().Start(Period, true, () =>
        {
          foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
            if (player.GetFaction() != null)
            {
              var goldPerSecond = player.GetTotalIncome() * Period / 60;
              player.AddGold(goldPerSecond);
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
          throw new SystemNotInitializedException($"{nameof(ControlPointManager)} has not been initialized.");
        return _instance;
      }
      set
      {
        if (_instance != null)
          throw new SystemAlreadyInitializedException($"{nameof(ControlPointManager)} has already been initialized.");
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
            var controlPoint = _byUnit[GetTriggerUnit()];
            controlPoint.ControlLevel += 1;
            AddSpecialEffect(@"Abilities\Spells\Items\AIlm\AIlmTarget.mdl", GetUnitX(controlPoint.Unit),
                GetUnitY(controlPoint.Unit))
              .SetScale(1.5f)
              .SetLifespan();
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
        return controlPoint;
      throw new KeyNotFoundException(
        $"There is no {nameof(ControlPoint)} with unit type ID {GeneralHelpers.DebugIdInteger2IdString(unitType)}");
    }

    /// <summary>
    ///   Registers a <see cref="ControlPoint" /> to the Control Point system.
    /// </summary>
    public void Register(ControlPoint controlPoint)
    {
      _byUnit.Add(controlPoint.Unit, controlPoint);
      if (!_byUnitType.ContainsKey(controlPoint.UnitType))
        _byUnitType.Add(controlPoint.UnitType, controlPoint);

      BlzSetUnitMaxHP(controlPoint.Unit, StartingMaxHitPoints);
      controlPoint.Unit.SetLifePercent(100);
      controlPoint.Unit.SetArmorType(2);

      BlzSetUnitName(controlPoint.Unit, $"{GetUnitName(controlPoint.Unit)} ({controlPoint.Value} gold/min)");
      UnitAddAbility(controlPoint.Unit, PiercingResistanceAbility);
      
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
      if (controlPoint.Unit.OwningPlayer() != Player(PLAYER_NEUTRAL_AGGRESSIVE))
        controlPoint.Unit.AddAbility(RegenerationAbility);
    }

    private static void RegisterIncome(ControlPoint controlPoint)
    {
      var controlPointOwner = PlayerData.ByHandle(controlPoint.Owner);
      controlPointOwner.AddControlPoint(controlPoint);
      controlPointOwner.BaseIncome = controlPoint.Owner.GetBaseIncome() + controlPoint.Value;
    }

    private static void RegisterDamageTrigger(ControlPoint controlPoint)
    {
      var trigger = CreateTrigger();
      trigger.RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_DAMAGED);
      trigger.AddAction(() =>
      {
        try
        {
          var attacker = GetEventDamageSource();
          var hitPoints = GetUnitState(controlPoint.Unit, UNIT_STATE_LIFE) - GetEventDamage();
          if (hitPoints > 1)
            return;
          BlzSetEventDamage(0);
          SetUnitOwner(controlPoint.Unit, GetOwningPlayer(attacker), true);
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
      var trigger = CreateTrigger();
      trigger.RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_CHANGE_OWNER);
      trigger.AddAction(() =>
        {
          try
          {
            var previousOwner = PlayerData.ByHandle(GetChangingUnitPrevOwner());
            previousOwner.RemoveControlPoint(controlPoint);
            previousOwner.BaseIncome -= controlPoint.Value;

            var newOwner = PlayerData.ByHandle(GetTriggerUnit().OwningPlayer());
            newOwner.AddControlPoint(controlPoint);
            newOwner.BaseIncome += controlPoint.Value;

            if (GetUnitAbilityLevel(controlPoint.Unit, RegenerationAbility) == 0)
              controlPoint.Unit.AddAbility(RegenerationAbility);
            
            if (GetUnitAbilityLevel(controlPoint.Unit, PiercingResistanceAbility) == 0)
              controlPoint.Unit.AddAbility(PiercingResistanceAbility);
            
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
          SetUnitScale(controlPoint.Unit, 1.2f, 1.2f, 1.2f);
          if ((int)controlPoint.ControlLevel == ControlLevelSettings.ControlLevelMaximum)
          {
            UnitRemoveAbility(controlPoint.Unit, IncreaseControlLevelAbilityTypeId);
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
      GameTime.TurnEnded += (_, _) =>
      {
        if (controlPoint.Owner == Player(PLAYER_NEUTRAL_AGGRESSIVE) ||
            controlPoint.Owner == Player(PLAYER_NEUTRAL_PASSIVE) ||
            controlPoint.Owner == Player(bj_PLAYER_NEUTRAL_VICTIM) ||
            controlPoint.ControlLevel >= ControlLevelSettings.ControlLevelMaximum)
          return;
        controlPoint.ControlLevel += 1 + controlPoint.Owner.GetControlLevelPerTurnBonus();
        AddSpecialEffect(@"Abilities\Spells\Items\AIlm\AIlmTarget.mdl", GetUnitX(controlPoint.Unit),
            GetUnitY(controlPoint.Unit))
          .SetScale(1.5f)
          .SetLifespan();
      };
    }

    private void ConfigureControlPointStats(ControlPoint controlPoint, bool initialize)
    {
      var flooredLevel = (int)controlPoint.ControlLevel;
      var maxHitPoints = StartingMaxHitPoints + flooredLevel * ControlLevelSettings.HitPointsPerControlLevel;
      var lifePercent = Math.Max(controlPoint.Unit.GetLifePercent(), 1);

      BlzSetUnitMaxHP(controlPoint.Unit, maxHitPoints);
      BlzSetUnitArmor(controlPoint.Unit, ControlLevelSettings.ArmorPerControlLevel * ControlLevelSettings.ArmorPerControlLevel);
      BlzSetUnitIntegerField(controlPoint.Unit, UNIT_IF_LEVEL, flooredLevel);
      BlzSetUnitArmor(controlPoint.Unit, ControlLevelSettings.ArmorPerControlLevel * flooredLevel);
      controlPoint.Unit
        .ShowAttackUi(false);

      if (initialize && controlPoint.Unit.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE))
      {
        SetUnitState(controlPoint.Unit, UNIT_STATE_LIFE, HostileStartingCurrentHitPoints);
      }
      else
        controlPoint.Unit.SetLifePercent(lifePercent);

      ConfigureControlPointOrDefenderAttack(controlPoint.Unit, flooredLevel);
    }

    private void CreateOrUpdateDefender(ControlPoint controlPoint)
    {
      var flooredLevel = (int)controlPoint.ControlLevel;

      var defenderUnitTypeId = controlPoint.Owner.GetFaction()?.ControlPointDefenderUnitTypeId ??
                               ControlLevelSettings.DefaultDefenderUnitTypeId;
      controlPoint.Defender ??= CreateUnit(controlPoint.Owner, defenderUnitTypeId, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit), 270);
      controlPoint.Defender.AddAbility(FourCC("Aloc"));
      SetUnitInvulnerable(controlPoint.Defender, true);
      ConfigureControlPointOrDefenderAttack(controlPoint.Defender, flooredLevel);
      ConfigureControlPointOrDefenderAttack(controlPoint.Unit, flooredLevel);
    }

    private void RemoveDefender(ControlPoint controlPoint)
    {
      if (controlPoint.Defender != null) 
        KillUnit(controlPoint.Defender);

      controlPoint.Defender = null;
      SetUnitInvulnerable(controlPoint.Unit, false);
      controlPoint.Unit
        .AddAbility(IncreaseControlLevelAbilityTypeId);
    }

    private void ConfigureControlPointOrDefenderAttack(unit whichUnit, int controlLevel)
    {
      BlzSetUnitBaseDamage(whichUnit, controlLevel == 0
        ? -1
        : ControlLevelSettings.DamageBase - 1 + controlLevel * ControlLevelSettings.DamagePerControlLevel, 0);
      BlzSetUnitDiceNumber(whichUnit, 1, 0);
      BlzSetUnitDiceSides(whichUnit, 1, 0);
      whichUnit.SetAttackType(5);
    }
  }
}