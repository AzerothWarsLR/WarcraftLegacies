using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
using WCSharp.Events;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace MacroTools.ControlPointSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="ControlPoint"/>s.
  /// </summary>
  public sealed class ControlPointManager
  {
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
    /// The percentage of maximum hitpoints below which <see cref="ControlPoint"/>s will be transferred to the attacker.
    /// </summary>
    public float CaptureThreshold { get; init; }

    /// <summary>
    /// All <see cref="ControlPoint"/>s are given this many hitpoints.
    /// </summary>
    public int MaxHitpoints { get; init; }

    /// <summary>
    /// All <see cref="ControlPoint"/>s are given this ability.
    /// </summary>
    public int RegenerationAbility { get; init; }
    
    /// <summary>
    /// The maximum <see cref="ControlPoint.ControlLevel"/> a <see cref="ControlPoint"/> can have.
    /// </summary>
    public int ControlLevelMaximum { get; init; }

    /// <summary>
    /// Determines the settings for the <see cref="ControlPoint.Defender"/> units that defend <see cref="ControlPoint"/>s.
    /// </summary>
    public DefenderSettings DefenderSettings { get; init; } = new();

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
            controlPoint.ControlLevel++;
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
    ///   Whether or not the given unit is a <see cref="ControlPoint" />.
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
      if (_byUnitType.ContainsKey(controlPoint.UnitType))
        WarningLogger.Log(
          $"There are two Control Points with the same ID of {GeneralHelpers.DebugIdInteger2IdString(controlPoint.UnitType)}.");
      else
        _byUnitType.Add(controlPoint.UnitType, controlPoint);
      
      controlPoint.Unit
        .SetMaximumHitpoints(MaxHitpoints)
        .SetLifePercent(80)
        .AddAbility(IncreaseControlLevelAbilityTypeId);
      RegisterIncomeGeneration(controlPoint);
      RegisterDamageTrigger(controlPoint);
      RegisterOwnershipChangeTrigger(controlPoint);
      RegisterControlLevelChangeTrigger(controlPoint);
      RegisterControlLevelGrowthOverTime(controlPoint);
    }

    private static void RegisterIncomeGeneration(ControlPoint controlPoint)
    {
      controlPoint.Owner.SetBaseIncome(controlPoint.Owner.GetBaseIncome() + controlPoint.Value);
      controlPoint.Owner.SetControlPointCount(controlPoint.Owner.GetControlPointCount() + 1);
      var incomeTimer = CreateTimer();
      TimerStart(incomeTimer, Period, true, () =>
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
          if (player.GetFaction() != null)
          {
            var goldPerSecond = player.GetTotalIncome() * Period / 60;
            player.AddGold(goldPerSecond);
            var lumberPerSecond = player.GetLumberIncome() * Period / 60;
            player.AddLumber(lumberPerSecond);
          }
      });
    }
    
    private void RegisterDamageTrigger(ControlPoint controlPoint)
    {
      CreateTrigger()
        .RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_DEATH)
        .AddAction(() =>
        {
          try
          {
            var attacker = GetEventDamageSource();

            var hitPoints = (GetUnitState(controlPoint.Unit, UNIT_STATE_LIFE) - GetEventDamage()) /
                            GetUnitState(controlPoint.Unit, UNIT_STATE_MAX_LIFE);
            if (!(hitPoints < CaptureThreshold)) return;
            BlzSetEventDamage(0);
            SetUnitOwner(controlPoint.Unit, GetOwningPlayer(attacker), true);
            controlPoint.Unit.SetLifePercent(85);
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex);
          }
        });
    }
    
    private void RegisterOwnershipChangeTrigger(ControlPoint controlPoint)
    {
      CreateTrigger()
        .RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_CHANGE_OWNER)
        .AddAction(() =>
        {
          try
          {
            var formerOwner = GetChangingUnitPrevOwner();
            var newOwner = GetTriggerUnit().OwningPlayer();

            var playerData = PlayerData.ByHandle(formerOwner);

            playerData.ControlPointCount -= 1;
            playerData.BaseIncome -= controlPoint.Value;

            playerData = PlayerData.ByHandle(newOwner);

            playerData.ControlPointCount += 1;
            playerData.BaseIncome += controlPoint.Value;

            UnitAddAbility(controlPoint.Unit, RegenerationAbility);
            SetUnitState(controlPoint.Unit, UNIT_STATE_LIFE, GetUnitState(controlPoint.Unit, UNIT_STATE_MAX_LIFE));
            controlPoint.SignalOwnershipChange(new ControlPointOwnerChangeEventArgs(controlPoint, GetChangingUnitPrevOwner()));
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
          controlPoint.Defender ??= CreateUnit(controlPoint.Owner, DefenderSettings.DefenderUnitTypeId, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit), 0);
          controlPoint.Defender
            .SetDamageBase(DefenderSettings.DamageBase + controlPoint.ControlLevel * DefenderSettings.DamagePerControlLevel)
            .AddAbility(FourCC("Aloc"))
            .SetInvulnerable(true);
          var defenderUnitTypeId = controlPoint.Owner.GetFaction()?.ControlPointDefenderTemplateUnitTypeId;
          if (defenderUnitTypeId != null && defenderUnitTypeId != 0)
            controlPoint.Defender.SetSkin(defenderUnitTypeId.Value);
          controlPoint.Unit
            .SetScale(2);
          ScaleHitpointsToControlLevel(controlPoint);
          CreateTrigger()
            .RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_CHANGE_OWNER)
            .AddAction(() =>
            {
              controlPoint.ControlLevel = 0;
              controlPoint.Defender?.Kill();
              controlPoint.Unit.SetScale(1);
              if (controlPoint.ControlLevel >= IncreaseControlLevelAbilityTypeId)
                controlPoint.Unit.RemoveAbility(IncreaseControlLevelAbilityTypeId);
              DestroyTrigger(GetTriggeringTrigger());
            });
        }
        else
        {
          controlPoint.Defender?.Kill();
          controlPoint.Defender = null;
          controlPoint.Unit
            .SetInvulnerable(false)
            .AddAbility(IncreaseControlLevelAbilityTypeId);
          ScaleHitpointsToControlLevel(controlPoint);
        }
      };
    }

    private void RegisterControlLevelGrowthOverTime(ControlPoint controlPoint)
    {
      GameTime.TurnEnded += (_, _) =>
      {
        if (controlPoint.Owner != Player(PLAYER_NEUTRAL_AGGRESSIVE) &&
            controlPoint.Owner != Player(PLAYER_NEUTRAL_PASSIVE) &&
            controlPoint.Owner != Player(bj_PLAYER_NEUTRAL_VICTIM) && 
            controlPoint.ControlLevel < ControlLevelMaximum)
          controlPoint.ControlLevel++;
      };
    }

    private void ScaleHitpointsToControlLevel(ControlPoint controlPoint)
    {
      var maxHitPoints = MaxHitpoints + controlPoint.ControlLevel * 500;
      var lifePercent = controlPoint.Unit.GetLifePercent();
      controlPoint.Unit
        .SetMaximumHitpoints(maxHitPoints)
        .SetLifePercent(lifePercent);
    }
  }
}