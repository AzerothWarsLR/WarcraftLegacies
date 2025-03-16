using System.Collections.Generic;
using System.Linq;
using War3Api.Object;
using War3Api.Object.Enums;
using War3Net.Build;


namespace Launcher.MapMigrations
{
  /// <summary>
  /// Adds the self-destruct ability to all worker units.
  /// </summary>
  public sealed class SelfDestructMigration : IMapMigration
  {
    private const int SelfDestructAbilityId = 0xA041; // Rawcode for the "Self-Destruct" ability.

    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      // Safeguard: Ensure object database and units exist
      if (objectDatabase == null || objectDatabase.GetUnits() == null)
      {
        throw new System.ArgumentException("Invalid Object Database or no units available.");
      }

      // Iterate through all worker units and attempt to add the self-destruct ability
      foreach (var unit in objectDatabase.GetUnits().Where(IsWorkerUnit))
      {
        AddSelfDestructAbility(unit);
      }

      // Update the map with the modified unit data
      var unitData = objectDatabase.GetAllData()?.UnitData;
      if (unitData != null)
      {
        map.UnitObjectData = unitData;
        map.UnitSkinObjectData = unitData;
      }
    }

    private static bool IsWorkerUnit(Unit unit)
    {
      // Safeguard: Validate the unit object and its classifications
      if (unit == null || unit.StatsUnitClassification == null)
      {
        return false;
      }

      // Check if the unit is classified as Peon (worker)
      return unit.StatsUnitClassification.Contains(UnitClassification.Peon);
    }
