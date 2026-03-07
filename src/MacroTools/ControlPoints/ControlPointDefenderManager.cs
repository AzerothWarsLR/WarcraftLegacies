using MacroTools.Extensions;

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
    controlPointManager.ControlPointCreated += (_, controlPoint) =>
    {
      if (controlPoint.UseControlLevels)
      {
        controlPoint.ControlLevelChanged += OnControlPointLevelChanged;
      }
      OnControlPointLevelChanged(null, controlPoint);
    };
  }

  private static void OnControlPointLevelChanged(object? sender, ControlPoint controlPoint)
  {
    controlPoint.ControlLevelChanged += (_, _) =>
    {
      if (controlPoint.ControlLevel > 0)
      {
        CreateOrUpdateDefender(controlPoint);
        controlPoint.Unit.SetScale(1.2f, 1.2f, 1.2f);
      }
      else
      {
        RemoveDefender(controlPoint);
      }
      ConfigureControlPointStats(controlPoint);
    };
  }

  private static void ConfigureControlPointStats(ControlPoint controlPoint)
  {
    var flooredLevel = (int)controlPoint.ControlLevel;
    ConfigureControlPointOrDefenderAttack(controlPoint.Unit, flooredLevel);
  }

  private static void CreateOrUpdateDefender(ControlPoint controlPoint)
  {
    var flooredLevel = (int)controlPoint.ControlLevel;

    var owner = controlPoint.Owner;
    var playerData = owner.GetPlayerData();

    var defenderUnitTypeId = playerData.Faction?.ControlPointDefenderUnitTypeId ?? 0;
    if (controlPoint.Defender == null)
    {
      controlPoint.Defender = unit.Create(owner, defenderUnitTypeId, controlPoint.Unit.X, controlPoint.Unit.Y);
      controlPoint.Defender.AddAbility(FourCC("Aloc"));
      controlPoint.Defender.IsInvulnerable = true;
    }
    ConfigureControlPointOrDefenderAttack(controlPoint.Defender, flooredLevel);
    ConfigureControlPointOrDefenderAttack(controlPoint.Unit, flooredLevel);
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
