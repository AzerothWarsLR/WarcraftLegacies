using System;
using MacroTools.Extensions;
using MacroTools.Factions;

namespace MacroTools.ControlPoints;

/// <summary>
/// Handles the creation, destruction, and management of Control Point Defenders.
/// <remarks>
/// <para>When a Control Point gains a level above 0, a Control Point Defender spawns on top of it to defend it
/// from enemy threats.</para>
/// <para>Every level after that, the Control Point grows stronger.</para>
/// <para>Control Points that are reduced to level 0 have their Control Point Defenders destroyed.</para>
/// </remarks>
/// </summary>
public static class ControlPointDefenderManager
{
  private static ControlPointDefenderSettings _settings = null!;

  /// <summary>
  /// Initializes the <see cref="ControlPointDefenderManager"/>.
  /// </summary>
  /// <param name="controlPointManager">The manager will handle all <see cref="ControlPoint"/>s managed by the specified
  /// <see cref="ControlPointManager"/>.</param>
  /// <param name="controlPointSettings">Settings to determine the specifics of how Control Point Defenders are scaled.</param>
  public static void Initialize(ControlPointManager controlPointManager, ControlPointDefenderSettings controlPointSettings)
  {
    _settings = controlPointSettings;
    controlPointManager.ControlPointCreated += controlPoint =>
    {
      if (controlPoint.UseControlLevels)
      {
        controlPoint.ControlLevelChanged += OnControlPointLevelChanged;
        ConfigureControlPointOrDefenderAttack(controlPoint.Unit, (int)controlPoint.ControlLevel);
        if (controlPoint.ControlLevel > 0)
        {
          CreateOrUpdateDefender(controlPoint);
        }
      }
    };
  }

  private static void OnControlPointLevelChanged(ControlPoint controlPoint)
  {
    if (controlPoint.ControlLevel > 0)
    {
      CreateOrUpdateDefender(controlPoint);
    }
    else
    {
      RemoveDefender(controlPoint);
    }
    ConfigureControlPointOrDefenderAttack(controlPoint.Unit, (int)controlPoint.ControlLevel);
  }

  /// <summary>
  /// Creates a Defender atop the specified Control Point if it doesn't have one, and configures its attack
  /// statistics either way.
  /// </summary>
  /// <param name="controlPoint">The Control Point affected.</param>
  /// <exception cref="InvalidOperationException">Thrown if the owner of the Control Point is not appropriately
  /// configured to support Defenders.</exception>
  private static void CreateOrUpdateDefender(ControlPoint controlPoint)
  {
    var flooredLevel = (int)controlPoint.ControlLevel;

    var owner = controlPoint.Owner;
    var defenderUnitTypeId = owner.GetPlayerData().Faction?.ControlPointDefenderUnitTypeId;

    if (defenderUnitTypeId == null)
    {
      throw new InvalidOperationException(
        $"{controlPoint.Name} can't have a Defender affixed to it because {owner.Name} doesn't have a {nameof(Faction.ControlPointDefenderUnitTypeId)} configured.");
    }

    if (controlPoint.Defender == null)
    {
      controlPoint.Defender = unit.Create(owner, defenderUnitTypeId.Value, controlPoint.Unit.X, controlPoint.Unit.Y);
      controlPoint.Defender.AddAbility(FourCC("Aloc"));
      controlPoint.Defender.IsInvulnerable = true;
    }
    ConfigureControlPointOrDefenderAttack(controlPoint.Defender, flooredLevel);
  }

  private static void RemoveDefender(ControlPoint controlPoint)
  {
    if (controlPoint.Defender != null)
    {
      controlPoint.Defender.Kill();
    }

    controlPoint.Defender = null;
    controlPoint.Unit.IsInvulnerable = false;
  }

  /// <summary>
  /// Configures the provided unit's attack based on a specified control level.
  /// <remarks>This supports both the actual Control Point and the Defender on top of it because the Control Point
  /// is selectable but can't attack, and the Defender is unselectable but can attack. Thus, they both should be
  /// configured to the same attack damage values so the player knows how much damage their Defender deals.</remarks>
  /// </summary>
  /// <param name="whichUnit">The unit affected; either a Control Point or a Defender.</param>
  /// <param name="controlLevel">The level to use for calculations.</param>
  private static void ConfigureControlPointOrDefenderAttack(unit whichUnit, int controlLevel)
  {
    whichUnit.AttackBaseDamage1 = controlLevel == 0
      ? -1
      : _settings.DamageBase - 1 + controlLevel * _settings.DamagePerControlLevel;
    whichUnit.AttackDiceNumber1 = 1;
    whichUnit.AttackDiceSides1 = 1;
    whichUnit.AttackAttackType1 = WCSharp.Api.Enums.AttackType.Chaos;
  }
}
