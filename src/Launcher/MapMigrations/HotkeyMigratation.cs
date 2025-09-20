using System;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations;

/// <summary>
/// Migrates hotkeys for abilities and units based on their button position fields, excluding upgrades.
/// </summary>
public sealed class HotkeyMigration : IMapMigration
{
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    foreach (var ability in objectDatabase.GetAbilities())
    {
      try
      {
        SetAbilityHotkey(ability);
        SetAbilityResearchHotkey(ability);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to migrate hotkey for ability {ability.TextName}: {ex}");
      }
    }
    foreach (var unit in objectDatabase.GetUnits())
    {
      try
      {
        SetUnitHotkey(unit);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to migrate hotkey for unit {unit.TextName}: {ex}");
      }
    }

    map.AbilityObjectData = objectDatabase.GetAllData().AbilityData;
    map.UnitObjectData = objectDatabase.GetAllData().UnitData;
  }

  /// <summary>
  /// Sets the primary hotkey for an ability based on its normal art button position.
  /// </summary>
  private static void SetAbilityHotkey(Ability ability)
  {
    var x = ability.ArtButtonPositionNormalX;
    var y = ability.ArtButtonPositionNormalY;

    var hotkey = DetermineAbilityHotkey(x, y);

    if (hotkey.HasValue)
    {
      ability.TextHotkeyNormal = hotkey.Value;
    }
  }

  /// <summary>
  /// Sets the research (learn) hotkey for an ability based on its research art button positions.
  /// </summary>
  private static void SetAbilityResearchHotkey(Ability ability)
  {
    var researchX = ability.ArtButtonPositionResearchX;
    var researchY = ability.ArtButtonPositionResearchY;

    var hotkey = DetermineAbilityResearchHotkey(researchX, researchY);

    if (hotkey.HasValue)
    {
      ability.TextHotkeyLearn = hotkey.Value;
    }
  }

  /// <summary>
  /// Sets the primary hotkey for a unit based on its art button position.
  /// </summary>
  private static void SetUnitHotkey(Unit unit)
  {
    var x = unit.ArtButtonPositionX;
    var y = unit.ArtButtonPositionY;

    var hotkey = DetermineUnitHotkey(x, y);

    if (hotkey.HasValue)
    {
      unit.TextHotkey = hotkey.Value;
    }
  }

  /// <summary>
  /// Determines the hotkey for an ability based on its button position.
  /// </summary>
  private static char? DetermineAbilityHotkey(int x, int y)
  {
    return (x, y) switch
    {
      (0, 2) => 'Q',
      (1, 2) => 'W',
      (2, 2) => 'E',
      (3, 2) => 'R',
      (1, 1) => 'D',
      _ => null
    };
  }

  /// <summary>
  /// Determines the hotkey for a unit based on its button position.
  /// </summary>
  private static char? DetermineUnitHotkey(int x, int y)
  {
    return (x, y) switch
    {
      (0, 0) => 'Q',
      (1, 0) => 'W',
      (2, 0) => 'E',
      (3, 0) => 'R',
      _ => null
    };
  }

  /// <summary>
  /// Determines the research (learn) hotkey for an ability based on its research button positions.
  /// </summary>
  private static char? DetermineAbilityResearchHotkey(int researchX, int researchY)
  {
    return (researchX, researchY) switch
    {
      (0, 0) => 'Q',
      (1, 0) => 'W',
      (2, 0) => 'E',
      (3, 0) => 'R',
      _ => null
    };
  }
}
