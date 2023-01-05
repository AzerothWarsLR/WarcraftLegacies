using System;
using System.Collections.Generic;
using System.Linq;
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
    static ControlPointManager()
    {
      CreateTimer().Start(Period, true, () =>
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
    public int MaxHitpoints { get; init; }

    /// <summary>
    /// All <see cref="ControlPoint"/>s are given this ability.
    /// </summary>
    public int RegenerationAbility { get; init; }

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
            controlPoint.ControlLevel++;
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
        Logger.LogWarning(
          $"There are two Control Points with the same ID of {GeneralHelpers.DebugIdInteger2IdString(controlPoint.UnitType)}.");
      else
        _byUnitType.Add(controlPoint.UnitType, controlPoint);
      
      controlPoint.Unit
        .SetMaximumHitpoints(MaxHitpoints)
        .AddAbility(IncreaseControlLevelAbilityTypeId)
        .SetLifePercent(100);
      RegisterIncome(controlPoint);
      RegisterDamageTrigger(controlPoint);
      RegisterOwnershipChangeTrigger(controlPoint);
      RegisterControlLevelChangeTrigger(controlPoint);
      RegisterControlLevelGrowthOverTime(controlPoint);
      ConfigureControlPointStats(controlPoint);
    }

    private static void RegisterIncome(ControlPoint controlPoint)
    {
      controlPoint.Owner.SetBaseIncome(controlPoint.Owner.GetBaseIncome() + controlPoint.Value);
      controlPoint.Owner.SetControlPointCount(controlPoint.Owner.GetControlPointCount() + 1);
    }
    
    private static void RegisterDamageTrigger(ControlPoint controlPoint)
    {
      CreateTrigger()
        .RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_DAMAGED)
        .AddAction(() =>
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
      CreateTrigger()
        .RegisterUnitEvent(controlPoint.Unit, EVENT_UNIT_CHANGE_OWNER)
        .AddAction(() =>
        {
          try
          {
            var previousOwner = PlayerData.ByHandle(GetChangingUnitPrevOwner());
            previousOwner.ControlPointCount -= 1;
            previousOwner.BaseIncome -= controlPoint.Value;

            var newOwner = PlayerData.ByHandle(GetTriggerUnit().OwningPlayer());
            newOwner.ControlPointCount += 1;
            newOwner.BaseIncome += controlPoint.Value;

            controlPoint.Unit
              .AddAbility(RegenerationAbility)
              .SetLifePercent(100);
            controlPoint.ControlLevel = 0;
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
          CreateOrUpdateDefender(controlPoint);
          ConfigureControlPointStats(controlPoint);
          controlPoint.Unit.SetScale(1.2f);
          if (controlPoint.ControlLevel == ControlLevelSettings.ControlLevelMaximum)
            controlPoint.Unit.RemoveAbility(IncreaseControlLevelAbilityTypeId);
        }
        else
        {
          RemoveDefender(controlPoint);
          ConfigureControlPointStats(controlPoint);
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

    private void ConfigureControlPointStats(ControlPoint controlPoint)
    {
      var maxHitPoints = MaxHitpoints + controlPoint.ControlLevel * ControlLevelSettings.HitPointsPerControlLevel;
      var lifePercent = Math.Max(controlPoint.Unit.GetLifePercent(), 1);
      controlPoint.Unit
        .SetMaximumHitpoints(maxHitPoints)
        .SetLifePercent(lifePercent)
        .SetArmor(ControlLevelSettings.ArmorPerControlLevel * ControlLevelSettings.ArmorPerControlLevel)
        .SetUnitLevel(controlPoint.ControlLevel)
        .SetArmor(ControlLevelSettings.ArmorPerControlLevel * controlPoint.ControlLevel)
        .ShowAttackUi(false);
      ConfigureControlPointOrDefenderAttack(controlPoint.Unit, controlPoint.ControlLevel);
    }

    private void CreateOrUpdateDefender(ControlPoint controlPoint)
    {
      var defenderUnitTypeId = controlPoint.Owner.GetFaction()?.ControlPointDefenderUnitTypeId ??
                               ControlLevelSettings.DefaultDefenderUnitTypeId;
      controlPoint.Defender ??= CreateUnit(controlPoint.Owner, defenderUnitTypeId, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit), 270);
      controlPoint.Defender
        .AddAbility(FourCC("Aloc"))
        .SetInvulnerable(true);
      ConfigureControlPointOrDefenderAttack(controlPoint.Defender, controlPoint.ControlLevel);
      ConfigureControlPointOrDefenderAttack(controlPoint.Unit, controlPoint.ControlLevel);
    }

    private void RemoveDefender(ControlPoint controlPoint)
    {
      controlPoint.Defender?.Kill();
      controlPoint.Defender = null;
      controlPoint.Unit
        .SetInvulnerable(false)
        .AddAbility(IncreaseControlLevelAbilityTypeId);
    }

    private void ConfigureControlPointOrDefenderAttack(unit whichUnit, int controlLevel)
    {
      whichUnit
        .SetDamageBase(controlLevel == 0
          ? -1
          : ControlLevelSettings.DamageBase-1 + controlLevel * ControlLevelSettings.DamagePerControlLevel)
        .SetDamageDiceNumber(1)
        .SetDamageDiceSides(1)
        .SetAttackType(5);
    }
  }
}